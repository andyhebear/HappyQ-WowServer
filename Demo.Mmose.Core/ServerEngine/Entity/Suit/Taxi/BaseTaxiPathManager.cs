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
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Demo.Mmose.Core.Common.SafeCollections;
using Demo.Mmose.Core.Util;
#endregion

namespace Demo.Mmose.Core.Entity.Suit.Taxi
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseTaxiPathNodeManager
    {
        #region zh-CHS TaxiNode方法 | en Public Methods

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private SafeDictionary<long, BaseTaxiNode> m_TaxiNodes = new SafeDictionary<long, BaseTaxiNode>();
        #endregion
        /// <summary>
        /// last call GenerateTaxiPathNode(...)
        /// </summary>
        /// <param name="taxiNodeId"></param>
        /// <param name="mapId"></param>
        /// <param name="xCoord"></param>
        /// <param name="yCoord"></param>
        /// <param name="zCoord"></param>
        public void RegisterTaxiNode( BaseTaxiNode baseTaxiNode )
        {
            if ( baseTaxiNode == null )
            {
                Debug.WriteLine( "BaseTaxiPathNodeManager.RegisterTaxiNode(...) - baseTaxiNode == null error!" );
                return;
            }

            m_TaxiNodes.Add( baseTaxiNode.TaxiNodeId, baseTaxiNode );

            m_TaxiPathNodes = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public BaseTaxiNode GetTaxiNode( long taxiNodeId )
        {
            return m_TaxiNodes.GetValue( taxiNodeId );
        }

        /// <summary>
        /// 
        /// </summary>
        public BaseTaxiNode[] TaxiNodeToArray()
        {
            return m_TaxiNodes.ToArrayValues();
        }

        #endregion

        #region zh-CHS TaxiPath方法 | en Public Methods

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private SafeDictionary<long, BaseTaxiPath> m_TaxiPaths = new SafeDictionary<long, BaseTaxiPath>();
        #endregion
        /// <summary>
        /// last call GenerateTaxiPathNode(...)
        /// </summary>
        /// <param name="taxiPathId"></param>
        /// <param name="fromTaxiNodeId"></param>
        /// <param name="toTaxiNodeId"></param>
        public void RegisterTaxiPath( BaseTaxiPath baseTaxiPath )
        {
            if ( baseTaxiPath == null )
            {
                Debug.WriteLine( "BaseTaxiPathNodeManager.RegisterTaxiPath(...) - baseTaxiPath == null error!" );
                return;
            }

            m_TaxiPaths.Add( baseTaxiPath.TaxiPathId, baseTaxiPath );

            m_TaxiPathNodes = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public BaseTaxiPath GetTaxiPath( long taxiPathId )
        {
            return m_TaxiPaths.GetValue( taxiPathId );
        }

        /// <summary>
        /// 
        /// </summary>
        public BaseTaxiPath[] TaxiPathToArray()
        {
            return m_TaxiPaths.ToArrayValues();
        }

        #endregion

        #region zh-CHS TaxiPathNode方法 | en Public Methods

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private Dictionary<long, TaxiPathNode> m_TaxiPathNodes = null;
        /// <summary>
        /// 
        /// </summary>
        private ReaderWriterLockSlim m_LockTaxiPathNodes = new ReaderWriterLockSlim();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool GenerateTaxiPathNode()
        {
            if ( m_TaxiPathNodes != null )
                return true;

            if ( m_TaxiNodes.Count <= 0 )
                return false;

            if ( m_TaxiPaths.Count <= 0 )
                return false;

            bool bIsOK = true;
            m_LockTaxiPathNodes.EnterWriteLock();
            {
                do
                {
                    // 在多线程内防止多次调用GenerateTaxiPathNode(...)，再次检测可能已经完成了GenerateTaxiPathNode(...)的调用
                    if ( m_TaxiPathNodes != null )
                        break;

                    BaseTaxiNode[] taxiNodeArray = TaxiNodeToArray();
                    if ( taxiNodeArray == null )
                    {
                        bIsOK = false;
                        break;
                    }

                    BaseTaxiPath[] baseTaxiPathArray = TaxiPathToArray();
                    if ( baseTaxiPathArray == null )
                    {
                        bIsOK = false;
                        break;
                    }

                    Dictionary<long, TaxiPathNode> tempTaxiPathNodes = new Dictionary<long, TaxiPathNode>();

                    for ( int iIndex = 0; iIndex < taxiNodeArray.Length; iIndex++ )
                    {
                        BaseTaxiNode taxiNode = taxiNodeArray[iIndex];

                        List<BaseTaxiPath> nullTaxiPathList = new List<BaseTaxiPath>();
                        Dictionary<long, List<BaseTaxiPath[]>> toTaxiNodeDictionary = new Dictionary<long, List<BaseTaxiPath[]>>();

                        GetTaxiPathNodeInfo( taxiNode.TaxiNodeId, baseTaxiPathArray, ref nullTaxiPathList, ref toTaxiNodeDictionary );

                        tempTaxiPathNodes.Add( taxiNode.TaxiNodeId, TaxiPathNode.CreatInstance( taxiNode, toTaxiNodeDictionary ) );
                    }

                    m_TaxiPathNodes = tempTaxiPathNodes;
                } while ( false );
            }
            m_LockTaxiPathNodes.ExitWriteLock();

            return bIsOK;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="taxiNodeId"></param>
        /// <returns></returns>
        public TaxiPathNode GetTaxiPathNode( long fromTaxiNodeId )
        {
            if ( m_TaxiPathNodes == null )
            {
                if ( GenerateTaxiPathNode() == false )
                {
                    Debug.WriteLine( "BaseTaxiPathNodeManager.GetTaxiPathNode(...) - GenerateTaxiPathNode(...) == false error!" );

                    return null;
                }
            }

            TaxiPathNode returnTaxiPathNode = null;
            if ( m_TaxiPathNodes.TryGetValue( fromTaxiNodeId, out returnTaxiPathNode ) == false )
                return null;

            return returnTaxiPathNode;
        }

        #region zh-CHS 私有方法 | en Private Methods
        /// <summary>
        /// 产生路径点
        /// </summary>
        /// <param name="iTaxiNodeId"></param>
        /// <param name="baseTaxiPathArray"></param>
        /// <param name="baseTaxiPathList"></param>
        /// <param name="taxiPathNode"></param>
        private void GetTaxiPathNodeInfo( long iTaxiNodeId, BaseTaxiPath[] baseTaxiPathArray, ref List<BaseTaxiPath> baseTaxiPathList, ref Dictionary<long, List<BaseTaxiPath[]>> taxiPathNode )
        {
            for ( int iIndex = 0; iIndex < baseTaxiPathArray.Length; iIndex++ )
            {
                if ( iTaxiNodeId == baseTaxiPathArray[iIndex].FromTaxiNodeId )
                {
                    // 检测是否已经有相同的路径点存在
                    bool bIsInvalidTaxiPath = false;
                    foreach ( BaseTaxiPath baseTaxiPath in baseTaxiPathList )
                    {
                        if ( baseTaxiPathArray[iIndex].ToTaxiNodeId == baseTaxiPath.FromTaxiNodeId )
                        {
                            bIsInvalidTaxiPath = true;
                            break;
                        }
                    }

                    if ( bIsInvalidTaxiPath == true )
                        continue;

                    // 完成路径计算，添加路径
                    List<BaseTaxiPath[]> baseTaxiPathArrayList = null;
                    if ( taxiPathNode.TryGetValue( baseTaxiPathArray[iIndex].ToTaxiNodeId, out baseTaxiPathArrayList ) == false )
                        baseTaxiPathArrayList = new List<BaseTaxiPath[]>();

                    if ( baseTaxiPathArrayList == null )
                        baseTaxiPathArrayList = new List<BaseTaxiPath[]>();

                    List<BaseTaxiPath> taxiPathListDuplicate = new List<BaseTaxiPath>();
                    taxiPathListDuplicate.AddRange( baseTaxiPathList );
                    taxiPathListDuplicate.Add( baseTaxiPathArray[iIndex] );

                    baseTaxiPathArrayList.Add( taxiPathListDuplicate.ToArray() );

                    taxiPathNode[baseTaxiPathArray[iIndex].ToTaxiNodeId] = baseTaxiPathArrayList;

                    // 继续下一个路径计算
                    taxiPathListDuplicate.Clear();
                    taxiPathListDuplicate.AddRange( baseTaxiPathList );

                    GetTaxiPathNodeInfo( baseTaxiPathArray[iIndex].ToTaxiNodeId, baseTaxiPathArray, ref taxiPathListDuplicate, ref taxiPathNode );
                }
            }
        }
        #endregion

        #endregion
    }
}
#endregion