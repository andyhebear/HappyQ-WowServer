using System;
using System.Collections.Generic;
using System.Text;
using Demo.Mmose.Core.Common;

namespace Demo.Wow.WorldServer.DBC
{
    public class WorldSafeLocsEntry : ILoad<WorldSafeLocsEntry>
    {
        public uint m_WorldSafeLocsID;                    // 0
        public uint ID
        {
            get { return m_WorldSafeLocsID; }
        }

        public uint m_MapId;                                // 1
        public float m_X;                                   // 2
        public float m_Y;                                   // 3
        public float m_Z;                                   // 4
        public uint m_Unknown5;                             // 5
        public uint m_Unknown6;                             // 6
        public uint m_Unknown7;                             // 7
        public uint m_Unknown8;                             // 8
        public string m_Name;                               // 9
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


        public bool Load( DBCRecord dbcRecord )
        {
            this.m_WorldSafeLocsID = dbcRecord.GetUInt( 0 );
            this.m_MapId = dbcRecord.GetUInt( 1 );
            this.m_X = dbcRecord.GetFloat( 2 );
            this.m_Y = dbcRecord.GetFloat( 3 );
            this.m_Z = dbcRecord.GetFloat( 4 );
            this.m_Unknown5 = dbcRecord.GetUInt( 5 );
            this.m_Unknown6 = dbcRecord.GetUInt( 6 );
            this.m_Unknown7 = dbcRecord.GetUInt( 7 );
            this.m_Unknown8 = dbcRecord.GetUInt( 8 );
            this.m_Name = dbcRecord.GetString( 9 );
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

            //LOGs.WriteLine( LogMessageType.MSG_INFO, "{0}", m_WorldSafeLocsID );

            return true;
        }
    }
}
