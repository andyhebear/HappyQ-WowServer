using System;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using Demo.Mmose.Core.Network;
using Demo.Wow.RealmServer.Common;

namespace Demo.Wow.RealmServer.Network
{
    /// <summary>
    /// 
    /// </summary>
    internal partial class Auth_PacketHandlers : BasePacketHandlers
    {
        /// <summary>
        /// 登陆验证
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="packetReader"></param>
        public static void Auth_HandleAuthProof( NetState netState, PacketReader packetReader )
        {
            AuthExtendData extendData = netState.GetComponent<AuthExtendData>( AuthExtendData.COMPONENT_ID );
            if ( extendData == null )
            {
                Debug.WriteLine( "Auth_PacketHandlers.Auth_AuthProof(...) - extendData == null error!" );
                return;
            }

            if ( extendData.IsLoggedIn == false )
            {
                Debug.WriteLine( "Auth_PacketHandlers.Auth_AuthProof(...) - extendData.IsLoggedIn == false error!" );
                return;
            }

            extendData.AuthProof.AuthLogonProof = AuthLogonProof.ReadAuthLogonProof( packetReader );

            extendData.SRP.PublicEphemeralValueA = extendData.AuthProof.AuthLogonProof.PublicEphemeralValueA;

            if ( extendData.SRP.IsClientProofValid( extendData.AuthProof.AuthLogonProof.ClientProof ) == false )
            {
                // Authentication failed.
                //netState.Send( new RealmList_AuthProofResultError( RealmListErrorsInfo.LOGIN_NO_ACCOUNT ) );
                netState.Send( new Auth_AuthChallengeResultError( LogineErrorInfo.LOGIN_NO_ACCOUNT ) );
                return;
            }

            // 添加到全局的Key中
            SrpHandler.AddSRP( extendData.WowAccount.AccountName, extendData.SRP );

            // we're authenticated now :)
            extendData.IsAuthenticated = true;

            netState.Send( new Auth_AuthProofResult( extendData.SRP ) );
        }
    }
}
