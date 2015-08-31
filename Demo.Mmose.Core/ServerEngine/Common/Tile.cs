#region zh-CHS 2006 - 2008 DemoSoft 团队 | en 2006 - 2008 DemoSoft Team

//     NOTES
// ---------------
//
// This file is a part of the MMOSE(Massively Multiplayer Online Server Engine) for .NET.
//
//                              2006-2008 DemoSoft Team
//
//
// First Version : by H.Q.Cai - mailto:caihuanqing@hotmail.com

/***************************************************************************
 *
 *   This program is free software; you can redistribute it and/or modify
 *   it under the terms of the GNU Lesser General Public License as published
 *   by the Free Software Foundation; either version 2.1 of the License, or
 *   (at your option) any later version.
 *
 ***************************************************************************/

#region zh-CHS 包含名字空间 | en Include namespace
using System.Runtime.InteropServices;
#endregion

namespace Demo.Mmose.Core.Map
{
    [StructLayout( LayoutKind.Sequential, Pack = 1 )]
    internal struct Tile
    {
        internal short m_ID;
        internal sbyte m_Z;

        public int ID
        {
            get { return m_ID; }
        }

        public int Z
        {
            get { return m_Z; }
            set { m_Z = (sbyte)value; }
        }

        public int Height
        {
            get
            {
                //if ( m_ID < 0x4000 )
                //{
                return 0;
                //}
                //else
                //{
                //    return TileData.ItemTable[m_ID & 0x3FFF].Height;
                //}
            }
        }

        public bool Ignored
        {
            get { return ( m_ID == 2 || m_ID == 0x1DB || ( m_ID >= 0x1AE && m_ID <= 0x1B5 ) ); }
        }

        public Tile( short id, sbyte z )
        {
            m_ID = id;
            m_Z = z;
        }

        public void Set( short id, sbyte z )
        {
            m_ID = id;
            m_Z = z;
        }
    }
}
#endregion