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

#endregion

namespace Demo.Mmose.Core.Entity.Suit.Quest
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseQuestObjective
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public class BaseQuestItemObjective : BaseQuestObjective
    {
        #region zh-CHS 共有属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_ItemId = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public long ItemId
        {
            get { return m_ItemId; }
            set { m_ItemId = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_ItemCount = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public long ItemCount
        {
            get { return m_ItemCount; }
            set { m_ItemCount = value; }
        }

        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public class BaseQuestSourceObjective : BaseQuestObjective
    {
        #region zh-CHS 共有属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_SourceId = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public long SourceId
        {
            get { return m_SourceId; }
            set { m_SourceId = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_SourceCount = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public long SourceCount
        {
            get { return m_SourceCount; }
            set { m_SourceCount = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_SourceRef = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public long SourceRef
        {
            get { return m_SourceRef; }
            set { m_SourceRef = value; }
        }

        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public class BaseQuestCreatureObjective : BaseQuestObjective
    {
        #region zh-CHS 共有属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_SpellId = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public long SpellId
        {
            get { return m_SpellId; }
            set { m_SpellId = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_CreatureId = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public long CreatureId
        {
            get { return m_CreatureId; }
            set { m_CreatureId = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_CreatureCount = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public long CreatureCount
        {
            get { return m_CreatureCount; }
            set { m_CreatureCount = value; }
        }

        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public class BaseQuestGameobjectObjective : BaseQuestObjective
    {
        #region zh-CHS 共有属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_SpellId = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public long SpellId
        {
            get { return m_SpellId; }
            set { m_SpellId = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_GameobjectId = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public long GameobjectId
        {
            get { return m_GameobjectId; }
            set { m_GameobjectId = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_GameobjectCount = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public long GameobjectCount
        {
            get { return m_GameobjectCount; }
            set { m_GameobjectCount = value; }
        }

        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public class BaseQuestSpellObjective : BaseQuestObjective
    {
        #region zh-CHS 共有属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_SpellId = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public long SpellId
        {
            get { return m_SpellId; }
            set { m_SpellId = value; }
        }

        #endregion
    }
}
#endregion