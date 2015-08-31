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

namespace Demo.Mmose.Core.Entity.Item
{
    /// <summary>
    /// 
    /// </summary>
    public class ItemManager<T> where T : BaseItem
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
        public ItemManager()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iCapacity"></param>
        public ItemManager( int iCapacity )
        {
            m_Items = new SafeDictionary<long, T>( iCapacity );
        }
        #endregion

        #region zh-CHS �������� | en Public Properties
        /// <summary>
        /// �����ű�����ĵ��ߵ�����
        /// </summary>
        public int Count
        {
            get { return m_Items.Count; }
        }
        #endregion

        #region zh-CHS ItemHandler ���� | en ItemHandler Method

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// ���ߵļ���
        /// </summary>
        private SafeDictionary<long, T> m_Items = new SafeDictionary<long, T>( DICTIONARY_CAPACITY );
        #endregion
        /// <summary>
        /// ��ӵ��ߵ�����
        /// </summary>
        public void AddItem( long itemId, T itemT )
        {
            m_Items.Add( itemId, itemT );
        }

        /// <summary>
        /// �ڵ��ߵļ�����ɾ��ĳ����
        /// </summary>
        /// <param name="iMapID"></param>
        public void RemoveItem( long itemId )
        {
            m_Items.Remove( itemId );
        }

        /// <summary>
        /// �ڵ��ߵļ����ڸ���ĳ����
        /// </summary>
        /// <param name="iMapID"></param>
        /// <returns></returns>
        public T GetItem( long itemId )
        {
            return m_Items.GetValue( itemId );
        }

        /// <summary>
        /// ȫ�����ߵ�����
        /// </summary>
        /// <returns></returns>
        [MultiThreadedWarning( "zh-CHS", "(����)��ǰ���������б���ʱ������,���ܱ������������Ժ����:����!" )]
        public T[] ToArray()
        {
            return m_Items.ToArrayValues();
        }

        #endregion
    }
}
#endregion