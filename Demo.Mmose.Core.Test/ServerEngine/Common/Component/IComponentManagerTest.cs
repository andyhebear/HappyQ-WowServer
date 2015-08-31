using Demo.Mmose.Core.Common.Component;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 IComponentManagerTest 的测试类，旨在
    ///包含所有 IComponentManagerTest 单元测试
    ///</summary>
    [TestClass()]
    public class IComponentManagerTest
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
        ///SubScribeComponentMessage 的测试
        ///</summary>
        [TestMethod()]
        public void SubScribeComponentMessageTest()
        {
            IComponentManager target = CreateIComponentManager(); // TODO: 初始化为适当的值
            ComponentId componentId = new ComponentId(); // TODO: 初始化为适当的值
            ComponentMessage componentMessage = new ComponentMessage(); // TODO: 初始化为适当的值
            target.SubScribeComponentMessage( componentId, componentMessage );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///RegisterComponent 的测试
        ///</summary>
        public void RegisterComponentTestHelper<T>()
            where T : class, IComponent
        {
            IComponentManager target = CreateIComponentManager(); // TODO: 初始化为适当的值
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
        ///PostComponentMessage 的测试
        ///</summary>
        [TestMethod()]
        public void PostComponentMessageTest()
        {
            IComponentManager target = CreateIComponentManager(); // TODO: 初始化为适当的值
            ComponentMessage componentMessage = new ComponentMessage(); // TODO: 初始化为适当的值
            target.PostComponentMessage( componentMessage );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///GetComponent 的测试
        ///</summary>
        public void GetComponentTestHelper<T>()
            where T : class, IComponent
        {
            IComponentManager target = CreateIComponentManager(); // TODO: 初始化为适当的值
            ComponentId componentId = new ComponentId(); // TODO: 初始化为适当的值
            T expected = null; // TODO: 初始化为适当的值
            T actual;
            actual = target.GetComponent<T>( componentId );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        internal virtual IComponentManager CreateIComponentManager()
        {
            // TODO: 实例化相应的具体类。
            IComponentManager target = null;
            return target;
        }

        [TestMethod()]
        public void GetComponentTest()
        {
            Assert.Inconclusive( "没有找到能够满足 T 的类型约束的相应类型参数。请以适当的类型参数来调用 GetComponentTestHelper<T>()。" );
        }
    }
}
