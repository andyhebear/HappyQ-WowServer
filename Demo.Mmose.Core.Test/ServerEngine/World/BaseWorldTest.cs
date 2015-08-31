using Demo.Mmose.Core.World;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Demo.Mmose.Core.Network;
using Demo.Mmose.Core.Common.Component;
using System;
using Demo.Mmose.Core.Common.SupportSlice;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 BaseWorldTest 的测试类，旨在
    ///包含所有 BaseWorldTest 单元测试
    ///</summary>
    [TestClass()]
    public class BaseWorldTest
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
        ///WorldName 的测试
        ///</summary>
        [TestMethod()]
        public void WorldNameTest()
        {
            BaseWorld target = new BaseWorld(); // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            target.WorldName = expected;
            actual = target.WorldName;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///WaitExecute 的测试
        ///</summary>
        [TestMethod()]
        public void WaitExecuteTest()
        {
            BaseWorld target = new BaseWorld(); // TODO: 初始化为适当的值
            WorldWaitExecute actual;
            actual = target.WaitExecute;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///SliceUpdate 的测试
        ///</summary>
        [TestMethod()]
        public void SliceUpdateTest()
        {
            BaseWorld target = new BaseWorld(); // TODO: 初始化为适当的值
            SliceUpdate<ISupportSlice> actual;
            actual = target.SliceUpdate;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Saving 的测试
        ///</summary>
        [TestMethod()]
        public void SavingTest()
        {
            BaseWorld target = new BaseWorld(); // TODO: 初始化为适当的值
            bool actual;
            actual = target.Saving;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///NetStateManager 的测试
        ///</summary>
        [TestMethod()]
        public void NetStateManagerTest()
        {
            BaseWorld target = new BaseWorld(); // TODO: 初始化为适当的值
            NetStateManager actual;
            actual = target.NetStateManager;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///MessagePump 的测试
        ///</summary>
        [TestMethod()]
        public void MessagePumpTest()
        {
            BaseWorld target = new BaseWorld(); // TODO: 初始化为适当的值
            MessagePump[] actual;
            actual = target.MessagePump;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IntervalSave 的测试
        ///</summary>
        [TestMethod()]
        public void IntervalSaveTest()
        {
            BaseWorld target = new BaseWorld(); // TODO: 初始化为适当的值
            TimeSpan expected = new TimeSpan(); // TODO: 初始化为适当的值
            TimeSpan actual;
            target.IntervalSave = expected;
            actual = target.IntervalSave;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///CheckAliveTime 的测试
        ///</summary>
        [TestMethod()]
        public void CheckAliveTimeTest()
        {
            BaseWorld target = new BaseWorld(); // TODO: 初始化为适当的值
            TimeSpan expected = new TimeSpan(); // TODO: 初始化为适当的值
            TimeSpan actual;
            target.CheckAliveTime = expected;
            actual = target.CheckAliveTime;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToString 的测试
        ///</summary>
        [TestMethod()]
        public void ToStringTest()
        {
            BaseWorld target = new BaseWorld(); // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = target.ToString();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ThreadPool_ThreadEvent 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void ThreadPool_ThreadEventTest()
        {
            BaseWorld_Accessor target = new BaseWorld_Accessor(); // TODO: 初始化为适当的值
            //object sender = null; // TODO: 初始化为适当的值
            //CallbackThreadPoolEventArgs eventArgs = null; // TODO: 初始化为适当的值
            //target.ThreadPool_ThreadEvent( sender, eventArgs );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///SubScribeComponentMessage 的测试
        ///</summary>
        [TestMethod()]
        public void SubScribeComponentMessageTest()
        {
            BaseWorld target = new BaseWorld(); // TODO: 初始化为适当的值
            ComponentId componentId = new ComponentId(); // TODO: 初始化为适当的值
            ComponentMessage componentMessage = new ComponentMessage(); // TODO: 初始化为适当的值
            target.SubScribeComponentMessage( componentId, componentMessage );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///StopThreadPool 的测试
        ///</summary>
        [TestMethod()]
        public void StopThreadPoolTest()
        {
            BaseWorld target = new BaseWorld(); // TODO: 初始化为适当的值
            target.StopThreadPool();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///StartThreadPool 的测试
        ///</summary>
        [TestMethod()]
        public void StartThreadPoolTest()
        {
            BaseWorld target = new BaseWorld(); // TODO: 初始化为适当的值
            int maxThreadsAllowed = 0; // TODO: 初始化为适当的值
            target.StartThreadPool( maxThreadsAllowed );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///StartSaveTimeSlice 的测试
        ///</summary>
        [TestMethod()]
        public void StartSaveTimeSliceTest()
        {
            BaseWorld target = new BaseWorld(); // TODO: 初始化为适当的值
            target.StartSaveTimeSlice();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///StartCheckAllAliveTime 的测试
        ///</summary>
        [TestMethod()]
        public void StartCheckAllAliveTimeTest()
        {
            BaseWorld target = new BaseWorld(); // TODO: 初始化为适当的值
            target.StartCheckAllAliveTime();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///SliceWorld 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void SliceWorldTest()
        {
            BaseWorld_Accessor target = new BaseWorld_Accessor(); // TODO: 初始化为适当的值
            object state = null; // TODO: 初始化为适当的值
            target.SliceWorld( state );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///SetWorldSignal 的测试
        ///</summary>
        [TestMethod()]
        public void SetWorldSignalTest()
        {
            BaseWorld target = new BaseWorld(); // TODO: 初始化为适当的值
            target.SetWorldSignal();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Save 的测试
        ///</summary>
        [TestMethod()]
        public void SaveTest()
        {
            BaseWorld target = new BaseWorld(); // TODO: 初始化为适当的值
            target.Save();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///RegisterComponent 的测试
        ///</summary>
        public void RegisterComponentTestHelper<T>()
            where T : class, IComponent
        {
            BaseWorld target = new BaseWorld(); // TODO: 初始化为适当的值
            ComponentId componentId = new ComponentId(); // TODO: 初始化为适当的值
            T component = null; // TODO: 初始化为适当的值
            target.RegisterComponent<T>( componentId, component );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        [TestMethod()]
        public void RegisterComponentTest()
        {
            Assert.Inconclusive( "没有找到能够满足 T 的类型约束的相应类型参数。请以适当的类型参数来调用 RegisterComponentTestHelper<T>()。" );
        }

        /// <summary>
        ///ProcessDisposed 的测试
        ///</summary>
        [TestMethod()]
        public void ProcessDisposedTest()
        {
            BaseWorld target = new BaseWorld(); // TODO: 初始化为适当的值
            target.ProcessDisposed();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///PostComponentMessage 的测试
        ///</summary>
        [TestMethod()]
        public void PostComponentMessageTest()
        {
            BaseWorld target = new BaseWorld(); // TODO: 初始化为适当的值
            ComponentMessage componentMessage = new ComponentMessage(); // TODO: 初始化为适当的值
            target.PostComponentMessage( componentMessage );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnSave 的测试
        ///</summary>
        [TestMethod()]
        public void OnSaveTest()
        {
            BaseWorld target = new BaseWorld(); // TODO: 初始化为适当的值
            target.OnSave();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnInitOnce 的测试
        ///</summary>
        [TestMethod()]
        public void OnInitOnceTest()
        {
            BaseWorld target = new BaseWorld(); // TODO: 初始化为适当的值
            target.OnInitOnce();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnHandleComponentMessage 的测试
        ///</summary>
        [TestMethod()]
        public void OnHandleComponentMessageTest()
        {
            BaseWorld target = new BaseWorld(); // TODO: 初始化为适当的值
            ComponentMessage componentMessage = new ComponentMessage(); // TODO: 初始化为适当的值
            target.OnHandleComponentMessage( componentMessage );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnExit 的测试
        ///</summary>
        [TestMethod()]
        public void OnExitTest()
        {
            BaseWorld target = new BaseWorld(); // TODO: 初始化为适当的值
            target.OnExit();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnBroadcast 的测试
        ///</summary>
        [TestMethod()]
        public void OnBroadcastTest()
        {
            BaseWorld target = new BaseWorld(); // TODO: 初始化为适当的值
            object state = null; // TODO: 初始化为适当的值
            string strText = string.Empty; // TODO: 初始化为适当的值
            target.OnBroadcast( state, strText );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///GetComponent 的测试
        ///</summary>
        public void GetComponentTestHelper<T>()
            where T : class, IComponent
        {
            BaseWorld target = new BaseWorld(); // TODO: 初始化为适当的值
            ComponentId componentId = new ComponentId(); // TODO: 初始化为适当的值
            T expected = null; // TODO: 初始化为适当的值
            T actual;
            actual = target.GetComponent<T>( componentId );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void GetComponentTest()
        {
            Assert.Inconclusive( "没有找到能够满足 T 的类型约束的相应类型参数。请以适当的类型参数来调用 GetComponentTestHelper<T>()。" );
        }

        /// <summary>
        ///FlushNetStates 的测试
        ///</summary>
        [TestMethod()]
        public void FlushNetStatesTest()
        {
            BaseWorld target = new BaseWorld(); // TODO: 初始化为适当的值
            NetState netSatate = null; // TODO: 初始化为适当的值
            target.FlushNetStates( netSatate );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///FlushAll 的测试
        ///</summary>
        [TestMethod()]
        public void FlushAllTest()
        {
            BaseWorld target = new BaseWorld(); // TODO: 初始化为适当的值
            target.FlushAll();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///DisposedNetStates 的测试
        ///</summary>
        [TestMethod()]
        public void DisposedNetStatesTest()
        {
            BaseWorld target = new BaseWorld(); // TODO: 初始化为适当的值
            NetState netSatate = null; // TODO: 初始化为适当的值
            target.DisposedNetStates( netSatate );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///CheckAllAlive 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void CheckAllAliveTest()
        {
            BaseWorld_Accessor target = new BaseWorld_Accessor(); // TODO: 初始化为适当的值
            target.CheckAllAlive();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Broadcast 的测试
        ///</summary>
        [TestMethod()]
        public void BroadcastTest1()
        {
            BaseWorld target = new BaseWorld(); // TODO: 初始化为适当的值
            object state = null; // TODO: 初始化为适当的值
            string strFormat = string.Empty; // TODO: 初始化为适当的值
            object[] args = null; // TODO: 初始化为适当的值
            target.Broadcast( state, strFormat, args );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Broadcast 的测试
        ///</summary>
        [TestMethod()]
        public void BroadcastTest()
        {
            BaseWorld target = new BaseWorld(); // TODO: 初始化为适当的值
            object state = null; // TODO: 初始化为适当的值
            string strText = string.Empty; // TODO: 初始化为适当的值
            target.Broadcast( state, strText );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///AddMessagePump 的测试
        ///</summary>
        [TestMethod()]
        public void AddMessagePumpTest()
        {
            BaseWorld target = new BaseWorld(); // TODO: 初始化为适当的值
            MessagePump messagePump = null; // TODO: 初始化为适当的值
            target.AddMessagePump( messagePump );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///BaseWorld 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void BaseWorldConstructorTest()
        {
            BaseWorld target = new BaseWorld();
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
