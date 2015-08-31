using Demo.Mmose.Core.Timer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Demo.Mmose.Core.World;
using Demo.Mmose.Core.Common.SafeCollections;
using System.Collections.Generic;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 TimeSliceTest 的测试类，旨在
    ///包含所有 TimeSliceTest 单元测试
    ///</summary>
    [TestClass()]
    public class TimeSliceTest
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
        ///TimeSliceDictionary 的测试
        ///</summary>
        [TestMethod()]
        public void TimeSliceDictionaryTest()
        {
            TimeSpan delayTimeSpan = new TimeSpan(); // TODO: 初始化为适当的值
            TimeSlice target = new TimeSlice( delayTimeSpan ); // TODO: 初始化为适当的值
            Dictionary<TimeSlice, TimeSlice> expected = null; // TODO: 初始化为适当的值
            Dictionary<TimeSlice, TimeSlice> actual;
            target.TimeSliceDictionary = expected;
            actual = target.TimeSliceDictionary;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Profiles 的测试
        ///</summary>
        [TestMethod()]
        public void ProfilesTest()
        {
            SafeDictionary<string, TimerProfile> actual;
            actual = TimeSlice.Profiles;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Priority 的测试
        ///</summary>
        [TestMethod()]
        public void PriorityTest()
        {
            TimeSpan delayTimeSpan = new TimeSpan(); // TODO: 初始化为适当的值
            TimeSlice target = new TimeSlice( delayTimeSpan ); // TODO: 初始化为适当的值
            TimerPriority expected = new TimerPriority(); // TODO: 初始化为适当的值
            TimerPriority actual;
            target.Priority = expected;
            actual = target.Priority;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///NextTime 的测试
        ///</summary>
        [TestMethod()]
        public void NextTimeTest()
        {
            TimeSpan delayTimeSpan = new TimeSpan(); // TODO: 初始化为适当的值
            TimeSlice target = new TimeSlice( delayTimeSpan ); // TODO: 初始化为适当的值
            DateTime expected = new DateTime(); // TODO: 初始化为适当的值
            DateTime actual;
            target.NextTime = expected;
            actual = target.NextTime;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IsRunning 的测试
        ///</summary>
        [TestMethod()]
        public void IsRunningTest()
        {
            TimeSpan delayTimeSpan = new TimeSpan(); // TODO: 初始化为适当的值
            TimeSlice target = new TimeSlice( delayTimeSpan ); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            target.IsRunning = expected;
            actual = target.IsRunning;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IntervalTime 的测试
        ///</summary>
        [TestMethod()]
        public void IntervalTimeTest()
        {
            TimeSpan delayTimeSpan = new TimeSpan(); // TODO: 初始化为适当的值
            TimeSlice target = new TimeSlice( delayTimeSpan ); // TODO: 初始化为适当的值
            TimeSpan expected = new TimeSpan(); // TODO: 初始化为适当的值
            TimeSpan actual;
            target.IntervalTime = expected;
            actual = target.IntervalTime;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///InQueued 的测试
        ///</summary>
        [TestMethod()]
        public void InQueuedTest()
        {
            TimeSpan delayTimeSpan = new TimeSpan(); // TODO: 初始化为适当的值
            TimeSlice target = new TimeSlice( delayTimeSpan ); // TODO: 初始化为适当的值
            bool actual;
            actual = target.InQueued;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Frequency 的测试
        ///</summary>
        [TestMethod()]
        public void FrequencyTest()
        {
            TimeSpan delayTimeSpan = new TimeSpan(); // TODO: 初始化为适当的值
            TimeSlice target = new TimeSlice( delayTimeSpan ); // TODO: 初始化为适当的值
            TimerFrequency expected = new TimerFrequency(); // TODO: 初始化为适当的值
            TimerFrequency actual;
            target.Frequency = expected;
            actual = target.Frequency;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///DelayTime 的测试
        ///</summary>
        [TestMethod()]
        public void DelayTimeTest()
        {
            TimeSpan delayTimeSpan = new TimeSpan(); // TODO: 初始化为适当的值
            TimeSlice target = new TimeSlice( delayTimeSpan ); // TODO: 初始化为适当的值
            TimeSpan expected = new TimeSpan(); // TODO: 初始化为适当的值
            TimeSpan actual;
            target.DelayTime = expected;
            actual = target.DelayTime;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Count 的测试
        ///</summary>
        [TestMethod()]
        public void CountTest()
        {
            TimeSpan delayTimeSpan = new TimeSpan(); // TODO: 初始化为适当的值
            TimeSlice target = new TimeSlice( delayTimeSpan ); // TODO: 初始化为适当的值
            long actual;
            actual = target.Count;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///BreakSliceAtNumber 的测试
        ///</summary>
        [TestMethod()]
        public void BreakSliceAtNumberTest()
        {
            long expected = 0; // TODO: 初始化为适当的值
            long actual;
            TimeSlice.BreakSliceAtNumber = expected;
            actual = TimeSlice.BreakSliceAtNumber;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///BaseWorld 的测试
        ///</summary>
        [TestMethod()]
        public void BaseWorldTest()
        {
            TimeSpan delayTimeSpan = new TimeSpan(); // TODO: 初始化为适当的值
            TimeSlice target = new TimeSlice( delayTimeSpan ); // TODO: 初始化为适当的值
            BaseWorld expected = null; // TODO: 初始化为适当的值
            BaseWorld actual;
            target.BaseWorld = expected;
            actual = target.BaseWorld;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Adding 的测试
        ///</summary>
        [TestMethod()]
        public void AddingTest()
        {
            TimeSpan delayTimeSpan = new TimeSpan(); // TODO: 初始化为适当的值
            TimeSlice target = new TimeSlice( delayTimeSpan ); // TODO: 初始化为适当的值
            long expected = 0; // TODO: 初始化为适当的值
            long actual;
            target.Adding = expected;
            actual = target.Adding;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToString 的测试
        ///</summary>
        [TestMethod()]
        public void ToStringTest()
        {
            TimeSpan delayTimeSpan = new TimeSpan(); // TODO: 初始化为适当的值
            TimeSlice target = new TimeSlice( delayTimeSpan ); // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = target.ToString();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Stop 的测试
        ///</summary>
        [TestMethod()]
        public void StopTest()
        {
            TimeSpan delayTimeSpan = new TimeSpan(); // TODO: 初始化为适当的值
            TimeSlice target = new TimeSlice( delayTimeSpan ); // TODO: 初始化为适当的值
            target.Stop();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///StartTimeSlice 的测试
        ///</summary>
        [TestMethod()]
        public void StartTimeSliceTest17()
        {
            TimeSpan delayTimeSpan = new TimeSpan(); // TODO: 初始化为适当的值
            TimeSpan intervalTimeSpan = new TimeSpan(); // TODO: 初始化为适当的值
            TimeSliceStateCallback timerStateCallback = null; // TODO: 初始化为适当的值
            object tState = null; // TODO: 初始化为适当的值
            TimeSlice expected = null; // TODO: 初始化为适当的值
            TimeSlice actual;
            actual = TimeSlice.StartTimeSlice( delayTimeSpan, intervalTimeSpan, timerStateCallback, tState );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///StartTimeSlice 的测试
        ///</summary>
        [TestMethod()]
        public void StartTimeSliceTest16()
        {
            TimerPriority processPriority = new TimerPriority(); // TODO: 初始化为适当的值
            TimeSpan delayTimeSpan = new TimeSpan(); // TODO: 初始化为适当的值
            TimeSliceStateCallback timerStateCallback = null; // TODO: 初始化为适当的值
            object tState = null; // TODO: 初始化为适当的值
            TimeSlice expected = null; // TODO: 初始化为适当的值
            TimeSlice actual;
            actual = TimeSlice.StartTimeSlice( processPriority, delayTimeSpan, timerStateCallback, tState );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///StartTimeSlice 的测试
        ///</summary>
        [TestMethod()]
        public void StartTimeSliceTest15()
        {
            TimerPriority processPriority = new TimerPriority(); // TODO: 初始化为适当的值
            TimeSpan delayTimeSpan = new TimeSpan(); // TODO: 初始化为适当的值
            TimeSpan intervalTimeSpan = new TimeSpan(); // TODO: 初始化为适当的值
            TimeSliceStateCallback timerStateCallback = null; // TODO: 初始化为适当的值
            object tState = null; // TODO: 初始化为适当的值
            TimeSlice expected = null; // TODO: 初始化为适当的值
            TimeSlice actual;
            actual = TimeSlice.StartTimeSlice( processPriority, delayTimeSpan, intervalTimeSpan, timerStateCallback, tState );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///StartTimeSlice 的测试
        ///</summary>
        [TestMethod()]
        public void StartTimeSliceTest14()
        {
            TimerPriority processPriority = new TimerPriority(); // TODO: 初始化为适当的值
            TimeSpan delayTimeSpan = new TimeSpan(); // TODO: 初始化为适当的值
            TimeSpan intervalTimeSpan = new TimeSpan(); // TODO: 初始化为适当的值
            long iCount = 0; // TODO: 初始化为适当的值
            TimeSliceStateCallback timerStateCallback = null; // TODO: 初始化为适当的值
            object tState = null; // TODO: 初始化为适当的值
            TimeSlice expected = null; // TODO: 初始化为适当的值
            TimeSlice actual;
            actual = TimeSlice.StartTimeSlice( processPriority, delayTimeSpan, intervalTimeSpan, iCount, timerStateCallback, tState );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///StartTimeSlice 的测试
        ///</summary>
        [TestMethod()]
        public void StartTimeSliceTest13()
        {
            TimeSpan delayTimeSpan = new TimeSpan(); // TODO: 初始化为适当的值
            TimeSpan intervalTimeSpan = new TimeSpan(); // TODO: 初始化为适当的值
            long iCount = 0; // TODO: 初始化为适当的值
            TimeSliceStateCallback timerStateCallback = null; // TODO: 初始化为适当的值
            object tState = null; // TODO: 初始化为适当的值
            TimeSlice expected = null; // TODO: 初始化为适当的值
            TimeSlice actual;
            actual = TimeSlice.StartTimeSlice( delayTimeSpan, intervalTimeSpan, iCount, timerStateCallback, tState );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///StartTimeSlice 的测试
        ///</summary>
        [TestMethod()]
        public void StartTimeSliceTest12()
        {
            TimerPriority processPriority = new TimerPriority(); // TODO: 初始化为适当的值
            TimeSpan delayTimeSpan = new TimeSpan(); // TODO: 初始化为适当的值
            TimeSpan intervalTimeSpan = new TimeSpan(); // TODO: 初始化为适当的值
            long iCount = 0; // TODO: 初始化为适当的值
            TimeSliceCallback timerCallback = null; // TODO: 初始化为适当的值
            TimeSlice expected = null; // TODO: 初始化为适当的值
            TimeSlice actual;
            actual = TimeSlice.StartTimeSlice( processPriority, delayTimeSpan, intervalTimeSpan, iCount, timerCallback );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///StartTimeSlice 的测试
        ///</summary>
        [TestMethod()]
        public void StartTimeSliceTest11()
        {
            TimerPriority processPriority = new TimerPriority(); // TODO: 初始化为适当的值
            TimeSpan delayTimeSpan = new TimeSpan(); // TODO: 初始化为适当的值
            TimeSliceCallback timerCallback = null; // TODO: 初始化为适当的值
            TimeSlice expected = null; // TODO: 初始化为适当的值
            TimeSlice actual;
            actual = TimeSlice.StartTimeSlice( processPriority, delayTimeSpan, timerCallback );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///StartTimeSlice 的测试
        ///</summary>
        [TestMethod()]
        public void StartTimeSliceTest10()
        {
            TimeSpan delayTimeSpan = new TimeSpan(); // TODO: 初始化为适当的值
            TimeSliceCallback timerCallback = null; // TODO: 初始化为适当的值
            TimeSlice expected = null; // TODO: 初始化为适当的值
            TimeSlice actual;
            actual = TimeSlice.StartTimeSlice( delayTimeSpan, timerCallback );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///StartTimeSlice 的测试
        ///</summary>
        [TestMethod()]
        public void StartTimeSliceTest9()
        {
            TimeSpan delayTimeSpan = new TimeSpan(); // TODO: 初始化为适当的值
            TimeSpan intervalTimeSpan = new TimeSpan(); // TODO: 初始化为适当的值
            TimeSliceCallback timerCallback = null; // TODO: 初始化为适当的值
            TimeSlice expected = null; // TODO: 初始化为适当的值
            TimeSlice actual;
            actual = TimeSlice.StartTimeSlice( delayTimeSpan, intervalTimeSpan, timerCallback );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///StartTimeSlice 的测试
        ///</summary>
        [TestMethod()]
        public void StartTimeSliceTest8()
        {
            TimeSpan delayTimeSpan = new TimeSpan(); // TODO: 初始化为适当的值
            TimeSpan intervalTimeSpan = new TimeSpan(); // TODO: 初始化为适当的值
            long iCount = 0; // TODO: 初始化为适当的值
            TimeSliceCallback timerCallback = null; // TODO: 初始化为适当的值
            TimeSlice expected = null; // TODO: 初始化为适当的值
            TimeSlice actual;
            actual = TimeSlice.StartTimeSlice( delayTimeSpan, intervalTimeSpan, iCount, timerCallback );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///StartTimeSlice 的测试
        ///</summary>
        [TestMethod()]
        public void StartTimeSliceTest7()
        {
            TimerPriority processPriority = new TimerPriority(); // TODO: 初始化为适当的值
            TimeSpan delayTimeSpan = new TimeSpan(); // TODO: 初始化为适当的值
            TimeSpan intervalTimeSpan = new TimeSpan(); // TODO: 初始化为适当的值
            TimeSliceCallback timerCallback = null; // TODO: 初始化为适当的值
            TimeSlice expected = null; // TODO: 初始化为适当的值
            TimeSlice actual;
            actual = TimeSlice.StartTimeSlice( processPriority, delayTimeSpan, intervalTimeSpan, timerCallback );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///StartTimeSlice 的测试
        ///</summary>
        public void StartTimeSliceTest6Helper<T>()
        {
            TimeSpan delayTimeSpan = new TimeSpan(); // TODO: 初始化为适当的值
            TimeSliceStateCallback<T> timerStateCallback = null; // TODO: 初始化为适当的值
            T tState = default( T ); // TODO: 初始化为适当的值
            TimeSlice expected = null; // TODO: 初始化为适当的值
            TimeSlice actual;
            actual = TimeSlice.StartTimeSlice<T>( delayTimeSpan, timerStateCallback, tState );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void StartTimeSliceTest6()
        {
            StartTimeSliceTest6Helper<GenericParameterHelper>();
        }

        /// <summary>
        ///StartTimeSlice 的测试
        ///</summary>
        public void StartTimeSliceTest5Helper<T>()
        {
            TimeSpan delayTimeSpan = new TimeSpan(); // TODO: 初始化为适当的值
            TimeSpan intervalTimeSpan = new TimeSpan(); // TODO: 初始化为适当的值
            long iCount = 0; // TODO: 初始化为适当的值
            TimeSliceStateCallback<T> timerStateCallback = null; // TODO: 初始化为适当的值
            T tState = default( T ); // TODO: 初始化为适当的值
            TimeSlice expected = null; // TODO: 初始化为适当的值
            TimeSlice actual;
            actual = TimeSlice.StartTimeSlice<T>( delayTimeSpan, intervalTimeSpan, iCount, timerStateCallback, tState );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void StartTimeSliceTest5()
        {
            StartTimeSliceTest5Helper<GenericParameterHelper>();
        }

        /// <summary>
        ///StartTimeSlice 的测试
        ///</summary>
        public void StartTimeSliceTest4Helper<T>()
        {
            TimerPriority processPriority = new TimerPriority(); // TODO: 初始化为适当的值
            TimeSpan delayTimeSpan = new TimeSpan(); // TODO: 初始化为适当的值
            TimeSpan intervalTimeSpan = new TimeSpan(); // TODO: 初始化为适当的值
            long iCount = 0; // TODO: 初始化为适当的值
            TimeSliceStateCallback<T> timerStateCallback = null; // TODO: 初始化为适当的值
            T tState = default( T ); // TODO: 初始化为适当的值
            TimeSlice expected = null; // TODO: 初始化为适当的值
            TimeSlice actual;
            actual = TimeSlice.StartTimeSlice<T>( processPriority, delayTimeSpan, intervalTimeSpan, iCount, timerStateCallback, tState );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void StartTimeSliceTest4()
        {
            StartTimeSliceTest4Helper<GenericParameterHelper>();
        }

        /// <summary>
        ///StartTimeSlice 的测试
        ///</summary>
        [TestMethod()]
        public void StartTimeSliceTest3()
        {
            TimeSpan delayTimeSpan = new TimeSpan(); // TODO: 初始化为适当的值
            TimeSliceStateCallback timerStateCallback = null; // TODO: 初始化为适当的值
            object tState = null; // TODO: 初始化为适当的值
            TimeSlice expected = null; // TODO: 初始化为适当的值
            TimeSlice actual;
            actual = TimeSlice.StartTimeSlice( delayTimeSpan, timerStateCallback, tState );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///StartTimeSlice 的测试
        ///</summary>
        public void StartTimeSliceTest2Helper<T>()
        {
            TimerPriority processPriority = new TimerPriority(); // TODO: 初始化为适当的值
            TimeSpan delayTimeSpan = new TimeSpan(); // TODO: 初始化为适当的值
            TimeSliceStateCallback<T> timerStateCallback = null; // TODO: 初始化为适当的值
            T tState = default( T ); // TODO: 初始化为适当的值
            TimeSlice expected = null; // TODO: 初始化为适当的值
            TimeSlice actual;
            actual = TimeSlice.StartTimeSlice<T>( processPriority, delayTimeSpan, timerStateCallback, tState );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void StartTimeSliceTest2()
        {
            StartTimeSliceTest2Helper<GenericParameterHelper>();
        }

        /// <summary>
        ///StartTimeSlice 的测试
        ///</summary>
        public void StartTimeSliceTest1Helper<T>()
        {
            TimeSpan delayTimeSpan = new TimeSpan(); // TODO: 初始化为适当的值
            TimeSpan intervalTimeSpan = new TimeSpan(); // TODO: 初始化为适当的值
            TimeSliceStateCallback<T> timerStateCallback = null; // TODO: 初始化为适当的值
            T tState = default( T ); // TODO: 初始化为适当的值
            TimeSlice expected = null; // TODO: 初始化为适当的值
            TimeSlice actual;
            actual = TimeSlice.StartTimeSlice<T>( delayTimeSpan, intervalTimeSpan, timerStateCallback, tState );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void StartTimeSliceTest1()
        {
            StartTimeSliceTest1Helper<GenericParameterHelper>();
        }

        /// <summary>
        ///StartTimeSlice 的测试
        ///</summary>
        public void StartTimeSliceTestHelper<T>()
        {
            TimerPriority processPriority = new TimerPriority(); // TODO: 初始化为适当的值
            TimeSpan delayTimeSpan = new TimeSpan(); // TODO: 初始化为适当的值
            TimeSpan intervalTimeSpan = new TimeSpan(); // TODO: 初始化为适当的值
            TimeSliceStateCallback<T> timerStateCallback = null; // TODO: 初始化为适当的值
            T tState = default( T ); // TODO: 初始化为适当的值
            TimeSlice expected = null; // TODO: 初始化为适当的值
            TimeSlice actual;
            actual = TimeSlice.StartTimeSlice<T>( processPriority, delayTimeSpan, intervalTimeSpan, timerStateCallback, tState );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void StartTimeSliceTest()
        {
            StartTimeSliceTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///Start 的测试
        ///</summary>
        [TestMethod()]
        public void StartTest()
        {
            TimeSpan delayTimeSpan = new TimeSpan(); // TODO: 初始化为适当的值
            TimeSlice target = new TimeSlice( delayTimeSpan ); // TODO: 初始化为适当的值
            target.Start();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Slice_Normal 的测试
        ///</summary>
        [TestMethod()]
        public void Slice_NormalTest()
        {
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = TimeSlice.Slice_Normal();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Slice_Lowest 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void Slice_LowestTest()
        {
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = TimeSlice_Accessor.Slice_Lowest();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Slice_Highest 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void Slice_HighestTest()
        {
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = TimeSlice_Accessor.Slice_Highest();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Slice_BelowNormal 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void Slice_BelowNormalTest()
        {
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = TimeSlice_Accessor.Slice_BelowNormal();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Slice_AboveNormal 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void Slice_AboveNormalTest()
        {
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = TimeSlice_Accessor.Slice_AboveNormal();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Slice 的测试
        ///</summary>
        [TestMethod()]
        public void SliceTest()
        {
            TimeSlice.Slice();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///RegCreation 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void RegCreationTest()
        {
            PrivateObject param0 = null; // TODO: 初始化为适当的值
            TimeSlice_Accessor target = new TimeSlice_Accessor( param0 ); // TODO: 初始化为适当的值
            target.RegCreation();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnTick 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void OnTickTest()
        {
            PrivateObject param0 = null; // TODO: 初始化为适当的值
            TimeSlice_Accessor target = new TimeSlice_Accessor( param0 ); // TODO: 初始化为适当的值
            target.OnTick();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///JoinProcessQueue 的测试
        ///</summary>
        [TestMethod()]
        public void JoinProcessQueueTest()
        {
            TimeSlice timeSlice = null; // TODO: 初始化为适当的值
            TimeSlice.JoinProcessQueue( timeSlice );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///GetProfile 的测试
        ///</summary>
        [TestMethod()]
        public void GetProfileTest()
        {
            TimeSpan delayTimeSpan = new TimeSpan(); // TODO: 初始化为适当的值
            TimeSlice target = new TimeSlice( delayTimeSpan ); // TODO: 初始化为适当的值
            TimerProfile expected = null; // TODO: 初始化为适当的值
            TimerProfile actual;
            actual = target.GetProfile();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///FormatDelegate 的测试
        ///</summary>
        [TestMethod()]
        public void FormatDelegateTest()
        {
            Delegate delegateCallback = null; // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = TimeSlice.FormatDelegate( delegateCallback );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ComputePriority 的测试
        ///</summary>
        [TestMethod()]
        public void ComputePriorityTest()
        {
            TimeSpan timeSpan = new TimeSpan(); // TODO: 初始化为适当的值
            TimerFrequency expected = new TimerFrequency(); // TODO: 初始化为适当的值
            TimerFrequency actual;
            actual = TimeSlice.ComputePriority( timeSpan );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///TimeSlice 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void TimeSliceConstructorTest5()
        {
            TimeSpan delayTimeSpan = new TimeSpan(); // TODO: 初始化为适当的值
            TimeSpan intervalTimeSpan = new TimeSpan(); // TODO: 初始化为适当的值
            TimeSlice target = new TimeSlice( delayTimeSpan, intervalTimeSpan );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        /// <summary>
        ///TimeSlice 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void TimeSliceConstructorTest4()
        {
            TimerPriority processPriority = new TimerPriority(); // TODO: 初始化为适当的值
            TimeSpan delayTimeSpan = new TimeSpan(); // TODO: 初始化为适当的值
            TimeSlice target = new TimeSlice( processPriority, delayTimeSpan );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        /// <summary>
        ///TimeSlice 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void TimeSliceConstructorTest3()
        {
            TimeSpan delayTimeSpan = new TimeSpan(); // TODO: 初始化为适当的值
            TimeSlice target = new TimeSlice( delayTimeSpan );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        /// <summary>
        ///TimeSlice 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void TimeSliceConstructorTest2()
        {
            TimerPriority processPriority = new TimerPriority(); // TODO: 初始化为适当的值
            TimeSpan delayTimeSpan = new TimeSpan(); // TODO: 初始化为适当的值
            TimeSpan intervalTimeSpan = new TimeSpan(); // TODO: 初始化为适当的值
            long iCount = 0; // TODO: 初始化为适当的值
            TimeSlice target = new TimeSlice( processPriority, delayTimeSpan, intervalTimeSpan, iCount );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        /// <summary>
        ///TimeSlice 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void TimeSliceConstructorTest1()
        {
            TimeSpan delayTimeSpan = new TimeSpan(); // TODO: 初始化为适当的值
            TimeSpan intervalTimeSpan = new TimeSpan(); // TODO: 初始化为适当的值
            long iCount = 0; // TODO: 初始化为适当的值
            TimeSlice target = new TimeSlice( delayTimeSpan, intervalTimeSpan, iCount );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        /// <summary>
        ///TimeSlice 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void TimeSliceConstructorTest()
        {
            TimerPriority processPriority = new TimerPriority(); // TODO: 初始化为适当的值
            TimeSpan delayTimeSpan = new TimeSpan(); // TODO: 初始化为适当的值
            TimeSpan intervalTimeSpan = new TimeSpan(); // TODO: 初始化为适当的值
            TimeSlice target = new TimeSlice( processPriority, delayTimeSpan, intervalTimeSpan );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
