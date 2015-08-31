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
using System;
using Demo.Mmose.Core.Common;
#endregion

namespace Demo.Mmose.Core.Entity.GameObject
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseGameObject : WorldEntity, IComparable, IComparable<BaseGameObject>
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public BaseGameObject()
        {
            DefaultGameObjectInit();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="serial">唯一序号</param>
        public BaseGameObject( Serial serial )
            : base( serial )
        {
            DefaultGameObjectInit();
        }

        #region zh-CHS 人物的初始化 | en
        /// <summary>
        /// 缺省的初始化人物
        /// </summary>
        protected virtual void DefaultGameObjectInit()
        {
        }
        #endregion

        #endregion

        #region zh-CHS 共有属性 | en Public Properties

        #region zh-CHS Name属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 人物的名字
        /// </summary>
        private string m_Name = string.Empty;
        #endregion
        /// <summary>
        /// 人物的名字
        /// </summary>
        public string Name
        {
            get { return m_Name; }
            set
            {
                string oldName = m_Name;

                if ( m_BaseGameObjectState != null )
                {
                    if ( m_BaseGameObjectState.OnUpdatingName( value, this ) == true )
                        return;
                }

                m_Name = value;
                m_BaseGameObjectState.IsUpdateName = true;

                if ( m_BaseGameObjectState != null )
                    m_BaseGameObjectState.OnUpdatedName( oldName, this );
            }
        }

        #endregion

        #region zh-CHS GameObjectState属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 人物的状态机
        /// </summary>
        private BaseGameObjectState m_BaseGameObjectState = null;
        #endregion
        /// <summary>
        /// BaseCreatureState人物的状态器
        /// </summary>
        public BaseGameObjectState BaseGameObjectState
        {
            get { return m_BaseGameObjectState; }
            protected set { m_BaseGameObjectState = value; }
        }

        #endregion

        #endregion

        #region zh-CHS 创建一个新的自身 | en Public Method
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public BaseGameObject CreateNewGameObjectInstance()
        {
            return CreateNewInstance<BaseGameObject>();
        }
        #endregion

        #region zh-CHS 接口实现 | en Interface Implementation
        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo( BaseGameObject other )
        {
            return CompareTo( other as WorldEntity );
        }
        #endregion

        #region zh-CHS 方法覆盖 | en Override Methods
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return m_Name;
        }
        #endregion
    }
}
#endregion