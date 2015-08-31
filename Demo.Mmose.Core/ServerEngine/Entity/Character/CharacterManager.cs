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

namespace Demo.Mmose.Core.Entity.Character
{
    /// <summary>
    /// ��ҵ���Ϣ����
    /// </summary>
    public class CharacterManager<T> where T : BaseCharacter
    {
        #region zh-CHS ����ͳ�ʼ�������� | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        public CharacterManager()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iCapacity"></param>
        public CharacterManager( int iCapacity )
        {
            m_Characters = new SafeDictionary<long, T>( iCapacity );
        }
        #endregion

        #region zh-CHS �������� | en Public Properties
        /// <summary>
        /// ���������Ϣ������
        /// </summary>
        public int Count
        {
            get { return m_Characters.Count; }
        }
        #endregion

        #region zh-CHS CharacterHandler ���� | en CharacterHandler Method

        #region zh-CHS ���з��� | en Public Methods
        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// �����Ϣ�ļ���
        /// </summary>
        private SafeDictionary<long, T> m_Characters = new SafeDictionary<long, T>();
        #endregion
        /// <summary>
        /// ��������Ϣ������
        /// </summary>
        public void AddCharacter( long iCharacterId, T characterT )
        {
            m_Characters.Add( iCharacterId, characterT );
        }

        /// <summary>
        /// �������Ϣ�ļ�����ɾ��ĳ�����Ϣ
        /// </summary>
        /// <param name="iMapID"></param>
        public void RemoveCharacter( long iCharacterId )
        {
            m_Characters.Remove( iCharacterId );
        }

        /// <summary>
        /// �������Ϣ�ļ����ڸ���ĳ�����Ϣ
        /// </summary>
        /// <param name="iMapID"></param>
        /// <returns></returns>
        public T GetCharacter( long iCharacterId )
        {
            return m_Characters.GetValue( iCharacterId );
        }

        /// <summary>
        /// ȫ�������Ϣ������
        /// </summary>
        /// <returns></returns>
        [MultiThreadedWarning( "zh-CHS", "(��ҵ���Ϣ)��ǰ���������б���ʱ������,���ܱ������������Ժ����:����!" )]
        public T[] ToArray()
        {
            return m_Characters.ToArrayValues();
        }
        #endregion

        #endregion
    }
}
#endregion