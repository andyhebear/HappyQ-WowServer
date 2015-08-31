using Demo.Mmose.Core.Timer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 TimerThreadTest 的测试类，旨在
    ///包含所有 TimerThreadTest 单元测试
    ///</summary>
    [TestClass()]
    public class TimerThreadTest
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
        ///StartTimerThread 的测试
        ///</summary>
        [TestMethod()]
        public void StartTimerThreadTest()
        {
            TimerThread.StartTimerThread();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///RunTimerThread 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void RunTimerThreadTest()
        {
            TimerThread_Accessor.RunTimerThread();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///RemoveTimer 的测试
        ///</summary>
        [TestMethod()]
        public void RemoveTimerTest()
        {
            TimeSlice tTimer = null; // TODO: 初始化为适当的值
            TimerThread.RemoveTimer( tTimer );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///ProcessChangeQueue 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void ProcessChangeQueueTest()
        {
            TimerThread_Accessor.ProcessChangeQueue();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///PriorityChange 的测试
        ///</summary>
        [TestMethod()]
        public void PriorityChangeTest()
        {
            TimeSlice tTimer = null; // TODO: 初始化为适当的值
            TimerFrequency newPriority = new TimerFrequency(); // TODO: 初始化为适当的值
            TimerThread.PriorityChange( tTimer, newPriority );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///InternalDumpInfo 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void InternalDumpInfoTest()
        {
            TimerThread_Accessor.InternalDumpInfo();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///DumpInfo 的测试
        ///</summary>
        [TestMethod()]
        public void DumpInfoTest()
        {
            TimerThread.DumpInfo();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Change 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void ChangeTest()
        {
            TimeSlice tTimer = null; // TODO: 初始化为适当的值
            long newIndex = 0; // TODO: 初始化为适当的值
            bool isAdd = false; // TODO: 初始化为适当的值
            TimerThread_Accessor.Change( tTimer, newIndex, isAdd );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///AddTimer 的测试
        ///</summary>
        [TestMethod()]
        public void AddTimerTest()
        {
            TimeSlice tTimer = null; // TODO: 初始化为适当的值
            TimerThread.AddTimer( tTimer );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///TimerThread 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void TimerThreadConstructorTest()
        {
            TimerThread target = new TimerThread();
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
