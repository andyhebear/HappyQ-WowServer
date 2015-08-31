using System;
using System.Collections.Generic;
using System.Text;
using Demo.Mmose.Core.Common;

namespace Demo.Wow.WorldServer.DBC
{
    public class StableSlotPricesEntry : ILoad<StableSlotPricesEntry>
    {
        public uint m_StableSlotPricesID;                    // 0
        public uint ID
        {
            get { return m_StableSlotPricesID; }
        }

        public uint m_Unknown1;                             // 1


        public bool Load( DBCRecord dbcRecord )
        {
            this.m_StableSlotPricesID = dbcRecord.GetUInt( 0 );
            this.m_Unknown1 = dbcRecord.GetUInt( 1 );

            //LOGs.WriteLine( LogMessageType.MSG_INFO, "{0}", m_StableSlotPricesID );

            return true;
        }
    }
}
