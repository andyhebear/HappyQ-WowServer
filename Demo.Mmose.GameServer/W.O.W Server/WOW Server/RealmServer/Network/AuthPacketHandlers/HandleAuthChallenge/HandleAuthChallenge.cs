using System;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using Demo.Mmose.Core.Common.Srp;
using Demo.Mmose.Core.Network;
using Demo.Wow.RealmServer.Common;
using Demo.Mmose.Core.Common;

namespace Demo.Wow.RealmServer.Network
{
    /// <summary>
    /// 
    /// </summary>
    internal partial class Auth_PacketHandlers : BasePacketHandlers
    {
        /// <summary>
        /// ��½����
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="packetReader"></param>
        public static void Auth_HandleAuthChallenge( NetState netState, PacketReader packetReader )
        {

            AuthExtendData extendData = netState.GetComponent<AuthExtendData>( AuthExtendData.COMPONENT_ID );
            if ( extendData == null )
            {
                Debug.WriteLine( "Auth_PacketHandlers.Auth_HandleAuthChallenge(...) - extendData == null error!" );
                return;
            }

            if ( extendData.IsLoggedIn == true )
            {
                Debug.WriteLine( "Auth_PacketHandlers.Auth_HandleAuthChallenge(...) - extendData.IsLoggedIn == false error!" );
                return;
            }

            extendData.AuthChallenge.AuthLogonChallenge = AuthLogonChallenge.ReadAuthLogonChallenge( packetReader );

            // �汾��֤
            if ( extendData.AuthChallenge.AuthLogonChallenge.Build > (ushort)CLIENT_VERSIONS.CLIENT_MAX || extendData.AuthChallenge.AuthLogonChallenge.Build < (ushort)CLIENT_VERSIONS.CLIENT_MIN )
            {
                netState.Send( new Auth_AuthChallengeResultError( LogineErrorInfo.LOGIN_WRONG_BUILD_NUMBER ) );
                return;
            }

            // �ʺ��Ƿ����
            WowAccount wowAccount = WowAccountHandler.GetAccount( extendData.AuthChallenge.AuthLogonChallenge.AccountName );
            if ( wowAccount == null )
            {
                netState.Send( new Auth_AuthChallengeResultError( LogineErrorInfo.LOGIN_NO_ACCOUNT ) );
                return;
            }
            extendData.WowAccount = wowAccount;

            // �ʺ��Ƿ�ͣ��
            if ( wowAccount.Banned )
            {
                netState.Send( new Auth_AuthChallengeResultError( LogineErrorInfo.LOGIN_ACCOUNT_CLOSED ) );
                return;
            }

            // �ʺ��Ƿ�����
            if ( wowAccount.Locked )
            {
                netState.Send( new Auth_AuthChallengeResultError( LogineErrorInfo.LOGIN_ACCOUNT_FREEZED ) );
                return;
            }

            // �ɹ� ����IP
            WowAccountHandler.UpdateAccountLastIP( wowAccount.AccountName, netState.NetAddress.Address.ToString() );

            // ��½�ɹ�
            extendData.IsLoggedIn = true;

            // ��ȡSRP��Key
            extendData.SRP = new SecureRemotePassword( true, wowAccount.AccountName, wowAccount.Password );

            netState.Send( new Auth_AuthChallengeResult( extendData.SRP ) );
        }
    }
}
