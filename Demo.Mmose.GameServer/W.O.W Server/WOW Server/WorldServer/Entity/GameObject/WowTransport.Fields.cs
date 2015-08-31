using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Demo.Wow.WorldServer.Entity.Fields;

namespace Demo.Wow.WorldServer.Object
{
    /// <summary>
    /// 
    /// </summary>
    public partial class WowTransport
    {
        /// <summary>
        /// 
        /// </summary>
        private GameObjectField m_GameObjectField = new GameObjectField();
        /// <summary>
        /// 
        /// </summary>
        public GameObjectField GameObjectField
        {
            get { return m_GameObjectField; }
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
