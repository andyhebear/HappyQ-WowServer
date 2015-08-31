using System;
using System.Collections.Generic;
using System.Text;
using Demo.Mmose.Core.Common;

namespace Demo.Wow.WorldServer.DBC
{
    public class TaxiPathEntry : ILoad<TaxiPathEntry>
    {
        public uint m_TaxiPathID;                        // 0
        public uint ID
        {
            get { return m_TaxiPathID; }
        }

        public uint m_From;                              // 1
        public uint m_To;                                // 2
        public uint m_Price;                             // 3


        public bool Load( DBCRecord dbcRecord )
        {
            this.m_TaxiPathID = dbcRecord.GetUInt( 0 );
            this.m_From = dbcRecord.GetUInt( 1 );
            this.m_To = dbcRecord.GetUInt( 2 );
            this.m_Price = dbcRecord.GetUInt( 3 );

            //LOGs.WriteLine( LogMessageType.MSG_INFO, "{0}", m_TaxiPathID );

            return true;
        }
    }
}
