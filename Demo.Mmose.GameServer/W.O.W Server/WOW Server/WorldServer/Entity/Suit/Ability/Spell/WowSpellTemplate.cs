using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Demo.Mmose.Core.Entity.Suit.Ability.Spell;

namespace Demo.Wow.WorldServer.Ability.Spell
{
    /// <summary>
    /// 
    /// </summary>
    public class WowSpellTemplate : BaseSpellTemplate
    {
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
