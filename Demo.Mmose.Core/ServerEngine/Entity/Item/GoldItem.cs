#region zh-CHS 2006 - 2008 DemoSoft �Ŷ� | en 2006 - 2008 DemoSoft Team

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

#region zh-CHS �������ֿռ� | en Include namespace
using Demo.Mmose.Core.Util;
#endregion

namespace Demo.Mmose.Core.Entity.Item
{
    /// <summary>
    /// 
    /// </summary>
    public class GoldItem : BaseItem
    {
        #region zh-CHS ����ͳ�ʼ�������� | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        /// <param name="loot"></param>
        /// <param name="probability"></param>
        public GoldItem()
        {
        }

        public GoldItem( ulong minGold, ulong maxGold )
        {
            m_MinGold = minGold;
            m_MaxGold = maxGold;
        }
        #endregion

        #region zh-CHS �������� | en Public Properties
        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private ulong m_MinGold = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public ulong MinGold
        {
            get { return m_MinGold; }
            set { m_MinGold = value; }
        }

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private ulong m_MaxGold = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public ulong MaxGold
        {
            get { return m_MaxGold; }
            set { m_MaxGold = value; }
        }

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_bIsDrop = false;
        /// <summary>
        /// 
        /// </summary>
        private ulong m_iGold = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public ulong Gold
        {
            get
            {
                if ( m_bIsDrop == false )
                {
                    m_iGold = RandomGoldGenerator();
                    m_bIsDrop = true;
                }

                return m_iGold;
            }
        }
        #endregion

        #region zh-CHS ���о�̬���� | en Public Static Properties
        #region zh-CHS ˽�о�̬��Ա���� | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static ulong s_GoldMultiplier = 1;
        #endregion
        /// <summary>
        /// ��ҵ������������
        /// </summary>
        public static ulong GoldMultiplier
        {
            get { return s_GoldMultiplier; }
            set { s_GoldMultiplier = value; }
        }
        #endregion

        #region zh-CHS ���з��� | en Public Methods
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ulong RandomGoldGenerator()
        {
            if ( m_MinGold < 0 )
                m_MinGold = 0;

            if ( m_MaxGold < 0 )
                m_MaxGold = 0;

            return (ulong)RandomEx.RandomMinMax( (int)m_MinGold, (int)m_MaxGold ) * s_GoldMultiplier;
        }

        #endregion
   }
}
#endregion