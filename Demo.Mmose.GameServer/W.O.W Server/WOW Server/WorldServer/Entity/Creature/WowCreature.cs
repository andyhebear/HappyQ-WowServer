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
using Demo.Mmose.Core.Entity.Creature;
using Demo.Mmose.Core.Entity.Suit.Treasure;
using Demo.Wow.WorldServer.Entity.Common;
using Demo.Mmose.Core.Network;
using Demo.Mmose.Core.Entity;
using Demo.Wow.WorldServer.Character;
using Demo.Wow.WorldServer.Entity;
using Demo.Wow.WorldServer.Entity.Fields;
using Demo.Wow.WorldServer.Util;
using Demo.Mmose.Core.Common.Component;
#endregion

namespace Demo.Wow.WorldServer.Creature
{
    /// <summary>
    /// 
    /// </summary>
    public partial class WowCreature : BaseCreature
    {
        #region zh-CHS ����ͳ�ʼ�������� | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        protected override void DefaultCreatureInit()
        {
            base.DefaultCreatureInit();

            // IWowUpdate
            this.RegisterComponent<IWowUpdate>( WowUpdate.WOW_UPDATE_COMPONENT_ID, this );

            // NPCField
            this.NPCField.EventRequestUpdate += new RequestUpdateEventHandler( this.OnFieldRequestUpdate );
        }
        #endregion

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_QueuedForUpdate = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool QueuedForUpdate
        {
            get { return m_QueuedForUpdate; }
        }

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_isInWorld = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsInWorld
        {
            get { return m_isInWorld; }
            internal set { m_isInWorld = value; }
        }

        public virtual void WriteUpdateMask( Packet writer, bool updatingSelf, bool forCreation )
        {
        }

        public virtual void WriteMovementUpdate( Packet writer, bool updatingSelf )
        {
        }

        public void ResetUpdateInfo()
        {
        }

        public Packet GetDestroyPacket()
        {
            return null;
        }


        protected Packet GetFieldUpdatePacket( UpdateFieldId field, uint value )
        {
            return null;
        }

        protected Packet GetFieldUpdatePacket( UpdateFieldId field, EntityId value )
        {
            return null;
        }

        protected static void SendUpdatePacket( WowCharacter character, Packet packet )
        {
        }

        protected static void SendUpdatePacket( IEnumerable<WowCharacter> characters, Packet packet )
        {
        }

        public virtual void Update( float dt )
        {
            //base.Slice += new EventHandler<GameEntityEventArgs>();

        }


        #region zh-CHS ���� | en
        ///// <summary>
        ///// 
        ///// </summary>
        //private uint m_CreatureFlag = 0;
        ///// <summary>
        ///// 
        ///// </summary>
        //public uint ���
        //{
        //    get { return m_CreatureFlag; }
        //    set { m_CreatureFlag = value; }
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        //private uint m_CreatureFlag2 = 0;
        ///// <summary>
        ///// 
        ///// </summary>
        //public uint ��־2
        //{
        //    get { return m_CreatureFlag2; }
        //    set { m_CreatureFlag2 = value; }
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        //private uint m_CreatureDynamicFlag = 0;
        ///// <summary>
        ///// 
        ///// </summary>
        //public uint ��̬���
        //{
        //    get { return m_CreatureDynamicFlag; }
        //    set { m_CreatureDynamicFlag = value; }
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        //private uint m_CreatureSpellA = 0;
        ///// <summary>
        ///// 
        ///// </summary>
        //public uint ħ������A
        //{
        //    get { return m_CreatureSpellA; }
        //    set { m_CreatureSpellA = value; }
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        //private uint m_CreatureAI = 0;
        ///// <summary>
        ///// 
        ///// </summary>
        //public uint �˹�����
        //{
        //    get { return m_CreatureAI; }
        //    set { m_CreatureAI = value; }
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        //private uint m_CreatureScriptName = 0;
        ///// <summary>
        ///// 
        ///// </summary>
        //public uint �����ű�
        //{
        //    get { return m_CreatureScriptName; }
        //    set { m_CreatureScriptName = value; }
        //}
        #endregion
    }
}
#endregion
