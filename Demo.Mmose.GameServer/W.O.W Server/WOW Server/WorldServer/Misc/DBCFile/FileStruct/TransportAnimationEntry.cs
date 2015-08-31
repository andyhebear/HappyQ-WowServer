using System;
using System.Collections.Generic;
using System.Text;
using Demo.Mmose.Core.Common;

namespace Demo.Wow.WorldServer.DBC
{
    public class TransportAnimationEntry : ILoad<TransportAnimationEntry>
    {
        public uint m_TransportAnimationID;                    // 0
        public uint ID
        {
            get { return m_TransportAnimationID; }
        }

        public uint m_Unknown1;                             // 1
        public uint m_Unknown2;                             // 2
        public uint m_Unknown3;                             // 3
        public uint m_Unknown4;                             // 4
        public uint m_Unknown5;                             // 5
        public uint m_Unknown6;                             // 6


        public bool Load( DBCRecord dbcRecord )
        {
            this.m_TransportAnimationID = dbcRecord.GetUInt( 0 );
            this.m_Unknown1 = dbcRecord.GetUInt( 1 );
            this.m_Unknown2 = dbcRecord.GetUInt( 2 );
            this.m_Unknown3 = dbcRecord.GetUInt( 3 );
            this.m_Unknown4 = dbcRecord.GetUInt( 4 );
            this.m_Unknown5 = dbcRecord.GetUInt( 5 );
            this.m_Unknown6 = dbcRecord.GetUInt( 6 );

            //LOGs.WriteLine( LogMessageType.MSG_INFO, "{0}", m_TransportAnimationID );

            return true;
        }
    }
}
