using Demo.Mmose.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 ServerInitTest 的测试类，旨在
    ///包含所有 ServerInitTest 单元测试
    ///</summary>
    [TestClass()]
    public class ServerInitTest
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
        ///IsInit 的测试
        ///</summary>
        [TestMethod()]
        public void IsInitTest()
        {
            bool actual;
            actual = ServerInit.IsInit;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Server_IsInit 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void Server_IsInitTest()
        {
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = ServerInit_Accessor.Server_IsInit();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Server_InitDefault 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void Server_InitDefaultTest()
        {
            ServerInit_Accessor.Server_InitDefault();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Server_Init 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void Server_InitTest()
        {
            int SERVER_CACHED_SIZE = 0; // TODO: 初始化为适当的值
            int SERVER_BUFFER_SIZE = 0; // TODO: 初始化为适当的值
            int SERVER_MANAGE_THREAD_POOL_SIZE = 0; // TODO: 初始化为适当的值
            int SERVER_SEND_THREAD_POOL_SIZE = 0; // TODO: 初始化为适当的值
            int SERVER_RECEIVE_THREAD_POOL_SIZE = 0; // TODO: 初始化为适当的值
            int SERVER_PROCESS_THREAD_POOL_SIZE = 0; // TODO: 初始化为适当的值
            int SERVER_MAX_CLIENTS = 0; // TODO: 初始化为适当的值
            int SERVER_OUT_TIME_INTERVAL = 0; // TODO: 初始化为适当的值
            ServerInit_Accessor.Server_Init( SERVER_CACHED_SIZE, SERVER_BUFFER_SIZE, SERVER_MANAGE_THREAD_POOL_SIZE, SERVER_SEND_THREAD_POOL_SIZE, SERVER_RECEIVE_THREAD_POOL_SIZE, SERVER_PROCESS_THREAD_POOL_SIZE, SERVER_MAX_CLIENTS, SERVER_OUT_TIME_INTERVAL );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Server_Fini 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void Server_FiniTest()
        {
            ServerInit_Accessor.Server_Fini();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///InitDefault 的测试
        ///</summary>
        [TestMethod()]
        public void InitDefaultTest()
        {
            ServerInit.InitDefault();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Init 的测试
        ///</summary>
        [TestMethod()]
        public void InitTest()
        {
            int SERVER_CACHED_SIZE = 0; // TODO: 初始化为适当的值
            int SERVER_BUFFER_SIZE = 0; // TODO: 初始化为适当的值
            int SERVER_MANAGE_THREAD_POOL_SIZE = 0; // TODO: 初始化为适当的值
            int SERVER_SEND_THREAD_POOL_SIZE = 0; // TODO: 初始化为适当的值
            int SERVER_RECEIVE_THREAD_POOL_SIZE = 0; // TODO: 初始化为适当的值
            int SERVER_PROCESS_THREAD_POOL_SIZE = 0; // TODO: 初始化为适当的值
            int SERVER_MAX_CLIENTS = 0; // TODO: 初始化为适当的值
            int SERVER_OUT_TIME_INTERVAL = 0; // TODO: 初始化为适当的值
            ServerInit.Init( SERVER_CACHED_SIZE, SERVER_BUFFER_SIZE, SERVER_MANAGE_THREAD_POOL_SIZE, SERVER_SEND_THREAD_POOL_SIZE, SERVER_RECEIVE_THREAD_POOL_SIZE, SERVER_PROCESS_THREAD_POOL_SIZE, SERVER_MAX_CLIENTS, SERVER_OUT_TIME_INTERVAL );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Fini 的测试
        ///</summary>
        [TestMethod()]
        public void FiniTest()
        {
            ServerInit.Fini();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///ServerInit 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void ServerInitConstructorTest()
        {
            ServerInit target = new ServerInit();
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
