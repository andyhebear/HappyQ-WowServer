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

#endregion

namespace Demo.Mmose.Core.World.DomainWorld
{
    /// <summary>
    /// 
    /// </summary>
    public class ConfigDomain
    {
        #region zh-CHS �������� | en Public Properties
        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_strDomainID = string.Empty;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public string DomainID
        {
            get { return m_strDomainID; }
            set { m_strDomainID = value; }
        }

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_strDomainHost = string.Empty;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public string DomainHost
        {
            get { return m_strDomainHost; }
            set { m_strDomainHost = value; }
        }

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_iDomainPort = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint DomainPort
        {
            get { return m_iDomainPort; }
            set { m_iDomainPort = value; }
        }

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_strDomainPassword = string.Empty;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public string DomainPassword
        {
            get { return m_strDomainPassword; }
            set { m_strDomainPassword = value; }
        }
        #endregion
    }
}
#endregion