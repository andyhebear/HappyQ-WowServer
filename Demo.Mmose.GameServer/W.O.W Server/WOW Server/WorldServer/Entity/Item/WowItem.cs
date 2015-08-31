#region zh-CHS 版权所有 (C) 2006 - 2006 DemoSoft Corporation. 保留所有权利 | en Copyright (C) 2006 - 2006 DemoSoft Corporation. All Rights Reserved.

// COPYRIGHT NOTES
// ---------------
// Program.cs : interface for the Program class.
//
// This file is a part of the Demo Toolkit for .NET.
// 2006-2006 Demo Software, All Rights Reserved.
//
// This source code can only be used under the terms and conditions 
// outlined in the accompanying license agreement.
//
// mailto:caihuanqing@hotmail.com

#region zh-CHS 包含名字空间 | en Include namespace
using System;
using System.Text;
using System.Collections.Generic;
using Demo.Wow.WorldServer.Character;
using Demo.Mmose.Core.Entity.Item;
using Demo.Wow.WorldServer.Entity.Fields;
using Demo.Mmose.Core.Common.Component;
using Demo.Wow.WorldServer.Entity.Common;
#endregion

namespace Demo.Wow.WorldServer.Item
{
    /// <summary>
    /// 
    /// </summary>
    public partial class WowItem : BaseItem
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        protected override void DefaultItemInit()
        {
            base.DefaultItemInit();

            // IWowUpdate
            this.RegisterComponent<IWowUpdate>( WowUpdate.WOW_UPDATE_COMPONENT_ID, this );

            // CharacterField
            this.ItemField.EventRequestUpdate += new RequestUpdateEventHandler( this.OnFieldRequestUpdate );
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        private long m_Amount = 1;
        /// <summary>
        /// 
        /// </summary>
        public long Amount
        {
            get { return m_Amount; }
            set { m_Amount = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public void SoulBind()
        {
        }

        #region zh-CHS 杂项 | en
        ///// <summary>
        ///// 
        ///// </summary>
        //private uint m_ItemScriptGUID = 0;
        ///// <summary>
        ///// 
        ///// </summary>
        //public uint 触发脚本编号
        //{
        //    get { return m_ItemScriptGUID; }
        //    set { m_ItemScriptGUID = value; }
        //}
        #endregion
    }
}
#endregion
