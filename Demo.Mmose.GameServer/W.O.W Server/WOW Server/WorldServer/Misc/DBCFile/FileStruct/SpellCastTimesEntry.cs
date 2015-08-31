using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Wow.WorldServer.DBC
{
    public class SpellCastTimesEntry : ILoad<SpellCastTimesEntry>
    {
        public uint m_SpellCastTimesID;                    // 0
        public uint ID
        {
            get { return m_SpellCastTimesID; }
        }

        public uint m_Unknown1;                             // 1
        public uint m_Unknown2;                             // 2
        public uint m_Unknown3;                             // 3


        public bool Load( DBCRecord dbcRecord )
        {
            this.m_SpellCastTimesID = dbcRecord.GetUInt( 0 );
            this.m_Unknown1 = dbcRecord.GetUInt( 1 );
            this.m_Unknown2 = dbcRecord.GetUInt( 2 );
            this.m_Unknown3 = dbcRecord.GetUInt( 3 );

            //LOGs.WriteLine( LogMessageType.MSG_INFO, "{0}", m_SpellCastTimesID );

            return true;
        }
    }

    //internal struct SpellCastTime
    //{
    //    public uint ID;
    //    public uint CastTime;
    //    public uint unk1;
    //    public uint unk2;

    //    public SpellCastTime Load()
    //    {
    //        SpellCastTime spellCastTime = new SpellCastTime();

    //        spellCastTime.ID = 0;
    //        spellCastTime.CastTime = 0;
    //        spellCastTime.unk1 = 0;
    //        spellCastTime.unk2 = 0;

    //        return spellCastTime;
    //    }
    //}

}
