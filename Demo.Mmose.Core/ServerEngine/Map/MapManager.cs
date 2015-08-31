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

namespace Demo.Mmose.Core.Map
{
    /// <summary>
    /// 
    /// </summary>
    public class MapManager<MapT> where MapT : BaseMap
    {
        #region zh-CHS ����ͳ�ʼ�������� | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        public MapManager()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iCapacity"></param>
        public MapManager( int iCapacity )
        {
            m_Maps = new SafeDictionary<long, MapT>( iCapacity );
        }
        #endregion

        #region zh-CHS �������� | en Public Properties
        /// <summary>
        /// �����ű�����ĵ�ͼ������
        /// </summary>
        public int MapCount
        {
            get { return m_Maps.Count; }
        }
        #endregion

        #region zh-CHS MapHandler ���� | en MapHandler Method
        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        #region zh-CHS ˽�г��� | en Private Constants
        /// <summary>
        /// 
        /// </summary>
        private readonly static int DICTIONARY_CAPACITY = 20;
        #endregion
        /// <summary>
        /// ��ͼ�ļ���
        /// </summary>
        private SafeDictionary<long, MapT> m_Maps = new SafeDictionary<long, MapT>( DICTIONARY_CAPACITY );
        #endregion
        /// <summary>
        /// ��ӵ�ͼ������
        /// </summary>
        public void AddMap( Serial mapId, MapT addMap )
        {
            m_Maps.Add( mapId, addMap );
        }

        /// <summary>
        /// �ڵ�ͼ�ļ����ڸ���ĳ��ͼ
        /// </summary>
        /// <param name="iMapID"></param>
        /// <returns></returns>
        public MapT GetMap( Serial mapId )
        {
            return m_Maps.GetValue( mapId );
        }

        /// <summary>
        /// �ڵ�ͼ�ļ�����ɾ��ĳ��ͼ
        /// </summary>
        /// <param name="iMapID"></param>
        public void RemoveMap( Serial mapId )
        {
            m_Maps.Remove( mapId );
        }

        /// <summary>
        /// ȫ����ͼ������
        /// </summary>
        /// <returns></returns>
        [MultiThreadedWarning( "zh-CHS", "(��ͼ)��ǰ���������б���ʱ������,���ܱ������������Ժ����:����!" )]
        public MapT[] ToArrayInMaps()
        {
            return m_Maps.ToArrayValues();
        }
        #endregion
    }
}
#endregion