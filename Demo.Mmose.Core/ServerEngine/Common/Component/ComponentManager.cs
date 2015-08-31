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
using System.Collections.Generic;
using Demo.Mmose.Core.Common.SafeCollections;
using Demo.Mmose.Core.Common.LockFree;
using System;
#endregion

namespace Demo.Mmose.Core.Common.Component
{
    /// <summary>
    /// 
    /// </summary>
    [MultiThreadedSupport( "zh-CHS", "当前的类所有成员都可锁定,支持多线程操作" )]
    public class ComponentManager : Component, IComponentManager
    {
        #region zh-CHS IComponent接口实现 | en IComponent Interface Implementation

        /// <summary>
        /// 
        /// </summary>
        /// <param name="componentMessage"></param>
        public override void OnHandleComponentMessage( ComponentMessage componentMessage )
        {
            this.PostComponentMessage( componentMessage );
        }

        #endregion

        #region zh-CHS IComponentHandler接口实现 | en IComponentHandler Interface Implementation

        #region zh-CHS 共有方法 | en Public Methods
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        LockFreeDictionary<ComponentId, IComponent> m_ComponentDictionary = new LockFreeDictionary<ComponentId, IComponent>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="componentId"></param>
        /// <param name="component"></param>
        public void RegisterComponent<T>( ComponentId componentId, T component ) where T : class, IComponent
        {
            if ( component == null )
                throw new Exception( "ComponentHandler.RegisterComponent(...) - component == null error!" );

            m_ComponentDictionary.Add( componentId, component );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="componentId"></param>
        /// <returns></returns>
        public T GetComponent<T>( ComponentId componentId ) where T : class, IComponent
        {
            IComponent returnValue = null;

            m_ComponentDictionary.TryGetValue( componentId, out returnValue );

            return returnValue as T;
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        LockFreeMultiDictionary<ComponentMessage, IComponent> m_MessageMultiDictionary = new LockFreeMultiDictionary<ComponentMessage, IComponent>( false );
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="componentMessage"></param>
        public void SubScribeComponentMessage( ComponentId componentId, ComponentMessage componentMessage )
        {
            IComponent outComponent = null;

            if ( m_ComponentDictionary.TryGetValue( componentId, out outComponent ) == true )
                m_MessageMultiDictionary.Add( componentMessage, outComponent );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="componentMessage"></param>
        public void PostComponentMessage( ComponentMessage componentMessage )
        {
            IEnumerable<IComponent> componentEnumerable = m_MessageMultiDictionary[componentMessage];
            if ( componentEnumerable == null )
                return;

            foreach ( IComponent component in componentEnumerable )
                component.OnHandleComponentMessage( componentMessage );
        }
        #endregion

        #endregion
    }
}
#endregion