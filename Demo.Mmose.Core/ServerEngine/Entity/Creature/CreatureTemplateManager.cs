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

namespace Demo.Mmose.Core.Entity.Creature
{
    /// <summary>
    /// 
    /// </summary>
    public class CreatureTemplateManager<T> where T : BaseCreatureTemplate
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        public CreatureTemplateManager()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iCapacity"></param>
        public CreatureTemplateManager( int iCapacity )
        {
            m_CreatureTemplates = new SafeDictionary<long, T>( iCapacity );
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        /// <summary>
        /// 给出脚本里面的可运动物体的数量(NPCs、Monster)
        /// </summary>
        public int Count
        {
            get { return m_CreatureTemplates.Count; }
        }
        #endregion

        #region zh-CHS CreatureTemplateHandler Type(模型) 方法 | en CreatureTemplateHandler Type Method

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 移动物体类型(npc, player, monster)的集合
        /// </summary>
        private SafeDictionary<long, T> m_CreatureTemplates = new SafeDictionary<long, T>();
        #endregion
        /// <summary>
        /// 添加移动物体类型(npc, player, monster)到集合
        /// </summary>
        public void AddCreatureTemplate( long iCreatureId, T creatureT )
        {
            m_CreatureTemplates.Add( iCreatureId, creatureT );
        }

        /// <summary>
        /// 在移动物体类型(npc, player, monster)的集合内给出某移动物体(npc, player, monster)
        /// </summary>
        /// <param name="iMapID"></param>
        /// <returns></returns>
        public T GetCreatureTemplate( long iCreatureId )
        {
            return m_CreatureTemplates.GetValue( iCreatureId );
        }

        /// <summary>
        /// 在移动物体类型(npc, player, monster)的集合内删除某移动物体(npc, player, monster)
        /// </summary>
        /// <param name="iMapID"></param>
        public void RemoveCreatureTemplate( long iCreatureId )
        {
            m_CreatureTemplates.Remove( iCreatureId );
        }

        /// <summary>
        /// 全部移动物体类型(npc, player, monster)的数组
        /// </summary>
        /// <returns></returns>
        [MultiThreadedWarning( "zh-CHS", "(移动物类型-npc,player,monster)当前的数组是列表临时产生的,不能保存数组用于以后操作:警告!" )]
        public T[] ToArray()
        {
            return m_CreatureTemplates.ToArrayValues();
        }

        #endregion
    }
}
#endregion