using System;
using System.Collections.Generic;
using System.Text;
using Demo.Mmose.Core.Common;

namespace Demo.Wow.WorldServer.DBC
{
    public class TaxiPathNodeEntry : ILoad<TaxiPathNodeEntry>
    {
        public uint m_TaxiPathNodeID;                       // 0
        public uint ID
        {
            get { return m_TaxiPathNodeID; }
        }

        public uint m_Path;                                 // 1
        public uint m_Seq;                                  // 2
        public uint m_MapId;                                // 3
        public float m_X;                                   // 4
        public float m_Y;                                   // 5
        public float m_Z;                                   // 6
        public uint m_ActionFlag;                           // 7
        public uint m_WaitTime;                             // 8
        public uint m_Unknown9;                             // 9
        public uint m_Unknown10;                            // 10


        public bool Load( DBCRecord dbcRecord )
        {
            this.m_TaxiPathNodeID = dbcRecord.GetUInt( 0 );
            this.m_Path = dbcRecord.GetUInt( 1 );
            this.m_Seq = dbcRecord.GetUInt( 2 );
            this.m_MapId = dbcRecord.GetUInt( 3 );
            this.m_X = dbcRecord.GetFloat( 4 );
            this.m_Y = dbcRecord.GetFloat( 5 );
            this.m_Z = dbcRecord.GetFloat( 6 );
            this.m_ActionFlag = dbcRecord.GetUInt( 7 );
            this.m_WaitTime = dbcRecord.GetUInt( 8 );
            this.m_Unknown9 = dbcRecord.GetUInt( 9 );
            this.m_Unknown10 = dbcRecord.GetUInt( 10 );

            //LOGs.WriteLine( LogMessageType.MSG_INFO, "{0}", m_TaxiPathNodeID );

            return true;
        }
    }

    //internal struct DBCTaxiPathNode
    //{
    //    public uint id;
    //    public uint path;
    //    public uint seq;
    //    public uint mapid;
    //    public float x;
    //    public float y;
    //    public float z;
    //    public uint unk1;
    //    public uint waittime;
    //    public uint unk2;
    //    public uint unk3;

    //    public DBCTaxiPathNode Load()
    //    {
    //        DBCTaxiPathNode dbcTaxiPathNode = new DBCTaxiPathNode();

    //        dbcTaxiPathNode.id = 0;
    //        dbcTaxiPathNode.path = 0;
    //        dbcTaxiPathNode.seq = 0;
    //        dbcTaxiPathNode.mapid = 0;
    //        dbcTaxiPathNode.x = 0;
    //        dbcTaxiPathNode.y = 0;
    //        dbcTaxiPathNode.z = 0;
    //        dbcTaxiPathNode.unk1 = 0;
    //        dbcTaxiPathNode.waittime = 0;
    //        dbcTaxiPathNode.unk2 = 0;
    //        dbcTaxiPathNode.unk3 = 0;

    //        return dbcTaxiPathNode;
    //    }
    //}

}
