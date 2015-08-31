using System;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using Demo.Mmose.Core.Entity.Item;

namespace Demo.Wow.WorldServer.Item
{
    /// <summary>
    /// 
    /// </summary>
    public class WowItemContainer : BaseItemContainer<WowItem>
    {
        ///// <summary>
        ///// 初始化一个箭袋、子弹袋或灵魂袋等Wow的物品容器
        ///// </summary>
        ///// <param name="itemTemplate"></param>
        //public WowItemContainer( WowItemTemplate itemTemplate )
        //{
        //    if ( itemTemplate == null )
        //    {
        //        Debug.WriteLine( "WowItemContainer.WowItemContainer(...) - itemTemplate == null error!" );
        //        return;
        //    }

        //    base.ItemTemplate = itemTemplate;
        //    m_Slot = new WowItem[itemTemplate.ContainerSlots]; // 背包的格数
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="iSlot"></param>
        ///// <param name="wowItem"></param>
        ///// <returns></returns>
        //public bool AddItem( int iSlot, WowItem wowItem )
        //{
        //    if ( iSlot > m_Slot.Length )
        //        return false;

        //    if ( m_Slot[iSlot] != null )
        //        return false;

        //    if ( Owner == null )
        //        return false;

        //    m_Slot[iSlot] = wowItem;
        //    //item->m_isDirty = true;

        //    //item->SetUInt64Value(ITEM_FIELD_CONTAINED, GetGUID());
        //    //item->SetOwner(m_owner);

        //    //if ( wowItem.ItemTemplate.Bonding == ITEM_BIND_ON_PICKUP )
        //    //    wowItem.SoulBind();

        //    //SetUInt64Value(CONTAINER_FIELD_SLOT_1  + (slot*2), item->GetGUID());

        //    ////new version to fix bag issues
        //    //if(m_owner->IsInWorld() && !item->IsInWorld())
        //    //{
        //    //    //item->AddToWorld();
        //    //    item->PushToWorld(m_owner->GetMapMgr());

        //    //    ByteBuffer buf(2500);
        //    //    uint32 count = item->BuildCreateUpdateBlockForPlayer(&buf, m_owner);
        //    //    m_owner->PushUpdateData(&buf, count);
        //    //}
        //    //return true;

        //    return false;
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="wowItem"></param>
        ///// <returns></returns>
        //public bool AddItemToFreeSlot( WowItem wowItem )
        //{
        //    //uint32 slot;
        //    //for(slot = 0; slot < GetProto()->ContainerSlots; slot++)
        //    //{
        //    //    if(!m_Slot[slot])
        //    //    {
        //    //        m_Slot[slot] = pItem;
        //    //        pItem->m_isDirty = true;

        //    //        pItem->SetUInt64Value(ITEM_FIELD_CONTAINED, GetGUID());
        //    //        pItem->SetOwner(m_owner);

        //    //        SetUInt64Value(CONTAINER_FIELD_SLOT_1  + (slot*2), pItem->GetGUID());

        //    //        if(m_owner->IsInWorld() && !pItem->IsInWorld())
        //    //        {
        //    //            //pItem->AddToWorld();
        //    //            pItem->PushToWorld(m_owner->GetMapMgr());
        //    //            ByteBuffer buf(2500);
        //    //            uint32 count = pItem->BuildCreateUpdateBlockForPlayer( &buf, m_owner );
        //    //            m_owner->PushUpdateData(&buf, count);
        //    //        }
        //    //        return true;
        //    //    }
        //    //}
        //    //return false;

        //    return false;
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="iSlot"></param>
        ///// <returns></returns>
        //public WowItem GetItem( int iSlot )
        //{
        //    if ( iSlot < ItemTemplate.ContainerSlots )
        //        return m_Slot[iSlot];
        //    else
        //        return null;
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <returns></returns>
        //public int FindFreeSlot()
        //{
        //    for ( int iIndex = 0; iIndex < m_Slot.Length; iIndex++ )
        //    {
        //        if ( m_Slot[iIndex] == null )
        //            return iIndex;
        //    }

        //    //return ITEM_NO_SLOT_AVAILABLE;
        //    return -1;
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <returns></returns>
        //public bool HasItems()
        //{
        //    for ( int iIndex = 0; iIndex < m_Slot.Length; iIndex++ )
        //    {
        //        if ( m_Slot[iIndex] != null )
        //            return true;
        //    }

        //    return false;
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="iSrcSlot"></param>
        ///// <param name="iDstSlot"></param>
        //public void SwapItems( int iSrcSlot, int iDstSlot )
        //{
        //    //Item* temp;
        //    //if ( m_Slot[DstSlot] && m_Slot[SrcSlot] && m_Slot[DstSlot]->GetEntry() == m_Slot[SrcSlot]->GetEntry() && m_Slot[DstSlot]->GetProto()->MaxCount > 1 )
        //    //{
        //    //    uint32 total = m_Slot[SrcSlot]->GetUInt32Value( ITEM_FIELD_STACK_COUNT ) + m_Slot[DstSlot]->GetUInt32Value( ITEM_FIELD_STACK_COUNT );
        //    //    m_Slot[DstSlot]->m_isDirty = m_Slot[SrcSlot]->m_isDirty = true;
        //    //    if ( total <= m_Slot[DstSlot]->GetProto()->MaxCount )
        //    //    {
        //    //        m_Slot[DstSlot]->ModUInt32Value( ITEM_FIELD_STACK_COUNT, m_Slot[SrcSlot]->GetUInt32Value( ITEM_FIELD_STACK_COUNT ) );
        //    //        SafeFullRemoveItemFromSlot( SrcSlot );
        //    //        return;
        //    //    }
        //    //    else
        //    //    {
        //    //        if ( m_Slot[DstSlot]->GetUInt32Value( ITEM_FIELD_STACK_COUNT ) == m_Slot[DstSlot]->GetProto()->MaxCount )
        //    //        {

        //    //        }
        //    //        else
        //    //        {
        //    //            int32 delta = m_Slot[DstSlot]->GetProto()->MaxCount - m_Slot[DstSlot]->GetUInt32Value( ITEM_FIELD_STACK_COUNT );
        //    //            m_Slot[DstSlot]->SetUInt32Value( ITEM_FIELD_STACK_COUNT, m_Slot[DstSlot]->GetProto()->MaxCount );
        //    //            m_Slot[SrcSlot]->ModUInt32Value( ITEM_FIELD_STACK_COUNT, -delta );
        //    //            return;
        //    //        }
        //    //    }
        //    //}

        //    //temp = m_Slot[SrcSlot];
        //    //m_Slot[SrcSlot] = m_Slot[DstSlot];
        //    //m_Slot[DstSlot] = temp;

        //    //if ( m_Slot[DstSlot] )
        //    //{
        //    //    SetUInt64Value( CONTAINER_FIELD_SLOT_1 + ( DstSlot * 2 ), m_Slot[DstSlot]->GetGUID() );
        //    //    m_Slot[DstSlot]->m_isDirty = true;
        //    //}
        //    //else
        //    //{
        //    //    SetUInt64Value( CONTAINER_FIELD_SLOT_1 + ( DstSlot * 2 ), 0 );
        //    //}

        //    //if ( m_Slot[SrcSlot] )
        //    //{
        //    //    SetUInt64Value( CONTAINER_FIELD_SLOT_1 + ( SrcSlot * 2 ), m_Slot[SrcSlot]->GetGUID() );
        //    //    m_Slot[SrcSlot]->m_isDirty = true;
        //    //}
        //    //else
        //    //{
        //    //    SetUInt64Value( CONTAINER_FIELD_SLOT_1 + ( SrcSlot * 2 ), 0 );
        //    //}
        //}

        //public WowItem SafeRemoveAndRetreiveItemFromSlot( int iSlot, bool iDestroy ) //doesnt destroy item from memory
        //{
        //    //ASSERT( (uint32)slot < GetProto()->ContainerSlots );

        //    //Item* pItem = m_Slot[slot];

        //    //if ( pItem == NULL ) return NULL;
        //    //m_Slot[slot] = NULL;

        //    //SetUInt64Value( CONTAINER_FIELD_SLOT_1 + slot * 2, 0 );
        //    //pItem->SetUInt64Value( ITEM_FIELD_CONTAINED, 0 );

        //    //if ( destroy )
        //    //{
        //    //    if ( pItem->IsInWorld() )
        //    //    {
        //    //        pItem->RemoveFromWorld();
        //    //    }
        //    //    pItem->DeleteFromDB();
        //    //}

        //    //return pItem;

        //    return null;
        //}

        //public bool SafeFullRemoveItemFromSlot( int slot ) //destroys item fully
        //{
        //    //ASSERT( (uint32)slot < GetProto()->ContainerSlots );

        //    //Item* pItem = m_Slot[slot];

        //    //if ( pItem == NULL ) return false;
        //    //m_Slot[slot] = NULL;

        //    //SetUInt64Value( CONTAINER_FIELD_SLOT_1 + slot * 2, 0 );
        //    //pItem->SetUInt64Value( ITEM_FIELD_CONTAINED, 0 );


        //    //if ( pItem->IsInWorld() )
        //    //{
        //    //    pItem->RemoveFromWorld();
        //    //}
        //    //pItem->DeleteFromDB();
        //    //delete pItem;

        //    //return true;

        //    return false;
        //}

        ////public void LoadFromDB( Field*fields)
        ////{
        ////}
        ////public void SaveBagToDB( int8 slot, bool first )
        ////{
        ////}

        //private WowItem[] m_Slot = new WowItem[0];
    }
}
