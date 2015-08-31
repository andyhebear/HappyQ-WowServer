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
using System;
using System.Collections.Generic;
using Demo.Mmose.Core.Entity.Creature;
#endregion

namespace Demo.Mmose.Core.Common.EventSkin
{
    /// <summary>
    /// 
    /// </summary>
    public class AggressiveActionEventArgs : EventArgs
    {
        private BaseCreature m_Aggressed;
        private BaseCreature m_Aggressor;
        private bool m_Criminal;

        public BaseCreature Aggressed { get { return m_Aggressed; } }
        public BaseCreature Aggressor { get { return m_Aggressor; } }
        public bool Criminal { get { return m_Criminal; } }

        private static Queue<AggressiveActionEventArgs> m_Pool = new Queue<AggressiveActionEventArgs>();

        public static AggressiveActionEventArgs Create( BaseCreature aggressed, BaseCreature aggressor, bool criminal )
        {
            AggressiveActionEventArgs args;

            if ( m_Pool.Count > 0 )
            {
                args = m_Pool.Dequeue();

                args.m_Aggressed = aggressed;
                args.m_Aggressor = aggressor;
                args.m_Criminal = criminal;
            }
            else
            {
                args = new AggressiveActionEventArgs( aggressed, aggressor, criminal );
            }

            return args;
        }

        private AggressiveActionEventArgs( BaseCreature aggressed, BaseCreature aggressor, bool criminal )
        {
            m_Aggressed = aggressed;
            m_Aggressor = aggressor;
            m_Criminal = criminal;
        }

        public void Release()
        {
            m_Pool.Enqueue( this );
        }
    }
}
#endregion