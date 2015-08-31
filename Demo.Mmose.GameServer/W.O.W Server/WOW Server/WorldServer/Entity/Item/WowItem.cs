#region zh-CHS ��Ȩ���� (C) 2006 - 2006 DemoSoft Corporation. ��������Ȩ�� | en Copyright (C) 2006 - 2006 DemoSoft Corporation. All Rights Reserved.

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

#region zh-CHS �������ֿռ� | en Include namespace
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
        #region zh-CHS ����ͳ�ʼ�������� | en Constructors and Initializers and Dispose
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

        #region zh-CHS ���� | en
        ///// <summary>
        ///// 
        ///// </summary>
        //private uint m_ItemScriptGUID = 0;
        ///// <summary>
        ///// 
        ///// </summary>
        //public uint �����ű����
        //{
        //    get { return m_ItemScriptGUID; }
        //    set { m_ItemScriptGUID = value; }
        //}
        #endregion
    }
}
#endregion
