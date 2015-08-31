using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Wow.WorldServer.DBC
{
    public class ChrRacesEntry : ILoad<ChrRacesEntry>
    {
        public uint m_ChrRacesID;                      // 0
        public uint ID
        {
            get { return m_ChrRacesID; }
        }

        public uint m_Unknown1;                             // 1
        public uint m_FactionId;                             // 2
        public uint m_Unknown3;                             // 3
        public uint m_Unknown4;                             // 4
        public uint m_Unknown5;                             // 5
        public string m_Unknown6;                             // 6
        public uint m_Unknown7;                           // 7
        public uint m_TeamId;                             // 8
        public uint m_Unknown9;                             // 9
        public uint m_Unknown10;                            // 10
        public uint m_Unknown11;                            // 11
        public string m_Unknown12;                            // 12
        public uint m_CinematicId;                            // 13
        public uint m_Unknown14;                            // 14
        public uint m_Unknown15;                            // 15
        public uint m_Unknown16;                            // 16
        public uint m_Unknown17;                            // 17
        public string m_Unknown18;                          // 18
        public uint m_Unknown19;                            // 19
        public uint m_Unknown20;                            // 20
        public uint m_Unknown21;                            // 21
        public uint m_Unknown22;                            // 22
        public uint m_Unknown23;                            // 23
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


        public bool Load( DBCRecord dbcRecord )
        {
            this.m_ChrRacesID = dbcRecord.GetUInt( 0 );
            this.m_Unknown1 = dbcRecord.GetUInt( 1 );
            this.m_FactionId = dbcRecord.GetUInt( 2 );
            this.m_Unknown3 = dbcRecord.GetUInt( 3 );
            this.m_Unknown4 = dbcRecord.GetUInt( 4 );
            this.m_Unknown5 = dbcRecord.GetUInt( 5 );
            this.m_Unknown6 = dbcRecord.GetString( 6 );
            this.m_Unknown7 = dbcRecord.GetUInt( 7 );
            this.m_TeamId = dbcRecord.GetUInt( 8 );
            this.m_Unknown9 = dbcRecord.GetUInt( 9 );
            this.m_Unknown10 = dbcRecord.GetUInt( 10 );
            this.m_Unknown11 = dbcRecord.GetUInt( 11 );
            this.m_Unknown12 = dbcRecord.GetString( 12 );
            this.m_CinematicId = dbcRecord.GetUInt( 13 );
            this.m_Unknown14 = dbcRecord.GetUInt( 14 );
            this.m_Unknown15 = dbcRecord.GetUInt( 15 );
            this.m_Unknown16 = dbcRecord.GetUInt( 16 );
            this.m_Unknown17 = dbcRecord.GetUInt( 17 );
            this.m_Unknown18 = dbcRecord.GetString( 18 );
            this.m_Unknown19 = dbcRecord.GetUInt( 19 );
            this.m_Unknown20 = dbcRecord.GetUInt( 20 );
            this.m_Unknown21 = dbcRecord.GetUInt( 21 );
            this.m_Unknown22 = dbcRecord.GetUInt( 22 );
            this.m_Unknown23 = dbcRecord.GetUInt( 23 );
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


            //LOGs.WriteLine( LogMessageType.MSG_INFO, "{0}, {1}, {2}, {3}", m_ChrRacesID, m_Unknown6, m_Unknown12, m_Unknown18 );

            return true;
        }
    }

    //internal struct CharRaceEntry
    //{
    //    public uint race_id;
    //    public uint unk1;
    //    public uint faction_id;
    //    public uint unk2;
    //    public uint unk3;
    //    public uint unk4;
    //    public uint unk5;
    //    public uint unk6;
    //    public uint team_id;
    //    public uint unk7;
    //    public uint unk8;
    //    public uint unk9;
    //    public uint name1;
    //    public uint cinematic_id;
    //    public uint name2;
    //    public uint unk10;
    //    public uint unk11;
    //    public uint unk12;
    //    public uint unk13;
    //    public uint unk14;
    //    public uint unk15;
    //    public uint unk16;
    //    public uint unk17;
    //    public uint unk18;
    //    public uint unk19;
    //    public uint unk20;
    //    public uint unk21;
    //    public uint unk22;
    //    public uint unk23;
    //    public uint unk24;
    //    public uint unk25;
    //    public uint unk26;
    //    public uint unk27;
    //    public uint unk28;
    //    public uint unk29;

    //    public CharRaceEntry Load()
    //    {
    //        CharRaceEntry charRaceEntry = new CharRaceEntry();

    //        charRaceEntry.race_id = 0;
    //        charRaceEntry.unk1 = 0;
    //        charRaceEntry.faction_id = 0;
    //        charRaceEntry.unk2 = 0;
    //        charRaceEntry.unk3 = 0;
    //        charRaceEntry.unk4 = 0;
    //        charRaceEntry.unk5 = 0;
    //        charRaceEntry.unk6 = 0;
    //        charRaceEntry.team_id = 0;
    //        charRaceEntry.unk7 = 0;
    //        charRaceEntry.unk8 = 0;
    //        charRaceEntry.unk9 = 0;
    //        charRaceEntry.name1 = 0;
    //        charRaceEntry.cinematic_id = 0;
    //        charRaceEntry.name2 = 0;
    //        charRaceEntry.unk10 = 0;
    //        charRaceEntry.unk11 = 0;
    //        charRaceEntry.unk12 = 0;
    //        charRaceEntry.unk13 = 0;
    //        charRaceEntry.unk14 = 0;
    //        charRaceEntry.unk15 = 0;
    //        charRaceEntry.unk16 = 0;
    //        charRaceEntry.unk17 = 0;
    //        charRaceEntry.unk18 = 0;
    //        charRaceEntry.unk19 = 0;
    //        charRaceEntry.unk20 = 0;
    //        charRaceEntry.unk21 = 0;
    //        charRaceEntry.unk22 = 0;
    //        charRaceEntry.unk23 = 0;
    //        charRaceEntry.unk24 = 0;
    //        charRaceEntry.unk25 = 0;
    //        charRaceEntry.unk26 = 0;
    //        charRaceEntry.unk27 = 0;
    //        charRaceEntry.unk28 = 0;
    //        charRaceEntry.unk29 = 0;

    //        return charRaceEntry;
    //    }
    //}
}
