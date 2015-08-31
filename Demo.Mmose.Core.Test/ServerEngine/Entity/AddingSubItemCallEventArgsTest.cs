using Demo.Mmose.Core.Entity.Item;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 AddingSubItemCallEventArgsTest 的测试类，旨在
    ///包含所有 AddingSubItemCallEventArgsTest 单元测试
    ///</summary>
    [TestClass()]
    public class AddingSubItemCallEventArgsTest
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
        ///IsCancel 的测试
        ///</summary>
        public void IsCancelTestHelper<T>()
            where T : BaseItem
        {
            T addSubItem = default( T ); // TODO: 初始化为适当的值
            BaseItemContainer<T> itemContainerT = null; // TODO: 初始化为适当的值
            AddingSubItemCallEventArgs<T> target = new AddingSubItemCallEventArgs<T>( addSubItem, itemContainerT ); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            target.IsCancel = expected;
            actual = target.IsCancel;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void IsCancelTest()
        {
            Assert.Inconclusive( "没有找到能够满足 T 的类型约束的相应类型参数。请以适当的类型参数来调用 IsCancelTestHelper<T>()。" );
        }

        /// <summary>
        ///AddSubItem 的测试
        ///</summary>
        public void AddSubItemTestHelper<T>()
            where T : BaseItem
        {
            T addSubItem = default( T ); // TODO: 初始化为适当的值
            BaseItemContainer<T> itemContainerT = null; // TODO: 初始化为适当的值
            AddingSubItemCallEventArgs<T> target = new AddingSubItemCallEventArgs<T>( addSubItem, itemContainerT ); // TODO: 初始化为适当的值
            T actual;
            actual = target.AddSubItem;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void AddSubItemTest()
        {
            Assert.Inconclusive( "没有找到能够满足 T 的类型约束的相应类型参数。请以适当的类型参数来调用 AddSubItemTestHelper<T>()。" );
        }

        /// <summary>
        ///AddingSubItemCallEventArgs`1 构造函数 的测试
        ///</summary>
        public void AddingSubItemCallEventArgsConstructorTestHelper<T>()
            where T : BaseItem
        {
            T addSubItem = default( T ); // TODO: 初始化为适当的值
            BaseItemContainer<T> itemContainerT = null; // TODO: 初始化为适当的值
            AddingSubItemCallEventArgs<T> target = new AddingSubItemCallEventArgs<T>( addSubItem, itemContainerT );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        [TestMethod()]
        public void AddingSubItemCallEventArgsConstructorTest()
        {
            Assert.Inconclusive( "没有找到能够满足 T 的类型约束的相应类型参数。请以适当的类型参数来调用 AddingSubItemCallEventArgsConstructorTestHel" +
                    "per<T>()。" );
        }
    }
}
