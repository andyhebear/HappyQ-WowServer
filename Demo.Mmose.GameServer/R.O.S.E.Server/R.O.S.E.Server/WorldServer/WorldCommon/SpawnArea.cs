using System;
using Demo_R.O.S.E.WorldServer.Network;

namespace Demo_R.O.S.E.WorldServer.Common
{
    /// <summary>
    /// A monster spawn zone
    /// </summary>
    class SpawnArea
    {
        uint id;
        byte map;
        int min;
        int max;
        int respawntime;
        ushort montype;
        int pcount;
        int amon;
        fPoint points;
        DateTime lastRespawnTime;
        NPCData thisnpc;
        DropData mobdrop;
        DropData mapdrop;
    }
}
