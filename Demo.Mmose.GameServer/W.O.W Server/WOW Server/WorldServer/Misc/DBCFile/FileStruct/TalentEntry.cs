using System;
using System.Collections.Generic;
using System.Text;
using Demo.Mmose.Core.Common;

namespace Demo.Wow.WorldServer.DBC
{
    public class TalentEntry : ILoad<TalentEntry>
    {
        public uint m_TalentID;                    // 0
        public uint ID
        {
            get { return m_TalentID; }
        }

        public uint m_TalentTree;                           // 1
        public uint m_Row;                                  // 2
        public uint m_Col;                                  // 3
        public uint m_RankID1;                              // 4
        public uint m_RankID2;                              // 5
        public uint m_RankID3;                              // 6
        public uint m_RankID4;                              // 7
        public uint m_RankID5;                              // 8
        public uint m_Unknown9;                             // 9
        public uint m_Unknown10;                            // 10
        public uint m_Unknown11;                            // 11
        public uint m_Unknown12;                            // 12
        public uint m_DependsOn;                            // 13
        public uint m_Unknown14;                            // 14
        public uint m_Unknown15;                            // 15
        public uint m_DependsOnRank;                        // 16
        public uint m_Unknown17;                            // 17
        public uint m_Unknown18;                            // 18
        public uint m_Unknown19;                            // 19
        public uint m_Unknown20;                            // 20


        public bool Load( DBCRecord dbcRecord )
        {
            this.m_TalentID = dbcRecord.GetUInt( 0 );
            this.m_TalentTree = dbcRecord.GetUInt( 1 );
            this.m_Row = dbcRecord.GetUInt( 2 );
            this.m_Col = dbcRecord.GetUInt( 3 );
            this.m_RankID1 = dbcRecord.GetUInt( 4 );
            this.m_RankID2 = dbcRecord.GetUInt( 5 );
            this.m_RankID3 = dbcRecord.GetUInt( 6 );
            this.m_RankID4 = dbcRecord.GetUInt( 7 );
            this.m_RankID5 = dbcRecord.GetUInt( 8 );
            this.m_Unknown9 = dbcRecord.GetUInt( 9 );
            this.m_Unknown10 = dbcRecord.GetUInt( 10 );
            this.m_Unknown11 = dbcRecord.GetUInt( 11 );
            this.m_Unknown12 = dbcRecord.GetUInt( 12 );
            this.m_DependsOn = dbcRecord.GetUInt( 13 );
            this.m_Unknown14 = dbcRecord.GetUInt( 14 );
            this.m_Unknown15 = dbcRecord.GetUInt( 15 );
            this.m_DependsOnRank = dbcRecord.GetUInt( 16 );
            this.m_Unknown17 = dbcRecord.GetUInt( 17 );
            this.m_Unknown18 = dbcRecord.GetUInt( 18 );
            this.m_Unknown19 = dbcRecord.GetUInt( 19 );
            this.m_Unknown20 = dbcRecord.GetUInt( 20 );

            //LOGs.WriteLine( LogMessageType.MSG_INFO, "{0}", m_TalentID );

            return true;
        }
    }

    //internal struct TalentEntry
    //{
    //    public uint TalentID;
    //    public uint TalentTree;
    //    public uint Row;
    //    public uint Col;
    //    public uint[] RankID;
    //    public uint[] unk;
    //    public uint DependsOn;
    //    public uint[] unk1;
    //    public uint DependsOnRank;
    //    public uint[] unk2;

    //    public TalentEntry Load()
    //    {
    //        TalentEntry talentEntry = new TalentEntry();

    //        talentEntry.TalentID = 0;
    //        talentEntry.TalentTree = 0;
    //        talentEntry.Row = 0;
    //        talentEntry.Col = 0;
    //        talentEntry.RankID = new uint[5];
    //        talentEntry.unk = new uint[4];
    //        talentEntry.DependsOn = 0;
    //        talentEntry.unk1 = new uint[2];
    //        talentEntry.DependsOnRank = 0;
    //        talentEntry.unk2 = new uint[4];

    //        return talentEntry;
    //    }
    //}
}
