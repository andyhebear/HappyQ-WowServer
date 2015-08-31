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
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Common.SafeCollections;
#endregion

namespace Demo.Mmose.Core.Entity.Item
{
    /// <summary>
    /// 
    /// </summary>
    public class ItemManager<T> where T : BaseItem
    {
        #region zh-CHS 私有常量 | en Private Constants
        /// <summary>
        /// 
        /// </summary>
        private readonly static int DICTIONARY_CAPACITY = 1024;
        #endregion

        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        public ItemManager()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iCapacity"></param>
        public ItemManager( int iCapacity )
        {
            m_Items = new SafeDictionary<long, T>( iCapacity );
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        /// <summary>
        /// 给出脚本里面的道具的数量
        /// </summary>
        public int Count
        {
            get { return m_Items.Count; }
        }
        #endregion

        #region zh-CHS ItemHandler 方法 | en ItemHandler Method

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 道具的集合
        /// </summary>
        private SafeDictionary<long, T> m_Items = new SafeDictionary<long, T>( DICTIONARY_CAPACITY );
        #endregion
        /// <summary>
        /// 添加道具到集合
        /// </summary>
        public void AddItem( long itemId, T itemT )
        {
            m_Items.Add( itemId, itemT );
        }

        /// <summary>
        /// 在道具的集合内删除某道具
        /// </summary>
        /// <param name="iMapID"></param>
        public void RemoveItem( long itemId )
        {
            m_Items.Remove( itemId );
        }

        /// <summary>
        /// 在道具的集合内给出某道具
        /// </summary>
        /// <param name="iMapID"></param>
        /// <returns></returns>
        public T GetItem( long itemId )
        {
            return m_Items.GetValue( itemId );
        }

        /// <summary>
        /// 全部道具的数组
        /// </summary>
        /// <returns></returns>
        [MultiThreadedWarning( "zh-CHS", "(道具)当前的数组是列表临时产生的,不能保存数组用于以后操作:警告!" )]
        public T[] ToArray()
        {
            return m_Items.ToArrayValues();
        }

        #endregion
    }
}
#endregion