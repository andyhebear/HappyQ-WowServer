using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Wow.WorldServer.DBC
{
    public class NameGenEntry : ILoad<NameGenEntry>
    {
        public uint m_NameGenID;                   // 0
        public uint ID
        {
            get { return m_NameGenID; }
        }

        public string m_Name;                           // 1
        public uint m_Unknown1;                         // 2
        public bool m_Unknown2;                         // 3

        public bool Load( DBCRecord dbcRecord )
        {
            this.m_NameGenID = dbcRecord.GetUInt( 0 );
            this.m_Name = dbcRecord.GetString( 1 );
            this.m_Unknown1 = dbcRecord.GetUInt( 2 );
            this.m_Unknown2 = dbcRecord.GetBool( 3 );

            //LOGs.WriteLine( LogMessageType.MSG_INFO, "{0}, {1}, {2}, {3}", m_NameGenID, m_Name, m_Unknown1, m_Unknown2 );

            return true;
        }
    }
}
