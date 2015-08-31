#region zh-CHS ��Ȩ���� (C) 2006 - 2006 DemoSoft Corporation. ��������Ȩ�� | en Copyright (C) 2006 - 2006 DemoSoft Corporation. All Rights Reserved.

// COPYRIGHT NOTES
// ---------------
//
// This file is a part of the G.O.S.E(Game Online Server Engine) for .NET.
//
//           2007-2008 Demo Software, All Rights Reserved.
//
// This source code can only be used under the terms and conditions outlined
// in the accompanying license agreement.
//
//
// First Version : by H.Q.Cai - mailto:caihuanqing@hotmail.com

#region zh-CHS �������ֿռ� | en Include namespace
using System;
using System.IO;
using System.Text;
using System.Globalization;
using System.Collections.Generic;
using Demo.Mmose.Core.Util;
using DevExpress.Xpo;
#endregion

namespace Demo.Wow.Database.Ver1a
{
    #region zh-CHS ���� ���� | en 
    #endregion

    #region zh-CHS ����/NPC ���� | en
    #endregion

    #region zh-CHS ���� ���� | en 
    #endregion

    #region zh-CHS ʬ�� ���� | en 
    #endregion

    #region zh-CHS �Ŷ�ϵͳ ���� | en 
    #endregion

    #region zh-CHS �л� ���� | en 
    #endregion

    #region zh-CHS ����ϵͳ ���� | en 
    #endregion

    #region zh-CHS �ʼ�ϵͳ ���� | en 
    #endregion

    #region zh-CHS ������������ʱ��  ���� | en 
    #endregion

    #region zh-CHS ��¼��־ ���� | en
    #endregion



    /// <summary>
    /// ��Ϸ�˺��������Ϸ����
    /// </summary>
    public abstract class Characters_Instance : XPObject
    {
        #region zh-CHS ���� | en Properties
        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_CharacterGuid;
        #endregion
        /// <summary>
        /// ��Ϸ��������Ƶ�ID
        /// </summary>
        [Indexed( Unique = true )]
        public long CharacterGuid
        {
            get { return m_CharacterGuid; }
            set { SetPropertyValue<long>( "CharacterGuid", ref m_CharacterGuid, value ); }
        }
        #endregion

        #region zh-CHS ���� | en Method
        /// <summary>
        /// ��ֹΥ������Ψһ�Ĺ���
        /// </summary>
        public override void AfterConstruction()
        {
            CharacterGuid = Guid.NewGuid().GetHashCode();

            base.AfterConstruction();
        }
        #endregion
    }

    /// <summary>
    /// ��Ϸ�˺��������Ϸ����
    /// </summary>
    public class Characters_Ticket : XPObject
    {
        #region zh-CHS ���� | en Properties
        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_CharacterGuid;
        #endregion
        /// <summary>
        /// ��Ϸ��������Ƶ�ID
        /// </summary>
        [Indexed( Unique = true )]
        public long CharacterGuid
        {
            get { return m_CharacterGuid; }
            set { SetPropertyValue<long>( "CharacterGuid", ref m_CharacterGuid, value ); }
        }
        #endregion

        #region zh-CHS ���� | en Method
        /// <summary>
        /// ��ֹΥ������Ψһ�Ĺ���
        /// </summary>
        public override void AfterConstruction()
        {
            CharacterGuid = Guid.NewGuid().GetHashCode();

            base.AfterConstruction();
        }
        #endregion
    }

    /// <summary>
    ///  ˢNPC������ǵ�ˢNPC������
    /// </summary>
    public class SpawnNPCs : XPObject
    {
        #region zh-CHS ���� | en Properties
        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_NPCGuid;
        #endregion
        /// <summary>
        /// NPC��GUID
        /// </summary>
        [Indexed]
        public long NPCGuid
        {
            get { return m_NPCGuid; }
            set { SetPropertyValue<long>( "NPCGuid", ref m_NPCGuid, value ); }
        }

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_MapID;
        #endregion
        /// <summary>
        /// NPC���ڵ�ͼ��ID
        /// </summary>
        public int MapID
        {
            get { return m_MapID; }
            set { SetPropertyValue<int>( "MapID", ref m_MapID, value ); }
        }

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_PositionX;
        #endregion
        /// <summary>
        /// NPC�� X ����
        /// </summary>
        public int PositionX
        {
            get { return m_PositionX; }
            set { SetPropertyValue<int>( "PositionX", ref m_PositionX, value ); }
        }

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_PositionY;
        #endregion
        /// <summary>
        /// NPC�� Y ����
        /// </summary>
        public int PositionY
        {
            get { return m_PositionY; }
            set { SetPropertyValue<int>( "PositionY", ref m_PositionY, value ); }
        }

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_Direction;
        #endregion
        /// <summary>
        /// NPC�ķ���
        /// </summary>
        public int Direction
        {
            get { return m_Direction; }
            set { SetPropertyValue<int>( "Direction", ref m_Direction, value ); }
        }
        #endregion

        #region zh-CHS ���� | en Method
        /// <summary>
        /// ��ֹΥ������Ψһ�Ĺ���
        /// </summary>
        public override void AfterConstruction()
        {
            NPCGuid = 0;
            MapID = 0;
            PositionX = 0;
            PositionY = 0;
            Direction = 0;

            base.AfterConstruction();
        }
        #endregion
    }

    /// <summary>
    /// ˢ�ֵ������ǵ�ˢ������
    /// </summary>
    public class SpawnMonsters : XPObject
    {
        #region zh-CHS ���� | en Properties
        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_MobileGUID;
        #endregion
        /// <summary>
        /// �����GUID
        /// </summary>
        [Indexed]
        public long MobileGUID
        {
            get { return m_MobileGUID; }
            set { SetPropertyValue<long>( "MobileGUID", ref m_MobileGUID, value ); }
        }

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_MapID;
        #endregion
        /// <summary>
        /// ˢ�ֵ��ͼ��ID
        /// </summary>
        public int MapID
        {
            get { return m_MapID; }
            set { SetPropertyValue<int>( "MapID", ref m_MapID, value ); }
        }

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_Count;
        #endregion
        /// <summary>
        /// ����ˢ�ֵ�����(������ķ�Χ�����ˢ��ˢ�ֵ�)
        /// </summary>
        public int Count
        {
            get { return m_Count; }
            set { SetPropertyValue<int>( "Count", ref m_Count, value ); }
        }

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_Points;
        #endregion
        /// <summary>
        /// ˢ�ֵ�����������λ��x��λ��y(count|x,y|x,y|...|...)����3�����������,�Ǹ�һ�������ǵķ�Χ,�����ڴ����Ƿ�Χ��ˢ��
        /// </summary>
        //[SqlType( SqlType.Text )]
        public string Points
        {
            get { return m_Points; }
            set { SetPropertyValue<string>( "Points", ref m_Points, value ); }
        }

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_MinRespawn;
        #endregion
        /// <summary>
        /// ˢ���������С����(��Χ�����ڴ˹�������������ˢ��,����ˢ�ֵ�ʱ����)
        /// </summary>
        public int MinRespawn
        {
            get { return m_MinRespawn; }
            set { SetPropertyValue<int>( "MinRespawn", ref m_MinRespawn, value ); }
        }

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_RespawnTime;
        #endregion
        /// <summary>
        /// ˢ�ֵ�ʱ����(��ˢ�ֵ�����: �����ǹ���������ˢ�ֵ�ʱ����,��ʱ������������ˢ��ֱ������ˢ�ֵ�����λ��......��)
        /// </summary>
        public int RespawnTime
        {
            get { return m_RespawnTime; }
            set { SetPropertyValue<int>( "RespawnTime", ref m_RespawnTime, value ); }
        }
        #endregion

        #region zh-CHS ���� | en Method
        /// <summary>
        /// ��ֹΥ������Ψһ�Ĺ���
        /// </summary>
        public override void AfterConstruction()
        {
            MobileGUID = 0;
            MapID = 0;
            Count = 0;
            Points = "3|5000,5000|5100,5000|5000,5100";
            RespawnTime = 30;

            base.AfterConstruction();
        }
        #endregion
    }
}
#endregion