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
using System.Diagnostics;
#endregion

namespace Demo.Mmose.Core.Entity.Suit.Taxi
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseTaxiPath
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        /// <param name="taxiPathId"></param>
        /// <param name="taxiNodeFromId"></param>
        /// <param name="taxiNodeToId"></param>
        public BaseTaxiPath( long taxiPathId, long fromTaxiNodeId, long toTaxiNodeId )
        {
            if ( fromTaxiNodeId == toTaxiNodeId )
            {
                Debug.WriteLine( "BaseTaxiPath.BaseTaxiPath(...) - fromTaxiNodeId == toTaxiNodeId error!" );
                return;
            }

            m_TaxiPathId = taxiPathId;
            m_FromTaxiNodeId = fromTaxiNodeId;
            m_ToTaxiNodeId = toTaxiNodeId;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_TaxiPathId;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public long TaxiPathId
        {
            get { return m_TaxiPathId; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_FromTaxiNodeId;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public long FromTaxiNodeId
        {
            get { return m_FromTaxiNodeId; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_ToTaxiNodeId;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public long ToTaxiNodeId
        {
            get { return m_ToTaxiNodeId; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_Cost;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public long Cost
        {
            get { return m_Cost; }
            set { m_Cost = value; }
        }

        #endregion
    }
}
#endregion