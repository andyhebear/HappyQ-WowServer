using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Demo.Mmose.Core.Common.Srp
{
    /// <summary>
    /// Provides facilities for performing common-but-specific
    /// cryptographical operations
    /// </summary>
    public sealed class HashUtilities
    {
        #region zh-CHS 共有的类 | en Public Class
        /// <summary>
        /// Brokers various data types into their integral raw
        /// form for usage by other cryptographical functions
        /// </summary>
        public class HashDataBroker
        {
            #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
            /// <summary>
            /// Default constructor
            /// </summary>
            /// <param name="data">the data to broker</param>
            public HashDataBroker( byte[] data )
            {
                m_RawData = data;
            }
            #endregion

            #region zh-CHS 内部属性 | en Internal Properties
            #region zh-CHS 私有成员变量 | en Private Member Variables
            /// <summary>
            /// 
            /// </summary>
            private byte[] m_RawData = null;
            #endregion
            /// <summary>
            /// 
            /// </summary>
            internal byte[] RawData
            {
                get { return m_RawData; }
            }

            /// <summary>
            /// 
            /// </summary>
            internal int Length
            {
                get { return m_RawData.Length; }
            }
            #endregion

            #region zh-CHS 共有静态属性 | en Public Static Properties
            /// <summary>
            /// Implicit operator for byte[]->HashDataBroker casts
            /// </summary>
            /// <param name="data">the data to broker</param>
            /// <returns>a HashDataBroker object representing the original data</returns>
            public static implicit operator HashDataBroker( byte[] data )
            {
                return new HashDataBroker( data );
            }

            /// <summary>
            /// Implicit operator for string->HashDataBroker casts
            /// </summary>
            /// <param name="str">the data to broker</param>
            /// <returns>a HashDataBroker object representing the original data</returns>
            public static implicit operator HashDataBroker( string str )
            {
                return new HashDataBroker( Encoding.ASCII.GetBytes( str ) );
            }

            /// <summary>
            /// Implicit operator for BigInteger->HashDataBroker casts
            /// </summary>
            /// <param name="integer">the data to broker</param>
            /// <returns>a HashDataBroker object representing the original data</returns>
            public static implicit operator HashDataBroker( BigInteger bigInteger )
            {
                return new HashDataBroker( bigInteger.GetBytes() );
            }

            /// <summary>
            /// Implicit operator for uint->HashDataBroker casts
            /// </summary>
            /// <param name="integer">the data to broker</param>
            /// <returns>a HashDataBroker object representing the original data</returns>
            public static implicit operator HashDataBroker( uint integer )
            {
                return new HashDataBroker( new BigInteger( integer ).GetBytes() );
            }
            #endregion
        }
        #endregion

        #region zh-CHS 共有静态事件 | en Public Static Event
        /// <summary>
        /// Computes a hash from hash data brokers using the given
        /// hashing algorithm
        /// </summary>
        /// <param name="algorithm">the hashing algorithm to use</param>
        /// <param name="brokers">the data brokers to hash</param>
        /// <returns>the hash result of all the data brokers</returns>
        public static byte[] FinalizeHash( HashAlgorithm algorithm, params HashDataBroker[] dataBrokers )
        {
            MemoryStream memoryStream = new MemoryStream();

            foreach ( HashDataBroker broker in dataBrokers )
                memoryStream.Write( broker.RawData, 0, broker.Length );

            memoryStream.Seek( 0, SeekOrigin.Begin );
            return algorithm.ComputeHash( memoryStream );
        }

        /// <summary>
        /// Computes a hash from hash data brokers using the given 
        /// hash algorithm, and generates a BigInteger from it
        /// </summary>
        /// <param name="algorithm"></param>
        /// <param name="brokers"></param>
        /// <returns></returns>
        public static BigInteger HashToBigInteger( HashAlgorithm algorithm, params HashDataBroker[] dataBrokers )
        {
            return new BigInteger( FinalizeHash( algorithm, dataBrokers ) );
        }
        #endregion
    }
}