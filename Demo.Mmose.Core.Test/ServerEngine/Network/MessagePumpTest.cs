using Demo.Mmose.Core.Network;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Demo.Mmose.Core.World;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 MessagePumpTest 的测试类，旨在
    ///包含所有 MessagePumpTest 单元测试
    ///</summary>
    [TestClass()]
    public class MessagePumpTest
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
            MessagePump target = new MessagePump(); // TODO: 初始化为适当的值
            BaseWorld expected = null; // TODO: 初始化为适当的值
            BaseWorld actual;
            target.World = expected;
            actual = target.World;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Listeners 的测试
        ///</summary>
        [TestMethod()]
        public void ListenersTest()
        {
            MessagePump target = new MessagePump(); // TODO: 初始化为适当的值
            Listener[] actual;
            actual = target.Listeners;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Connecters 的测试
        ///</summary>
        [TestMethod()]
        public void ConnectersTest()
        {
            MessagePump target = new MessagePump(); // TODO: 初始化为适当的值
            Connecter[] actual;
            actual = target.Connecters;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Slice 的测试
        ///</summary>
        [TestMethod()]
        public void SliceTest()
        {
            MessagePump target = new MessagePump(); // TODO: 初始化为适当的值
            target.Slice();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnReceive 的测试
        ///</summary>
        [TestMethod()]
        public void OnReceiveTest()
        {
            MessagePump target = new MessagePump(); // TODO: 初始化为适当的值
            NetState netState = null; // TODO: 初始化为适当的值
            target.OnReceive( netState );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnProcessReceive 的测试
        ///</summary>
        [TestMethod()]
        public void OnProcessReceiveTest()
        {
            MessagePump target = new MessagePump(); // TODO: 初始化为适当的值
            NetState netState = null; // TODO: 初始化为适当的值
            target.OnProcessReceive( netState );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnNetStateInit 的测试
        ///</summary>
        [TestMethod()]
        public void OnNetStateInitTest()
        {
            MessagePump target = new MessagePump(); // TODO: 初始化为适当的值
            NetState newNetState = null; // TODO: 初始化为适当的值
            target.OnNetStateInit( newNetState );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnceAgainReceive 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void OnceAgainReceiveTest()
        {
            MessagePump_Accessor target = new MessagePump_Accessor(); // TODO: 初始化为适当的值
            NetState netState = null; // TODO: 初始化为适当的值
            target.OnceAgainReceive( netState );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///CheckListener 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void CheckListenerTest()
        {
            MessagePump_Accessor target = new MessagePump_Accessor(); // TODO: 初始化为适当的值
            target.CheckListener();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///CheckConnecter 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void CheckConnecterTest()
        {
            MessagePump_Accessor target = new MessagePump_Accessor(); // TODO: 初始化为适当的值
            target.CheckConnecter();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///AddListener 的测试
        ///</summary>
        [TestMethod()]
        public void AddListenerTest()
        {
            MessagePump target = new MessagePump(); // TODO: 初始化为适当的值
            Listener listener = null; // TODO: 初始化为适当的值
            target.AddListener( listener );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///AddConnecter 的测试
        ///</summary>
        [TestMethod()]
        public void AddConnecterTest()
        {
            MessagePump target = new MessagePump(); // TODO: 初始化为适当的值
            Connecter connecter = null; // TODO: 初始化为适当的值
            target.AddConnecter( connecter );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///MessagePump 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void MessagePumpConstructorTest()
        {
            MessagePump target = new MessagePump();
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
