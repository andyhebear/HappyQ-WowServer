using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Wow.WorldServer.DBC
{
    public class SpellDurationEntry : ILoad<SpellDurationEntry>
    {
        public uint m_SpellDurationID;                    // 0
        public uint ID
        {
            get { return m_SpellDurationID; }
        }

        public uint m_Unknown1;                             // 1
        public uint m_Unknown2;                             // 2
        public uint m_Unknown3;                             // 3


        public bool Load( DBCRecord dbcRecord )
        {
            this.m_SpellDurationID = dbcRecord.GetUInt( 0 );
            this.m_Unknown1 = dbcRecord.GetUInt( 1 );
            this.m_Unknown2 = dbcRecord.GetUInt( 2 );
            this.m_Unknown3 = dbcRecord.GetUInt( 3 );

            //LOGs.WriteLine( LogMessageType.MSG_INFO, "{0}", m_SpellDurationID );

            return true;
        }
    }

    //internal struct SpellDuration
    //{
    //    public uint ID;
    //    public uint Duration1;
    //    public uint Duration2;
    //    public uint Duration3;

    //    public SpellDuration Load()
    //    {
    //        SpellDuration spellDuration = new SpellDuration();

    //        spellDuration.ID = 0;
    //        spellDuration.Duration1 = 0;
    //        spellDuration.Duration2 = 0;
    //        spellDuration.Duration3 = 0;

    //        return spellDuration;
    //    }
    //}

}
