using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Demo.Mmose.Core.Entity.Suit.Ability.Skill;

namespace Demo.Wow.WorldServer.Ability.Skill
{
    /// <summary>
    /// 
    /// </summary>
    public class WowSkillTemplate : BaseSkillTemplate
    {
        /// <summary>
        /// 
        /// </summary>
        private long m_SkillId = 0;
        /// <summary>
        /// 
        /// </summary>
        public long SkillId
        {
            get { return m_SkillId; }
            set { m_SkillId = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private long m_SpellId = 0;
        /// <summary>
        /// 
        /// </summary>
        public long SpellId
        {
            get { return m_SpellId; }
            set { m_SpellId = value; }
        }
    }
}
