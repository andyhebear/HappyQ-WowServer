using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Wow.WorldServer.DBC
{
    public class FactionTemplateEntry : ILoad<FactionTemplateEntry>
    {
        public uint m_FactionTemplateID;                    // 0
        public uint ID
        {
            get { return m_FactionTemplateID; }
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


        public bool Load( DBCRecord dbcRecord )
        {
            this.m_FactionTemplateID = dbcRecord.GetUInt( 0 );
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

            //LOGs.WriteLine( LogMessageType.MSG_INFO, "{0}", m_FactionTemplateID );

            return true;
        }
    }

    //internal struct FactionTemplateDBC
    //{
    //    public uint ID;
    //    public uint Faction;
    //    public uint FactionGroup;
    //    public uint Mask;
    //    public uint FriendlyMask;
    //    public uint HostileMask;
    //    public uint[] EnemyFactions;
    //    public uint[] FriendlyFactions;

    //    public FactionTemplateDBC Load()
    //    {
    //        FactionTemplateDBC factionTemplateDBC = new FactionTemplateDBC();

    //        factionTemplateDBC.ID = 0;
    //        factionTemplateDBC.Faction = 0;
    //        factionTemplateDBC.FactionGroup = 0;
    //        factionTemplateDBC.Mask = 0;
    //        factionTemplateDBC.FriendlyMask = 0;
    //        factionTemplateDBC.HostileMask = 0;
    //        factionTemplateDBC.EnemyFactions = new uint[4];
    //        factionTemplateDBC.FriendlyFactions = new uint[4];

    //        return factionTemplateDBC;
    //    }
    //}
}
