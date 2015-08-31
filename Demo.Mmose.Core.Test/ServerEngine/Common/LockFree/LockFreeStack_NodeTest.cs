using Demo.Mmose.Core.Common.LockFree;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 LockFreeStack_NodeTest 的测试类，旨在
    ///包含所有 LockFreeStack_NodeTest 单元测试
    ///</summary>
    [TestClass()]
    public class LockFreeStack_NodeTest
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
        ///Item 的测试
        ///</summary>
        public void ItemTestHelper<ValueT, T>()
        {
            LockFreeStack_Accessor<ValueT>.Node<T> target = new LockFreeStack_Accessor<ValueT>.Node<T>(); // TODO: 初始化为适当的值
            T actual;
            actual = target.Item;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void ItemTest()
        {
            ItemTestHelper<GenericParameterHelper, GenericParameterHelper>();
        }

        /// <summary>
        ///Node`1 构造函数 的测试
        ///</summary>
        public void LockFreeStack_NodeConstructorTest1Helper<ValueT, T>()
        {
            LockFreeStack_Accessor<ValueT>.Node<T> target = new LockFreeStack_Accessor<ValueT>.Node<T>();
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void LockFreeStack_NodeConstructorTest1()
        {
            LockFreeStack_NodeConstructorTest1Helper<GenericParameterHelper, GenericParameterHelper>();
        }

        /// <summary>
        ///Node`1 构造函数 的测试
        ///</summary>
        public void LockFreeStack_NodeConstructorTestHelper<ValueT, T>()
        {
            T item = default( T ); // TODO: 初始化为适当的值
            LockFreeStack_Accessor<ValueT>.Node<T> target = new LockFreeStack_Accessor<ValueT>.Node<T>( item );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void LockFreeStack_NodeConstructorTest()
        {
            LockFreeStack_NodeConstructorTestHelper<GenericParameterHelper, GenericParameterHelper>();
        }
    }
}
