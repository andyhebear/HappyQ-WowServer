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
using Demo.Mmose.Core.Entity;
#endregion

namespace Demo.Mmose.Core.Common.EventSkin
{
    /// <summary>
    /// 
    /// </summary>
    public class MoveToEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mobile"></param>
        /// <param name="newLocation"></param>
        public MoveToEventArgs( Point3D newLocation, WorldEntity entity )
        {
            m_Entity = entity;
            m_NewLocation = newLocation;
        }

        /// <summary>
        /// 
        /// </summary>
        private WorldEntity m_Entity = null;
        /// <summary>
        /// 
        /// </summary>
        public WorldEntity GameEntity
        {
            get { return m_Entity; }
        }

        /// <summary>
        /// 
        /// </summary>
        private Point3D m_NewLocation = Point3D.Zero;
        /// <summary>
        /// 
        /// </summary>
        public Point3D NewLocation
        {
            get { return m_NewLocation; }
        }

        /// <summary>
        /// 
        /// </summary>
        private bool m_Blocked = false;
        /// <summary>
        /// 
        /// </summary>
        public bool Blocked
        {
            get { return m_Blocked; }
            set { m_Blocked = value; }
        }
    }
}
#endregion