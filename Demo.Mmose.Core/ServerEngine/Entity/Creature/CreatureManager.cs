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

namespace Demo.Mmose.Core.Entity.Creature
{
    /// <summary>
    /// 
    /// </summary>
    public class CreatureManager<T> where T : BaseCreature
    {
        #region zh-CHS ˽�г��� | en Private Constants
        /// <summary>
        /// 
        /// </summary>
        private readonly static int DICTIONARY_CAPACITY = 1024;
        #endregion

        #region zh-CHS ����ͳ�ʼ�������� | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        public CreatureManager()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iCapacity"></param>
        public CreatureManager( int iCapacity )
        {
            m_Creatures = new SafeDictionary<long, T>( iCapacity );
        }
        #endregion
  
        #region zh-CHS �������� | en Public Properties
        /// <summary>
        /// �����ű�����Ŀ��˶����������(NPCs��Monster)
        /// </summary>
        public int Count
        {
            get { return m_Creatures.Count; }
        }
        #endregion

        #region zh-CHS CreatureHandler ���� | en CreatureHandler Method

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// �ƶ�����(npc, player, monster)�ļ���
        /// </summary>
        private SafeDictionary<long, T> m_Creatures = new SafeDictionary<long, T>( DICTIONARY_CAPACITY );
        #endregion
        /// <summary>
        /// ����ƶ�����(npc, player, monster)������
        /// </summary>
        internal void AddCreature( long iCreatureId, T creatureT )
        {
            m_Creatures.Add( iCreatureId, creatureT );
        }

        /// <summary>
        /// ���ƶ�����(npc, player, monster)�ļ�����ɾ��ĳ�ƶ�����(npc, player, monster)
        /// </summary>
        /// <param name="iMapID"></param>
        internal void RemoveCreature( long iCreatureId )
        {
            m_Creatures.Remove( iCreatureId );
        }

        /// <summary>
        /// ���ƶ�����(npc, player, monster)�ļ����ڸ���ĳ�ƶ�����(npc, player, monster)
        /// </summary>
        /// <param name="iMapID"></param>
        /// <returns></returns>
        public T GetCreature( long iCreatureId )
        {
            return m_Creatures.GetValue( iCreatureId );
        }

        /// <summary>
        /// ȫ���ƶ�����(npc, player, monster)������
        /// </summary>
        /// <returns></returns>
        [MultiThreadedWarning( "zh-CHS", "(�ƶ���-npc,player,monster)��ǰ���������б���ʱ������,���ܱ������������Ժ����:����!" )]
        public T[] ToArray()
        {
            return m_Creatures.ToArrayValues();
        }

        #endregion
    }
}
#endregion