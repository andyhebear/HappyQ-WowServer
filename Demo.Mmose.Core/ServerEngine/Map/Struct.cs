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

#endregion

namespace Demo.Mmose.Core.Map
{
    /// <summary>
    /// 
    /// </summary>
    public struct RankIndex
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rank0Index"></param>
        /// <param name="rank1Index"></param>
        /// <param name="rank2Index"></param>
        public RankIndex( int rank0Index, int rank1Index, int rank2Index )
        {
            m_Rank0Index = rank0Index;
            m_Rank1Index = rank1Index;
            m_Rank2Index = rank2Index;
        }
        #endregion

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_Rank0Index;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public int Rank0Index
        {
            get { return m_Rank0Index; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_Rank1Index;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public int Rank1Index
        {
            get { return m_Rank1Index; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_Rank2Index;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public int Rank2Index
        {
            get { return m_Rank2Index; }
        }
    }
}
#endregion