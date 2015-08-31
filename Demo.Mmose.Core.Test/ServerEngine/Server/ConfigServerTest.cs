using Demo.Mmose.Core.Server;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 ConfigServerTest 的测试类，旨在
    ///包含所有 ConfigServerTest 单元测试
    ///</summary>
    [TestClass()]
    public class ConfigServerTest
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
        ///WorldThreadCount 的测试
        ///</summary>
        [TestMethod()]
        public void WorldThreadCountTest()
        {
            ConfigServer target = new ConfigServer(); // TODO: 初始化为适当的值
            byte expected = 0; // TODO: 初始化为适当的值
            byte actual;
            target.WorldThreadCount = expected;
            actual = target.WorldThreadCount;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Service 的测试
        ///</summary>
        [TestMethod()]
        public void ServiceTest()
        {
            ConfigServer target = new ConfigServer(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            target.Service = expected;
            actual = target.Service;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ScriptDirectory 的测试
        ///</summary>
        [TestMethod()]
        public void ScriptDirectoryTest()
        {
            ConfigServer target = new ConfigServer(); // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            target.ScriptDirectory = expected;
            actual = target.ScriptDirectory;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Profiling 的测试
        ///</summary>
        [TestMethod()]
        public void ProfilingTest()
        {
            ConfigServer target = new ConfigServer(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            target.Profiling = expected;
            actual = target.Profiling;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///LogFile 的测试
        ///</summary>
        [TestMethod()]
        public void LogFileTest()
        {
            ConfigServer target = new ConfigServer(); // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            target.LogFile = expected;
            actual = target.LogFile;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IsChangeWorldThreadCount 的测试
        ///</summary>
        [TestMethod()]
        public void IsChangeWorldThreadCountTest()
        {
            ConfigServer target = new ConfigServer(); // TODO: 初始化为适当的值
            bool actual;
            actual = target.IsChangeWorldThreadCount;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IsChangeService 的测试
        ///</summary>
        [TestMethod()]
        public void IsChangeServiceTest()
        {
            ConfigServer target = new ConfigServer(); // TODO: 初始化为适当的值
            bool actual;
            actual = target.IsChangeService;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IsChangeServerNetConfig 的测试
        ///</summary>
        [TestMethod()]
        public void IsChangeServerNetConfigTest()
        {
            ConfigServer target = new ConfigServer(); // TODO: 初始化为适当的值
            bool actual;
            actual = target.IsChangeServerNetConfig;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IsChangeScriptDirectory 的测试
        ///</summary>
        [TestMethod()]
        public void IsChangeScriptDirectoryTest()
        {
            ConfigServer target = new ConfigServer(); // TODO: 初始化为适当的值
            bool actual;
            actual = target.IsChangeScriptDirectory;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IsChangeProfiling 的测试
        ///</summary>
        [TestMethod()]
        public void IsChangeProfilingTest()
        {
            ConfigServer target = new ConfigServer(); // TODO: 初始化为适当的值
            bool actual;
            actual = target.IsChangeProfiling;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IsChangeLogFile 的测试
        ///</summary>
        [TestMethod()]
        public void IsChangeLogFileTest()
        {
            ConfigServer target = new ConfigServer(); // TODO: 初始化为适当的值
            bool actual;
            actual = target.IsChangeLogFile;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IsChangeHaltOnWarning 的测试
        ///</summary>
        [TestMethod()]
        public void IsChangeHaltOnWarningTest()
        {
            ConfigServer target = new ConfigServer(); // TODO: 初始化为适当的值
            bool actual;
            actual = target.IsChangeHaltOnWarning;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IsChangeDebug 的测试
        ///</summary>
        [TestMethod()]
        public void IsChangeDebugTest()
        {
            ConfigServer target = new ConfigServer(); // TODO: 初始化为适当的值
            bool actual;
            actual = target.IsChangeDebug;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IsChangeClientNetConfig 的测试
        ///</summary>
        [TestMethod()]
        public void IsChangeClientNetConfigTest()
        {
            ConfigServer target = new ConfigServer(); // TODO: 初始化为适当的值
            bool actual;
            actual = target.IsChangeClientNetConfig;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IsChangeCache 的测试
        ///</summary>
        [TestMethod()]
        public void IsChangeCacheTest()
        {
            ConfigServer target = new ConfigServer(); // TODO: 初始化为适当的值
            bool actual;
            actual = target.IsChangeCache;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IsChangeAssemblyDirectory 的测试
        ///</summary>
        [TestMethod()]
        public void IsChangeAssemblyDirectoryTest()
        {
            ConfigServer target = new ConfigServer(); // TODO: 初始化为适当的值
            bool actual;
            actual = target.IsChangeAssemblyDirectory;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///HaltOnWarning 的测试
        ///</summary>
        [TestMethod()]
        public void HaltOnWarningTest()
        {
            ConfigServer target = new ConfigServer(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            target.HaltOnWarning = expected;
            actual = target.HaltOnWarning;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Debug 的测试
        ///</summary>
        [TestMethod()]
        public void DebugTest()
        {
            ConfigServer target = new ConfigServer(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            target.Debug = expected;
            actual = target.Debug;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Cache 的测试
        ///</summary>
        [TestMethod()]
        public void CacheTest()
        {
            ConfigServer target = new ConfigServer(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            target.Cache = expected;
            actual = target.Cache;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///AssemblyDirectory 的测试
        ///</summary>
        [TestMethod()]
        public void AssemblyDirectoryTest()
        {
            ConfigServer target = new ConfigServer(); // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            target.AssemblyDirectory = expected;
            actual = target.AssemblyDirectory;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///SetServerNetConfig 的测试
        ///</summary>
        [TestMethod()]
        public void SetServerNetConfigTest()
        {
            ConfigServer target = new ConfigServer(); // TODO: 初始化为适当的值
            int ServerCachedSize = 0; // TODO: 初始化为适当的值
            int ServerBufferSize = 0; // TODO: 初始化为适当的值
            int ServerManageThreadPoolSize = 0; // TODO: 初始化为适当的值
            int ServerSendThreadPoolSize = 0; // TODO: 初始化为适当的值
            int ServerReceiveThreadPoolSize = 0; // TODO: 初始化为适当的值
            int ServerProcessThreadPoolSize = 0; // TODO: 初始化为适当的值
            int ServerMaxClients = 0; // TODO: 初始化为适当的值
            int ServerOutTimeInterval = 0; // TODO: 初始化为适当的值
            target.SetServerNetConfig( ServerCachedSize, ServerBufferSize, ServerManageThreadPoolSize, ServerSendThreadPoolSize, ServerReceiveThreadPoolSize, ServerProcessThreadPoolSize, ServerMaxClients, ServerOutTimeInterval );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///SetClientNetConfig 的测试
        ///</summary>
        [TestMethod()]
        public void SetClientNetConfigTest()
        {
            ConfigServer target = new ConfigServer(); // TODO: 初始化为适当的值
            int ClientCachedSize = 0; // TODO: 初始化为适当的值
            int ClientBufferSize = 0; // TODO: 初始化为适当的值
            int ClientManageThreadPoolSize = 0; // TODO: 初始化为适当的值
            int ClientSendThreadPoolSize = 0; // TODO: 初始化为适当的值
            int ClientReceiveThreadPoolSize = 0; // TODO: 初始化为适当的值
            int ClientProcessThreadPoolSize = 0; // TODO: 初始化为适当的值
            int ClientOutTimeInterval = 0; // TODO: 初始化为适当的值
            target.SetClientNetConfig( ClientCachedSize, ClientBufferSize, ClientManageThreadPoolSize, ClientSendThreadPoolSize, ClientReceiveThreadPoolSize, ClientProcessThreadPoolSize, ClientOutTimeInterval );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///ConfigServer 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void ConfigServerConstructorTest()
        {
            ConfigServer target = new ConfigServer();
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
