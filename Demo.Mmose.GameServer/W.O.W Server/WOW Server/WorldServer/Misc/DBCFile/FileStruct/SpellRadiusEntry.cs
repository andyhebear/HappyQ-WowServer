using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Wow.WorldServer.DBC
{
    public class SpellRadiusEntry : ILoad<SpellRadiusEntry>
    {
        public uint m_SpellRadiusID;                    // 0
        public uint ID
        {
            get { return m_SpellRadiusID; }
        }

        public uint m_Unknown1;                             // 1
        public uint m_Unknown2;                             // 2
        public uint m_Unknown3;                             // 3


        public bool Load( DBCRecord dbcRecord )
        {
            this.m_SpellRadiusID = dbcRecord.GetUInt( 0 );
            this.m_Unknown1 = dbcRecord.GetUInt( 1 );
            this.m_Unknown2 = dbcRecord.GetUInt( 2 );
            this.m_Unknown3 = dbcRecord.GetUInt( 3 );

            //LOGs.WriteLine( LogMessageType.MSG_INFO, "{0}", m_SpellRadiusID );

            return true;
        }
    }

    //internal struct SpellRadius
    //{
    //    public uint ID;
    //    public float Radius;
    //    public float unk1;
    //    public float Radius2;

    //    public SpellRadius Load()
    //    {
    //        SpellRadius spellRadius = new SpellRadius();

    //        spellRadius.ID = 0;
    //        spellRadius.Radius = 0;
    //        spellRadius.unk1 = 0;
    //        spellRadius.Radius2 = 0;

    //        return spellRadius;
    //    }
    //}

}
