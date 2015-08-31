using Demo.Mmose.Core.Common.ThreadPool;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 CallbackThreadPoolTest 的测试类，旨在
    ///包含所有 CallbackThreadPoolTest 单元测试
    ///</summary>
    [TestClass()]
    public class CallbackThreadPoolTest
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
        ///ThreadsInPool 的测试
        ///</summary>
        [TestMethod()]
        public void ThreadsInPoolTest()
        {
            int idleThreadTimeout = 0; // TODO: 初始化为适当的值
            CallbackThreadPool target = new CallbackThreadPool( idleThreadTimeout ); // TODO: 初始化为适当的值
            int actual;
            actual = target.ThreadsInPool;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///MaxThreadsEverInPool 的测试
        ///</summary>
        [TestMethod()]
        public void MaxThreadsEverInPoolTest()
        {
            int idleThreadTimeout = 0; // TODO: 初始化为适当的值
            CallbackThreadPool target = new CallbackThreadPool( idleThreadTimeout ); // TODO: 初始化为适当的值
            int actual;
            actual = target.MaxThreadsEverInPool;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///MaxThreadsAllowed 的测试
        ///</summary>
        [TestMethod()]
        public void MaxThreadsAllowedTest()
        {
            int idleThreadTimeout = 0; // TODO: 初始化为适当的值
            CallbackThreadPool target = new CallbackThreadPool( idleThreadTimeout ); // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            target.MaxThreadsAllowed = expected;
            actual = target.MaxThreadsAllowed;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ItemsProcessed 的测试
        ///</summary>
        [TestMethod()]
        public void ItemsProcessedTest()
        {
            int idleThreadTimeout = 0; // TODO: 初始化为适当的值
            CallbackThreadPool target = new CallbackThreadPool( idleThreadTimeout ); // TODO: 初始化为适当的值
            int actual;
            actual = target.ItemsProcessed;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ItemsPosted 的测试
        ///</summary>
        [TestMethod()]
        public void ItemsPostedTest()
        {
            int idleThreadTimeout = 0; // TODO: 初始化为适当的值
            CallbackThreadPool target = new CallbackThreadPool( idleThreadTimeout ); // TODO: 初始化为适当的值
            int actual;
            actual = target.ItemsPosted;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ItemsPending 的测试
        ///</summary>
        [TestMethod()]
        public void ItemsPendingTest()
        {
            int idleThreadTimeout = 0; // TODO: 初始化为适当的值
            CallbackThreadPool target = new CallbackThreadPool( idleThreadTimeout ); // TODO: 初始化为适当的值
            int actual;
            actual = target.ItemsPending;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///BusyThreads 的测试
        ///</summary>
        [TestMethod()]
        public void BusyThreadsTest()
        {
            int idleThreadTimeout = 0; // TODO: 初始化为适当的值
            CallbackThreadPool target = new CallbackThreadPool( idleThreadTimeout ); // TODO: 初始化为适当的值
            int actual;
            actual = target.BusyThreads;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ThreadPoolFunction 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void ThreadPoolFunctionTest()
        {
            PrivateObject param0 = null; // TODO: 初始化为适当的值
            CallbackThreadPool_Accessor target = new CallbackThreadPool_Accessor( param0 ); // TODO: 初始化为适当的值
            target.ThreadPoolFunction();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///QueueUserWorkItem 的测试
        ///</summary>
        [TestMethod()]
        public void QueueUserWorkItemTest1()
        {
            int idleThreadTimeout = 0; // TODO: 初始化为适当的值
            CallbackThreadPool target = new CallbackThreadPool( idleThreadTimeout ); // TODO: 初始化为适当的值
            WaitCallback callback = null; // TODO: 初始化为适当的值
            target.QueueUserWorkItem( callback );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///QueueUserWorkItem 的测试
        ///</summary>
        [TestMethod()]
        public void QueueUserWorkItemTest()
        {
            int idleThreadTimeout = 0; // TODO: 初始化为适当的值
            CallbackThreadPool target = new CallbackThreadPool( idleThreadTimeout ); // TODO: 初始化为适当的值
            WaitCallback callback = null; // TODO: 初始化为适当的值
            object state = null; // TODO: 初始化为适当的值
            target.QueueUserWorkItem( callback, state );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnThreadEvent 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void OnThreadEventTest()
        {
            PrivateObject param0 = null; // TODO: 初始化为适当的值
            CallbackThreadPool_Accessor target = new CallbackThreadPool_Accessor( param0 ); // TODO: 初始化为适当的值
            CallbackReason reason = new CallbackReason(); // TODO: 初始化为适当的值
            target.OnThreadEvent( reason );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///InterlockedMax 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void InterlockedMaxTest()
        {
            int target = 0; // TODO: 初始化为适当的值
            int targetExpected = 0; // TODO: 初始化为适当的值
            int val = 0; // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = CallbackThreadPool_Accessor.InterlockedMax( ref target, val );
            Assert.AreEqual( targetExpected, target );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IncreaseMaximumThreadsInPool 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void IncreaseMaximumThreadsInPoolTest()
        {
            PrivateObject param0 = null; // TODO: 初始化为适当的值
            CallbackThreadPool_Accessor target = new CallbackThreadPool_Accessor( param0 ); // TODO: 初始化为适当的值
            int increment = 0; // TODO: 初始化为适当的值
            long expected = 0; // TODO: 初始化为适当的值
            long actual;
            actual = target.IncreaseMaximumThreadsInPool( increment );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Finalize 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void FinalizeTest()
        {
            PrivateObject param0 = null; // TODO: 初始化为适当的值
            CallbackThreadPool_Accessor target = new CallbackThreadPool_Accessor( param0 ); // TODO: 初始化为适当的值
            target.Finalize();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Dispose 的测试
        ///</summary>
        [TestMethod()]
        public void DisposeTest1()
        {
            int idleThreadTimeout = 0; // TODO: 初始化为适当的值
            CallbackThreadPool target = new CallbackThreadPool( idleThreadTimeout ); // TODO: 初始化为适当的值
            target.Dispose();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Dispose 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void DisposeTest()
        {
            PrivateObject param0 = null; // TODO: 初始化为适当的值
            CallbackThreadPool_Accessor target = new CallbackThreadPool_Accessor( param0 ); // TODO: 初始化为适当的值
            bool disposing = false; // TODO: 初始化为适当的值
            target.Dispose( disposing );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///AddThreadToPool 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void AddThreadToPoolTest()
        {
            PrivateObject param0 = null; // TODO: 初始化为适当的值
            CallbackThreadPool_Accessor target = new CallbackThreadPool_Accessor( param0 ); // TODO: 初始化为适当的值
            target.AddThreadToPool();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///CallbackThreadPool 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void CallbackThreadPoolConstructorTest2()
        {
            int idleThreadTimeout = 0; // TODO: 初始化为适当的值
            CallbackThreadPool target = new CallbackThreadPool( idleThreadTimeout );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        /// <summary>
        ///CallbackThreadPool 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void CallbackThreadPoolConstructorTest1()
        {
            int idleThreadTimeout = 0; // TODO: 初始化为适当的值
            int maxThreadsAllowed = 0; // TODO: 初始化为适当的值
            CallbackThreadPool target = new CallbackThreadPool( idleThreadTimeout, maxThreadsAllowed );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        /// <summary>
        ///CallbackThreadPool 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void CallbackThreadPoolConstructorTest()
        {
            int idleThreadTimeout = 0; // TODO: 初始化为适当的值
            int maxThreadsAllowed = 0; // TODO: 初始化为适当的值
            int maxConcurrency = 0; // TODO: 初始化为适当的值
            CallbackThreadPool target = new CallbackThreadPool( idleThreadTimeout, maxThreadsAllowed, maxConcurrency );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
