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
using System;
#endregion

namespace Demo.Mmose.Core.Scripts
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage( AttributeTargets.Class )]
    public class TypeAliasAttribute : Attribute
    {
        #region zh-CHS ����ͳ�ʼ�������� | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aliases"></param>
        public TypeAliasAttribute( params string[] aliases )
        {
            m_Aliases = aliases;
        }
        #endregion

        #region zh-CHS �������� | en Public Properties
        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string[] m_Aliases;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public string[] Aliases
        {
            get { return m_Aliases; }
        }
        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage( AttributeTargets.Method )]
    public class CallPriorityAttribute : Attribute
    {
        #region zh-CHS ����ͳ�ʼ�������� | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        /// <param name="priority"></param>
        public CallPriorityAttribute( int iPriority )
        {
            m_Priority = iPriority;
        }
        #endregion

        #region zh-CHS �������� | en Public Properties
        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_Priority = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public int Priority
        {
            get { return m_Priority; }
            set { m_Priority = value; }
        }
        #endregion
    }
}
#endregion