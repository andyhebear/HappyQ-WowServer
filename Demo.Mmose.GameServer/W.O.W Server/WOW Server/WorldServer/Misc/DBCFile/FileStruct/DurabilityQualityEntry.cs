using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Wow.WorldServer.DBC
{
    public class DurabilityQualityEntry : ILoad<DurabilityQualityEntry>
    {
        public uint m_DurabilityQualityID;                   // 0
        public uint ID
        {
            get { return m_DurabilityQualityID; }
        }

        public uint m_Unknown1;                    // 1

        public bool Load( DBCRecord dbcRecord )
        {
            this.m_DurabilityQualityID = dbcRecord.GetUInt( 0 );
            this.m_Unknown1 = dbcRecord.GetUInt( 1 );

            //LOGs.WriteLine( LogMessageType.MSG_INFO, "{0}, {1}", m_DurabilityQualityID, m_Unknown1 );

            return true;
        }
    }
}
