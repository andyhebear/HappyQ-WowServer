using Demo.Mmose.Core.Common.Srp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 SecureRemotePasswordTest 的测试类，旨在
    ///包含所有 SecureRemotePasswordTest 单元测试
    ///</summary>
    [TestClass()]
    public class SecureRemotePasswordTest
    {
        private TestContext testContextInstance;
        /// <summary>
        ///获取或设置测试上下文，上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        #region 附加测试属性
        // 
        //编写测试时，还可使用以下属性:
        //
        //使用 ClassInitialize 在运行类中的第一个测试前先运行代码
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //使用 ClassCleanup 在运行完类中的所有测试后再运行代码
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //使用 TestInitialize 在运行每个测试前先运行代码
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //使用 TestCleanup 在运行完每个测试后运行代码
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        /// <summary>
        ///Verifier 的测试
        ///</summary>
        [TestMethod()]
        public void VerifierTest()
        {
            bool isServer = false; // TODO: 初始化为适当的值
            SecureRemotePassword target = new SecureRemotePassword( isServer ); // TODO: 初始化为适当的值
            BigInteger expected = null; // TODO: 初始化为适当的值
            BigInteger actual;
            target.Verifier = expected;
            actual = target.Verifier;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Username 的测试
        ///</summary>
        [TestMethod()]
        public void UsernameTest()
        {
            bool isServer = false; // TODO: 初始化为适当的值
            SecureRemotePassword target = new SecureRemotePassword( isServer ); // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            target.Username = expected;
            actual = target.Username;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///SessionKeyRaw 的测试
        ///</summary>
        [TestMethod()]
        public void SessionKeyRawTest()
        {
            bool isServer = false; // TODO: 初始化为适当的值
            SecureRemotePassword target = new SecureRemotePassword( isServer ); // TODO: 初始化为适当的值
            BigInteger actual;
            actual = target.SessionKeyRaw;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///SessionKey 的测试
        ///</summary>
        [TestMethod()]
        public void SessionKeyTest()
        {
            bool isServer = false; // TODO: 初始化为适当的值
            SecureRemotePassword target = new SecureRemotePassword( isServer ); // TODO: 初始化为适当的值
            BigInteger actual;
            actual = target.SessionKey;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ServerSessionKeyProof 的测试
        ///</summary>
        [TestMethod()]
        public void ServerSessionKeyProofTest()
        {
            bool isServer = false; // TODO: 初始化为适当的值
            SecureRemotePassword target = new SecureRemotePassword( isServer ); // TODO: 初始化为适当的值
            BigInteger actual;
            actual = target.ServerSessionKeyProof;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ScramblingParameter 的测试
        ///</summary>
        [TestMethod()]
        public void ScramblingParameterTest()
        {
            bool isServer = false; // TODO: 初始化为适当的值
            SecureRemotePassword target = new SecureRemotePassword( isServer ); // TODO: 初始化为适当的值
            BigInteger actual;
            actual = target.ScramblingParameter;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Salt 的测试
        ///</summary>
        [TestMethod()]
        public void SaltTest()
        {
            bool isServer = false; // TODO: 初始化为适当的值
            SecureRemotePassword target = new SecureRemotePassword( isServer ); // TODO: 初始化为适当的值
            BigInteger expected = null; // TODO: 初始化为适当的值
            BigInteger actual;
            target.Salt = expected;
            actual = target.Salt;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///PublicEphemeralValueB 的测试
        ///</summary>
        [TestMethod()]
        public void PublicEphemeralValueBTest()
        {
            bool isServer = false; // TODO: 初始化为适当的值
            SecureRemotePassword target = new SecureRemotePassword( isServer ); // TODO: 初始化为适当的值
            BigInteger expected = null; // TODO: 初始化为适当的值
            BigInteger actual;
            target.PublicEphemeralValueB = expected;
            actual = target.PublicEphemeralValueB;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///PublicEphemeralValueA 的测试
        ///</summary>
        [TestMethod()]
        public void PublicEphemeralValueATest()
        {
            bool isServer = false; // TODO: 初始化为适当的值
            SecureRemotePassword target = new SecureRemotePassword( isServer ); // TODO: 初始化为适当的值
            BigInteger expected = null; // TODO: 初始化为适当的值
            BigInteger actual;
            target.PublicEphemeralValueA = expected;
            actual = target.PublicEphemeralValueA;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Password 的测试
        ///</summary>
        [TestMethod()]
        public void PasswordTest()
        {
            bool isServer = false; // TODO: 初始化为适当的值
            SecureRemotePassword target = new SecureRemotePassword( isServer ); // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            target.Password = expected;
            actual = target.Password;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Parameters 的测试
        ///</summary>
        [TestMethod()]
        public void ParametersTest()
        {
            bool isServer = false; // TODO: 初始化为适当的值
            SecureRemotePassword target = new SecureRemotePassword( isServer ); // TODO: 初始化为适当的值
            SecureRemotePassword.SRPParameters expected = null; // TODO: 初始化为适当的值
            SecureRemotePassword.SRPParameters actual;
            target.Parameters = expected;
            actual = target.Parameters;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Multiplier 的测试
        ///</summary>
        [TestMethod()]
        public void MultiplierTest()
        {
            bool isServer = false; // TODO: 初始化为适当的值
            SecureRemotePassword target = new SecureRemotePassword( isServer ); // TODO: 初始化为适当的值
            BigInteger actual;
            actual = target.Multiplier;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Modulus 的测试
        ///</summary>
        [TestMethod()]
        public void ModulusTest()
        {
            bool isServer = false; // TODO: 初始化为适当的值
            SecureRemotePassword target = new SecureRemotePassword( isServer ); // TODO: 初始化为适当的值
            BigInteger actual;
            actual = target.Modulus;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IsServer 的测试
        ///</summary>
        [TestMethod()]
        public void IsServerTest()
        {
            bool isServer = false; // TODO: 初始化为适当的值
            SecureRemotePassword target = new SecureRemotePassword( isServer ); // TODO: 初始化为适当的值
            bool actual;
            actual = target.IsServer;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Generator 的测试
        ///</summary>
        [TestMethod()]
        public void GeneratorTest()
        {
            bool isServer = false; // TODO: 初始化为适当的值
            SecureRemotePassword target = new SecureRemotePassword( isServer ); // TODO: 初始化为适当的值
            BigInteger actual;
            actual = target.Generator;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///CredentialsHash 的测试
        ///</summary>
        [TestMethod()]
        public void CredentialsHashTest()
        {
            bool isServer = false; // TODO: 初始化为适当的值
            SecureRemotePassword target = new SecureRemotePassword( isServer ); // TODO: 初始化为适当的值
            BigInteger actual;
            actual = target.CredentialsHash;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Credentials 的测试
        ///</summary>
        [TestMethod()]
        public void CredentialsTest()
        {
            bool isServer = false; // TODO: 初始化为适当的值
            SecureRemotePassword target = new SecureRemotePassword( isServer ); // TODO: 初始化为适当的值
            string actual;
            actual = target.Credentials;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ClientSessionKeyProof 的测试
        ///</summary>
        [TestMethod()]
        public void ClientSessionKeyProofTest()
        {
            bool isServer = false; // TODO: 初始化为适当的值
            SecureRemotePassword target = new SecureRemotePassword( isServer ); // TODO: 初始化为适当的值
            BigInteger actual;
            actual = target.ClientSessionKeyProof;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Test 的测试
        ///</summary>
        [TestMethod()]
        public void TestTest()
        {
            SecureRemotePassword.Test();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///RandomNumber 的测试
        ///</summary>
        [TestMethod()]
        public void RandomNumberTest1()
        {
            uint size = 0; // TODO: 初始化为适当的值
            BigInteger expected = null; // TODO: 初始化为适当的值
            BigInteger actual;
            actual = SecureRemotePassword.RandomNumber( size );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///RandomNumber 的测试
        ///</summary>
        [TestMethod()]
        public void RandomNumberTest()
        {
            BigInteger expected = null; // TODO: 初始化为适当的值
            BigInteger actual;
            actual = SecureRemotePassword.RandomNumber();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IsServerProofValid 的测试
        ///</summary>
        [TestMethod()]
        public void IsServerProofValidTest()
        {
            bool isServer = false; // TODO: 初始化为适当的值
            SecureRemotePassword target = new SecureRemotePassword( isServer ); // TODO: 初始化为适当的值
            BigInteger server_proof = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.IsServerProofValid( server_proof );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IsClientProofValid 的测试
        ///</summary>
        [TestMethod()]
        public void IsClientProofValidTest()
        {
            bool isServer = false; // TODO: 初始化为适当的值
            SecureRemotePassword target = new SecureRemotePassword( isServer ); // TODO: 初始化为适当的值
            BigInteger client_proof = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.IsClientProofValid( client_proof );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///InternalsToString 的测试
        ///</summary>
        [TestMethod()]
        public void InternalsToStringTest()
        {
            bool isServer = false; // TODO: 初始化为适当的值
            SecureRemotePassword target = new SecureRemotePassword( isServer ); // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = target.InternalsToString();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Hash 的测试
        ///</summary>
        [TestMethod()]
        public void HashTest()
        {
            bool isServer = false; // TODO: 初始化为适当的值
            SecureRemotePassword target = new SecureRemotePassword( isServer ); // TODO: 初始化为适当的值
            HashUtilities.HashDataBroker[] brokers = null; // TODO: 初始化为适当的值
            BigInteger expected = null; // TODO: 初始化为适当的值
            BigInteger actual;
            actual = target.Hash( brokers );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///SecureRemotePassword 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void SecureRemotePasswordConstructorTest5()
        {
            bool isServer = false; // TODO: 初始化为适当的值
            string username = string.Empty; // TODO: 初始化为适当的值
            string password = string.Empty; // TODO: 初始化为适当的值
            SecureRemotePassword target = new SecureRemotePassword( isServer, username, password );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        /// <summary>
        ///SecureRemotePassword 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void SecureRemotePasswordConstructorTest4()
        {
            bool isServer = false; // TODO: 初始化为适当的值
            SecureRemotePassword.SRPParameters parameters = null; // TODO: 初始化为适当的值
            SecureRemotePassword target = new SecureRemotePassword( isServer, parameters );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        /// <summary>
        ///SecureRemotePassword 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void SecureRemotePasswordConstructorTest3()
        {
            bool isServer = false; // TODO: 初始化为适当的值
            SecureRemotePassword target = new SecureRemotePassword( isServer );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        /// <summary>
        ///SecureRemotePassword 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void SecureRemotePasswordConstructorTest2()
        {
            string username = string.Empty; // TODO: 初始化为适当的值
            BigInteger verifier = null; // TODO: 初始化为适当的值
            BigInteger salt = null; // TODO: 初始化为适当的值
            SecureRemotePassword.SRPParameters parameters = null; // TODO: 初始化为适当的值
            SecureRemotePassword target = new SecureRemotePassword( username, verifier, salt, parameters );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        /// <summary>
        ///SecureRemotePassword 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void SecureRemotePasswordConstructorTest1()
        {
            string username = string.Empty; // TODO: 初始化为适当的值
            BigInteger verifier = null; // TODO: 初始化为适当的值
            BigInteger salt = null; // TODO: 初始化为适当的值
            SecureRemotePassword target = new SecureRemotePassword( username, verifier, salt );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        /// <summary>
        ///SecureRemotePassword 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void SecureRemotePasswordConstructorTest()
        {
            bool isServer = false; // TODO: 初始化为适当的值
            string username = string.Empty; // TODO: 初始化为适当的值
            string password = string.Empty; // TODO: 初始化为适当的值
            SecureRemotePassword.SRPParameters parameters = null; // TODO: 初始化为适当的值
            SecureRemotePassword target = new SecureRemotePassword( isServer, username, password, parameters );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
