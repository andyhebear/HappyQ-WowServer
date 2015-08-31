using Demo.Mmose.Core.Entity.Item;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 BaseItemContainerTest 的测试类，旨在
    ///包含所有 BaseItemContainerTest 单元测试
    ///</summary>
    [TestClass()]
    public class BaseItemContainerTest
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
        ///MinSlot 的测试
        ///</summary>
        public void MinSlotTestHelper<T>()
            where T : BaseItem
        {
            BaseItemContainer_Accessor<T> target = new BaseItemContainer_Accessor<T>(); // TODO: 初始化为适当的值
            long expected = 0; // TODO: 初始化为适当的值
            long actual;
            target.MinSlot = expected;
            actual = target.MinSlot;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void MinSlotTest()
        {
            Assert.Inconclusive( "没有找到能够满足 T 的类型约束的相应类型参数。请以适当的类型参数来调用 MinSlotTestHelper<T>()。" );
        }

        /// <summary>
        ///MaxSlot 的测试
        ///</summary>
        public void MaxSlotTestHelper<T>()
            where T : BaseItem
        {
            BaseItemContainer_Accessor<T> target = new BaseItemContainer_Accessor<T>(); // TODO: 初始化为适当的值
            long expected = 0; // TODO: 初始化为适当的值
            long actual;
            target.MaxSlot = expected;
            actual = target.MaxSlot;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void MaxSlotTest()
        {
            Assert.Inconclusive( "没有找到能够满足 T 的类型约束的相应类型参数。请以适当的类型参数来调用 MaxSlotTestHelper<T>()。" );
        }

        /// <summary>
        ///IsContainerFull 的测试
        ///</summary>
        public void IsContainerFullTestHelper<T>()
            where T : BaseItem
        {
            BaseItemContainer<T> target = new BaseItemContainer<T>(); // TODO: 初始化为适当的值
            bool actual;
            actual = target.IsContainerFull;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void IsContainerFullTest()
        {
            Assert.Inconclusive( "没有找到能够满足 T 的类型约束的相应类型参数。请以适当的类型参数来调用 IsContainerFullTestHelper<T>()。" );
        }

        /// <summary>
        ///ContainerOwner 的测试
        ///</summary>
        public void ContainerOwnerTestHelper<T>()
            where T : BaseItem
        {
            BaseItemContainer<T> target = new BaseItemContainer<T>(); // TODO: 初始化为适当的值
            T expected = default( T ); // TODO: 初始化为适当的值
            T actual;
            target.ContainerOwner = expected;
            actual = target.ContainerOwner;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void ContainerOwnerTest()
        {
            Assert.Inconclusive( "没有找到能够满足 T 的类型约束的相应类型参数。请以适当的类型参数来调用 ContainerOwnerTestHelper<T>()。" );
        }

        /// <summary>
        ///BaseItemContainerState 的测试
        ///</summary>
        public void BaseItemContainerStateTestHelper<T>()
            where T : BaseItem
        {
            BaseItemContainer_Accessor<T> target = new BaseItemContainer_Accessor<T>(); // TODO: 初始化为适当的值
            BaseItemContainerState<T> expected = null; // TODO: 初始化为适当的值
            BaseItemContainerState<T> actual;
            target.BaseItemContainerState = expected;
            actual = target.BaseItemContainerState;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void BaseItemContainerStateTest()
        {
            Assert.Inconclusive( "没有找到能够满足 T 的类型约束的相应类型参数。请以适当的类型参数来调用 BaseItemContainerStateTestHelper<T>()。" );
        }

        /// <summary>
        ///TryFindFreeSlot 的测试
        ///</summary>
        public void TryFindFreeSlotTestHelper<T>()
            where T : BaseItem
        {
            BaseItemContainer<T> target = new BaseItemContainer<T>(); // TODO: 初始化为适当的值
            long iRetrunItemSlot = 0; // TODO: 初始化为适当的值
            long iRetrunItemSlotExpected = 0; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.TryFindFreeSlot( ref iRetrunItemSlot );
            Assert.AreEqual( iRetrunItemSlotExpected, iRetrunItemSlot );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void TryFindFreeSlotTest()
        {
            Assert.Inconclusive( "没有找到能够满足 T 的类型约束的相应类型参数。请以适当的类型参数来调用 TryFindFreeSlotTestHelper<T>()。" );
        }

        /// <summary>
        ///SubItemsToArray 的测试
        ///</summary>
        public void SubItemsToArrayTestHelper<T>()
            where T : BaseItem
        {
            BaseItemContainer<T> target = new BaseItemContainer<T>(); // TODO: 初始化为适当的值
            T[] expected = null; // TODO: 初始化为适当的值
            T[] actual;
            actual = target.SubItemsToArray();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void SubItemsToArrayTest()
        {
            Assert.Inconclusive( "没有找到能够满足 T 的类型约束的相应类型参数。请以适当的类型参数来调用 SubItemsToArrayTestHelper<T>()。" );
        }

        /// <summary>
        ///RemoveSubItem 的测试
        ///</summary>
        public void RemoveSubItemTestHelper<T>()
            where T : BaseItem
        {
            BaseItemContainer<T> target = new BaseItemContainer<T>(); // TODO: 初始化为适当的值
            long lItemSlot = 0; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.RemoveSubItem( lItemSlot );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void RemoveSubItemTest()
        {
            Assert.Inconclusive( "没有找到能够满足 T 的类型约束的相应类型参数。请以适当的类型参数来调用 RemoveSubItemTestHelper<T>()。" );
        }

        /// <summary>
        ///InitContainerSlot 的测试
        ///</summary>
        public void InitContainerSlotTestHelper<T>()
            where T : BaseItem
        {
            BaseItemContainer<T> target = new BaseItemContainer<T>(); // TODO: 初始化为适当的值
            long lMinSlot = 0; // TODO: 初始化为适当的值
            long lMaxSlot = 0; // TODO: 初始化为适当的值
            target.InitContainerSlot( lMinSlot, lMaxSlot );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        [TestMethod()]
        public void InitContainerSlotTest()
        {
            Assert.Inconclusive( "没有找到能够满足 T 的类型约束的相应类型参数。请以适当的类型参数来调用 InitContainerSlotTestHelper<T>()。" );
        }

        /// <summary>
        ///FindSubItemAtSlot 的测试
        ///</summary>
        public void FindSubItemAtSlotTestHelper<T>()
            where T : BaseItem
        {
            BaseItemContainer<T> target = new BaseItemContainer<T>(); // TODO: 初始化为适当的值
            long lItemSlot = 0; // TODO: 初始化为适当的值
            T expected = default( T ); // TODO: 初始化为适当的值
            T actual;
            actual = target.FindSubItemAtSlot( lItemSlot );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void FindSubItemAtSlotTest()
        {
            Assert.Inconclusive( "没有找到能够满足 T 的类型约束的相应类型参数。请以适当的类型参数来调用 FindSubItemAtSlotTestHelper<T>()。" );
        }

        /// <summary>
        ///EmptyContainer 的测试
        ///</summary>
        public void EmptyContainerTestHelper<T>()
            where T : BaseItem
        {
            BaseItemContainer<T> target = new BaseItemContainer<T>(); // TODO: 初始化为适当的值
            target.EmptyContainer();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        [TestMethod()]
        public void EmptyContainerTest()
        {
            Assert.Inconclusive( "没有找到能够满足 T 的类型约束的相应类型参数。请以适当的类型参数来调用 EmptyContainerTestHelper<T>()。" );
        }

        /// <summary>
        ///AddToFreeSlot 的测试
        ///</summary>
        public void AddToFreeSlotTestHelper<T>()
            where T : BaseItem
        {
            BaseItemContainer<T> target = new BaseItemContainer<T>(); // TODO: 初始化为适当的值
            T itemT = default( T ); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.AddToFreeSlot( itemT );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void AddToFreeSlotTest()
        {
            Assert.Inconclusive( "没有找到能够满足 T 的类型约束的相应类型参数。请以适当的类型参数来调用 AddToFreeSlotTestHelper<T>()。" );
        }

        /// <summary>
        ///AddSubItem 的测试
        ///</summary>
        public void AddSubItemTestHelper<T>()
            where T : BaseItem
        {
            BaseItemContainer<T> target = new BaseItemContainer<T>(); // TODO: 初始化为适当的值
            long lItemSlot = 0; // TODO: 初始化为适当的值
            T itemT = default( T ); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.AddSubItem( lItemSlot, itemT );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void AddSubItemTest()
        {
            Assert.Inconclusive( "没有找到能够满足 T 的类型约束的相应类型参数。请以适当的类型参数来调用 AddSubItemTestHelper<T>()。" );
        }

        /// <summary>
        ///BaseItemContainer`1 构造函数 的测试
        ///</summary>
        public void BaseItemContainerConstructorTestHelper<T>()
            where T : BaseItem
        {
            BaseItemContainer<T> target = new BaseItemContainer<T>();
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        [TestMethod()]
        public void BaseItemContainerConstructorTest()
        {
            Assert.Inconclusive( "没有找到能够满足 T 的类型约束的相应类型参数。请以适当的类型参数来调用 BaseItemContainerConstructorTestHelper<T>()。" +
                    "" );
        }
    }
}
