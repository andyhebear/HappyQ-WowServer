using Demo.Mmose.Core.Common.Component;
using Demo.Mmose.Core.Entity.Character;
using Demo.Mmose.Core.Network;
using System.Collections.Generic;
using Demo.Wow.WorldServer.Character;

namespace Demo.Wow.WorldServer.Entity.Common
{
    /// <summary>
    /// 
    /// </summary>
    interface IWowUpdate : IComponent
    {
        /// <summary>
        /// 
        /// </summary>
        void BroadcastValueUpdate();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="updatingSelf"></param>
        void ObjectCreationUpdate( Packet packet, bool updatingSelf );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="character"></param>
        void SendDestroyToPlayer( BaseCharacter character );
    }

    /// <summary>
    /// 
    /// </summary>
    public class WowUpdate
	{
        /// <summary>
        /// 
        /// </summary>
        public readonly static ComponentId WOW_UPDATE_COMPONENT_ID = "IWowUpdate";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="character"></param>
        /// <param name="packet"></param>
        protected static void SendUpdatePacket( WowCharacter character, Packet packet )
        {
            character.NetState.Send( packet );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="characters"></param>
        /// <param name="packet"></param>
        protected static void SendUpdatePacket( IEnumerable<WowCharacter> characters, Packet packet )
        {
            foreach ( var character in characters )
                character.NetState.Send( packet );
        }
	}
}
