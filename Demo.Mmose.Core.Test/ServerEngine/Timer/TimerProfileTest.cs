using Demo.Mmose.Core.Timer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 TimerProfileTest 的测试类，旨在
    ///包含所有 TimerProfileTest 单元测试
    ///</summary>
    [TestClass()]
    public class TimerProfileTest
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
        ///TotalProcTime 的测试
        ///</summary>
        [TestMethod()]
        public void TotalProcTimeTest()
        {
            TimerProfile target = new TimerProfile(); // TODO: 初始化为适当的值
            TimeSpan actual;
            actual = target.TotalProcTime;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Ticked 的测试
        ///</summary>
        [TestMethod()]
        public void TickedTest()
        {
            TimerProfile target = new TimerProfile(); // TODO: 初始化为适当的值
            int actual;
            actual = target.Ticked;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Stopped 的测试
        ///</summary>
        [TestMethod()]
        public void StoppedTest()
        {
            TimerProfile target = new TimerProfile(); // TODO: 初始化为适当的值
            int actual;
            actual = target.Stopped;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Started 的测试
        ///</summary>
        [TestMethod()]
        public void StartedTest()
        {
            TimerProfile target = new TimerProfile(); // TODO: 初始化为适当的值
            int actual;
            actual = target.Started;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///PeakProcTime 的测试
        ///</summary>
        [TestMethod()]
        public void PeakProcTimeTest()
        {
            TimerProfile target = new TimerProfile(); // TODO: 初始化为适当的值
            TimeSpan actual;
            actual = target.PeakProcTime;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Created 的测试
        ///</summary>
        [TestMethod()]
        public void CreatedTest()
        {
            TimerProfile target = new TimerProfile(); // TODO: 初始化为适当的值
            int actual;
            actual = target.Created;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///AverageProcTime 的测试
        ///</summary>
        [TestMethod()]
        public void AverageProcTimeTest()
        {
            TimerProfile target = new TimerProfile(); // TODO: 初始化为适当的值
            TimeSpan actual;
            actual = target.AverageProcTime;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///RegTicked 的测试
        ///</summary>
        [TestMethod()]
        public void RegTickedTest()
        {
            TimerProfile target = new TimerProfile(); // TODO: 初始化为适当的值
            TimeSpan procTime = new TimeSpan(); // TODO: 初始化为适当的值
            target.RegTicked( procTime );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///RegStopped 的测试
        ///</summary>
        [TestMethod()]
        public void RegStoppedTest()
        {
            TimerProfile target = new TimerProfile(); // TODO: 初始化为适当的值
            target.RegStopped();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///RegStart 的测试
        ///</summary>
        [TestMethod()]
        public void RegStartTest()
        {
            TimerProfile target = new TimerProfile(); // TODO: 初始化为适当的值
            target.RegStart();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///RegCreation 的测试
        ///</summary>
        [TestMethod()]
        public void RegCreationTest()
        {
            TimerProfile target = new TimerProfile(); // TODO: 初始化为适当的值
            target.RegCreation();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///TimerProfile 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void TimerProfileConstructorTest()
        {
            TimerProfile target = new TimerProfile();
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
