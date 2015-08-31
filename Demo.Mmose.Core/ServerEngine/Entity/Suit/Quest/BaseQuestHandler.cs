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
using System.Diagnostics;
using Demo.Mmose.Core.Common.SafeCollections;
#endregion

namespace Demo.Mmose.Core.Entity.Suit.Quest
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseQuestHandler
    {
        #region zh-CHS 共有方法 | en Public Methods

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private SafeDictionary<long, BaseQuest> m_Quests = new SafeDictionary<long, BaseQuest>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseTaxiNode"></param>
        public void AddQuest( long iQuestSerial, BaseQuest baseQuest )
        {
            if ( baseQuest == null )
            {
                Debug.WriteLine( "BaseQuestManager.AddQuest(...) - baseQuest == null error!" );
                return;
            }

            m_Quests.Add( iQuestSerial, baseQuest );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public BaseQuest GetQuest( long iQuestSerial )
        {
            return m_Quests.GetValue( iQuestSerial );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void RemoveQuest( long iQuestSerial )
        {
            m_Quests.Remove( iQuestSerial );
        }

        /// <summary>
        /// 
        /// </summary>
        public BaseQuest[] ToArray()
        {
            return m_Quests.ToArrayValues();
        }

        #endregion
    }
}
#endregion