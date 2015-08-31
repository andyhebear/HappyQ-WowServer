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
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Common.SafeCollections;
#endregion

namespace Demo.Mmose.Core.Network
{
    /// <summary>
    /// 
    /// </summary>
    public class NetStateManager
    {
        #region zh-CHS ˽�г��� | en Private Constants
        /// <summary>
        /// 
        /// </summary>
        private readonly static int HANDLER_CAPACITY_SIZE = 1024;
        #endregion

        #region zh-CHS �������� | en Public Properties
        /// <summary>
        /// 
        /// </summary>
        public int Count
        {
            get { return m_NetStates.Count; }
        }
        #endregion

        #region zh-CHS NetState ���� | en BaseItem Method

        #region zh-CHS �ڲ����� | en Internal Methods
        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// ����ͻ��˵ļ���
        /// </summary>
        private SafeDictionary<NetState, NetState> m_NetStates = new SafeDictionary<NetState, NetState>( HANDLER_CAPACITY_SIZE );
        #endregion
        /// <summary>
        /// ��ӿͻ��˵�����
        /// </summary>
        internal void InternalAddNetState( NetState netState )
        {
            m_NetStates.Add( netState, netState );
        }

        /// <summary>
        /// �ڿͻ��˵ļ�����ɾ��ĳ�ͻ���
        /// </summary>
        /// <param name="iMapID"></param>
        internal void InternalRemoveNetState( NetState netState )
        {
            m_NetStates.Remove( netState );
        }
        #endregion

        #region zh-CHS ���з��� | en Public Methods
        /// <summary>
        /// ȫ������ͻ��˵�����
        /// </summary>
        /// <returns></returns>
        [MultiThreadedWarning( "zh-CHS", "(NetState)��ǰ���������б���ʱ������,���ܱ������������Ժ����(�������ֵ�ʵ���Ѿ�������Ч,���� Running == true ���ʵ���Ƿ���Ч):����!" )]
        public NetState[] ToArray()
        {
            return m_NetStates.ToArrayValues();
        }
        #endregion

        #endregion
    }
}
#endregion