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
using Demo.Mmose.Core.Util;
#endregion

namespace Demo.Mmose.Core.Entity.Item
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseItemContainer<T> where T : BaseItem
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        public void InitContainerSlot( long lMinSlot, long lMaxSlot )
        {
            if ( m_MinSlot < 0 )
                throw new ArgumentOutOfRangeException();

            if ( m_MaxSlot < 0 )
                throw new ArgumentOutOfRangeException();

            if ( m_MinSlot > m_MaxSlot )
                throw new ArgumentException();

            m_MinSlot = lMinSlot;
            m_MaxSlot = lMaxSlot;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties

        #region zh-CHS ContainerOwner属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private T m_ContainerOwner = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public T ContainerOwner
        {
            get { return m_ContainerOwner; }
            set { m_ContainerOwner = value; }
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
            protected set
            {
                if ( m_MinSlot < 0 )
                    throw new ArgumentOutOfRangeException();

                if ( m_MinSlot > m_MaxSlot )
                    throw new ArgumentException();

                m_MinSlot = value;
            }
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
            protected set
            {
                if ( m_MaxSlot < 0 )
                    throw new ArgumentOutOfRangeException();

                if ( m_MaxSlot < m_MinSlot )
                    throw new ArgumentException();

                m_MaxSlot = value;
            }
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
                if ( m_ToteSubItems.Count < ( ( this.MaxSlot - this.MinSlot ) + 1 ) )
                    return false;
                else
                    return true;
            }
        }
        #endregion

        #region zh-CHS 道具列表 属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 人物的道具列表
        /// </summary>
        private SafeDictionary<long, T> m_ToteSubItems = new SafeDictionary<long, T>();
        #endregion
        /// <summary>
        /// 人物的道具列表(包裹与身上)
        /// </summary>
        /// <returns></returns>
        [MultiThreadedWarning( "zh-CHS", "(道具)当前的数组是列表临时产生的,不能保存数组用于以后操作:警告!" )]
        public T[] SubItemsToArray()
        {
            return m_ToteSubItems.ToArrayValues();
        }

        #region zh-CHS 共有方法 | en Public Methods
        /// <summary>
        /// 添加道具
        /// </summary>
        /// <param name="item"></param>
        public bool AddSubItem( long lItemSlot, T itemT )
        {
            if ( itemT == null )
                throw new Exception( "BaseItemContainer.AddSubItem(...) - itemT == null error!" );

            if ( lItemSlot > this.MaxSlot || lItemSlot < this.MinSlot )
                return false;

            T findItemT = FindSubItemAtSlot( lItemSlot );
            if ( findItemT != null )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, "BaseItemContainer.AddSubItem(...) - findBaseItemT != null error!" );

                return false;
            }

            if ( m_BaseItemContainerState != null )
            {
                if ( m_BaseItemContainerState.OnAddingSubItem( itemT, this ) == true )
                    return false;
            }

            m_ToteSubItems.Add( lItemSlot, itemT );
            itemT.SlotId = lItemSlot;
            m_BaseItemContainerState.IsUpdateAddSubItemCall = true;

            if ( m_BaseItemContainerState != null )
                m_BaseItemContainerState.OnAddedSubItem( itemT, this );

            return true;
        }

        /// <summary>
        /// 移出道具
        /// </summary>
        /// <param name="item"></param>
        public bool RemoveSubItem( long lItemSlot )
        {
            if ( lItemSlot > this.MaxSlot || lItemSlot < this.MinSlot )
                return false;

            T itemT = FindSubItemAtSlot( lItemSlot );
            if ( itemT == null )
                return false;

            if ( m_BaseItemContainerState != null )
            {
                if ( m_BaseItemContainerState.OnRemovingSubItem( itemT, this ) == true )
                    return false;
            }

            m_ToteSubItems.Remove( lItemSlot );
            itemT.SlotId = BaseItem.SlotNotSet;
            m_BaseItemContainerState.IsUpdateRemoveSubItemCall = true;

            if ( m_BaseItemContainerState != null )
                m_BaseItemContainerState.OnRemovedSubItem( itemT, this );

            return true;
        }

        /// <summary>
        /// 找道具
        /// </summary>
        /// <param name="layer"></param>
        /// <returns></returns>
        public T FindSubItemAtSlot( long lItemSlot )
        {
            return m_ToteSubItems.GetValue( lItemSlot );
        }

        /// <summary>
        /// 
        /// </summary>
        public void EmptyContainer()
        {
            m_ToteSubItems.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public bool AddToFreeSlot( T itemT )
        {
            long iRetrunItemSlot = BaseItem.SlotNotSet;

            if ( this.TryFindFreeSlot( ref iRetrunItemSlot ) == false )
                return false;

            if ( this.AddSubItem( iRetrunItemSlot, itemT )  == false )
                return false;

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="layer"></param>
        /// <returns></returns>
        public bool TryFindFreeSlot( ref long iRetrunItemSlot )
        {
            iRetrunItemSlot = BaseItem.SlotNotSet;

            if ( this.IsContainerFull == true )
                return false;

            for ( long iIndexSlot = this.MinSlot; iIndexSlot <= this.MaxSlot; iIndexSlot++ )
			{
                T itemT = FindSubItemAtSlot( iIndexSlot );

                if ( itemT == null )
                {
                    iRetrunItemSlot = iIndexSlot;
                    return true;
                }
			}

            return false;
        }
        #endregion

        #endregion

        #region zh-CHS BaseItemContainerState属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 道具的的状态
        /// </summary>
        private BaseItemContainerState<T> m_BaseItemContainerState = null;
        #endregion
        /// <summary>
        /// 道具的的状态
        /// </summary>
        public BaseItemContainerState<T> BaseItemContainerState
        {
            get { return m_BaseItemContainerState; }
            protected set { m_BaseItemContainerState = value; }
        }

        #endregion

        #endregion
    }
}
#endregion