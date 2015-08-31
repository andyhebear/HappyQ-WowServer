using Demo.Mmose.Core.Timer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 DelayStateCallTimerTest 的测试类，旨在
    ///包含所有 DelayStateCallTimerTest 单元测试
    ///</summary>
    [TestClass()]
    public class DelayStateCallTimerTest
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
        ///Callback 的测试
        ///</summary>
        [TestMethod()]
        public void CallbackTest1()
        {
            TimerPriority processPriority = new TimerPriority(); // TODO: 初始化为适当的值
            TimeSpan delayTimeSpan = new TimeSpan(); // TODO: 初始化为适当的值
            TimeSpan intervalTimeSpan = new TimeSpan(); // TODO: 初始化为适当的值
            long iCount = 0; // TODO: 初始化为适当的值
            TimeSliceStateCallback timerStateCallback = null; // TODO: 初始化为适当的值
            object oState = null; // TODO: 初始化为适当的值
            DelayStateCallTimer target = new DelayStateCallTimer( processPriority, delayTimeSpan, intervalTimeSpan, iCount, timerStateCallback, oState ); // TODO: 初始化为适当的值
            TimeSliceStateCallback actual;
            actual = target.Callback;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToString 的测试
        ///</summary>
        [TestMethod()]
        public void ToStringTest1()
        {
            TimerPriority processPriority = new TimerPriority(); // TODO: 初始化为适当的值
            TimeSpan delayTimeSpan = new TimeSpan(); // TODO: 初始化为适当的值
            TimeSpan intervalTimeSpan = new TimeSpan(); // TODO: 初始化为适当的值
            long iCount = 0; // TODO: 初始化为适当的值
            TimeSliceStateCallback timerStateCallback = null; // TODO: 初始化为适当的值
            object oState = null; // TODO: 初始化为适当的值
            DelayStateCallTimer target = new DelayStateCallTimer( processPriority, delayTimeSpan, intervalTimeSpan, iCount, timerStateCallback, oState ); // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = target.ToString();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnTick 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void OnTickTest1()
        {
            PrivateObject param0 = null; // TODO: 初始化为适当的值
            DelayStateCallTimer_Accessor target = new DelayStateCallTimer_Accessor( param0 ); // TODO: 初始化为适当的值
            target.OnTick();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Callback 的测试
        ///</summary>
        public void CallbackTestHelper<T>()
        {
            TimerPriority processPriority = new TimerPriority(); // TODO: 初始化为适当的值
            TimeSpan delayTimeSpan = new TimeSpan(); // TODO: 初始化为适当的值
            TimeSpan intervalTimeSpan = new TimeSpan(); // TODO: 初始化为适当的值
            long iCount = 0; // TODO: 初始化为适当的值
            TimeSliceStateCallback<T> timerStateCallback = null; // TODO: 初始化为适当的值
            T tState = default( T ); // TODO: 初始化为适当的值
            DelayStateCallTimer<T> target = new DelayStateCallTimer<T>( processPriority, delayTimeSpan, intervalTimeSpan, iCount, timerStateCallback, tState ); // TODO: 初始化为适当的值
            TimeSliceStateCallback<T> actual;
            actual = target.Callback;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void CallbackTest()
        {
            CallbackTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///ToString 的测试
        ///</summary>
        public void ToStringTestHelper<T>()
        {
            TimerPriority processPriority = new TimerPriority(); // TODO: 初始化为适当的值
            TimeSpan delayTimeSpan = new TimeSpan(); // TODO: 初始化为适当的值
            TimeSpan intervalTimeSpan = new TimeSpan(); // TODO: 初始化为适当的值
            long iCount = 0; // TODO: 初始化为适当的值
            TimeSliceStateCallback<T> timerStateCallback = null; // TODO: 初始化为适当的值
            T tState = default( T ); // TODO: 初始化为适当的值
            DelayStateCallTimer<T> target = new DelayStateCallTimer<T>( processPriority, delayTimeSpan, intervalTimeSpan, iCount, timerStateCallback, tState ); // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = target.ToString();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void ToStringTest()
        {
            ToStringTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///OnTick 的测试
        ///</summary>
        public void OnTickTestHelper<T>()
        {
            PrivateObject param0 = null; // TODO: 初始化为适当的值
            DelayStateCallTimer_Accessor<T> target = new DelayStateCallTimer_Accessor<T>( param0 ); // TODO: 初始化为适当的值
            target.OnTick();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void OnTickTest()
        {
            OnTickTestHelper<GenericParameterHelper>();
        }
    }
}
