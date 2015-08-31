using Demo.Mmose.Core.Entity.Item;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 BaseItemContainerStateTest 的测试类，旨在
    ///包含所有 BaseItemContainerStateTest 单元测试
    ///</summary>
    [TestClass()]
    public class BaseItemContainerStateTest
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
        ///SingletonInstance 的测试
        ///</summary>
        public void SingletonInstanceTestHelper<T>()
            where T : BaseItem
        {
            BaseItemContainerState<T> actual;
            actual = BaseItemContainerState<T>.SingletonInstance;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void SingletonInstanceTest()
        {
            Assert.Inconclusive( "没有找到能够满足 T 的类型约束的相应类型参数。请以适当的类型参数来调用 SingletonInstanceTestHelper<T>()。" );
        }

        /// <summary>
        ///IsUpdateRemoveSubItemCall 的测试
        ///</summary>
        public void IsUpdateRemoveSubItemCallTestHelper<T>()
            where T : BaseItem
        {
            BaseItemContainerState<T> target = new BaseItemContainerState<T>(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            target.IsUpdateRemoveSubItemCall = expected;
            actual = target.IsUpdateRemoveSubItemCall;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void IsUpdateRemoveSubItemCallTest()
        {
            Assert.Inconclusive( "没有找到能够满足 T 的类型约束的相应类型参数。请以适当的类型参数来调用 IsUpdateRemoveSubItemCallTestHelper<T>()。" );
        }

        /// <summary>
        ///IsUpdateAddSubItemCall 的测试
        ///</summary>
        public void IsUpdateAddSubItemCallTestHelper<T>()
            where T : BaseItem
        {
            BaseItemContainerState<T> target = new BaseItemContainerState<T>(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            target.IsUpdateAddSubItemCall = expected;
            actual = target.IsUpdateAddSubItemCall;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void IsUpdateAddSubItemCallTest()
        {
            Assert.Inconclusive( "没有找到能够满足 T 的类型约束的相应类型参数。请以适当的类型参数来调用 IsUpdateAddSubItemCallTestHelper<T>()。" );
        }

        /// <summary>
        ///RestoreAll 的测试
        ///</summary>
        public void RestoreAllTestHelper<T>()
            where T : BaseItem
        {
            BaseItemContainerState<T> target = new BaseItemContainerState<T>(); // TODO: 初始化为适当的值
            target.RestoreAll();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        [TestMethod()]
        public void RestoreAllTest()
        {
            Assert.Inconclusive( "没有找到能够满足 T 的类型约束的相应类型参数。请以适当的类型参数来调用 RestoreAllTestHelper<T>()。" );
        }

        /// <summary>
        ///OnRemovingSubItem 的测试
        ///</summary>
        public void OnRemovingSubItemTestHelper<T>()
            where T : BaseItem
        {
            BaseItemContainerState<T> target = new BaseItemContainerState<T>(); // TODO: 初始化为适当的值
            T removeSubItem = default( T ); // TODO: 初始化为适当的值
            BaseItemContainer<T> itemContainer = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.OnRemovingSubItem( removeSubItem, itemContainer );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void OnRemovingSubItemTest()
        {
            Assert.Inconclusive( "没有找到能够满足 T 的类型约束的相应类型参数。请以适当的类型参数来调用 OnRemovingSubItemTestHelper<T>()。" );
        }

        /// <summary>
        ///OnRemovedSubItem 的测试
        ///</summary>
        public void OnRemovedSubItemTestHelper<T>()
            where T : BaseItem
        {
            BaseItemContainerState<T> target = new BaseItemContainerState<T>(); // TODO: 初始化为适当的值
            T removeSubItem = default( T ); // TODO: 初始化为适当的值
            BaseItemContainer<T> itemContainer = null; // TODO: 初始化为适当的值
            target.OnRemovedSubItem( removeSubItem, itemContainer );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        [TestMethod()]
        public void OnRemovedSubItemTest()
        {
            Assert.Inconclusive( "没有找到能够满足 T 的类型约束的相应类型参数。请以适当的类型参数来调用 OnRemovedSubItemTestHelper<T>()。" );
        }

        /// <summary>
        ///OnAddingSubItem 的测试
        ///</summary>
        public void OnAddingSubItemTestHelper<T>()
            where T : BaseItem
        {
            BaseItemContainerState<T> target = new BaseItemContainerState<T>(); // TODO: 初始化为适当的值
            T addSubItemT = default( T ); // TODO: 初始化为适当的值
            BaseItemContainer<T> itemContainer = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.OnAddingSubItem( addSubItemT, itemContainer );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void OnAddingSubItemTest()
        {
            Assert.Inconclusive( "没有找到能够满足 T 的类型约束的相应类型参数。请以适当的类型参数来调用 OnAddingSubItemTestHelper<T>()。" );
        }

        /// <summary>
        ///OnAddedSubItem 的测试
        ///</summary>
        public void OnAddedSubItemTestHelper<T>()
            where T : BaseItem
        {
            BaseItemContainerState<T> target = new BaseItemContainerState<T>(); // TODO: 初始化为适当的值
            T addSubItemT = default( T ); // TODO: 初始化为适当的值
            BaseItemContainer<T> itemContainer = null; // TODO: 初始化为适当的值
            target.OnAddedSubItem( addSubItemT, itemContainer );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        [TestMethod()]
        public void OnAddedSubItemTest()
        {
            Assert.Inconclusive( "没有找到能够满足 T 的类型约束的相应类型参数。请以适当的类型参数来调用 OnAddedSubItemTestHelper<T>()。" );
        }

        /// <summary>
        ///BaseItemContainerState`1 构造函数 的测试
        ///</summary>
        public void BaseItemContainerStateConstructorTestHelper<T>()
            where T : BaseItem
        {
            BaseItemContainerState<T> target = new BaseItemContainerState<T>();
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        [TestMethod()]
        public void BaseItemContainerStateConstructorTest()
        {
            Assert.Inconclusive( "没有找到能够满足 T 的类型约束的相应类型参数。请以适当的类型参数来调用 BaseItemContainerStateConstructorTestHelper<" +
                    "T>()。" );
        }
    }
}
