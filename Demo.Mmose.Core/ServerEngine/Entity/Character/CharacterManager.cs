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

namespace Demo.Mmose.Core.Entity.Character
{
    /// <summary>
    /// 玩家的信息管理
    /// </summary>
    public class CharacterManager<T> where T : BaseCharacter
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        public CharacterManager()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iCapacity"></param>
        public CharacterManager( int iCapacity )
        {
            m_Characters = new SafeDictionary<long, T>( iCapacity );
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        /// <summary>
        /// 给出玩家信息的数量
        /// </summary>
        public int Count
        {
            get { return m_Characters.Count; }
        }
        #endregion

        #region zh-CHS CharacterHandler 方法 | en CharacterHandler Method

        #region zh-CHS 共有方法 | en Public Methods
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 玩家信息的集合
        /// </summary>
        private SafeDictionary<long, T> m_Characters = new SafeDictionary<long, T>();
        #endregion
        /// <summary>
        /// 添加玩家信息到集合
        /// </summary>
        public void AddCharacter( long iCharacterId, T characterT )
        {
            m_Characters.Add( iCharacterId, characterT );
        }

        /// <summary>
        /// 在玩家信息的集合内删除某玩家信息
        /// </summary>
        /// <param name="iMapID"></param>
        public void RemoveCharacter( long iCharacterId )
        {
            m_Characters.Remove( iCharacterId );
        }

        /// <summary>
        /// 在玩家信息的集合内给出某玩家信息
        /// </summary>
        /// <param name="iMapID"></param>
        /// <returns></returns>
        public T GetCharacter( long iCharacterId )
        {
            return m_Characters.GetValue( iCharacterId );
        }

        /// <summary>
        /// 全部玩家信息的数组
        /// </summary>
        /// <returns></returns>
        [MultiThreadedWarning( "zh-CHS", "(玩家的信息)当前的数组是列表临时产生的,不能保存数组用于以后操作:警告!" )]
        public T[] ToArray()
        {
            return m_Characters.ToArrayValues();
        }
        #endregion

        #endregion
    }
}
#endregion