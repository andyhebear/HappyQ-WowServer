#region zh-CHS 2006 - 2008 DemoSoft 团队 | en 2006 - 2008 DemoSoft Team

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

#region zh-CHS 包含名字空间 | en Include namespace
using System.Diagnostics;
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Common.SafeCollections;
#endregion

namespace Demo.Mmose.Core.Entity.Suit.Ability.Aura
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseAuraTemplateHandler<T> where T : BaseAuraTemplate
    {
        #region zh-CHS 共有属性 | en Public Properties
        /// <summary>
        /// 
        /// </summary>
        public int Count
        {
            get { return m_AuraTemplates.Count; }
        }
        #endregion

        #region zh-CHS AuraTemplate方法 | en Public Methods

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private SafeDictionary<long, T> m_AuraTemplates = new SafeDictionary<long, T>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseTaxiNode"></param>
        public void AddAuraTemplate( long lAuraTemplateSerial, T auraTemplateT )
        {
            if ( auraTemplateT == null )
            {
                Debug.WriteLine( "BaseAuraTemplateHandler.AddAuraTemplate(...) - auraTemplateT == null error!" );
                return;
            }

            m_AuraTemplates.Add( lAuraTemplateSerial, auraTemplateT );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public T GetAuraTemplate( long lAuraTemplateSerial )
        {
            return m_AuraTemplates.GetValue( lAuraTemplateSerial );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void RemoveAuraTemplate( long lAuraTemplateSerial )
        {
            m_AuraTemplates.Remove( lAuraTemplateSerial );
        }

        /// <summary>
        /// 
        /// </summary>
        [MultiThreadedWarning( "zh-CHS", "(AuraTemplate)当前的数组是列表临时产生的,不能保存数组用于以后操作:警告!" )]
        public T[] ToArray()
        {
            return m_AuraTemplates.ToArrayValues();
        }

        #endregion
    }
}
#endregion