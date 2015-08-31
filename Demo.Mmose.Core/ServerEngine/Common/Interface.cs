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
using System.Collections;
using System.Collections.Generic;
using Demo.Mmose.Core.Entity.Creature;
using Demo.Mmose.Core.Entity.Item;
using Demo.Mmose.Core.Map;
#endregion

namespace Demo.Mmose.Core.Common
{
    #region zh-CHS 接口 | en Interface
    /// <summary>
    /// 
    /// </summary>
    public interface ISerial
    {
        Serial Serial { get; }
    }

    /// <summary>
    /// 
    /// </summary>
    public interface IPoint2D
    {
        float X { get; }
        float Y { get; }
    }

    /// <summary>
    /// 
    /// </summary>
    public interface IPoint3D : IPoint2D
    {
        float Z { get; }
    }

    /// <summary>
    /// 
    /// </summary>
    public interface IPoint4D : IPoint3D
    {
        float O { get; }
    }

    /// <summary>
    /// 
    /// </summary>
    public interface ILocation : IPoint3D
    {
        Point3D Location { get; }
    }
    
    /// <summary>
    /// 
    /// </summary>
    public interface IEntity : IPoint3D, IComparable, IComparable<IEntity>
    {
        Serial Serial { get; }
        Point3D Location { get; }
        BaseMap Map { get; }
    }

    /// <summary>
    /// AI
    /// </summary>
    public interface IArtificialIntelligence
    {
        void SliceAI();
    }











    public interface IMount
    {
        BaseCreature Rider { get; set; }
        void OnRiderDamaged( int amount, BaseCreature from, bool willKill );
    }

    public interface IMountItem
    {
        IMount Mount { get; }
    }

    public interface IVendor
    {
        bool OnBuyItems( BaseCreature from, ArrayList list );
        bool OnSellItems( BaseCreature from, ArrayList list );

        DateTime LastRestock { get; set; }
        TimeSpan RestockDelay { get; }
        void Restock();
    }

    public interface ICarvable
    {
        void Carve( BaseCreature from, BaseItem item );
    }

    public interface IWeapon
    {
        int MaxRange { get; }
        void OnBeforeSwing( BaseCreature attacker, BaseCreature defender );
        TimeSpan OnSwing( BaseCreature attacker, BaseCreature defender );
        void GetStatusDamage( BaseCreature from, out int min, out int max );
    }

    public interface IHued
    {
        int HuedItemID { get; }
    }

    internal interface ISpell
    {
        bool IsCasting { get; }
        void OnCasterHurt();
        void OnCasterKilled();
        void OnConnectionChanged();
        //bool OnCasterMoving( Direction d );
        bool OnCasterEquiping( BaseItem item );
        bool OnCasterUsingObject( object o );
        bool OnCastInTown( Region r );
    }

    public interface IParty
    {
        void OnStamChanged( BaseCreature m );
        void OnManaChanged( BaseCreature m );
        void OnStatsQuery( BaseCreature beholder, BaseCreature beheld );
    }


    /// <summary>
    /// 当前脚本类需初始化实例
    /// </summary>
    public interface IInitialize
    {
    }

    /// <summary>
    /// 当前脚本类需配置化实例
    /// </summary>
    public interface IConfigure
    {
    }

    /// <summary>
    /// 当前类的有内存池,可释放自己入内存池
    /// </summary>
    public interface IRelease
    {
        #region zh-CHS 接口 | en Interface
        void Release();
        #endregion
    }

    /// <summary>
    /// 当前类实例的在多线程中需锁定
    /// </summary>
    public interface ILock
    {
        #region zh-CHS 接口 | en Interface
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool Lock();
        /// <summary>
        /// 
        /// </summary>
        void Free();
        #endregion
    }

    /// <summary>
    /// 刷物/怪
    /// </summary>
    public interface ISpawner
    {
        /// <summary>
        /// 物/怪所在的地图
        /// </summary>
        BaseMap Map { get; }
        /// <summary>
        /// 所需刷物/怪的数量(在下面的范围内随机刷的刷怪点)
        /// </summary>
        long Count { get; }
        /// <summary>
        /// 刷物/怪的数据数量和位置x和位置y(count|x,y|x,y|...|...)至少3个坐标点以上,是个一或多个三角的范围,物/怪在此三角范围内刷
        /// </summary>
        List<Point3D> Points { get; }
        /// <summary>
        /// 物/怪的方向
        /// </summary>
        long Direction { get; }
        /// <summary>
        /// 刷物/怪所需的最小数量(范围内少于此物/怪数量将马上刷,忽略刷的时间间隔)
        /// </summary>
        long MinSpawn { get; }
        /// <summary>
        /// 刷物/怪的时间间隔(据刷物/怪的类型: 怪物死亡后刷怪的时间间隔,或物品(采集/开箱)后刷的时间间隔......等)
        /// </summary>
        TimeSpan RespawnTime { get; }
    }
    #endregion
}
#endregion