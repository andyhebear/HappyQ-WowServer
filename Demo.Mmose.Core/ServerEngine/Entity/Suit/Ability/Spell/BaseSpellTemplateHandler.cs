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

namespace Demo.Mmose.Core.Entity.Suit.Ability.Spell
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseSpellTemplateHandler<T> where T : BaseSpellTemplate
    {
        #region zh-CHS 共有属性 | en Public Properties
        /// <summary>
        /// 
        /// </summary>
        public int Count
        {
            get { return m_SpellTemplates.Count; }
        }
        #endregion

        #region zh-CHS SpellTemplate方法 | en Public Methods

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private SafeDictionary<long, T> m_SpellTemplates = new SafeDictionary<long, T>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseTaxiNode"></param>
        public void AddSpellTemplate( long lSpellTemplateSerial, T spellTemplateT )
        {
            if ( spellTemplateT == null )
            {
                Debug.WriteLine( "BaseSpellTemplateHandler.AddSpellTemplate(...) - spellTemplateT == null error!" );
                return;
            }

            m_SpellTemplates.Add( lSpellTemplateSerial, spellTemplateT );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public T GetSpellTemplate( long lSpellTemplateSerial )
        {
            return m_SpellTemplates.GetValue( lSpellTemplateSerial );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void RemoveSpellTemplate( long lSpellTemplateSerial )
        {
            m_SpellTemplates.Remove( lSpellTemplateSerial );
        }

        /// <summary>
        /// 
        /// </summary>
        [MultiThreadedWarning( "zh-CHS", "(SpellTemplate)当前的数组是列表临时产生的,不能保存数组用于以后操作:警告!" )]
        public T[] ToArray()
        {
            return m_SpellTemplates.ToArrayValues();
        }

        #endregion
    }
}
#endregion