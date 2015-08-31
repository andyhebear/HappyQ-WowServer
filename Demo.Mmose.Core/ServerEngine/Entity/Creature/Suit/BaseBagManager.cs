#region zh-CHS 2006 - 2008 DemoSoft 团队 | en 2006 - 2008 DemoSoft Team

//     NOTES
// ---------------
//
// This file is a part of the MMOSE(Massively Multiplayer Online Server Engine) for .NET.
//
//                              2006-2008 DemoSoft Team
//
//
// First Version : by H.Q.Cai - mailto:caihuanqing@hotmail.com

/***************************************************************************
 *
 *   This program is free software; you can redistribute it and/or modify
 *   it under the terms of the GNU Lesser General Public License as published
 *   by the Free Software Foundation; either version 2.1 of the License, or
 *   (at your option) any later version.
 *
 ***************************************************************************/

#region zh-CHS 包含名字空间 | en Include namespace
using System;
using System.Diagnostics;
using System.Threading;
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Common.SafeCollections;
using Demo.Mmose.Core.Entity.Item;
using Demo.Mmose.Core.Util;
#endregion

namespace Demo.Mmose.Core.Entity.Creature.Suit
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseBagManager<ContainerT, ItemT>
        where ContainerT : BaseItemContainer<ItemT>
        where ItemT : BaseItem
    {
        #region zh-CHS 共有属性 | en Public Properties

        #region zh-CHS Owner 属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private BaseCreature m_Owner = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public BaseCreature Owner
        {
            get { return m_Owner; }
            set { m_Owner = value; }
        }

        #endregion

        #region zh-CHS MinSlot属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_MinSlot = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public long MinSlot
        {
            get { return m_MinSlot; }
            protected set { m_MinSlot = value; }
        }
        #endregion

        #region zh-CHS MaxSlot属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_MaxSlot = long.MaxValue;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public long MaxSlot
        {
            get { return m_MaxSlot; }
            protected set { m_MaxSlot = value; }
        }
        #endregion

        #region zh-CHS IsContainerFull属性 | en Public Properties
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsContainerFull
        {
            get
            {
                if ( m_ToteContainers.Count < ( ( this.MaxSlot - this.MinSlot ) + 1 ) )
                    return false;
                else
                    return true;
            }
        }
        #endregion

        #region zh-CHS ItemContainer 属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 人物的道具列表
        /// </summary>
        private SafeDictionary<long, ContainerT> m_ToteContainers = new SafeDictionary<long, ContainerT>();
        #endregion
        /// <summary>
        /// 人物的道具列表(包裹与身上)
        /// </summary>
        /// <returns></returns>
        [MultiThreadedWarning( "zh-CHS", "(道具)当前的数组是列表临时产生的,不能保存数组用于以后操作:警告!" )]
        public ContainerT[] ToArray()
        {
            return m_ToteContainers.ToArrayValues();
        }

        #region zh-CHS 共有方法 | en Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public bool AddContainer( long lContainerSlot, ContainerT itemContainerT )
        {
            if ( itemContainerT == null )
                throw new Exception( "BaseBagHandler.AddContainer(...) - itemContainerT == null error!" );
            
            if ( itemContainerT.ContainerOwner == null )
                throw new Exception( "BaseBagHandler.AddContainer(...) - itemContainerT.Item == null error!" );

            if ( lContainerSlot > this.MaxSlot || lContainerSlot < this.MinSlot )
                return false;

            ContainerT findItemContainerT = FindContainerAtSlot( lContainerSlot );
            if ( findItemContainerT != null )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, "BaseBagHandler.AddContainer(...) - findItemContainerT != null error!" );

                return false;
            }

            EventHandler<BeforeAddItemContainerCallEventArgs<ContainerT, ItemT>> tempBeforeEventArgs = m_ThreadEventBeforeAddItemContainerCall;
            if ( tempBeforeEventArgs != null )
            {
                BeforeAddItemContainerCallEventArgs<ContainerT, ItemT> eventArgs = new BeforeAddItemContainerCallEventArgs<ContainerT, ItemT>( itemContainerT, this );
                tempBeforeEventArgs( this, eventArgs );

                if ( eventArgs.IsCancel == true )
                    return false;
            }

            m_ToteContainers.Add( lContainerSlot, itemContainerT );
            itemContainerT.ContainerOwner.SlotId = lContainerSlot;

            EventHandler<AfterAddItemContainerCallEventArgs<ContainerT, ItemT>> tempAfterEventArgs = m_ThreadEventAfterAddItemContainerCall;
            if ( tempAfterEventArgs != null )
            {
                AfterAddItemContainerCallEventArgs<ContainerT, ItemT> eventArgs = new AfterAddItemContainerCallEventArgs<ContainerT, ItemT>( itemContainerT, this );
                tempAfterEventArgs( this, eventArgs );
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public bool RemoveContainer( long lContainerSlot )
        {
            if ( lContainerSlot > this.MaxSlot || lContainerSlot < this.MinSlot )
                return false;

            ContainerT itemContainerT = FindContainerAtSlot( lContainerSlot );
            if ( itemContainerT == null )
                return false;

            EventHandler<BeforeRemoveItemContainerCallEventArgs<ContainerT, ItemT>> tempBeforeEventArgs = m_ThreadEventBeforeRemoveItemContainerCall;
            if ( tempBeforeEventArgs != null )
            {
                BeforeRemoveItemContainerCallEventArgs<ContainerT, ItemT> eventArgs = new BeforeRemoveItemContainerCallEventArgs<ContainerT, ItemT>( itemContainerT, this );
                tempBeforeEventArgs( this, eventArgs );

                if ( eventArgs.IsCancel == true )
                    return false;
            }

            m_ToteContainers.Remove( lContainerSlot );

            if ( itemContainerT.ContainerOwner != null )
                itemContainerT.ContainerOwner.SlotId = BaseItem.SlotNotSet;

            EventHandler<AfterRemoveItemContainerCallEventArgs<ContainerT, ItemT>> tempAfterEventArgs = m_ThreadEventAfterRemoveItemContainerCall;
            if ( tempAfterEventArgs != null )
            {
                AfterRemoveItemContainerCallEventArgs<ContainerT, ItemT> eventArgs = new AfterRemoveItemContainerCallEventArgs<ContainerT, ItemT>( itemContainerT, this );
                tempAfterEventArgs( this, eventArgs );
            }

            return true;
        }

        /// <summary>
        /// 找道具
        /// </summary>
        /// <param name="layer"></param>
        /// <returns></returns>
        public ContainerT FindContainerAtSlot( long lContainerSlot )
        {
            return m_ToteContainers.GetValue( lContainerSlot );
        }

        /// <summary>
        /// 
        /// </summary>
        public void EmptyBag()
        {
            m_ToteContainers.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public bool AddToFreeContainerSlot( ContainerT itemContainerT )
        {
            long lRetrunItemContainerSlot = BaseItem.SlotNotSet;

            if ( this.FindFreeContainerSlot( ref lRetrunItemContainerSlot ) == false )
                return false;

            if ( this.AddContainer( lRetrunItemContainerSlot, itemContainerT ) == false )
                return false;

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="layer"></param>
        /// <returns></returns>
        public bool FindFreeContainerSlot( ref long lRetrunItemContainerSlot )
        {
            lRetrunItemContainerSlot = BaseItem.SlotNotSet;

            if ( this.IsContainerFull == true )
                return false;

            for ( long iIndexSlot = this.MinSlot; iIndexSlot <= this.MaxSlot; iIndexSlot++ )
            {
                ContainerT itemContainerT = FindContainerAtSlot( iIndexSlot );

                if ( itemContainerT == null )
                {
                    lRetrunItemContainerSlot = iIndexSlot;
                    return true;
                }
            }

            return false;
        }
        #endregion

        #endregion

        #endregion

        #region zh-CHS 共有方法 | en Public Methods

        /// <summary>
        /// 
        /// </summary>
        public void InitBagSlot( long lMinSlot, long lMaxSlot )
        {
            m_MinSlot = lMinSlot;
            m_MaxSlot = lMaxSlot;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wowItem"></param>
        /// <returns></returns>
        public ContainerT FindSpecialBag( ItemT item )
        {
            if ( item == null )
                return null;

            ContainerT[] itemContainerArrayT = this.ToArray();
            if ( itemContainerArrayT == null )
                return null;

            for ( int iIndex = 0; iIndex < itemContainerArrayT.Length; iIndex++ )
            {
                ContainerT itemContainerT = itemContainerArrayT[iIndex];
                ItemT[] itemArray = itemContainerT.SubItemsToArray();
                if ( itemContainerArrayT == null )
                    continue;

                for ( int iIndex2 = 0; iIndex2 < itemArray.Length; iIndex2++ )
                {
                    if ( itemArray[iIndex2].Serial == item.Serial )
                        return itemContainerT;
                }
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="layer"></param>
        /// <returns></returns>
        public ItemT FindSubItemAtContainerSlot( long lContainerSlot, long lItemSlot )
        {
            ContainerT itemContainerT = FindContainerAtSlot( lContainerSlot );
            if ( itemContainerT == null )
                return null;

            return itemContainerT.FindSubItemAtSlot( lItemSlot );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseItem"></param>
        /// <returns></returns>
        public bool AddSubItemToFreeContainer( ItemT item )
        {
            ContainerT[] itemContainerArrayT = this.ToArray();
            if ( itemContainerArrayT == null )
                return false;

            for ( int iIndex = 0; iIndex < itemContainerArrayT.Length; iIndex++ )
            {
                ContainerT itemContainerT = itemContainerArrayT[iIndex];
                if ( itemContainerT.AddToFreeSlot( item ) == true )
                    return true;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iContainerSlotForm"></param>
        /// <param name="iItemSlotForm"></param>
        /// <param name="iContainerSlotTo"></param>
        /// <returns></returns>
        public bool MoveSubItemToSpecialContainer( long lContainerSlotForm, long lItemSlotForm, long lContainerSlotTo )
        {
            ContainerT itemContainerFormT = FindContainerAtSlot( lContainerSlotForm );
            if ( itemContainerFormT == null )
                return false;

            ItemT itemFormV = itemContainerFormT.FindSubItemAtSlot( lItemSlotForm );
            if ( itemFormV == null )
                return false;

            ContainerT itemContainerToT = FindContainerAtSlot( lContainerSlotTo );
            if ( itemContainerToT == null )
                return false;

            long lRetrunItemSlot = BaseItem.SlotNotSet;

            if ( itemContainerToT.TryFindFreeSlot( ref lRetrunItemSlot ) == false )
                return false;

            if ( itemContainerFormT.RemoveSubItem( lItemSlotForm ) == false )
                return false;

            if ( itemContainerToT.AddSubItem( lRetrunItemSlot, itemFormV ) == false )
            {
                if ( itemContainerFormT.AddToFreeSlot( itemFormV ) == false )
                {
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, "BaseBagHandler.MoveItem(...) - itemContainerFormT.AddToFreeSlot(...) error(No Complete, Lost itemFormV)!" );
                    return false;
                }

                return false;
            }
            else
                return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iContainerSlotForm"></param>
        /// <param name="iItemSlotForm"></param>
        /// <param name="iContainerSlotTo"></param>
        /// <param name="iItemSlotTo"></param>
        /// <returns></returns>
        public bool SwapSubItem( long lContainerSlotForm, long lItemSlotForm, long lContainerSlotTo, long lItemSlotTo )
        {
            ContainerT itemContainerFormT = FindContainerAtSlot( lContainerSlotForm );
            if ( itemContainerFormT == null )
                return false;

            ItemT itemFormV = itemContainerFormT.FindSubItemAtSlot( lItemSlotForm );
            if ( itemFormV == null )
                return false;

            ContainerT itemContainerToT = FindContainerAtSlot( lContainerSlotTo );
            if ( itemContainerToT == null )
                return false;

            ItemT itemToV = itemContainerToT.FindSubItemAtSlot( lItemSlotTo );
            if ( itemToV == null )
                return false;

            if ( itemContainerFormT.RemoveSubItem( lItemSlotForm ) == false )
                return false;

            if ( itemContainerToT.RemoveSubItem( lItemSlotTo ) == false )
            {
                if ( itemContainerFormT.AddSubItem( lItemSlotForm, itemFormV ) == false )
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, "BaseBagHandler.SwapItem(...) - itemContainerFormT.AddSubItem(.1.) error(No Complete, Lost itemFormV)!" );

                return false;
            }

            if ( itemContainerFormT.AddSubItem( lItemSlotForm, itemToV ) == false )
            {
                if ( itemContainerFormT.AddSubItem( lItemSlotForm, itemFormV ) == false )
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, "BaseBagHandler.SwapItem(...) - itemContainerFormT.AddSubItem(.2.) error(No Complete, Lost itemFormV)!" );

                if ( itemContainerToT.AddSubItem( lItemSlotTo, itemToV ) == false )
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, "BaseBagHandler.SwapItem(...) - itemContainerToT.AddSubItem(.1.) error(No Complete, Lost itemToV)!" );

                return false;
            }

            if ( itemContainerToT.AddSubItem( lItemSlotTo, itemFormV ) == false )
            {
                if ( itemContainerFormT.RemoveSubItem( lItemSlotForm ) == false )
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, "BaseBagHandler.SwapItem(...) - itemContainerFormT.RemoveSubItem(...) error!" );
                else
                {
                    // 恢复到原来
                    if ( itemContainerFormT.AddSubItem( lItemSlotForm, itemFormV ) == false )
                        LOGs.WriteLine( LogMessageType.MSG_ERROR, "BaseBagHandler.SwapItem(...) - itemContainerFormT.AddSubItem(.3.) error(No Complete, Lost itemFormV)!" );
                }

                if ( itemContainerToT.AddSubItem( lItemSlotTo, itemToV ) == false )
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, "BaseBagHandler.SwapItem(...) - itemContainerToT.AddSubItem(.2.) error(No Complete, Lost itemToV)!" );

                return false;
            }

            return true;
        }

        #endregion

        #region zh-CHS 共有事件 | en Public Event

        #region zh-CHS AddItemContainerCall事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<BeforeAddItemContainerCallEventArgs<ContainerT, ItemT>> m_ThreadEventBeforeAddItemContainerCall;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockThreadEventBeforeAddItemContainerCall = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<BeforeAddItemContainerCallEventArgs<ContainerT, ItemT>> ThreadBeforeAddItemContainerCall
        {
            add
            {
                m_LockThreadEventBeforeAddItemContainerCall.Enter();
                {
                    m_ThreadEventBeforeAddItemContainerCall += value;
                }
                m_LockThreadEventBeforeAddItemContainerCall.Exit();
            }
            remove
            {
                m_LockThreadEventBeforeAddItemContainerCall.Enter();
                {
                    m_ThreadEventBeforeAddItemContainerCall -= value;
                }
                m_LockThreadEventBeforeAddItemContainerCall.Exit();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<AfterAddItemContainerCallEventArgs<ContainerT, ItemT>> m_ThreadEventAfterAddItemContainerCall;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockThreadEventAfterAddItemContainerCall = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<AfterAddItemContainerCallEventArgs<ContainerT, ItemT>> ThreadAfterAddItemContainerCall
        {
            add
            {
                m_LockThreadEventAfterAddItemContainerCall.Enter();
                {
                    m_ThreadEventAfterAddItemContainerCall += value;
                }
                m_LockThreadEventAfterAddItemContainerCall.Exit();
            }
            remove
            {
                m_LockThreadEventAfterAddItemContainerCall.Enter();
                {
                    m_ThreadEventAfterAddItemContainerCall -= value;
                }
                m_LockThreadEventAfterAddItemContainerCall.Exit();
            }
        }
        #endregion

        #region zh-CHS RemoveItemContainerCall事件 | en Public Event
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<BeforeRemoveItemContainerCallEventArgs<ContainerT, ItemT>> m_ThreadEventBeforeRemoveItemContainerCall;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockThreadEventBeforeRemoveItemContainerCall = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<BeforeRemoveItemContainerCallEventArgs<ContainerT, ItemT>> ThreadBeforeRemoveItemContainerCall
        {
            add
            {
                m_LockThreadEventBeforeRemoveItemContainerCall.Enter();
                {
                    m_ThreadEventBeforeRemoveItemContainerCall += value;
                }
                m_LockThreadEventBeforeRemoveItemContainerCall.Exit();
            }
            remove
            {
                m_LockThreadEventBeforeRemoveItemContainerCall.Enter();
                {
                    m_ThreadEventBeforeRemoveItemContainerCall -= value;
                }
                m_LockThreadEventBeforeRemoveItemContainerCall.Exit();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EventHandler<AfterRemoveItemContainerCallEventArgs<ContainerT, ItemT>> m_ThreadEventAfterRemoveItemContainerCall;
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockThreadEventAfterRemoveItemContainerCall = new SpinLock();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<AfterRemoveItemContainerCallEventArgs<ContainerT, ItemT>> ThreadAfterRemoveItemContainerCall
        {
            add
            {
                m_LockThreadEventAfterRemoveItemContainerCall.Enter();
                {
                    m_ThreadEventAfterRemoveItemContainerCall += value;
                }
                m_LockThreadEventAfterRemoveItemContainerCall.Exit();
            }
            remove
            {
                m_LockThreadEventAfterRemoveItemContainerCall.Enter();
                {
                    m_ThreadEventAfterRemoveItemContainerCall -= value;
                }
                m_LockThreadEventAfterRemoveItemContainerCall.Exit();
            }
        }
        #endregion

        #endregion
    }
}
#endregion