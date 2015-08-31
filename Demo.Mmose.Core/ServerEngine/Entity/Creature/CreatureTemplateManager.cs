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
    public class CreatureTemplateManager<T> where T : BaseCreatureTemplate
    {
        #region zh-CHS ����ͳ�ʼ�������� | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        public CreatureTemplateManager()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iCapacity"></param>
        public CreatureTemplateManager( int iCapacity )
        {
            m_CreatureTemplates = new SafeDictionary<long, T>( iCapacity );
        }
        #endregion

        #region zh-CHS �������� | en Public Properties
        /// <summary>
        /// �����ű�����Ŀ��˶����������(NPCs��Monster)
        /// </summary>
        public int Count
        {
            get { return m_CreatureTemplates.Count; }
        }
        #endregion

        #region zh-CHS CreatureTemplateHandler Type(ģ��) ���� | en CreatureTemplateHandler Type Method

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// �ƶ���������(npc, player, monster)�ļ���
        /// </summary>
        private SafeDictionary<long, T> m_CreatureTemplates = new SafeDictionary<long, T>();
        #endregion
        /// <summary>
        /// ����ƶ���������(npc, player, monster)������
        /// </summary>
        public void AddCreatureTemplate( long iCreatureId, T creatureT )
        {
            m_CreatureTemplates.Add( iCreatureId, creatureT );
        }

        /// <summary>
        /// ���ƶ���������(npc, player, monster)�ļ����ڸ���ĳ�ƶ�����(npc, player, monster)
        /// </summary>
        /// <param name="iMapID"></param>
        /// <returns></returns>
        public T GetCreatureTemplate( long iCreatureId )
        {
            return m_CreatureTemplates.GetValue( iCreatureId );
        }

        /// <summary>
        /// ���ƶ���������(npc, player, monster)�ļ�����ɾ��ĳ�ƶ�����(npc, player, monster)
        /// </summary>
        /// <param name="iMapID"></param>
        public void RemoveCreatureTemplate( long iCreatureId )
        {
            m_CreatureTemplates.Remove( iCreatureId );
        }

        /// <summary>
        /// ȫ���ƶ���������(npc, player, monster)������
        /// </summary>
        /// <returns></returns>
        [MultiThreadedWarning( "zh-CHS", "(�ƶ�������-npc,player,monster)��ǰ���������б���ʱ������,���ܱ������������Ժ����:����!" )]
        public T[] ToArray()
        {
            return m_CreatureTemplates.ToArrayValues();
        }

        #endregion
    }
}
#endregion