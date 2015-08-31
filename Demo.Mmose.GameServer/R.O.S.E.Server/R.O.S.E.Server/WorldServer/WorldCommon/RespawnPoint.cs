
using Demo_R.O.S.E.WorldServer.Network;

namespace Demo_R.O.S.E.WorldServer.Common
{
    /// <summary>
    /// A respawn point object
    /// </summary>
    class RespawnPoint
    {
        ushort id;
        fPoint dest;
        byte destMap;
        byte radius;
        bool masterdest;
    }
}
