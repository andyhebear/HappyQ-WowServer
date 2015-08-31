using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Wow.WorldServer.DBC
{
    public class ItemExtendedCostEntry : ILoad<ItemExtendedCostEntry>
    {
        public uint m_ItemExtendedCostID;                    // 0
        public uint ID
        {
            get { return m_ItemExtendedCostID; }
        }

        public uint m_Unknown1;                             // 1
        public uint m_Unknown2;                             // 2
        public uint m_Unknown3;                             // 3
        public uint m_Unknown4;                             // 4
        public uint m_Unknown5;                             // 5
        public uint m_Unknown6;                             // 6
        public uint m_Unknown7;                             // 7
        public uint m_Unknown8;                             // 8
        public uint m_Unknown9;                             // 9
        public uint m_Unknown10;                            // 10
        public uint m_Unknown11;                            // 11
        public uint m_Unknown12;                            // 12


        public bool Load( DBCRecord dbcRecord )
        {
            this.m_ItemExtendedCostID = dbcRecord.GetUInt( 0 );
            this.m_Unknown1 = dbcRecord.GetUInt( 1 );
            this.m_Unknown2 = dbcRecord.GetUInt( 2 );
            this.m_Unknown3 = dbcRecord.GetUInt( 3 );
            this.m_Unknown4 = dbcRecord.GetUInt( 4 );
            this.m_Unknown5 = dbcRecord.GetUInt( 5 );
            this.m_Unknown6 = dbcRecord.GetUInt( 6 );
            this.m_Unknown7 = dbcRecord.GetUInt( 7 );
            this.m_Unknown8 = dbcRecord.GetUInt( 8 );
            this.m_Unknown9 = dbcRecord.GetUInt( 9 );
            this.m_Unknown10 = dbcRecord.GetUInt( 10 );
            this.m_Unknown11 = dbcRecord.GetUInt( 11 );
            this.m_Unknown12 = dbcRecord.GetUInt( 12 );

            //LOGs.WriteLine( LogMessageType.MSG_INFO, "{0}", m_ItemExtendedCostID );

            return true;
        }
    }

    //internal struct ItemExtendedCostEntry
    //{
    //    public uint costid;
    //    public uint honor;
    //    public uint arena;
    //    public uint[] item;
    //    public uint[] count;

    //    public ItemExtendedCostEntry Load()
    //    {
    //        ItemExtendedCostEntry itemExtendedCostEntry = new ItemExtendedCostEntry();

    //        itemExtendedCostEntry.costid = 0;
    //        itemExtendedCostEntry.honor = 0;
    //        itemExtendedCostEntry.arena = 0;
    //        itemExtendedCostEntry.item = new uint[5];
    //        itemExtendedCostEntry.count = new uint[5];

    //        return itemExtendedCostEntry;
    //    }
    //}

}
