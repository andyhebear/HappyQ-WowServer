using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Demo.Wow.WorldServer.Entity.Fields;

namespace Demo.Wow.WorldServer.Creature
{
    public partial class WowPet
    {
        /// <summary>
        /// 
        /// </summary>
        private NPCField m_NPCField = new NPCField();
        /// <summary>
        /// 
        /// </summary>
        public NPCField NPCField
        {
            get { return m_NPCField; }
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnFieldRequestUpdate()
        {
            //if ( m_QueuedForUpdate == false && m_isInWorld == true )
            {
            }
        }
    }
}
