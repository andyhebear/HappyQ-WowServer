using System;
using System.Collections.Generic;
using System.Text;
using Demo.Mmose.Core.Common;

namespace Demo.Wow.WorldServer.DBC
{
    public class WorldMapOverlayEntry : ILoad<WorldMapOverlayEntry>
    {
        public uint m_WorldMapOverlayID;                    // 0
        public uint ID
        {
            get { return m_WorldMapOverlayID; }
        }

        public uint m_Unknown1;                             // 1
        public uint m_Unknown2;                             // 2
        public uint m_Unknown3;                             // 3
        public uint m_Unknown4;                             // 4
        public uint m_Unknown5;                             // 5
        public uint m_Unknown6;                             // 6
        public uint m_Unknown7;                             // 7
        public uint m_Unknown8;                             // 8
        public uint m_Unknown9;                             // 9
        public uint m_Unknown10;                            // 10
        public uint m_Unknown11;                            // 11
        public uint m_Unknown12;                            // 12
        public uint m_Unknown13;                            // 13
        public uint m_Unknown14;                            // 14
        public uint m_Unknown15;                            // 15
        public uint m_Unknown16;                            // 16


        public bool Load( DBCRecord dbcRecord )
        {
            this.m_WorldMapOverlayID = dbcRecord.GetUInt( 0 );
            this.m_Unknown1 = dbcRecord.GetUInt( 1 );
            this.m_Unknown2 = dbcRecord.GetUInt( 2 );
            this.m_Unknown3 = dbcRecord.GetUInt( 3 );
            this.m_Unknown4 = dbcRecord.GetUInt( 4 );
            this.m_Unknown5 = dbcRecord.GetUInt( 5 );
            this.m_Unknown6 = dbcRecord.GetUInt( 6 );
            this.m_Unknown7 = dbcRecord.GetUInt( 7 );
            this.m_Unknown8 = dbcRecord.GetUInt( 8 );
            this.m_Unknown9 = dbcRecord.GetUInt( 9 );
            this.m_Unknown10 = dbcRecord.GetUInt( 10 );
            this.m_Unknown11 = dbcRecord.GetUInt( 11 );
            this.m_Unknown12 = dbcRecord.GetUInt( 12 );
            this.m_Unknown13 = dbcRecord.GetUInt( 13 );
            this.m_Unknown14 = dbcRecord.GetUInt( 14 );
            this.m_Unknown15 = dbcRecord.GetUInt( 15 );
            this.m_Unknown16 = dbcRecord.GetUInt( 16 );

            //LOGs.WriteLine( LogMessageType.MSG_INFO, "{0}", m_WorldMapOverlayID );

            return true;
        }
    }

    //struct WorldMapOverlay
    //{
    //    public uint ID;
    //    public uint worldMapAreaID;
    //    public uint areaTableID;
    //    public uint unk1;
    //    public uint unk2;
    //    public uint unk3;
    //    public uint unk4;
    //    public uint unk5;
    //    public uint name;
    //    public uint areaW;
    //    public uint areaH;
    //    public uint areaX;
    //    public uint areaY;
    //    public uint y1;
    //    public uint x1;
    //    public uint y2;
    //    public uint x2;

    //    public WorldMapOverlay Load()
    //    {
    //        WorldMapOverlay worldMapOverlay = new WorldMapOverlay();

    //        worldMapOverlay.ID = 0;
    //        worldMapOverlay.worldMapAreaID = 0;
    //        worldMapOverlay.areaTableID = 0;
    //        worldMapOverlay.unk1 = 0;
    //        worldMapOverlay.unk2 = 0;
    //        worldMapOverlay.unk3 = 0;
    //        worldMapOverlay.unk4 = 0;
    //        worldMapOverlay.unk5 = 0;
    //        worldMapOverlay.name = 0;
    //        worldMapOverlay.areaW = 0;
    //        worldMapOverlay.areaH = 0;
    //        worldMapOverlay.areaX = 0;
    //        worldMapOverlay.areaY = 0;
    //        worldMapOverlay.y1 = 0;
    //        worldMapOverlay.x1 = 0;
    //        worldMapOverlay.y2 = 0;
    //        worldMapOverlay.x2 = 0;

    //        return worldMapOverlay;
    //    }
    //}

}
