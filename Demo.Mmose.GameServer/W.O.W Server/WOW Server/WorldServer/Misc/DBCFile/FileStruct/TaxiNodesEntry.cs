using System;
using System.Collections.Generic;
using System.Text;
using Demo.Mmose.Core.Common;

namespace Demo.Wow.WorldServer.DBC
{
    public class TaxiNodesEntry : ILoad<TaxiNodesEntry>
    {
        public uint m_TaxiNodesID;                    // 0
        public uint ID
        {
            get { return m_TaxiNodesID; }
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
        public uint m_Unknown13;                            // 13
        public uint m_Unknown14;                            // 14
        public uint m_Unknown15;                            // 15
        public uint m_Unknown16;                            // 16
        public uint m_Unknown17;                            // 17
        public uint m_Unknown18;                            // 18
        public uint m_Unknown19;                            // 19
        public uint m_Unknown20;                            // 20
        public uint m_Unknown21;                            // 21
        public uint m_Unknown22;                            // 22
        public uint m_Unknown23;                            // 23

        public bool Load( DBCRecord dbcRecord )
        {
            this.m_TaxiNodesID = dbcRecord.GetUInt( 0 );
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
            this.m_Unknown13 = dbcRecord.GetUInt( 13 );
            this.m_Unknown14 = dbcRecord.GetUInt( 14 );
            this.m_Unknown15 = dbcRecord.GetUInt( 15 );
            this.m_Unknown16 = dbcRecord.GetUInt( 16 );
            this.m_Unknown17 = dbcRecord.GetUInt( 17 );
            this.m_Unknown18 = dbcRecord.GetUInt( 18 );
            this.m_Unknown19 = dbcRecord.GetUInt( 19 );
            this.m_Unknown20 = dbcRecord.GetUInt( 20 );
            this.m_Unknown21 = dbcRecord.GetUInt( 21 );
            this.m_Unknown22 = dbcRecord.GetUInt( 22 );
            this.m_Unknown23 = dbcRecord.GetUInt( 23 );

            //LOGs.WriteLine( LogMessageType.MSG_INFO, "{0}, {1}", m_TaxiNodesID, m_Unknown23 );

            return true;
        }
    }

    //struct DBCTaxiNode
    //{
    //    public uint id;
    //    public uint mapid;
    //    public float x;
    //    public float y;
    //    public float z;
    //    public uint name;
    //    public uint namealt1;
    //    public uint namealt2;
    //    public uint namealt3;
    //    public uint namealt4;
    //    public uint namealt5;
    //    public uint namealt6;
    //    public uint namealt7;
    //    public uint namealt8;
    //    public uint namealt9;
    //    public uint namealt10;
    //    public uint namealt11;
    //    public uint namealt12;
    //    public uint namealt13;
    //    public uint namealt14;
    //    public uint namealt15;
    //    public uint nameflags;
    //    public uint horde_mount;
    //    public uint alliance_mount;

    //    public DBCTaxiNode Load()
    //    {
    //        DBCTaxiNode dbcTaxiNode = new DBCTaxiNode();

    //        dbcTaxiNode.id = 0;
    //        dbcTaxiNode.mapid = 0;
    //        dbcTaxiNode.x = 0;
    //        dbcTaxiNode.y = 0;
    //        dbcTaxiNode.z = 0;
    //        dbcTaxiNode.name = 0;
    //        dbcTaxiNode.namealt1 = 0;
    //        dbcTaxiNode.namealt2 = 0;
    //        dbcTaxiNode.namealt3 = 0;
    //        dbcTaxiNode.namealt4 = 0;
    //        dbcTaxiNode.namealt5 = 0;
    //        dbcTaxiNode.namealt6 = 0;
    //        dbcTaxiNode.namealt7 = 0;
    //        dbcTaxiNode.namealt8 = 0;
    //        dbcTaxiNode.namealt9 = 0;
    //        dbcTaxiNode.namealt10 = 0;
    //        dbcTaxiNode.namealt11 = 0;
    //        dbcTaxiNode.namealt12 = 0;
    //        dbcTaxiNode.namealt13 = 0;
    //        dbcTaxiNode.namealt14 = 0;
    //        dbcTaxiNode.namealt15 = 0;
    //        dbcTaxiNode.nameflags = 0;
    //        dbcTaxiNode.horde_mount = 0;
    //        dbcTaxiNode.alliance_mount = 0;

    //        return dbcTaxiNode;
    //    }
    //}

}
