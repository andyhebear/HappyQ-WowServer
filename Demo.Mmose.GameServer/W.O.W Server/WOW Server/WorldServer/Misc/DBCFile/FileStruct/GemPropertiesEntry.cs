using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Wow.WorldServer.DBC
{
    public class GemPropertiesEntry : ILoad<GemPropertiesEntry>
    {
        public uint m_GemPropertiesID;                    // 0
        public uint ID
        {
            get { return m_GemPropertiesID; }
        }

        public uint m_Unknown1;                             // 1
        public uint m_Unknown2;                             // 2
        public uint m_Unknown3;                             // 3
        public uint m_Unknown4;                             // 4


        public bool Load( DBCRecord dbcRecord )
        {
            this.m_GemPropertiesID = dbcRecord.GetUInt( 0 );
            this.m_Unknown1 = dbcRecord.GetUInt( 1 );
            this.m_Unknown2 = dbcRecord.GetUInt( 2 );
            this.m_Unknown3 = dbcRecord.GetUInt( 3 );
            this.m_Unknown4 = dbcRecord.GetUInt( 4 );

            //LOGs.WriteLine( LogMessageType.MSG_INFO, "{0}", m_GemPropertiesID );

            return true;
        }
    }

    //internal struct GemPropertyEntry
    //{
    //    public uint Entry;
    //    public uint EnchantmentID;
    //    public uint unk1;//bool
    //    public uint unk2;//bool
    //    public uint SocketMask;

    //    public GemPropertyEntry Load()
    //    {
    //        GemPropertyEntry gemPropertyEntry = new GemPropertyEntry();

    //        gemPropertyEntry.Entry = 0;
    //        gemPropertyEntry.EnchantmentID = 0;
    //        gemPropertyEntry.unk1 = 0;//bool
    //        gemPropertyEntry.unk2 = 0;//bool
    //        gemPropertyEntry.SocketMask = 0;

    //        return gemPropertyEntry;
    //    }
    //}
}
