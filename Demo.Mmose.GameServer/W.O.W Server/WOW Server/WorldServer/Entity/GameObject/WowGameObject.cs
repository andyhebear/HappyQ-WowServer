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
using Demo.Mmose.Core.Entity.Item;
using Demo.Mmose.Core.Entity.Suit.Treasure;
using Demo.Mmose.Core.Entity.GameObject;
using Demo.Wow.WorldServer.Entity.Fields;
using Demo.Wow.WorldServer.Entity.Common;
#endregion

namespace Demo.Wow.WorldServer.Object
{
    /// <summary>
    /// 
    /// </summary>
    public partial class WowGameObject : BaseGameObject
    {
        #region zh-CHS ����ͳ�ʼ�������� | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        protected override void DefaultGameObjectInit()
        {
            base.DefaultGameObjectInit();

            // IWowUpdate
            this.RegisterComponent<IWowUpdate>( WowUpdate.WOW_UPDATE_COMPONENT_ID, this );

            // CorpseField
            this.GameObjectField.EventRequestUpdate += new RequestUpdateEventHandler( this.OnFieldRequestUpdate );
        }
        #endregion

        #region zh-CHS ���� | en
        ///// <summary>
        ///// 
        ///// </summary>
        //uint m_ObjectScriptGUID = 0;
        ///// <summary>
        ///// 
        ///// </summary>
        //public uint ���崥���ű����
        //{
        //    get { return m_ObjectScriptGUID; }
        //    set { m_ObjectScriptGUID = value; }
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        //uint m_ObjectCastsSpell = 0;
        ///// <summary>
        ///// 
        ///// </summary>
        //public uint �����ݾ�ħ�����˱��
        //{
        //    get { return m_ObjectCastsSpell; }
        //    set { m_ObjectCastsSpell = value; }
        //}
        #endregion
    }
}
#endregion
