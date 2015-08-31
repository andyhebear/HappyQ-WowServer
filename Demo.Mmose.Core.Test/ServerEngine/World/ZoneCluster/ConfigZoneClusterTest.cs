using Demo.Mmose.Core.World.ZoneClusterWorld;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Demo.Mmose.Core.Test
{
    
    
    /// <summary>
    ///这是 ConfigZoneClusterTest 的测试类，旨在
    ///包含所有 ConfigZoneClusterTest 单元测试
    ///</summary>
    [TestClass()]
    public class ConfigZoneClusterTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
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
        ///ZoneClusterPort 的测试
        ///</summary>
        [TestMethod()]
        public void ZoneClusterPortTest()
        {
            ConfigZoneCluster target = new ConfigZoneCluster(); // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            target.ZoneClusterPort = expected;
            actual = target.ZoneClusterPort;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ZoneClusterPassword 的测试
        ///</summary>
        [TestMethod()]
        public void ZoneClusterPasswordTest()
        {
            ConfigZoneCluster target = new ConfigZoneCluster(); // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            target.ZoneClusterPassword = expected;
            actual = target.ZoneClusterPassword;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ZoneClusterID 的测试
        ///</summary>
        [TestMethod()]
        public void ZoneClusterIDTest()
        {
            ConfigZoneCluster target = new ConfigZoneCluster(); // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            target.ZoneClusterID = expected;
            actual = target.ZoneClusterID;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ZoneClusterHost 的测试
        ///</summary>
        [TestMethod()]
        public void ZoneClusterHostTest()
        {
            ConfigZoneCluster target = new ConfigZoneCluster(); // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            target.ZoneClusterHost = expected;
            actual = target.ZoneClusterHost;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///DomainPort 的测试
        ///</summary>
        [TestMethod()]
        public void DomainPortTest()
        {
            ConfigZoneCluster target = new ConfigZoneCluster(); // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            target.DomainPort = expected;
            actual = target.DomainPort;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///DomainPassword 的测试
        ///</summary>
        [TestMethod()]
        public void DomainPasswordTest()
        {
            ConfigZoneCluster target = new ConfigZoneCluster(); // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            target.DomainPassword = expected;
            actual = target.DomainPassword;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///DomainID 的测试
        ///</summary>
        [TestMethod()]
        public void DomainIDTest()
        {
            ConfigZoneCluster target = new ConfigZoneCluster(); // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            target.DomainID = expected;
            actual = target.DomainID;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///DomainHost 的测试
        ///</summary>
        [TestMethod()]
        public void DomainHostTest()
        {
            ConfigZoneCluster target = new ConfigZoneCluster(); // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            target.DomainHost = expected;
            actual = target.DomainHost;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ConfigZoneCluster 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void ConfigZoneClusterConstructorTest()
        {
            ConfigZoneCluster target = new ConfigZoneCluster();
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
