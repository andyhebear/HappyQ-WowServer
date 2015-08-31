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
    public class ItemTemplateManager<T> where T : BaseItemTemplate
    {
        #region zh-CHS ����ͳ�ʼ�������� | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        public ItemTemplateManager()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iCapacity"></param>
        public ItemTemplateManager( int iCapacity )
        {
            m_ItemTemplates = new SafeDictionary<long, T>( iCapacity );
        }
        #endregion

        #region zh-CHS �������� | en Public Properties
        /// <summary>
        /// �����ű�����ĵ������͵�����
        /// </summary>
        public int Count
        {
            get { return m_ItemTemplates.Count; }
        }
        #endregion

        #region zh-CHS ItemTemplateHandler(ģ��) ���� | en ItemTemplateHandler Method
        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// �������͵ļ���
        /// </summary>
        private SafeDictionary<long, T> m_ItemTemplates = new SafeDictionary<long, T>();
        #endregion
        /// <summary>
        /// ��ӵ������͵�����
        /// </summary>
        public void AddItemTemplate( long itemTemplateId, T itemTemplateT )
        {
            m_ItemTemplates.Add( itemTemplateId, itemTemplateT );
        }

        /// <summary>
        /// �ڵ������͵ļ����ڸ���ĳ��������
        /// </summary>
        /// <param name="iMapID"></param>
        /// <returns></returns>
        public T GetItemTemplate( long itemTemplateId )
        {
            return m_ItemTemplates.GetValue( itemTemplateId );
        }

        /// <summary>
        /// �ڵ������͵ļ�����ɾ��ĳ��������
        /// </summary>
        /// <param name="iMapID"></param>
        public void RemoveItemTemplate( long itemTemplateId )
        {
            m_ItemTemplates.Remove( itemTemplateId );
        }

        /// <summary>
        /// ȫ���������͵�����
        /// </summary>
        /// <returns></returns>
        [MultiThreadedWarning( "zh-CHS", "(��������)��ǰ���������б���ʱ������,���ܱ������������Ժ����:����!" )]
        public T[] ToArray()
        {
            return m_ItemTemplates.ToArrayValues();
        }
        #endregion
    }
}
#endregion