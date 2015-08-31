using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Wow.WorldServer.DBC
{
    public class CreatureFamilyEntry : ILoad<CreatureFamilyEntry>
    {
        public uint m_CreatureFamilyID;              // 0
        public uint ID
        {
            get { return m_CreatureFamilyID; }
        }

        public float m_MinSize;                      // 1
        public uint m_MinLevel;                      // 2
        public float m_MaxSize;                      // 3
        public uint m_MaxLevel;                      // 4
        public uint m_Skilline;                      // 5
        public uint m_Tameable;                      // 6
        public uint m_PetFoodID;                     // 7
        public uint m_Name;                          // 8
        public uint m_Namealt1;                      // 9
        public uint m_Namealt2;                      // 10
        public uint m_Namealt3;                      // 11
        public string m_Namealt4;                    // 12
        public uint m_Namealt5;                      // 13
        public uint m_Namealt6;                      // 14
        public uint m_Namealt7;                      // 15
        public uint m_Namealt8;                      // 16
        public uint m_Namealt9;                      // 17
        public uint m_Namealt10;                     // 18
        public uint m_Namealt11;                     // 19
        public uint m_Namealt12;                     // 20
        public uint m_Namealt13;                     // 21
        public uint m_Namealt14;                     // 22
        public uint m_Namealt15;                     // 23
        public uint m_Nameflags;                     // 24
        public uint m_Unknown1;                      // 25

        public bool Load( DBCRecord dbcRecord )
        {
            this.m_CreatureFamilyID = dbcRecord.GetUInt( 0 );
            this.m_MinSize = dbcRecord.GetFloat( 1 );
            this.m_MinLevel = dbcRecord.GetUInt( 2 );
            this.m_MaxSize = dbcRecord.GetFloat( 3 );
            this.m_MaxLevel = dbcRecord.GetUInt( 4 );
            this.m_Skilline = dbcRecord.GetUInt( 5 );
            this.m_Tameable = dbcRecord.GetUInt( 6 );
            this.m_PetFoodID = dbcRecord.GetUInt( 7 );
            this.m_Name = dbcRecord.GetUInt( 8 );
            this.m_Namealt1 = dbcRecord.GetUInt( 9 );
            this.m_Namealt2 = dbcRecord.GetUInt( 10 );
            this.m_Namealt3 = dbcRecord.GetUInt( 11 );
            this.m_Namealt4 = dbcRecord.GetString( 12 );
            this.m_Namealt5 = dbcRecord.GetUInt( 13 );
            this.m_Namealt6 = dbcRecord.GetUInt( 14 );
            this.m_Namealt7 = dbcRecord.GetUInt( 15 );
            this.m_Namealt8 = dbcRecord.GetUInt( 16 );
            this.m_Namealt9 = dbcRecord.GetUInt( 17 );
            this.m_Namealt10 = dbcRecord.GetUInt( 18 );
            this.m_Namealt11 = dbcRecord.GetUInt( 19 );
            this.m_Namealt12 = dbcRecord.GetUInt( 20 );
            this.m_Namealt13 = dbcRecord.GetUInt( 21 );
            this.m_Namealt14 = dbcRecord.GetUInt( 22 );
            this.m_Namealt15 = dbcRecord.GetUInt( 23 );
            this.m_Nameflags = dbcRecord.GetUInt( 24 );
            this.m_Unknown1 = dbcRecord.GetUInt( 25 );

            //LOGs.WriteLine( LogMessageType.MSG_INFO, "{0}, {1}", m_CreatureFamilyID, m_Namealt4 );

            return true;
        }
    }
}
