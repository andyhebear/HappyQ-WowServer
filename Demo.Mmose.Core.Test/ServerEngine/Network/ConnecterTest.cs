using Demo.Mmose.Core.Network;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Demo.Mmose.Net;
using Demo.Mmose.Core.World;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 ConnecterTest 的测试类，旨在
    ///包含所有 ConnecterTest 单元测试
    ///</summary>
    [TestClass()]
    public class ConnecterTest
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
        ///World 的测试
        ///</summary>
        [TestMethod()]
        public void WorldTest()
        {
            Connecter target = new Connecter(); // TODO: 初始化为适当的值
            BaseWorld expected = null; // TODO: 初始化为适当的值
            BaseWorld actual;
            target.World = expected;
            actual = target.World;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IsSlice 的测试
        ///</summary>
        [TestMethod()]
        public void IsSliceTest()
        {
            Connecter target = new Connecter(); // TODO: 初始化为适当的值
            bool actual;
            actual = target.IsNeedSlice;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ConnecterSocket 的测试
        ///</summary>
        [TestMethod()]
        public void ConnecterSocketTest()
        {
            Connecter target = new Connecter(); // TODO: 初始化为适当的值
            SocketClient actual;
            actual = target.ConnecterSocket;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///StartConnectServer 的测试
        ///</summary>
        [TestMethod()]
        public void StartConnectServerTest()
        {
            Connecter target = new Connecter(); // TODO: 初始化为适当的值
            string strHostNamePort = string.Empty; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.StartConnectServer( strHostNamePort );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Slice 的测试
        ///</summary>
        [TestMethod()]
        public void SliceTest()
        {
            Connecter target = new Connecter(); // TODO: 初始化为适当的值
            ClientSocketManager expected = null; // TODO: 初始化为适当的值
            ClientSocketManager actual;
            actual = target.Slice();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnConnecterProcessMessageBlock 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void OnConnecterProcessMessageBlockTest()
        {
            Connecter_Accessor target = new Connecter_Accessor(); // TODO: 初始化为适当的值
            object sender = null; // TODO: 初始化为适当的值
            ProcessMessageBlockAtClientEventArgs eventArgs = null; // TODO: 初始化为适当的值
            target.OnConnecterProcessMessageBlock( sender, eventArgs );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnConnecterDisconnect 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void OnConnecterDisconnectTest()
        {
            Connecter_Accessor target = new Connecter_Accessor(); // TODO: 初始化为适当的值
            object sender = null; // TODO: 初始化为适当的值
            DisconnectAtClientEventArgs eventArgs = null; // TODO: 初始化为适当的值
            target.OnConnecterDisconnect( sender, eventArgs );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Dispose 的测试
        ///</summary>
        [TestMethod()]
        public void DisposeTest()
        {
            Connecter target = new Connecter(); // TODO: 初始化为适当的值
            target.Dispose();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Connecter 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void ConnecterConstructorTest()
        {
            Connecter target = new Connecter();
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
