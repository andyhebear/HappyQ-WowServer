using System;
using System.Text;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using Demo.Mmose.Core.World;
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Network;
using Demo.Wow.Database;
using Demo.Wow.WorldServer.Server;
using Demo.Wow.Database.Ver1a;
using DevExpress.Xpo;

namespace Demo.Wow.WorldServer.Network
{
    /// <summary>
    /// 
    /// </summary>
    internal partial class WorldPacketHandlers : BasePacketHandlers
    {
        internal static void World_HandleCharRename( NetState netState, PacketReader packetReader )
        {
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
            string strName = packetReader.ReadUTF8String();

            if ( ProcessServer.WowZoneCluster.World.GlobalPlayerInfo.GetPlayerInfo( strName ) != null )
            {
                netState.Send( new Word_CharCreateResponseError( ResponseCodes.CHAR_CREATE_NAME_IN_USE ) );
                return;
            }

            CharRenameSQL charEnumSQL = new CharRenameSQL( extendData, netState, (long)iGuid, strName );
            WaitExecuteInfo<CharRenameSQL> waitExecuteInfo = new WaitExecuteInfo<CharRenameSQL>( charEnumSQL, WorldPacketHandlers.SQL_HandleCharRename );

            ProcessServer.WowZoneCluster.World.WaitExecute.JoinWaitExecuteQueue( waitExecuteInfo );
        }

        /// <summary>
        /// 
        /// </summary>
        private static void SQL_HandleCharRename( CharRenameSQL sqlInfo )
        {
            XPQuery<CharacterBase> characters = new XPQuery<CharacterBase>( OneDatabase.Session );

            var characterList = from character in characters
                                where character.Oid == sqlInfo.RenCharGuid
                                select character;


            bool bIsFind = false;
            foreach ( CharacterBase character in characterList )
            {
                character.CharacterName = sqlInfo.CharacterName;

                character.Save();

                OneDatabase.Session.CommitChanges();

                bIsFind = true;
                break;
            }

            if ( bIsFind == false )
                sqlInfo.NetState.Send( new Word_CharRenameResponseError( ResponseCodes.CHAR_CREATE_NAME_IN_USE ) );
            else
                sqlInfo.NetState.Send( new Word_CharRenameResponse() );
        }
    }
}
