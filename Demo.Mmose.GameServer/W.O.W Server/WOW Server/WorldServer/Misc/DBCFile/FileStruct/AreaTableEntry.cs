using System;
using System.Collections.Generic;
using System.Text;
using Demo.Mmose.Core.Common;

namespace Demo.Wow.WorldServer.DBC
{
    public class AreaTableEntry : ILoad<AreaTableEntry>
    {
        public uint m_AreaTableId;              // 0
        public uint ID
        {
            get { return m_AreaTableId; }
        }

        public uint m_MapId;                    // 1
        public uint m_ZoneId;                   // 2
        public uint m_ExplorationFlag;          // 3
        public uint m_AreaFlags;                // 4
        public uint m_Unknown2;                 // 5
        public uint m_Unknown3;                 // 6
        public uint m_Unknown4;                 // 7
        public uint m_EXP;//not XP              // 8
        public uint m_Unknown5;                 // 9
        public uint m_Level;                    // 10
        public uint m_NameAlt0;                 // 11
        public uint m_NameAlt1;                 // 12
        public uint m_NameAlt2;                 // 13
        public uint m_NameAlt3;                 // 14
        public string m_Name;                   // 15
        public uint m_NameAlt5;                 // 16
        public uint m_NameAlt6;                 // 17
        public uint m_NameAlt7;                 // 18
        public uint m_NameAlt8;                 // 19
        public uint m_NameAlt9;                 // 20
        public uint m_NameAlt10;                // 21
        public uint m_NameAlt11;                // 22
        public uint m_NameAlt12;                // 23
        public uint m_NameAlt13;                // 24
        public uint m_NameAlt14;                // 25
        public uint m_NameAlt15;                // 26
        public uint m_NameFlags;                // 27
        public uint m_Category;                 // 28
        public uint m_Unknown7;                 // 29
        public uint m_Unknown8;                 // 30
        public uint m_Unknown9;                 // 31
        public uint m_Unknown10;                // 32
        public float m_Unknown11;               // 33
        public float m_Unknown12;               // 34

        public bool Load( DBCRecord dbcRecord )
        {
            this.m_AreaTableId = dbcRecord.GetUInt( 0 );
            this.m_MapId = dbcRecord.GetUInt( 1 );
            this.m_ZoneId = dbcRecord.GetUInt( 2 );
            this.m_ExplorationFlag = dbcRecord.GetUInt( 3 );
            this.m_AreaFlags = dbcRecord.GetUInt( 4 );
            this.m_Unknown2 = dbcRecord.GetUInt( 5 );
            this.m_Unknown3 = dbcRecord.GetUInt( 6 );
            this.m_Unknown4 = dbcRecord.GetUInt( 7 );
            this.m_EXP = dbcRecord.GetUInt( 8 );
            this.m_Unknown5 = dbcRecord.GetUInt( 9 );
            this.m_Level = dbcRecord.GetUInt( 10 );
            this.m_NameAlt0 = dbcRecord.GetUInt( 11 );
            this.m_NameAlt1 = dbcRecord.GetUInt( 12 );
            this.m_NameAlt2 = dbcRecord.GetUInt( 13 );
            this.m_NameAlt3 = dbcRecord.GetUInt( 14 );
            this.m_Name = dbcRecord.GetString( 15 );
            this.m_NameAlt5 = dbcRecord.GetUInt( 16 );
            this.m_NameAlt6 = dbcRecord.GetUInt( 17 );
            this.m_NameAlt7 = dbcRecord.GetUInt( 18 );
            this.m_NameAlt8 = dbcRecord.GetUInt( 19 );
            this.m_NameAlt9 = dbcRecord.GetUInt( 20 );
            this.m_NameAlt10 = dbcRecord.GetUInt( 21 );
            this.m_NameAlt11 = dbcRecord.GetUInt( 22 );
            this.m_NameAlt12 = dbcRecord.GetUInt( 23 );
            this.m_NameAlt13 = dbcRecord.GetUInt( 24 );
            this.m_NameAlt14 = dbcRecord.GetUInt( 25 );
            this.m_NameAlt15 = dbcRecord.GetUInt( 26 );
            this.m_NameFlags = dbcRecord.GetUInt( 27 );
            this.m_Category = dbcRecord.GetUInt( 28 );
            this.m_Unknown7 = dbcRecord.GetUInt( 29 );
            this.m_Unknown8 = dbcRecord.GetUInt( 30 );
            this.m_Unknown9 = dbcRecord.GetUInt( 31 );
            this.m_Unknown10 = dbcRecord.GetUInt( 32 );
            this.m_Unknown11 = dbcRecord.GetFloat( 33 );
            this.m_Unknown12 = dbcRecord.GetFloat( 34 );

            //LOGs.WriteLine( LogMessageType.MSG_INFO, "{0}, {1}, {2}, {3} {4} {5}", m_AreaTableId, m_MapId, m_ZoneId, m_Name, m_ExplorationFlag, m_AreaFlags );

            return true;
        }
    }
}
