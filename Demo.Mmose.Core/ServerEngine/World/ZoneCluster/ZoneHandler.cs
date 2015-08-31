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
using Demo.Mmose.Core.Common.SafeCollections;
#endregion

namespace Demo.Mmose.Core.World.ZoneClusterWorld
{
    /// <summary>
    /// 
    /// </summary>
    public class ZoneHandler
    {
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private SafeDictionary<int, WorldId> m_ZoneCluster = new SafeDictionary<int, WorldId>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="worldID"></param>
        internal void AddZoneToZoneCluster( WorldId worldID )
        {
            m_ZoneCluster.Add( worldID.GetHashCode(), worldID );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="worldID"></param>
        internal void RemoveZoneFromZoneCluster( WorldId worldID )
        {
            m_ZoneCluster.Remove( worldID.GetHashCode() );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public WorldId[] ToArray()
        {
            return m_ZoneCluster.ToArrayValues();
        }

        /// <summary>
        /// 
        /// </summary>
        public long Count
        {
            get { return m_ZoneCluster.Count; }
        }

        ///// <summary>
        ///// 
        ///// </summary>
        //private bool m_IsZoneWorld = false;
        ///// <summary>
        ///// 
        ///// </summary>
        //public bool IsZoneWorld
        //{
        //    get { return m_IsZoneWorld; }
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        //private bool m_IsZoneClusterWorld = false;
        ///// <summary>
        ///// 
        ///// </summary>
        //public bool IsZoneClusterWorld
        //{
        //    get { return m_IsZoneClusterWorld; }
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        //internal void CurrentZoneWorld()
        //{
        //    m_IsZoneWorld = true;
        //    m_IsZoneClusterWorld = false;
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        //internal void CurrentZoneClusterWorld()
        //{
        //    m_IsZoneWorld = false;
        //    m_IsZoneClusterWorld = true;
        //}
    }
}
#endregion