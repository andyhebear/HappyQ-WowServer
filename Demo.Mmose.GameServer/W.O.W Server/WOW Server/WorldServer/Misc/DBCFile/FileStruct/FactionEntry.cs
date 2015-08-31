using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Wow.WorldServer.DBC
{
    public class FactionEntry : ILoad<FactionEntry>
    {
        public uint m_DurabilityCostsID;                    // 0
        public uint ID
        {
            get { return m_DurabilityCostsID; }
        }

        public uint m_RepListId;                            // 1
        public uint m_BaseRepMask1;                         // 2
        public uint m_BaseRepMask2;                         // 3
        public uint m_BaseRepMask3;                         // 4
        public uint m_BaseRepMask4;                         // 5
        public uint m_Unknown6;                             // 6
        public uint m_Unknown7;                             // 7
        public uint m_Unknown8;                             // 8
        public uint m_Unknown9;                             // 9
        public uint m_BaseRepValue1;                        // 10
        public uint m_BaseRepValue2;                        // 11
        public uint m_BaseRepValue3;                        // 12
        public uint m_BaseRepValue4;                        // 13
        public uint m_Unknown14;                            // 14
        public uint m_Unknown15;                            // 15
        public uint m_Unknown16;                            // 16
        public uint m_Unknown17;                            // 17
        public uint m_Team;                                 // 18
        public uint m_Unknown19;                            // 19
        public uint m_Unknown20;                            // 20
        public uint m_Unknown21;                            // 21
        public uint m_Unknown22;                            // 22
        public string m_Name;                               // 23
        public uint m_Unknown24;                            // 24
        public uint m_Unknown25;                            // 25
        public uint m_Unknown26;                            // 26
        public uint m_Unknown27;                            // 27
        public uint m_Unknown28;                            // 28
        public uint m_Unknown29;                            // 29
        public uint m_Unknown30;                            // 30
        public uint m_Unknown31;                            // 31
        public uint m_Unknown32;                            // 32
        public uint m_Unknown33;                            // 33
        public uint m_Unknown34;                            // 34
        public uint m_Unknown35;                            // 35
        public uint m_Unknown36;                            // 36
        public uint m_Unknown37;                            // 37
        public uint m_Unknown38;                            // 38
        public uint m_Unknown39;                            // 39
        public string m_Description;                        // 40
        public uint m_Unknown41;                            // 41
        public uint m_Unknown42;                            // 42
        public uint m_Unknown43;                            // 43
        public uint m_Unknown44;                            // 44
        public uint m_Unknown45;                            // 45
        public uint m_Unknown46;                            // 46
        public uint m_Unknown47;                            // 47
        public uint m_Unknown48;                            // 48
        public uint m_Unknown49;                            // 49
        public uint m_Unknown50;                            // 50
        public uint m_Unknown51;                            // 51
        public uint m_Unknown52;                            // 52


        public bool Load( DBCRecord dbcRecord )
        {
            this.m_DurabilityCostsID = dbcRecord.GetUInt( 0 );
            this.m_RepListId = dbcRecord.GetUInt( 1 );
            this.m_BaseRepMask1 = dbcRecord.GetUInt( 2 );
            this.m_BaseRepMask2 = dbcRecord.GetUInt( 3 );
            this.m_BaseRepMask3 = dbcRecord.GetUInt( 4 );
            this.m_BaseRepMask4 = dbcRecord.GetUInt( 5 );
            this.m_Unknown6 = dbcRecord.GetUInt( 6 );
            this.m_Unknown7 = dbcRecord.GetUInt( 7 );
            this.m_Unknown8 = dbcRecord.GetUInt( 8 );
            this.m_Unknown9 = dbcRecord.GetUInt( 9 );
            this.m_BaseRepValue1 = dbcRecord.GetUInt( 10 );
            this.m_BaseRepValue2 = dbcRecord.GetUInt( 11 );
            this.m_BaseRepValue3 = dbcRecord.GetUInt( 12 );
            this.m_BaseRepValue4 = dbcRecord.GetUInt( 13 );
            this.m_Unknown14 = dbcRecord.GetUInt( 14 );
            this.m_Unknown15 = dbcRecord.GetUInt( 15 );
            this.m_Unknown16 = dbcRecord.GetUInt( 16 );
            this.m_Unknown17 = dbcRecord.GetUInt( 17 );
            this.m_Team = dbcRecord.GetUInt( 18 );
            this.m_Unknown19 = dbcRecord.GetUInt( 19 );
            this.m_Unknown20 = dbcRecord.GetUInt( 20 );
            this.m_Unknown21 = dbcRecord.GetUInt( 21 );
            this.m_Unknown22 = dbcRecord.GetUInt( 22 );
            this.m_Name = dbcRecord.GetString( 23 );
            this.m_Unknown24 = dbcRecord.GetUInt( 24 );
            this.m_Unknown25 = dbcRecord.GetUInt( 25 );
            this.m_Unknown26 = dbcRecord.GetUInt( 26 );
            this.m_Unknown27 = dbcRecord.GetUInt( 27 );
            this.m_Unknown28 = dbcRecord.GetUInt( 28 );
            this.m_Unknown29 = dbcRecord.GetUInt( 29 );
            this.m_Unknown30 = dbcRecord.GetUInt( 30 );
            this.m_Unknown31 = dbcRecord.GetUInt( 31 );
            this.m_Unknown32 = dbcRecord.GetUInt( 32 );
            this.m_Unknown33 = dbcRecord.GetUInt( 33 );
            this.m_Unknown34 = dbcRecord.GetUInt( 34 );
            this.m_Unknown35 = dbcRecord.GetUInt( 35 );
            this.m_Unknown36 = dbcRecord.GetUInt( 36 );
            this.m_Unknown37 = dbcRecord.GetUInt( 37 );
            this.m_Unknown38 = dbcRecord.GetUInt( 38 );
            this.m_Unknown39 = dbcRecord.GetUInt( 39 );
            this.m_Description = dbcRecord.GetString( 40 );
            this.m_Unknown41 = dbcRecord.GetUInt( 41 );
            this.m_Unknown42 = dbcRecord.GetUInt( 42 );
            this.m_Unknown43 = dbcRecord.GetUInt( 43 );
            this.m_Unknown44 = dbcRecord.GetUInt( 44 );
            this.m_Unknown45 = dbcRecord.GetUInt( 45 );
            this.m_Unknown46 = dbcRecord.GetUInt( 46 );
            this.m_Unknown47 = dbcRecord.GetUInt( 47 );
            this.m_Unknown48 = dbcRecord.GetUInt( 48 );
            this.m_Unknown49 = dbcRecord.GetUInt( 49 );
            this.m_Unknown50 = dbcRecord.GetUInt( 50 );
            this.m_Unknown51 = dbcRecord.GetUInt( 51 );
            this.m_Unknown52 = dbcRecord.GetUInt( 52 );

            //LOGs.WriteLine( LogMessageType.MSG_INFO, "{0}, {1}", m_DurabilityCostsID, m_Unknown23 );

            return true;
        }
    }

    //internal struct FactionDBC
    //{
    //    public uint ID;
    //    public int RepListId;
    //    public uint[] baseRepMask;
    //    public uint[] unk1;
    //    public int[] baseRepValue;
    //    public uint[] unk2;
    //    public uint parentFaction;
    //    public uint Name;
    //    public uint[] shit;
    //    public uint Description;
    //    public uint[] shit2;

    //    public FactionDBC Load()
    //    {
    //        FactionDBC factionDBC = new FactionDBC();

    //        factionDBC.ID = 0;
    //        factionDBC.RepListId = 0;
    //        factionDBC.baseRepMask = new uint[4];
    //        factionDBC.unk1 = new uint[4];
    //        factionDBC.baseRepValue = new int[4];
    //        factionDBC.unk2 = new uint[4];
    //        factionDBC.parentFaction = 0;
    //        factionDBC.Name = 0;
    //        factionDBC.shit = new uint[16];
    //        factionDBC.Description = 0;
    //        factionDBC.shit2 = new uint[16];

    //        return factionDBC;
    //    }
    //}
}
