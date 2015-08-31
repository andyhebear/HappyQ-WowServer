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
using System.Collections.Generic;
using Demo.Mmose.Core.Entity.Character;
using Demo.Mmose.Core.Entity.Creature;
using Demo.Mmose.Core.Entity.Item;
#endregion

namespace Demo.Mmose.Core.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class VisibleRange<EntityT, ItemT, CreatureT, CharacterT>
        where EntityT : WorldEntity
        where ItemT : BaseItem
        where CreatureT : BaseCreature
        where CharacterT : BaseCharacter
    {
        #region zh-CHS 共有属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_Range = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public int Range
        {
            get { return m_Range; }
            set { m_Range = value; }
        }

        #region zh-CHS Entity属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EntityT[] m_EntityOriginalInRange = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public EntityT[] EntityOriginalInRange
        {
            get { return m_EntityOriginalInRange; }
            set { m_EntityOriginalInRange = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EntityT[] m_EntityInRange = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public EntityT[] EntityInRange
        {
            get { return m_EntityInRange; }
            set { m_EntityInRange = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EntityT[] m_EntityOutOfRange = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public EntityT[] EntityOutOfRange
        {
            get { return m_EntityOutOfRange; }
            set { m_EntityOutOfRange = value; }
        }
        #endregion

        #region zh-CHS Item属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private ItemT[] m_ItemOriginalInRange = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public ItemT[] ItemOriginalInRange
        {
            get { return m_ItemOriginalInRange; }
            set { m_ItemOriginalInRange = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private ItemT[] m_ItemInRange = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public ItemT[] ItemInRange
        {
            get { return m_ItemInRange; }
            set { m_ItemInRange = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private ItemT[] m_ItemOutOfRange = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public ItemT[] ItemOutOfRange
        {
            get { return m_ItemOutOfRange; }
            set { m_ItemOutOfRange = value; }
        }
        #endregion

        #region zh-CHS Creature属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private CreatureT[] m_CreatureOriginalInRange = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public CreatureT[] CreatureOriginalInRange
        {
            get { return m_CreatureOriginalInRange; }
            set { m_CreatureOriginalInRange = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private CreatureT[] m_CreatureInRange = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public CreatureT[] CreatureInRange
        {
            get { return m_CreatureInRange; }
            set { m_CreatureInRange = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private CreatureT[] m_CreatureOutOfRange = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public CreatureT[] CreatureOutOfRange
        {
            get { return m_CreatureOutOfRange; }
            set { m_CreatureOutOfRange = value; }
        }
        #endregion

        #region zh-CHS Character属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private CharacterT[] m_CharacterOriginalInRange = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public CharacterT[] CharacterOriginalInRange
        {
            get { return m_CharacterOriginalInRange; }
            set { m_CharacterOriginalInRange = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private CharacterT[] m_CharacterInRange = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public CharacterT[] CharacterInRange
        {
            get { return m_CharacterInRange; }
            set { m_CharacterInRange = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private CharacterT[] m_CharacterOutOfRange = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public CharacterT[] CharacterOutOfRange
        {
            get { return m_CharacterOutOfRange; }
            set { m_CharacterOutOfRange = value; }
        }
        #endregion

        #region zh-CHS AllEntity属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private WorldEntity[] m_AllEntityOriginalInRange = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public WorldEntity[] AllEntityOriginalInRange
        {
            get { return m_AllEntityOriginalInRange; }
            set { m_AllEntityOriginalInRange = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private WorldEntity[] m_AllEntityInRange = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public WorldEntity[] AllEntityInRange
        {
            get { return m_AllEntityInRange; }
            set { m_AllEntityInRange = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private WorldEntity[] m_AllEntityOutOfRange = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public WorldEntity[] AllEntityOutOfRange
        {
            get { return m_AllEntityOutOfRange; }
            set { m_AllEntityOutOfRange = value; }
        }
        #endregion

        #endregion

        #region zh-CHS 共有静态方法 | en Public Static Methods

        #region zh-CHS 私有常量 | en Private Constants
        /// <summary>
        /// 
        /// </summary>
        private readonly static int LIST_CAPACITY_SIZE = 1024;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="GameEntityT"></typeparam>
        /// <param name="fgg"></param>
        /// <returns></returns>
        public static T[] EnumerableToArray<T>( IEnumerable<T> enumerable )
        {
            List<T> entityList = new List<T>( LIST_CAPACITY_SIZE );

            foreach ( T itemEntity in enumerable )
                entityList.Add( itemEntity );
            
            return entityList.ToArray();
        }

        #endregion
    }
}
#endregion