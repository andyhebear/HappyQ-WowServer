using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Demo.Wow.WorldServer.Entity.Fields;
using Demo.Mmose.Core.Entity.Character;

namespace Demo.Wow.WorldServer.Character
{
    public partial class WowCharacter
    {
        /// <summary>
        /// 
        /// </summary>
        private CharacterField m_PlayerField = new CharacterField();
        /// <summary>
        /// 
        /// </summary>
        public CharacterField PlayerField
        {
            get { return m_PlayerField; }
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnFieldRequestUpdate()
        {
            if ( m_QueuedForUpdate == false && m_isInWorld == true )
            {
            }
        }
    }
}
