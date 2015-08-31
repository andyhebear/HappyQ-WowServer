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
using Demo.Mmose.Core.Common;
#endregion

namespace Demo.Mmose.Core.Entity.Creature
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseCreatureTemplate : ISerial
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 构造
        /// </summary>
        public BaseCreatureTemplate()
        {
            DefaultCreatureInit();
        }

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="serial">唯一序号</param>
        public BaseCreatureTemplate( Serial serial )
        {
            m_Serial = serial;
            DefaultCreatureInit();
        }

        #region zh-CHS 人物的初始化 | en
        /// <summary>
        /// 缺省的初始化人物
        /// </summary>
        protected virtual void DefaultCreatureInit()
        {
        }
        #endregion

        #endregion

        #region zh-CHS Serial属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 人物所定义的唯一序号GUID
        /// </summary>
        private Serial m_Serial = new Serial();
        #endregion
        /// <summary>
        /// 人物所定义的唯一序号GUID
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
