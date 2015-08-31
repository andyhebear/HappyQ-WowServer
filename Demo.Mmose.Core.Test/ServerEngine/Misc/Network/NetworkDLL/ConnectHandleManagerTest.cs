using Demo.Mmose.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 ConnectHandleManagerTest 的测试类，旨在
    ///包含所有 ConnectHandleManagerTest 单元测试
    ///</summary>
    [TestClass()]
    public class ConnectHandleManagerTest
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
        ///Value 的测试
        ///</summary>
        [TestMethod()]
        public void ValueTest()
        {
            ConnectHandleManager target = new ConnectHandleManager(); // TODO: 初始化为适当的值
            IntPtr expected = new IntPtr(); // TODO: 初始化为适当的值
            IntPtr actual;
            target.Handle = expected;
            actual = target.Handle;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GetNewSendMessageBlock 的测试
        ///</summary>
        [TestMethod()]
        public void GetNewSendMessageBlockTest()
        {
            ConnectHandleManager target = new ConnectHandleManager(); // TODO: 初始化为适当的值
            MessageBlock expected = MessageBlock.Zero; // TODO: 初始化为适当的值
            MessageBlock actual;
            actual = target.GetNewSendMessageBlock();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GetClientHandler 的测试
        ///</summary>
        [TestMethod()]
        public void GetClientHandlerTest()
        {
            ConnectHandleManager target = new ConnectHandleManager(); // TODO: 初始化为适当的值
            ConnectHandle expected = ConnectHandle.Zero; // TODO: 初始化为适当的值
            ConnectHandle actual;
            actual = target.GetConnectHandle();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ConnectHandleManager_GetNewSendMessageBlock 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void ConnectHandleManager_GetNewSendMessageBlockTest()
        {
            IntPtr pNewSendMessageBlock = new IntPtr(); // TODO: 初始化为适当的值
            IntPtr pNewSendMessageBlockExpected = new IntPtr(); // TODO: 初始化为适当的值
            IntPtr pSocketHandlerManagerAtClient = new IntPtr(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = ConnectHandleManager_Accessor.ConnectHandleManager_GetNewSendMessageBlock( ref pNewSendMessageBlock, pSocketHandlerManagerAtClient );
            Assert.AreEqual( pNewSendMessageBlockExpected, pNewSendMessageBlock );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ConnectHandleManager_GetConnectHandle 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void ConnectHandleManager_GetConnectHandleTest()
        {
            IntPtr pConnectHandlerAtClient = new IntPtr(); // TODO: 初始化为适当的值
            IntPtr pConnectHandlerAtClientExpected = new IntPtr(); // TODO: 初始化为适当的值
            IntPtr pSocketHandlerManagerAtClient = new IntPtr(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = ConnectHandleManager_Accessor.ConnectHandleManager_GetConnectHandle( ref pConnectHandlerAtClient, pSocketHandlerManagerAtClient );
            Assert.AreEqual( pConnectHandlerAtClientExpected, pConnectHandlerAtClient );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ConnectHandleManager 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void ConnectHandleManagerConstructorTest()
        {
            ConnectHandleManager target = new ConnectHandleManager();
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
