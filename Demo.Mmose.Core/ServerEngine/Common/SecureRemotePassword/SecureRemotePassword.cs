/* SRP Implementation - Version 1.0
 * 
 * By Joseph Gentle.
 * 
 * This code implements the SRP Authentication Protocol documented here:
 * http://srp.stanford.edu/
 * 
 * The algorithm is copyright The Stanford SRP Authentication Project,
 * distributed under this licence: http://srp.stanford.edu/license.txt
 *
 * This implementation is copyright Joseph Gentle.
 * 
 * Permission is hereby granted, free of charge, to any person obtaining
 * a copy of this software and associated documentation files (the
 * "Software"), to deal in the Software without restriction, including
 * without limitation the rights to use, copy, modify, merge, publish,
 * distribute, sublicense, and/or sell copies of the Software, and to
 * permit persons to whom the Software is furnished to do so, subject to
 * the following conditions:
 *
 * The above copyright notice and this permission notice shall be
 * included in all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS-IS" AND WITHOUT WARRANTY OF ANY KIND, 
 * EXPRESS, IMPLIED OR OTHERWISE, INCLUDING WITHOUT LIMITATION, ANY 
 * WARRANTY OF MERCHANTABILITY OR FITNESS FOR A PARTICULAR PURPOSE.  
 *
 * IN NO EVENT SHALL JOSEPH GENTLE BE LIABLE FOR ANY SPECIAL, INCIDENTAL,
 * INDIRECT OR CONSEQUENTIAL DAMAGES OF ANY KIND, OR ANY DAMAGES WHATSOEVER
 * RESULTING FROM LOSS OF USE, DATA OR PROFITS, WHETHER OR NOT ADVISED OF
 * THE POSSIBILITY OF DAMAGE, AND ON ANY THEORY OF LIABILITY, ARISING OUT
 * OF OR IN CONNECTION WITH THE USE OR PERFORMANCE OF THIS SOFTWARE.
 */

using System;
using System.IO;
using System.Security.Cryptography;

namespace Demo.Mmose.Core.Common.Srp
{
    /// <summary>
    /// This is an implementation of the SRP algorithm documented here:
    /// 
    /// http://srp.stanford.edu/design.html
    /// 
    ///
    /// Example code (though usually data is copied over the wire):
    /// 	SecureRemotePassword server = new SecureRemotePassword(true, "USER", "PASSWORD");
    ///		SecureRemotePassword client = new SecureRemotePassword(false, "USER", "PASSWORD");
    ///
    ///		server.PublicEphemeralValueA = client.PublicEphemeralValueA;
    ///		client.Salt = server.Salt;
    ///		client.PublicEphemeralValueB = server.PublicEphemeralValueB;
    ///
    ///		Console.WriteLine("Server's session key = {0}", server.SessionKey.ToHexString());
    ///		Console.WriteLine("Client's session key = {0}", client.SessionKey.ToHexString());
    ///
    ///		Console.WriteLine("\nServer key == client key {0}", server.SessionKey == client.SessionKey);
    ///
    ///		Console.WriteLine("Client proof valid: {0}", client.ClientSessionKeyProof == server.ClientSessionKeyProof);
    ///		Console.WriteLine("Server proof valid: {0}", client.ServerSessionKeyProof == server.ServerSessionKeyProof);
    /// </summary>
    public class SecureRemotePassword
    {
        #region zh-CHS 共有的SRPParameters类 | en Public SRPParameters Class
        /// <summary>
        /// 
        /// </summary>
        public class SRPParameters
        {
            #region zh-CHS 枚举 | en Enum
            /// <summary>
            /// Algorithm version. Consult specification for differences.
            /// </summary>
            public enum SRPVersion
            {
                /// <summary>
                /// 
                /// </summary>
                SRP6,
                /// <summary>
                /// 
                /// </summary>
                SRP6a,
            }
            #endregion

            #region zh-CHS 共有常量 | en Public Constants
            /// <summary>
            /// Maximum length of crypto keys in bytes.
            /// </summary>
            /// <remarks>You might get unlucky and have much shorter keys - this should be checked and keys recalculated.</remarks>
            public const uint KeyLength = 32;
            #endregion

            #region zh-CHS 共有属性 | en Public Properties
            #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
            /// <summary>
            /// Hashing function for the instance.
            /// </summary>
            /// <remarks>MD5 or other SHA hashes are usable, though SHA1 is more standard for SRP.</remarks>
            private HashAlgorithm m_Hash = new SHA1Managed();
            #endregion
            /// <summary>
            /// Hashing function for the instance.
            /// </summary>
            public HashAlgorithm Hash
            {
                get { return m_Hash; }
                set { m_Hash = value; }
            }

            #region zh-CHS 私有成员变量 | en Private Member Variables
            /// <summary>
            /// Version of this instance.
            /// </summary>
            private SRPVersion m_AlgorithmVersion = SRPVersion.SRP6;
            #endregion
            /// <summary>
            /// Version of this instance.
            /// </summary>
            public SRPVersion AlgorithmVersion
            {
                get { return m_AlgorithmVersion; }
                set { m_AlgorithmVersion = value; }
            }

            #region zh-CHS 私有成员变量 | en Private Member Variables
            /// <summary>
            /// 
            /// </summary>
            private BigInteger m_modulus = new BigInteger( "B79B3E2A87823CAB8F5EBFBF8EB10108535006298B5BADBD5B53E1895E644B89", 16 );
            #endregion
            /// <summary>
            /// All operations are mod this number. It should be a large prime.
            /// </summary>
            /// <remarks>Referred to as 'N' in the spec.</remarks>
            /// <remarks>Defaults to 128 bits.</remarks>
            public BigInteger Modulus
            {
                get { return m_modulus; }
                set { m_modulus = value; }
            }

            #region zh-CHS 私有成员变量 | en Private Member Variables
            /// <summary>
            /// 'g' in the spec. This number must be a generator in the finite field Modulus.
            /// </summary>
            private BigInteger m_generator = new BigInteger( 7 );
            #endregion
            /// <summary>
            /// 'g' in the spec. This number must be a generator in the finite field Modulus.
            /// </summary>
            public BigInteger Generator
            {
                get { return m_generator; }
                set { m_generator = value; }
            }

            #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
            /// <summary>
            /// 
            /// </summary>
            private bool m_CaseSensitive = false;
            #endregion
            /// <summary>
            /// 
            /// </summary>
            public bool CaseSensitive
            {
                get { return m_CaseSensitive; }
                set { m_CaseSensitive = value; }
            }
            #endregion

            #region zh-CHS 共有静态属性 | en Public Static Properties
            #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
            /// <summary>
            /// Random number generator for this instance.
            /// </summary>
            private static RandomNumberGenerator s_RandomGenerator = new RNGCryptoServiceProvider();
            #endregion
            /// <summary>
            /// 
            /// </summary>
            public static RandomNumberGenerator RandomGenerator
            {
                get { return s_RandomGenerator; }
                set { s_RandomGenerator = value; }
            }

            /// <summary>
            /// Default SRPParameters
            /// </summary>
            public static SRPParameters Defaults
            {
                get { return new SRPParameters(); }
            }
            #endregion
        }
        #endregion

        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        /// <param name="isServer"></param>
        public SecureRemotePassword( bool isServer )
            : this( isServer, SRPParameters.Defaults )
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isServer"></param>
        /// <param name="parameters"></param>
        public SecureRemotePassword( bool isServer, SRPParameters parameters )
        {
            m_srpParams = parameters;
            m_isServer = isServer;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="isServer"></param>
        public SecureRemotePassword( bool isServer, string username, string password )
            : this( isServer, username, password, SRPParameters.Defaults )
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="isServer"></param>
        /// <param name="parameters"></param>
        public SecureRemotePassword( bool isServer, string username, string password, SRPParameters parameters )
        {
            if ( parameters.CaseSensitive == false )
            {
                username = username.ToUpper();
                password = password.ToUpper();
            }

            m_srpParams = parameters;

            m_isServer = isServer;
            m_Username = username;
            m_Password = password;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="verifier"></param>
        /// <param name="salt"></param>
        public SecureRemotePassword( string username, BigInteger verifier, BigInteger salt )
            : this( username, verifier, salt, SRPParameters.Defaults )
        {
        }

        /// <summary>
        /// Make an SRP for user authentication. You use something like this when your
        /// verifier and salt are stored in a database
        /// </summary>
        /// <param name="username"></param>
        /// <param name="verifier"></param>
        /// <param name="salt"></param>
        /// <param name="parameters"></param>
        public SecureRemotePassword( string username, BigInteger verifier, BigInteger salt, SRPParameters parameters )
        {
            if ( parameters.CaseSensitive == false )
                username = username.ToUpper();

            m_srpParams = parameters;

            m_isServer = true;
            m_Username = username;
            Verifier = verifier;
            m_Salt = salt;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private SRPParameters m_srpParams = SRPParameters.Defaults;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public SRPParameters Parameters
        {
            get { return m_srpParams; }
            set { m_srpParams = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_isServer;
        #endregion
        /// <summary>
        /// Are we the server? This should be set before calculation commences.
        /// </summary>
        public bool IsServer
        {
            get { return m_isServer; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_Username;
        #endregion
        /// <summary>
        /// Correct username. This should be set before calculations happen.
        /// </summary>
        public string Username
        {
            get { return m_Username; }
            set { m_Username = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_Password;
        #endregion
        /// <summary>
        /// Correct (or, for the client, entered) password. This should be set before calculation happens.
        /// </summary>
        public string Password
        {
            get { return m_Password; }
            set { m_Password = value; }
        }

        #region Session key generation

        #region Hash functions
        /// <summary>
        /// 
        /// </summary>
        /// <param name="brokers"></param>
        /// <returns></returns>
        public BigInteger Hash( params HashUtilities.HashDataBroker[] brokers )
        {
            return HashUtilities.HashToBigInteger( Parameters.Hash, brokers );
        }
        #endregion

        #region Random number generation
        /// <summary>
        /// Generate a random number of a specified size
        /// </summary>
        /// <param name="size">Maximum size in bytes of the random number</param>
        /// <returns></returns>
        public static BigInteger RandomNumber( uint size )
        {
            byte[] buffer = new byte[size];

            SRPParameters.RandomGenerator.GetBytes( buffer );

            // Must make sure the most significant byte is not zero
            if ( buffer[0] == 0 )
                buffer[0] = 1;

            return new BigInteger( buffer );
        }

        /// <summary>
        /// Generate a random number of maximal size
        /// </summary>
        /// <returns></returns>
        public static BigInteger RandomNumber()
        {
            return RandomNumber( SRPParameters.KeyLength );
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        public BigInteger Modulus
        {
            get { return Parameters.Modulus; }
        }

        /// <summary>
        /// 
        /// </summary>
        public BigInteger Generator
        {
            get { return Parameters.Generator; }
        }

        /// <summary>
        /// 'k' in the spec. In SRP-6a k = H(N, g). Older versions have k = 3.
        /// </summary>
        public BigInteger Multiplier
        {
            get
            {
                if ( Parameters.AlgorithmVersion == SRPParameters.SRPVersion.SRP6 )
                    return (BigInteger)3;
                else
                    return Hash( Modulus, Generator );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Credentials
        {
            get { return string.Format( "{0}:{1}", Username, Password ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private BigInteger m_Salt = null;
        #endregion
        /// <summary>
        /// Salt for credentials hash. You can bind this to the users'
        /// account or use the automatically generated random salt.
        /// </summary>
        public BigInteger Salt
        {
            set { m_Salt = value; }
            get
            {
                if ( m_Salt == null )
                {
                    if ( IsServer == false )
                    {
                        throw new Exception( "Unknown salt! This should be set by the server." );
                    }
                    else
                    {
                        m_Salt = RandomNumber();
                    }
                }

                return m_Salt;
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private BigInteger m_CredentialsHash = null;
        #endregion
        /// <summary>
        /// 'x' in the spec. Note that this is slightly different - the spec says
        /// x = H(s, p) whereas here x = H(s, H(I, p)), which is the implementation in the demo.
        /// </summary>
        public BigInteger CredentialsHash
        {
            get
            {
                if ( m_CredentialsHash == null )
                    m_CredentialsHash = Hash( Salt, Hash( Credentials ) );

                return m_CredentialsHash;
            }
        }

        #region Client side
        /// <summary>
        /// 'a' in the spec. 
        /// </summary>
        private BigInteger m_secretEphemeralValueA = RandomNumber();
        /// <summary>
        /// 
        /// </summary>
        private BigInteger m_publicEphemeralValueA;
        #endregion

        #region Server Side
        /// <summary>
        /// 
        /// </summary>
        private BigInteger verifier;

        /// <summary>
        /// V in the spec.
        /// v = g^x (mod N)
        /// 
        /// This only makes sense for servers.
        /// </summary>
        public BigInteger Verifier
        {
            get
            {
                if ( verifier == null )
                {
                    verifier = Generator.ModPow( CredentialsHash, Modulus );
                }

                if ( verifier < 0 )
                {
                    verifier += Modulus;
                }

                return verifier;
            }
            set { verifier = value; }
        }

        /// <summary>
        /// 'b' in the spec
        /// </summary>
        private BigInteger m_secretEphemeralValueB;
        /// <summary>
        /// 
        /// </summary>
        private BigInteger m_publicEphemeralValueB;
        #endregion

        /// <summary>
        /// 'A' in the spec. A = g^a, generated by client and sent to the server
        /// </summary>
        public BigInteger PublicEphemeralValueA
        {
            get
            {
                // This guy is generated by the client and sent to the server
                if ( IsServer == false && m_publicEphemeralValueA == null )
                {
                    m_publicEphemeralValueA = Generator.ModPow( m_secretEphemeralValueA, Modulus );
                }

                return m_publicEphemeralValueA;
            }
            set
            {
                if ( IsServer == false )
                    throw new Exception( "Attempt by SRP client to set A. This is generated." );
                else
                {
                    m_publicEphemeralValueA = value;

                    m_publicEphemeralValueA %= Modulus;

                    if ( m_publicEphemeralValueA < 0 )
                    {
                        m_publicEphemeralValueA += Modulus;
                    }

                    if ( m_publicEphemeralValueA == 0 )
                    {
                        // Abort - we got hackers.
                        throw new InvalidDataException( "A cannot be 0 mod N!" );
                    }
                }
            }
        }

        /// <summary>
        /// 'B' in the spec. B = kv + g^b, generated by the server and sent to the client
        /// </summary>
        public BigInteger PublicEphemeralValueB
        {
            get
            {
                // This guy is generated by the server and sent to the client
                if ( IsServer && m_publicEphemeralValueB == null )
                {
                    m_secretEphemeralValueB = RandomNumber();
                    m_publicEphemeralValueB = Multiplier * Verifier + Generator.ModPow( m_secretEphemeralValueB, Modulus );
                    m_publicEphemeralValueB %= Modulus;

                    if ( m_publicEphemeralValueB < 0 )
                    {
                        m_publicEphemeralValueB += Modulus;
                    }
                }

                return m_publicEphemeralValueB;
            }
            set
            {
                if ( IsServer )
                    throw new Exception( "Attempt by SRP server to set B. This is generated." );
                else
                {
                    m_publicEphemeralValueB = value;
                    m_publicEphemeralValueB %= Modulus;
                    if ( m_publicEphemeralValueB < 0 )
                        m_publicEphemeralValueB += Modulus;

                    if ( m_publicEphemeralValueB == 0 )
                    {
                        // Abort - we got hackers.
                        throw new InvalidDataException( "B cannot be 0 mod N!" );
                    }
                }
            }
        }

        /// <summary>
        /// u in the spec. Generated by both server and client.
        /// </summary>
        public BigInteger ScramblingParameter
        {
            get { return Hash( PublicEphemeralValueA, PublicEphemeralValueB ); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private BigInteger m_SessionKey = null;
        #endregion
        /// <summary>
        /// This is the session key used for encryption later.
        /// 'K' in the spec. Note that this is different to 'k' (Multiplier)
        /// </summary>
        public BigInteger SessionKeyRaw
        {
            get
            {
                if ( m_SessionKey == null )
                {
                    BigInteger S;
                    if ( IsServer )
                    {
                        if ( m_publicEphemeralValueA == null )
                            return null;

                        // S = (Av^u) ^ b (mod N)
                        S = Verifier.ModPow( ScramblingParameter, Modulus );
                        S = ( S * PublicEphemeralValueA ) % Modulus;
                        S = S.ModPow( m_secretEphemeralValueB, Modulus );
                    }
                    else
                    {
                        // S = (B - kg^x) ^ (a + ux) (mod N)
                        S = PublicEphemeralValueB - ( Multiplier * Generator.ModPow( CredentialsHash, Modulus ) );
                        S = S.ModPow( m_secretEphemeralValueA + ScramblingParameter * CredentialsHash, Modulus );

                        // If S flips negative above the mod function preserves its sign.
                        // We want it positive.
                        if ( S < 0 )
                            S += Modulus;
                    }

                    m_SessionKey = S;
                }

                return m_SessionKey;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public BigInteger SessionKey
        {
            get
            {
                byte[] data = SessionKeyRaw.GetBytes( 32 );

                // This is a strange beast.
                byte[] temp = new byte[16];
                for ( int i = 0; i < temp.Length; i++ )
                {
                    temp[i] = data[2 * i];
                }
                byte[] hash1 = Hash( temp ).GetBytes( 20 );

                for ( int i = 0; i < temp.Length; i++ )
                {
                    temp[i] = data[2 * i + 1];
                }
                byte[] hash2 = Hash( temp ).GetBytes( 20 );

                // its an interleaving of the two hashes..
                data = new byte[40];

                for ( int i = 0; i < data.Length; i++ )
                {
                    if ( i % 2 == 0 )
                        data[i] = hash1[i / 2];
                    else
                        data[i] = hash2[i / 2];
                }

                return new BigInteger( data );
            }
        }

        #endregion

        /// <summary>
        /// Referred to as 'M' in the documentation. This is used for authentication.
        /// 
        /// The client sends this value to the server and the server calculates it locally to verify it.
        /// The same then happens with ServerSessionKeyProof. Note ClientSessionKeyProof should come first.
        /// </summary>
        public BigInteger ClientSessionKeyProof
        {
            get
            {
                return Hash( Hash( Modulus ) ^ Hash( Generator ), Hash( Username ), Salt, PublicEphemeralValueA, PublicEphemeralValueB, SessionKey );
            }
        }

        public bool IsClientProofValid( BigInteger clientProof )
        {
            return ClientSessionKeyProof == clientProof;
        }

        /// <summary>
        /// The server sends this to the client as proof it has the same session key as the client.
        /// The client will calculate this locally to verify.
        /// </summary>
        public BigInteger ServerSessionKeyProof
        {
            get { return Hash( PublicEphemeralValueA, ClientSessionKeyProof, SessionKey ); }
        }

        public bool IsServerProofValid( BigInteger serverProof )
        {
            return serverProof == ServerSessionKeyProof;
        }
        #endregion

        #region zh-CHS 共有方法 | en Public Methods
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string InternalsToString()
        {
            string type = IsServer ? "server" : "client";
            string str = string.Format( "SRP {0} Internals:\n", type );

            str += string.Format( "G      = {0}\n", Generator.ToHexString() );
            str += string.Format( "K      = {0}\n", Multiplier.ToHexString() );
            str += string.Format( "N      = {0}\n", Modulus.ToHexString() );

            str += string.Format( "I      = '{0}'\n", Credentials );
            str += string.Format( "Hash(I)= {0}\n", Hash( Credentials ).ToHexString() );
            str += string.Format( "X      = {0}\n", CredentialsHash.ToHexString() );
            str += string.Format( "V      = {0}\n", Verifier.ToHexString() );
            if ( m_Salt != null )
                str += string.Format( "Salt   = {0}\n", Salt.ToHexString() );
            if ( null != m_publicEphemeralValueA && null != m_publicEphemeralValueB )
            {
                str += string.Format( "u      = {0}\n", ScramblingParameter.ToHexString() );
                str += string.Format( "h(A)   = {0}\n", Hash( PublicEphemeralValueA ).ToHexString() );
                str += string.Format( "h(B)   = {0}\n", Hash( PublicEphemeralValueB.GetBytes() ).ToHexString() );
            }

            if ( IsServer == false || PublicEphemeralValueA != null )
                str += string.Format( "A      = {0}\n", PublicEphemeralValueA.ToHexString() );
            if ( IsServer || PublicEphemeralValueB != null )
            {
                str += string.Format( "B      = {0}\n", PublicEphemeralValueB.ToHexString() );
                BigInteger tmp = Multiplier * Generator.ModPow( CredentialsHash, Modulus );
                str += string.Format( "kg^x   = {0}\n", tmp.ToHexString() );
                tmp = PublicEphemeralValueB - tmp % Modulus;
                if ( tmp < 0 )
                    tmp += Modulus;
                str += string.Format( "B-kg^x = {0}\n", tmp.ToHexString() );
            }

            try
            {
                str += string.Format( "S.key  = {0}\n", SessionKey.ToHexString() );
            }
            catch
            {
                str += "S.key  = empty\n";
            }

            return str;
        }
        #endregion

        #region zh-CHS 共有静态方法 | en Public Static Methods
        /// <summary>
        /// 
        /// </summary>
        public static void Test()
        {
            SecureRemotePassword server = new SecureRemotePassword( true, "USER", "PASSWORD", SRPParameters.Defaults );
            SecureRemotePassword client = new SecureRemotePassword( false, "USER", "PASSWORD", SRPParameters.Defaults );

            /* Typical communication works something like this:
             * 
             * client: I want to log in. Here is my username and here is my PublicEphemeralValueA.
             * server: Here is the Salt and here is my PublicEphemeralValueB.
             * 
             * Server looks up the username in the database and finds the associated password.
             * 
             * client: Here's proof I have the correct session key (hence correct password)
             *         (sends client.ClientSessionKeyProof)
             * server: Thats valid. Here's proof that *I* have the correct session key:
             *         (sends server.ServerSessionKeyProof)
             * 
             * client: Cheerio. *encrypts stuff using SessionKey*
             */
            Console.WriteLine( "Client sending A = {0}", client.PublicEphemeralValueA.ToHexString() );
            server.PublicEphemeralValueA = client.PublicEphemeralValueA;

            Console.WriteLine( "Server sending salt = {0}", server.Salt.ToHexString() );
            Console.WriteLine( "Server sending B = {0}", server.PublicEphemeralValueB.ToHexString() );
            client.Salt = server.Salt;
            client.PublicEphemeralValueB = server.PublicEphemeralValueB;

            /*
                Console.WriteLine("X = {0}", server.CredentialsHash.ToHexString());
                Console.WriteLine("a = {0}", client.secretEphemeralValueA.ToHexString());
                Console.WriteLine("b = {0}", server.secretEphemeralValueB.ToHexString());
                Console.WriteLine("v = {0}", server.Verifier.ToHexString());
                Console.WriteLine("U = {0}", server.ScramblingParameter.ToHexString());
                */

            // Note that session keys are never sent.
            Console.WriteLine( "Server's session key = {0}", server.SessionKey.ToHexString() );
            Console.WriteLine( "Client's session key = {0}", client.SessionKey.ToHexString() );

            // Are the session keys actually the same?
            Console.WriteLine( "\nServer key == client key {0}", server.SessionKey == client.SessionKey );

            // This is how we can test it without sending actual session keys over the wire
            Console.WriteLine( "Client proof valid: {0}", server.IsClientProofValid( client.ClientSessionKeyProof ) );
            Console.WriteLine( "Server proof valid: {0}", client.IsServerProofValid( server.ServerSessionKeyProof ) );
        }
        #endregion
    }
}