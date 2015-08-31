using System;
using System.Text;
using System.Collections.Generic;

namespace Demo.Wow.WorldServer.DBC
{
    public class BankBagSlotPricesEntry : ILoad<BankBagSlotPricesEntry>
    {
        public uint m_BankBagSlotPricesId;                   // 0
        public uint ID
        {
            get { return m_BankBagSlotPricesId; }
        }

        public uint m_Unknown1;                              // 1

        public bool Load( DBCRecord dbcRecord )
        {
            this.m_BankBagSlotPricesId = dbcRecord.GetUInt( 0 );
            this.m_Unknown1 = dbcRecord.GetUInt( 1 );

            //LOGs.WriteLine( LogMessageType.MSG_INFO, "{0}, {1}", m_BankBagSlotPricesId, m_Unknown1 );

            return true;
        }
    }
}
