using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Demo.Wow.WorldServer.Entity.Fields;

namespace Demo.Wow.WorldServer.Item
{
    /// <summary>
    /// 
    /// </summary>
    public partial class WowItem
    {
        /// <summary>
        /// 
        /// </summary>
        private ItemField m_ItemField = new ItemField();
        /// <summary>
        /// 
        /// </summary>
        public ItemField ItemField
        {
            get { return m_ItemField; }
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
