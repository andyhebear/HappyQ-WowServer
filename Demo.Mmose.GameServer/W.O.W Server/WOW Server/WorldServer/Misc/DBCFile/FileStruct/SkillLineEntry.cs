using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Wow.WorldServer.DBC
{
    public class SkillLineEntry : ILoad<SkillLineEntry>
    {
        public uint m_SkillLineID;                    // 0
        public uint ID
        {
            get { return m_SkillLineID; }
        }

        public uint m_Category;                             // 1
        public string m_UnknownString;                      // 2
        public uint m_Unknown3;                             // 3
        public uint m_Unknown4;                             // 4
        public uint m_Unknown5;                             // 5
        public uint m_Unknown6;                             // 6
        public string m_SkillName;                          // 7
        public uint m_Unknown8;                             // 8
        public uint m_Unknown9;                             // 9
        public uint m_Unknown10;                            // 10
        public uint m_Unknown11;                            // 11
        public uint m_Unknown12;                            // 12
        public uint m_Unknown13;                            // 13
        public uint m_Unknown14;                            // 14
        public uint m_Unknown15;                            // 15
        public uint m_Unknown16;                            // 16
        public uint m_Unknown17;                            // 17
        public uint m_Unknown18;                            // 18
        public uint m_Unknown19;                            // 19
        public uint m_Unknown20;                            // 20
        public uint m_Unknown21;                            // 21
        public uint m_Unknown22;                            // 22
        public uint m_Unknown23;                            // 23
        public string m_Description;                        // 24
        public uint m_Unknown25;                            // 25
        public uint m_Unknown26;                            // 26
        public uint m_Unknown27;                            // 27
        public uint m_Unknown28;                            // 28
        public uint m_Unknown29;                            // 29
        public uint m_Unknown30;                            // 30
        public uint m_Unknown31;                            // 31
        public uint m_Unknown32;                            // 32
        public uint m_Unknown33;                            // 33
        public uint m_Unknown34;                            // 34
        public uint m_Unknown35;                            // 35
        public uint m_Unknown36;                            // 36
        public uint m_Unknown37;                            // 37


        public bool Load( DBCRecord dbcRecord )
        {
            this.m_SkillLineID = dbcRecord.GetUInt( 0 );
            this.m_Category = dbcRecord.GetUInt( 1 );
            this.m_UnknownString = dbcRecord.GetString( 2 );
            this.m_Unknown3 = dbcRecord.GetUInt( 3 );
            this.m_Unknown4 = dbcRecord.GetUInt( 4 );
            this.m_Unknown5 = dbcRecord.GetUInt( 5 );
            this.m_Unknown6 = dbcRecord.GetUInt( 6 );
            this.m_SkillName = dbcRecord.GetString( 7 );
            this.m_Unknown8 = dbcRecord.GetUInt( 8 );
            this.m_Unknown9 = dbcRecord.GetUInt( 9 );
            this.m_Unknown10 = dbcRecord.GetUInt( 10 );
            this.m_Unknown11 = dbcRecord.GetUInt( 11 );
            this.m_Unknown12 = dbcRecord.GetUInt( 12 );
            this.m_Unknown13 = dbcRecord.GetUInt( 13 );
            this.m_Unknown14 = dbcRecord.GetUInt( 14 );
            this.m_Unknown15 = dbcRecord.GetUInt( 15 );
            this.m_Unknown16 = dbcRecord.GetUInt( 16 );
            this.m_Unknown17 = dbcRecord.GetUInt( 17 );
            this.m_Unknown18 = dbcRecord.GetUInt( 18 );
            this.m_Unknown19 = dbcRecord.GetUInt( 19 );
            this.m_Unknown20 = dbcRecord.GetUInt( 20 );
            this.m_Unknown21 = dbcRecord.GetUInt( 21 );
            this.m_Unknown22 = dbcRecord.GetUInt( 22 );
            this.m_Unknown23 = dbcRecord.GetUInt( 23 );
            this.m_Description = dbcRecord.GetString( 24 );
            this.m_Unknown25 = dbcRecord.GetUInt( 25 );
            this.m_Unknown26 = dbcRecord.GetUInt( 26 );
            this.m_Unknown27 = dbcRecord.GetUInt( 27 );
            this.m_Unknown28 = dbcRecord.GetUInt( 28 );
            this.m_Unknown29 = dbcRecord.GetUInt( 29 );
            this.m_Unknown30 = dbcRecord.GetUInt( 30 );
            this.m_Unknown31 = dbcRecord.GetUInt( 31 );
            this.m_Unknown32 = dbcRecord.GetUInt( 32 );
            this.m_Unknown33 = dbcRecord.GetUInt( 33 );
            this.m_Unknown34 = dbcRecord.GetUInt( 34 );
            this.m_Unknown35 = dbcRecord.GetUInt( 35 );
            this.m_Unknown36 = dbcRecord.GetUInt( 36 );
            this.m_Unknown37 = dbcRecord.GetUInt( 37 );

            //LOGs.WriteLine( LogMessageType.MSG_INFO, "{0}", m_SkillLineID );

            return true;
        }
    }

    //internal struct skilllineentry
    //{
    //    public uint id;
    //    public uint type;
    //    public uint unk1;
    //    public uint Name;
    //    public uint NameAlt1;
    //    public uint NameAlt2;
    //    public uint NameAlt3;
    //    public uint NameAlt4;
    //    public uint NameAlt5;
    //    public uint NameAlt6;
    //    public uint NameAlt7;
    //    public uint NameAlt8;
    //    public uint NameAlt9;
    //    public uint NameAlt10;
    //    public uint NameAlt11;
    //    public uint NameAlt12;
    //    public uint NameAlt13;
    //    public uint NameAlt14;
    //    public uint NameAlt15;
    //    public uint NameFlags;
    //    public uint Description;
    //    public uint DescriptionAlt1;
    //    public uint DescriptionAlt2;
    //    public uint DescriptionAlt3;
    //    public uint DescriptionAlt4;
    //    public uint DescriptionAlt5;
    //    public uint DescriptionAlt6;
    //    public uint DescriptionAlt7;
    //    public uint DescriptionAlt8;
    //    public uint DescriptionAlt9;
    //    public uint DescriptionAlt10;
    //    public uint DescriptionAlt11;
    //    public uint DescriptionAlt12;
    //    public uint DescriptionAlt13;
    //    public uint DescriptionAlt14;
    //    public uint DescriptionAlt15;
    //    public uint DescriptionFlags;
    //    public uint unk2;

    //    public skilllineentry Load()
    //    {
    //        skilllineentry skilllineentry = new skilllineentry();

    //        skilllineentry.id = 0;
    //        skilllineentry.type = 0;
    //        skilllineentry.unk1 = 0;
    //        skilllineentry.Name = 0;
    //        skilllineentry.NameAlt1 = 0;
    //        skilllineentry.NameAlt2 = 0;
    //        skilllineentry.NameAlt3 = 0;
    //        skilllineentry.NameAlt4 = 0;
    //        skilllineentry.NameAlt5 = 0;
    //        skilllineentry.NameAlt6 = 0;
    //        skilllineentry.NameAlt7 = 0;
    //        skilllineentry.NameAlt8 = 0;
    //        skilllineentry.NameAlt9 = 0;
    //        skilllineentry.NameAlt10 = 0;
    //        skilllineentry.NameAlt11 = 0;
    //        skilllineentry.NameAlt12 = 0;
    //        skilllineentry.NameAlt13 = 0;
    //        skilllineentry.NameAlt14 = 0;
    //        skilllineentry.NameAlt15 = 0;
    //        skilllineentry.NameFlags = 0;
    //        skilllineentry.Description = 0;
    //        skilllineentry.DescriptionAlt1 = 0;
    //        skilllineentry.DescriptionAlt2 = 0;
    //        skilllineentry.DescriptionAlt3 = 0;
    //        skilllineentry.DescriptionAlt4 = 0;
    //        skilllineentry.DescriptionAlt5 = 0;
    //        skilllineentry.DescriptionAlt6 = 0;
    //        skilllineentry.DescriptionAlt7 = 0;
    //        skilllineentry.DescriptionAlt8 = 0;
    //        skilllineentry.DescriptionAlt9 = 0;
    //        skilllineentry.DescriptionAlt10 = 0;
    //        skilllineentry.DescriptionAlt11 = 0;
    //        skilllineentry.DescriptionAlt12 = 0;
    //        skilllineentry.DescriptionAlt13 = 0;
    //        skilllineentry.DescriptionAlt14 = 0;
    //        skilllineentry.DescriptionAlt15 = 0;
    //        skilllineentry.DescriptionFlags = 0;
    //        skilllineentry.unk2 = 0;

    //        return skilllineentry;
    //    }
    //}

}
