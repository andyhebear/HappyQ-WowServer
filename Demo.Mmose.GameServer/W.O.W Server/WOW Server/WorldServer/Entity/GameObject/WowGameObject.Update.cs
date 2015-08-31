using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Demo.Wow.WorldServer.Entity.Common;
using Demo.Mmose.Core.Network;
using Demo.Mmose.Core.Entity.Character;

namespace Demo.Wow.WorldServer.Object
{
    /// <summary>
    /// 
    /// </summary>
    public partial class WowGameObject : IWowUpdate
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
    }
}
