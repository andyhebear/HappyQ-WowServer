using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Demo.Wow.WorldServer.Entity.Common;
using Demo.Mmose.Core.Network;
using Demo.Mmose.Core.Entity.Character;
using Demo.Mmose.Core.Entity;

namespace Demo.Wow.WorldServer.Creature
{
    /// <summary>
    /// 
    /// </summary>
    public partial class WowCreature : IWowUpdate
    {
        /// <summary>
        /// 
        /// </summary>
        public void BroadcastValueUpdate()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="updatingSelf"></param>
        public void ObjectCreationUpdate( Packet packet, bool updatingSelf )
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="character"></param>
        public void SendDestroyToPlayer( BaseCharacter character )
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        public virtual void OnUpdate( object sender, WorldEntityEventArgs eventArgs )
        {
            // AI 
            // 空闲时走动
            // 如果数据变动就广播数据
        }
    }
}
