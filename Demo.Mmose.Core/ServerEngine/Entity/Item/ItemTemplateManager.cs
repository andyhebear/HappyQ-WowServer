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
    public class ItemTemplateManager<T> where T : BaseItemTemplate
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        public ItemTemplateManager()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iCapacity"></param>
        public ItemTemplateManager( int iCapacity )
        {
            m_ItemTemplates = new SafeDictionary<long, T>( iCapacity );
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        /// <summary>
        /// 给出脚本里面的道具类型的数量
        /// </summary>
        public int Count
        {
            get { return m_ItemTemplates.Count; }
        }
        #endregion

        #region zh-CHS ItemTemplateHandler(模板) 方法 | en ItemTemplateHandler Method
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 道具类型的集合
        /// </summary>
        private SafeDictionary<long, T> m_ItemTemplates = new SafeDictionary<long, T>();
        #endregion
        /// <summary>
        /// 添加道具类型到集合
        /// </summary>
        public void AddItemTemplate( long itemTemplateId, T itemTemplateT )
        {
            m_ItemTemplates.Add( itemTemplateId, itemTemplateT );
        }

        /// <summary>
        /// 在道具类型的集合内给出某道具类型
        /// </summary>
        /// <param name="iMapID"></param>
        /// <returns></returns>
        public T GetItemTemplate( long itemTemplateId )
        {
            return m_ItemTemplates.GetValue( itemTemplateId );
        }

        /// <summary>
        /// 在道具类型的集合内删除某道具类型
        /// </summary>
        /// <param name="iMapID"></param>
        public void RemoveItemTemplate( long itemTemplateId )
        {
            m_ItemTemplates.Remove( itemTemplateId );
        }

        /// <summary>
        /// 全部道具类型的数组
        /// </summary>
        /// <returns></returns>
        [MultiThreadedWarning( "zh-CHS", "(道具类型)当前的数组是列表临时产生的,不能保存数组用于以后操作:警告!" )]
        public T[] ToArray()
        {
            return m_ItemTemplates.ToArrayValues();
        }
        #endregion
    }
}
#endregion