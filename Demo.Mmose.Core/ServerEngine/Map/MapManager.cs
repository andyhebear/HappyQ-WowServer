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
using Demo.Mmose.Core.Common.SafeCollections;
#endregion

namespace Demo.Mmose.Core.Map
{
    /// <summary>
    /// 
    /// </summary>
    public class MapManager<MapT> where MapT : BaseMap
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        public MapManager()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iCapacity"></param>
        public MapManager( int iCapacity )
        {
            m_Maps = new SafeDictionary<long, MapT>( iCapacity );
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        /// <summary>
        /// 给出脚本里面的地图的数量
        /// </summary>
        public int MapCount
        {
            get { return m_Maps.Count; }
        }
        #endregion

        #region zh-CHS MapHandler 方法 | en MapHandler Method
        #region zh-CHS 私有成员变量 | en Private Member Variables
        #region zh-CHS 私有常量 | en Private Constants
        /// <summary>
        /// 
        /// </summary>
        private readonly static int DICTIONARY_CAPACITY = 20;
        #endregion
        /// <summary>
        /// 地图的集合
        /// </summary>
        private SafeDictionary<long, MapT> m_Maps = new SafeDictionary<long, MapT>( DICTIONARY_CAPACITY );
        #endregion
        /// <summary>
        /// 添加地图到集合
        /// </summary>
        public void AddMap( Serial mapId, MapT addMap )
        {
            m_Maps.Add( mapId, addMap );
        }

        /// <summary>
        /// 在地图的集合内给出某地图
        /// </summary>
        /// <param name="iMapID"></param>
        /// <returns></returns>
        public MapT GetMap( Serial mapId )
        {
            return m_Maps.GetValue( mapId );
        }

        /// <summary>
        /// 在地图的集合内删除某地图
        /// </summary>
        /// <param name="iMapID"></param>
        public void RemoveMap( Serial mapId )
        {
            m_Maps.Remove( mapId );
        }

        /// <summary>
        /// 全部地图的数组
        /// </summary>
        /// <returns></returns>
        [MultiThreadedWarning( "zh-CHS", "(地图)当前的数组是列表临时产生的,不能保存数组用于以后操作:警告!" )]
        public MapT[] ToArrayInMaps()
        {
            return m_Maps.ToArrayValues();
        }
        #endregion
    }
}
#endregion