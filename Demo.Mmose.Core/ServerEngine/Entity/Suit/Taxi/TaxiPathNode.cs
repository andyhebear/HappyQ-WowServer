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
#endregion

namespace Demo.Mmose.Core.Entity.Suit.Taxi
{
    /// <summary>
    /// 
    /// </summary>
    public class TaxiPathNode
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 私有构造函数
        /// </summary>
        private TaxiPathNode()
        {
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties

        /// <summary>
        /// 
        /// </summary>
        public int TaxiPathCount
        {
            get { return m_TaxiPathNode.Count; }
        }

        #region zh-CHS 私有属性 | en Private Properties
        /// <summary>
        /// 
        /// </summary>
        private BaseTaxiNode m_FromTaxiNode = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public BaseTaxiNode FromTaxiNode
        {
            get { return m_FromTaxiNode; }
        }

        #endregion

        #region zh-CHS 共有方法 | en Public Methods

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private Dictionary<long, List<BaseTaxiPath[]>> m_TaxiPathNode = new Dictionary<long, List<BaseTaxiPath[]>>();
        #endregion
        /// <summary>
        /// 1) 1(start) --> 2 --> 3(end) 
        /// 2) 1(start) --> 2 --> 4 --> 3(end) 
        /// </summary>
        /// <returns></returns>
        public List<BaseTaxiPath[]> GetPathToTaxiNode( long ToTaxiNodeId )
        {
            List<BaseTaxiPath[]> taxiPathArray = null;
            m_TaxiPathNode.TryGetValue( ToTaxiNodeId, out taxiPathArray );

            return taxiPathArray;
        }

        #endregion

        #region zh-CHS 内部静态方法 | en Internal Static Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="taxiPathNode"></param>
        /// <returns></returns>
        internal static TaxiPathNode CreatInstance( BaseTaxiNode fromTaxiNodeId, Dictionary<long, List<BaseTaxiPath[]>> toTaxiPathNode )
        {
            TaxiPathNode returnTaxiPathNode = new TaxiPathNode();

            returnTaxiPathNode.m_FromTaxiNode = fromTaxiNodeId;
            returnTaxiPathNode.m_TaxiPathNode = toTaxiPathNode;

            return returnTaxiPathNode;
        }

        #endregion
    }
}
#endregion