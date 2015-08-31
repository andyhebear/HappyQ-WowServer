using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Wow.WorldServer.DBC
{
    /// <summary>
    /// ”–Œ Ã‚
    /// </summary>
    public class SpellItemEnchantmentConditionEntry : ILoad<SpellItemEnchantmentConditionEntry>
    {
        public uint m_SpellItemEnchantmentConditionID;                    // 0
        public uint ID
        {
            get { return m_SpellItemEnchantmentConditionID; }
        }

        public byte m_Unknown1;                             // 1
        public byte m_Unknown2;                             // 2
        public byte m_Unknown3;                             // 3
        public byte m_Unknown4;                             // 4
        public byte m_Unknown5;                             // 5
        public uint m_Unknown6;                             // 6
        public uint m_Unknown7;                             // 7
        public uint m_Unknown8;                             // 8
        public uint m_Unknown9;                             // 9
        public uint m_Unknown10;                            // 10
        public byte m_Unknown11;                            // 11
        public byte m_Unknown12;                            // 12
        public byte m_Unknown13;                            // 13
        public byte m_Unknown14;                            // 14
        public byte m_Unknown15;                            // 15
        public byte m_Unknown16;                            // 16
        public byte m_Unknown17;                            // 17
        public byte m_Unknown18;                            // 18
        public byte m_Unknown19;                            // 19
        public byte m_Unknown20;                            // 20
        public uint m_Unknown21;                            // 21
        public uint m_Unknown22;                            // 22
        public uint m_Unknown23;                            // 23
        public uint m_Unknown24;                            // 24
        public uint m_Unknown25;                            // 25
        public byte m_Unknown26;                            // 26
        public byte m_Unknown27;                            // 27
        public byte m_Unknown28;                            // 28
        public byte m_Unknown29;                            // 29
        public byte m_Unknown30;                            // 30


        public bool Load( DBCRecord dbcRecord )
        {
            this.m_SpellItemEnchantmentConditionID = dbcRecord.GetOffsetUInt( 0 );
            this.m_Unknown1 = dbcRecord.GetOffsetByte( 4 );
            this.m_Unknown2 = dbcRecord.GetOffsetByte( 5 );
            this.m_Unknown3 = dbcRecord.GetOffsetByte( 6 );
            this.m_Unknown4 = dbcRecord.GetOffsetByte( 7 );
            this.m_Unknown5 = dbcRecord.GetOffsetByte( 8 );
            this.m_Unknown6 = dbcRecord.GetOffsetUInt( 9 );
            this.m_Unknown7 = dbcRecord.GetOffsetUInt( 13 );
            this.m_Unknown8 = dbcRecord.GetOffsetUInt( 17 );
            this.m_Unknown9 = dbcRecord.GetOffsetUInt( 21 );
            this.m_Unknown10 = dbcRecord.GetOffsetUInt( 25 );
            this.m_Unknown11 = dbcRecord.GetOffsetByte( 29 );
            this.m_Unknown12 = dbcRecord.GetOffsetByte( 30 );
            this.m_Unknown13 = dbcRecord.GetOffsetByte( 31 );
            this.m_Unknown14 = dbcRecord.GetOffsetByte( 32 );
            this.m_Unknown15 = dbcRecord.GetOffsetByte( 33 );
            this.m_Unknown16 = dbcRecord.GetOffsetByte( 34 );
            this.m_Unknown17 = dbcRecord.GetOffsetByte( 35 );
            this.m_Unknown18 = dbcRecord.GetOffsetByte( 36 );
            this.m_Unknown19 = dbcRecord.GetOffsetByte( 37 );
            this.m_Unknown20 = dbcRecord.GetOffsetByte( 38 );
            this.m_Unknown21 = dbcRecord.GetOffsetUInt( 39 );
            this.m_Unknown22 = dbcRecord.GetOffsetUInt( 43 );
            this.m_Unknown23 = dbcRecord.GetOffsetUInt( 47 );
            this.m_Unknown24 = dbcRecord.GetOffsetUInt( 51 );
            this.m_Unknown25 = dbcRecord.GetOffsetUInt( 55 );
            this.m_Unknown26 = dbcRecord.GetOffsetByte( 59 );
            this.m_Unknown27 = dbcRecord.GetOffsetByte( 60 );
            this.m_Unknown28 = dbcRecord.GetOffsetByte( 61 );
            this.m_Unknown29 = dbcRecord.GetOffsetByte( 62 );
            this.m_Unknown30 = dbcRecord.GetOffsetByte( 63 );

            //LOGs.WriteLine( LogMessageType.MSG_INFO, "{0}, {1}", m_SpellItemEnchantmentConditionID, m_Unknown30 );

            return true;
        }
    }
}
