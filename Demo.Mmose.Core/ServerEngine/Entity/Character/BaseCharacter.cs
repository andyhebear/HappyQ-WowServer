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
using Demo.Mmose.Core.Entity.Creature;
using Demo.Mmose.Core.Network;
#endregion

namespace Demo.Mmose.Core.Entity.Character
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseCharacter : BaseCreature
    {
        #region zh-CHS �������� | en Public Properties

        #region zh-CHS AccessLevel���� | en Public Properties

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// ������ʺŵȼ�
        /// </summary>
        private AccessLevel m_AccessLevel = AccessLevel.Player;
        #endregion
        /// <summary>
        /// ������ʺŵȼ�
        /// </summary>
        public AccessLevel AccessLevel
        {
            get { return m_AccessLevel; }
            set
            {
                AccessLevel oldAccessLevel = m_AccessLevel;

                if ( m_BaseCharacterState != null )
                {
                    if ( m_BaseCharacterState.OnUpdatingAccessLevel( value, this ) == true )
                        return;
                }

                m_AccessLevel = value;
                m_BaseCharacterState.IsUpdateAccessLevel = true;

                if ( m_BaseCharacterState != null )
                    m_BaseCharacterState.OnUpdatedAccessLevel( oldAccessLevel, this );
            }
        }

        #endregion

        #region zh-CHS NetState���� | en Public Properties

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// ���������״̬
        /// </summary>
        private NetState m_NetState = null;
        #endregion
        /// <summary>
        /// ���������״̬
        /// </summary>
        public NetState NetState
        {
            get { return m_NetState; }
            set
            {
                NetState oldNetState = m_NetState;

                if ( m_BaseCharacterState != null )
                {
                    if ( m_BaseCharacterState.OnUpdatingNetState( value, this ) == true )
                        return;
                }

                m_NetState = value;
                m_BaseCharacterState.IsUpdateNetState = true;

                if ( m_BaseCharacterState != null )
                    m_BaseCharacterState.OnUpdatedNetState( oldNetState, this );
            }
        }

        #endregion

        #region zh-CHS CharacterState���� | en Public Properties

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// �����״̬��
        /// </summary>
        private BaseCharacterState m_BaseCharacterState = null;
        #endregion
        /// <summary>
        /// BaseCreatureState�����״̬��
        /// </summary>
        public BaseCharacterState BaseCharacterState
        {
            get { return m_BaseCharacterState; }
            protected set { m_BaseCharacterState = value; }
        }

        #endregion

        #endregion
    }
}
#endregion