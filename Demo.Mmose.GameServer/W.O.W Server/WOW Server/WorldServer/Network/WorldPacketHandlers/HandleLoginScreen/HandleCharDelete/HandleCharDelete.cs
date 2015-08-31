using System.Diagnostics;
using System.Linq;
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Network;
using Demo.Mmose.Core.World;
using Demo.Wow.Database;
using Demo.Wow.Database.Ver1a;
using Demo.Wow.WorldServer.Server;
using DevExpress.Xpo;

namespace Demo.Wow.WorldServer.Network
{
    /// <summary>
    /// 
    /// </summary>
    internal partial class WorldPacketHandlers : BasePacketHandlers
    {
        internal static void World_HandleCharDelete( NetState netState, PacketReader packetReader )
        {
            LOGs.WriteLine( LogMessageType.MSG_ERROR, "World_HandleCharDelete!" );

            WorldExtendData extendData = netState.GetComponent<WorldExtendData>( WorldExtendData.COMPONENT_ID );
            if ( extendData == null )
            {
                Debug.WriteLine( "World_PacketHandlers.World_HandleCharDelete(...) - extendData == null error!" );
                return;
            }

            if ( extendData.IsLoggedIn == false )
            {
                Debug.WriteLine( "World_PacketHandlers.World_HandleCharDelete(...) - extendData.IsLoggedIn == false error!" );
                return;
            }

            ulong iGuid = packetReader.ReadULong64();

            CharDeleteSQL charEnumSQL = new CharDeleteSQL( extendData, netState, (long)iGuid );
            WaitExecuteInfo<CharDeleteSQL> waitExecuteInfo = new WaitExecuteInfo<CharDeleteSQL>( charEnumSQL, WorldPacketHandlers.SQL_HandleCharDelete );

            ProcessServer.WowZoneCluster.World.WaitExecute.JoinWaitExecuteQueue( waitExecuteInfo );
        }

        /// <summary>
        /// 
        /// </summary>
        private static void SQL_HandleCharDelete( CharDeleteSQL sqlInfo )
        {
            XPQuery<CharacterBase> characters = new XPQuery<CharacterBase>( OneDatabase.Session );

            var characterList = from character in characters
                               where character.Oid == sqlInfo.DelCharGuid
                               select character;

            bool bIsFinde = false;
            string strCharacterName = string.Empty;
            foreach ( CharacterBase character in characterList )
            {
                XPQuery<CharacterPet> creaturePets = new XPQuery<CharacterPet>( OneDatabase.Session );

                var creaturePetList = from creaturePet in creaturePets
                                      where creaturePet.Owner == character
                                      select creaturePet;

                foreach ( CharacterPet creaturePet in creaturePetList )
                    creaturePet.Delete();



                XPQuery<CharacterItem> characterItems = new XPQuery<CharacterItem>( OneDatabase.Session );

                var characterItemList = from characterItem in characterItems
                                        where characterItem.Owner == character
                                        select characterItem;

                foreach ( CharacterItem characterItem in characterItemList )
                    characterItem.Delete();



                character.Delete();
                OneDatabase.Session.CommitChanges();


                strCharacterName = character.CharacterName;
                bIsFinde = true;
                break;
            }

            if ( bIsFinde == false )
                sqlInfo.NetState.Send( new Word_CharDeleteResponseError( ResponseCodes.CHAR_DELETE_FAILED ) );
            else
            {
                ProcessServer.WowZoneCluster.World.GlobalPlayerInfo.RemovePlayerInfo( strCharacterName );

                sqlInfo.NetState.Send( new Word_CharDeleteResponse() );
            }

            CharEnumSQL charEnumSQL = new CharEnumSQL( sqlInfo.WorldExtendData, sqlInfo.NetState );
            WaitExecuteInfo<CharEnumSQL> waitExecuteInfo = new WaitExecuteInfo<CharEnumSQL>( charEnumSQL, WorldPacketHandlers.SQL_HandleCharEnum );

            ProcessServer.WowZoneCluster.World.WaitExecute.JoinWaitExecuteQueue( waitExecuteInfo );
        }
    }
}
