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
    public partial class WowCorpse
    {
        /// <summary>
        /// 
        /// </summary>
        private CorpseField m_CorpseField = new CorpseField();
        /// <summary>
        /// 
        /// </summary>
        public CorpseField CorpseField
        {
            get { return m_CorpseField; }
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
