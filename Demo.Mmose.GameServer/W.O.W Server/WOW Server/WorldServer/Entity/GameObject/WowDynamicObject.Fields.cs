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
    public partial class WowDynamicObject
    {
        /// <summary>
        /// 
        /// </summary>
        private DynamicObjectField m_DynamicObjectField = new DynamicObjectField();
        /// <summary>
        /// 
        /// </summary>
        public DynamicObjectField DynamicObjectField
        {
            get { return m_DynamicObjectField; }
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
