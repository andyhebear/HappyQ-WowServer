using System;
using System.Collections.Generic;
using System.Text;
using Demo.Mmose.Core.Common;

namespace Demo.Wow.WorldServer.DBC
{
    public class AuctionHouseEntry : ILoad<AuctionHouseEntry>
    {
        public uint m_AuctionHouseID;                    // 0
        public uint ID
        {
            get { return m_AuctionHouseID; }
        }

        public uint m_Unknown1;                             // 1
        public uint m_Unknown2;                             // 2
        public uint m_Unknown3;                             // 3
        public uint m_Unknown4;                             // 4
        public uint m_Unknown5;                             // 5
        public uint m_Unknown6;                             // 6
        public uint m_Unknown7;                             // 7
        public string m_Unknown8;                             // 8
        public uint m_Unknown9;                             // 9
        public uint m_Unknown10;                            // 10
        public uint m_Unknown11;                            // 11
        public uint m_Unknown12;                            // 12
        public uint m_Unknown13;                            // 13
        public uint m_Unknown14;                            // 14
        public uint m_Unknown15;                            // 15
        public uint m_Unknown16;                            // 16
        public uint m_Unknown17;                            // 17
        public uint m_Unknown18;                            // 18
        public uint m_Unknown19;                            // 19
        public uint m_Unknown20;                            // 20

        public bool Load( DBCRecord dbcRecord )
        {
            this.m_AuctionHouseID = dbcRecord.GetUInt( 0 );
            this.m_Unknown1 = dbcRecord.GetUInt( 1 );
            this.m_Unknown2 = dbcRecord.GetUInt( 2 );
            this.m_Unknown3 = dbcRecord.GetUInt( 3 );
            this.m_Unknown4 = dbcRecord.GetUInt( 4 );
            this.m_Unknown5 = dbcRecord.GetUInt( 5 );
            this.m_Unknown6 = dbcRecord.GetUInt( 6 );
            this.m_Unknown7 = dbcRecord.GetUInt( 7 );
            this.m_Unknown8 = dbcRecord.GetString( 8 );
            this.m_Unknown9 = dbcRecord.GetUInt( 9 );
            this.m_Unknown10 = dbcRecord.GetUInt( 10 );
            this.m_Unknown11 = dbcRecord.GetUInt( 11 );
            this.m_Unknown12 = dbcRecord.GetUInt( 12 );
            this.m_Unknown13 = dbcRecord.GetUInt( 13 );
            this.m_Unknown14 = dbcRecord.GetUInt( 14 );
            this.m_Unknown15 = dbcRecord.GetUInt( 15 );
            this.m_Unknown16 = dbcRecord.GetUInt( 16 );
            this.m_Unknown17 = dbcRecord.GetUInt( 17 );
            this.m_Unknown18 = dbcRecord.GetUInt( 18 );
            this.m_Unknown19 = dbcRecord.GetUInt( 19 );
            this.m_Unknown20 = dbcRecord.GetUInt( 20 );

            //LOGs.WriteLine( LogMessageType.MSG_INFO, "{0}, {1}", m_AuctionHouseID, m_Unknown8 );

            return true;
        }
    }

    //internal struct AuctionHouseDBC
    //{
    //    public uint id;
    //    public uint unk;
    //    public uint fee;
    //    public uint tax;
    //    //char* name;
    //    //char* nameAlt1;
    //    //char* nameAlt2;
    //    //char* nameAlt3;
    //    //char* nameAlt4;
    //    //char* nameAlt5;
    //    //char* nameAlt6;
    //    //char* nameAlt7;
    //    //char* nameAlt8;
    //    //char* nameAlt9;
    //    //char* nameAlt10;
    //    //char* nameAlt11;
    //    //char* nameAlt12;
    //    //char* nameAlt13;
    //    //char* nameAlt14;
    //    //char* nameAlt15;
    //    //char* nameFlags;

    //    public AuctionHouseDBC Load()
    //    {
    //        AuctionHouseDBC auctionHouseDBC = new AuctionHouseDBC();

    //        auctionHouseDBC.id = 0;
    //        auctionHouseDBC.unk = 0;
    //        auctionHouseDBC.fee = 0;
    //        auctionHouseDBC.tax = 0;
    //        //char* name;
    //        //char* nameAlt1;
    //        //char* nameAlt2;
    //        //char* nameAlt3;
    //        //char* nameAlt4;
    //        //char* nameAlt5;
    //        //char* nameAlt6;
    //        //char* nameAlt7;
    //        //char* nameAlt8;
    //        //char* nameAlt9;
    //        //char* nameAlt10;
    //        //char* nameAlt11;
    //        //char* nameAlt12;
    //        //char* nameAlt13;
    //        //char* nameAlt14;
    //        //char* nameAlt15;
    //        //char* nameFlags;

    //        return auctionHouseDBC;
    //    }
    //}

}
