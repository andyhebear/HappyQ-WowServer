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
#endregion

namespace Demo.Mmose.Core.Entity.Creature
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseCreatureTemplate : ISerial
    {
        #region zh-CHS ����ͳ�ʼ�������� | en Constructors and Initializers and Dispose
        /// <summary>
        /// ����
        /// </summary>
        public BaseCreatureTemplate()
        {
            DefaultCreatureInit();
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="serial">Ψһ���</param>
        public BaseCreatureTemplate( Serial serial )
        {
            m_Serial = serial;
            DefaultCreatureInit();
        }

        #region zh-CHS ����ĳ�ʼ�� | en
        /// <summary>
        /// ȱʡ�ĳ�ʼ������
        /// </summary>
        protected virtual void DefaultCreatureInit()
        {
        }
        #endregion

        #endregion

        #region zh-CHS Serial���� | en Public Properties

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// �����������Ψһ���GUID
        /// </summary>
        private Serial m_Serial = new Serial();
        #endregion
        /// <summary>
        /// �����������Ψһ���GUID
        /// </summary>
        public Serial Serial
        {
            get { return m_Serial; }
            set { m_Serial = value; }
        }

        #endregion
    }
}
#endregion
