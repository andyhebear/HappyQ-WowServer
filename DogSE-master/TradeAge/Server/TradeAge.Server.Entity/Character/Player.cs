﻿using System;
using DogSE.Common;
using DogSE.Server.Core.Net;
using TradeAge.Server.Entity.Common;


namespace TradeAge.Server.Entity.Character
{
    /// <summary>
    /// 玩家（存储数据）
    /// </summary>
    public partial class  Player
    {
        /// <summary>
        /// 玩家的唯一标示
        /// </summary>
        public int Id { get; set; }


        /// <summary>
        /// 角色名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 理论上id和账号id一一对应，这里的目的是为了单个账号对应多角色做的冗余设计
        /// </summary>
        public int AccountId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 上一次登录时间
        /// </summary>
        public DateTime LastLoginTime { get; set; }

        /// <summary>
        /// 上一次登出时间
        /// </summary>
        public DateTime LastLogoffTime { get; set; }

        /// <summary>
        /// 累计的在线时间，在离线时修改
        /// 单位：秒
        /// </summary>
        /// <remarks>
        /// 不用精确到毫秒，因为玩家的在线时间是一个很长的时间，
        /// 毫秒的单位对大的数据来说不会产生偏差影响
        /// </remarks>
        public int OnlineTime { get; set; }

        /// <summary>
        /// 玩家当前的位置
        /// </summary>
        public Vector3 Postion { get; set; }

        /// <summary>
        /// 方向已经速度
        /// </summary>
        public Vector3 Direction { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public Sex Sex { get; set; }

        public NetState NetState { get; set; }
    }
}
