
using Demo_R.O.S.E.WorldServer.Network;

namespace Demo_R.O.S.E.WorldServer.Common
{
    /// <summary>
    /// A typical npc
    /// </summary>
    class NPC
    {
        ushort clientid;
        fPoint pos;
        float dir;
        byte posMap;
        uint npctype;
        NPCData thisnpc;
    }
}
