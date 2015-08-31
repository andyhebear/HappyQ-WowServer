using Demo.Mmose.Core.Common.Srp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security.Cryptography;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 SecureRemotePassword_SRPParametersTest 的测试类，旨在
    ///包含所有 SecureRemotePassword_SRPParametersTest 单元测试
    ///</summary>
    [TestClass()]
    public class SecureRemotePassword_SRPParametersTest
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
        ///RandomGenerator 的测试
        ///</summary>
        [TestMethod()]
        public void RandomGeneratorTest()
        {
            RandomNumberGenerator expected = null; // TODO: 初始化为适当的值
            RandomNumberGenerator actual;
            SecureRemotePassword.SRPParameters.RandomGenerator = expected;
            actual = SecureRemotePassword.SRPParameters.RandomGenerator;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Modulus 的测试
        ///</summary>
        [TestMethod()]
        public void ModulusTest()
        {
            SecureRemotePassword.SRPParameters target = new SecureRemotePassword.SRPParameters(); // TODO: 初始化为适当的值
            BigInteger expected = null; // TODO: 初始化为适当的值
            BigInteger actual;
            target.Modulus = expected;
            actual = target.Modulus;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Hash 的测试
        ///</summary>
        [TestMethod()]
        public void HashTest()
        {
            SecureRemotePassword.SRPParameters target = new SecureRemotePassword.SRPParameters(); // TODO: 初始化为适当的值
            HashAlgorithm expected = null; // TODO: 初始化为适当的值
            HashAlgorithm actual;
            target.Hash = expected;
            actual = target.Hash;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Generator 的测试
        ///</summary>
        [TestMethod()]
        public void GeneratorTest()
        {
            SecureRemotePassword.SRPParameters target = new SecureRemotePassword.SRPParameters(); // TODO: 初始化为适当的值
            BigInteger expected = null; // TODO: 初始化为适当的值
            BigInteger actual;
            target.Generator = expected;
            actual = target.Generator;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Defaults 的测试
        ///</summary>
        [TestMethod()]
        public void DefaultsTest()
        {
            SecureRemotePassword.SRPParameters actual;
            actual = SecureRemotePassword.SRPParameters.Defaults;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///CaseSensitive 的测试
        ///</summary>
        [TestMethod()]
        public void CaseSensitiveTest()
        {
            SecureRemotePassword.SRPParameters target = new SecureRemotePassword.SRPParameters(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            target.CaseSensitive = expected;
            actual = target.CaseSensitive;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///AlgorithmVersion 的测试
        ///</summary>
        [TestMethod()]
        public void AlgorithmVersionTest()
        {
            SecureRemotePassword.SRPParameters target = new SecureRemotePassword.SRPParameters(); // TODO: 初始化为适当的值
            SecureRemotePassword.SRPParameters.SRPVersion expected = new SecureRemotePassword.SRPParameters.SRPVersion(); // TODO: 初始化为适当的值
            SecureRemotePassword.SRPParameters.SRPVersion actual;
            target.AlgorithmVersion = expected;
            actual = target.AlgorithmVersion;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///SRPParameters 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void SecureRemotePassword_SRPParametersConstructorTest()
        {
            SecureRemotePassword.SRPParameters target = new SecureRemotePassword.SRPParameters();
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
