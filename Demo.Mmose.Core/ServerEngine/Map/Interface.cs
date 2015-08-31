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
using Demo.Mmose.Core.Common;
#endregion

namespace Demo.Mmose.Core.Map
{
    #region zh-CHS 接口 | en Interface
    /// <summary>
    /// 
    /// </summary>
    public interface IPartitionSpaceNode
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        void InitSpaceNode( object sender, SpaceNodeEventArgs eventArgs );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        void ProcessPartitionSpaceNode( object sender, PartitionSpaceNodeEventArgs eventArgs );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        [MultiThreadedWarning( "zh-CHS", "同MapSpaceNode的OnActivate:警告!" )]
        void ActivateSpaceNode( object sender, ActivateSpaceNodeEventArgs eventArgs );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        [MultiThreadedWarning( "zh-CHS", "同MapSpaceNode的OnDeactivate:警告!" )]
        void DeactivateSpaceNode( object sender, DeactivateSpaceNodeEventArgs eventArgs );
    }

    /// <summary>
    /// 
    /// </summary>
    public interface IPartitionSpace : IPartitionSpaceNode
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        void InitMap( object sender, MapEventArgs eventArgs );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        void ProcessPartitionSpace( object sender, PartitionSpaceEventArgs eventArgs );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        void GetSpaceNod( object sender, GetSpaceNodeEventArgs eventArgs );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        void GetSpaceNodesInRange( object sender, GetGetSpaceNodesInRangeEventArgs eventArgs );
    }
    #endregion
}
#endregion

