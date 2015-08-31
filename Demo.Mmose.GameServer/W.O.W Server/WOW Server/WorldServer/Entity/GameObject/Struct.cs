using System;
using System.Text;
using System.Collections.Generic;
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Common.Collections;

namespace Demo.Wow.WorldServer.Object
{
    /// <summary>
    /// 
    /// </summary>
    public struct WowObjectQuest
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iQuestID"></param>
        public WowObjectQuest( ulong iQuestID )
        {
            m_QuestID = iQuestID;
        }

        /// <summary>
        /// 
        /// </summary>
        private ulong m_QuestID;
        /// <summary>
        /// 
        /// </summary>
        public ulong QuestID
        {
            get { return m_QuestID; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iQuestID"></param>
        /// <returns></returns>
        public WowObjectQuest GetWowObjectQuest( ulong iQuestID )
        {
            return new WowObjectQuest( iQuestID );
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class WowObjectQuests
    {
        /// <summary>
        /// 
        /// </summary>
        private SafeDictionary<ulong, WowObjectQuest> m_Quests = new SafeDictionary<ulong, WowObjectQuest>();
        /// <summary>
        /// 任务添加
        /// </summary>
        /// <param name="iQuestID"></param>
        public void Add( ulong iQuestID )
        {
            m_Quests.Add( iQuestID, new WowObjectQuest( iQuestID ) );
        }

        /// <summary>
        /// 任务编号
        /// </summary>
        public WowObjectQuest[] Quests
        {
            get { return m_Quests.ToArrayValues(); }
        }

        /// <summary>
        /// 任务数量
        /// </summary>
        public int Count
        {
            get { return m_Quests.Count; }
        }
    }
}
