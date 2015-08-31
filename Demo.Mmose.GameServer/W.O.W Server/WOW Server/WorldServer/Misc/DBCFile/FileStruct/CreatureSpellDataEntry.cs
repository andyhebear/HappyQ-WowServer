using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Wow.WorldServer.DBC
{
    public class CreatureSpellDataEntry : ILoad<CreatureSpellDataEntry>
    {
        public uint m_CreatureSpellDataID;                    // 0
        public uint ID
        {
            get { return m_CreatureSpellDataID; }
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
            this.m_CreatureSpellDataID = dbcRecord.GetUInt( 0 );
            this.m_Unknown1 = dbcRecord.GetUInt( 1 );
            this.m_Unknown2 = dbcRecord.GetUInt( 2 );
            this.m_Unknown3 = dbcRecord.GetUInt( 3 );
            this.m_Unknown4 = dbcRecord.GetUInt( 4 );
            this.m_Unknown5 = dbcRecord.GetUInt( 5 );
            this.m_Unknown6 = dbcRecord.GetUInt( 6 );
            this.m_Unknown7 = dbcRecord.GetUInt( 7 );
            this.m_Unknown8 = dbcRecord.GetUInt( 8 );

            //LOGs.WriteLine( LogMessageType.MSG_INFO, "{0}", m_CreatureSpellDataID );

            return true;
        }
    }

    //internal struct CreatureSpellDataEntry
    //{
    //    public uint id;
    //    public uint[] Spells;
    //    public uint PHSpell;
    //    public uint[] Cooldowns;
    //    public uint PH;

    //    public CreatureSpellDataEntry Load()
    //    {
    //        CreatureSpellDataEntry creatureSpellDataEntry = new CreatureSpellDataEntry();

    //        creatureSpellDataEntry.id = 0;
    //        creatureSpellDataEntry.Spells = new uint[3];
    //        creatureSpellDataEntry.PHSpell = 0;
    //        creatureSpellDataEntry.Cooldowns = new uint[3];
    //        creatureSpellDataEntry.PH = 0;

    //        return creatureSpellDataEntry;
    //    }
    //}

}
