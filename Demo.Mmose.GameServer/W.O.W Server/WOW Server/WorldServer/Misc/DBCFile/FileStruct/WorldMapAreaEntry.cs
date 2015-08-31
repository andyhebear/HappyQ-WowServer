using System;
using System.Collections.Generic;
using System.Text;
using Demo.Mmose.Core.Common;

namespace Demo.Wow.WorldServer.DBC
{
    public class WorldMapAreaEntry : ILoad<WorldMapAreaEntry>
    {
        public uint m_WorldMapAreaID;                    // 0
        public uint ID
        {
            get { return m_WorldMapAreaID; }
        }

        public uint m_Unknown1;                             // 1
        public uint m_Unknown2;                             // 2
        public uint m_Unknown3;                             // 3
        public uint m_Unknown4;                             // 4
        public uint m_Unknown5;                             // 5
        public uint m_Unknown6;                             // 6
        public uint m_Unknown7;                             // 7
        public uint m_Unknown8;                             // 8


        public bool Load( DBCRecord dbcRecord )
        {
            this.m_WorldMapAreaID = dbcRecord.GetUInt( 0 );
            this.m_Unknown1 = dbcRecord.GetUInt( 1 );
            this.m_Unknown2 = dbcRecord.GetUInt( 2 );
            this.m_Unknown3 = dbcRecord.GetUInt( 3 );
            this.m_Unknown4 = dbcRecord.GetUInt( 4 );
            this.m_Unknown5 = dbcRecord.GetUInt( 5 );
            this.m_Unknown6 = dbcRecord.GetUInt( 6 );
            this.m_Unknown7 = dbcRecord.GetUInt( 7 );
            this.m_Unknown8 = dbcRecord.GetUInt( 8 );

            //LOGs.WriteLine( LogMessageType.MSG_INFO, "{0}", m_WorldMapAreaID );

            return true;
        }
    }

    //internal struct WorldMapArea
    //{
    //    public uint ID;
    //    public uint mapId;
    //    public uint zoneId;
    //    public uint zoneName;
    //    public float y1;
    //    public float y2;
    //    public float x1;
    //    public float x2;
    //    public uint unk;

    //    public WorldMapArea Load()
    //    {
    //        WorldMapArea worldMapArea = new WorldMapArea();

    //        worldMapArea.ID = 0;
    //        worldMapArea.mapId = 0;
    //        worldMapArea.zoneId = 0;
    //        worldMapArea.zoneName = 0;
    //        worldMapArea.y1 = 0;
    //        worldMapArea.y2 = 0;
    //        worldMapArea.x1 = 0;
    //        worldMapArea.x2 = 0;
    //        worldMapArea.unk = 0;

    //        return worldMapArea;
    //    }
    //}

}
