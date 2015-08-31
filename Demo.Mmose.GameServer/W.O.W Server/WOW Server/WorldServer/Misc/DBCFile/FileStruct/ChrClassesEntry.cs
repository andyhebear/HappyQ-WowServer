using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Wow.WorldServer.DBC
{
    public class ChrClassesEntry : ILoad<ChrClassesEntry>
    {
        public uint m_ChrClassesID;                         // 0
        public uint ID
        {
            get { return m_ChrClassesID; }
        }

        public uint m_Unknown1;                             // 1
        public uint m_PowerType;                            // 2
        public uint m_Unknown3;                             // 3
        public uint m_Unknown4;                             // 4
        public uint m_Unknown5;                             // 5
        public uint m_Unknown6;                             // 6
        public uint m_Unknown7;                             // 7
        public string m_Unknown8;                           // 8
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
        public string m_Unknown21;                          // 21
        public uint m_Unknown22;                            // 22
        public uint m_Unknown23;                            // 23


        public bool Load( DBCRecord dbcRecord )
        {
            this.m_ChrClassesID = dbcRecord.GetUInt( 0 );
            this.m_Unknown1 = dbcRecord.GetUInt( 1 );
            this.m_PowerType = dbcRecord.GetUInt( 2 );
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
            this.m_Unknown21 = dbcRecord.GetString( 21 );
            this.m_Unknown22 = dbcRecord.GetUInt( 22 );
            this.m_Unknown23 = dbcRecord.GetUInt( 23 );


            //LOGs.WriteLine( LogMessageType.MSG_INFO, "{0}, {1}, {2}", m_ChrClassesID, m_Unknown8, m_Unknown21 );

            return true;
        }
    }

    //internal struct CharClassEntry
    //{
    //    public uint class_id;
    //    public uint unk1;
    //    public uint power_type;
    //    public uint unk2;
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
    //    public uint unk3;
    //    public uint unk4;
    //    public uint unk5;

    //    public CharClassEntry Load()
    //    {
    //        CharClassEntry charClassEntry = new CharClassEntry();

    //        charClassEntry.class_id = 0;
    //        charClassEntry.unk1 = 0;
    //        charClassEntry.power_type = 0;
    //        charClassEntry.unk2 = 0;
    //        charClassEntry.name = 0;
    //        charClassEntry.namealt1 = 0;
    //        charClassEntry.namealt2 = 0;
    //        charClassEntry.namealt3 = 0;
    //        charClassEntry.namealt4 = 0;
    //        charClassEntry.namealt5 = 0;
    //        charClassEntry.namealt6 = 0;
    //        charClassEntry.namealt7 = 0;
    //        charClassEntry.namealt8 = 0;
    //        charClassEntry.namealt9 = 0;
    //        charClassEntry.namealt10 = 0;
    //        charClassEntry.namealt11 = 0;
    //        charClassEntry.namealt12 = 0;
    //        charClassEntry.namealt13 = 0;
    //        charClassEntry.namealt14 = 0;
    //        charClassEntry.namealt15 = 0;
    //        charClassEntry.nameflags = 0;
    //        charClassEntry.unk3 = 0;
    //        charClassEntry.unk4 = 0;
    //        charClassEntry.unk5 = 0;

    //        return charClassEntry;
    //    }
    //}
}
