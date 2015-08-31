using Demo.Mmose.Core.Entity.Item;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 ItemManagerTest 的测试类，旨在
    ///包含所有 ItemManagerTest 单元测试
    ///</summary>
    [TestClass()]
    public class ItemManagerTest
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
        ///Count 的测试
        ///</summary>
        public void CountTestHelper<T>()
            where T : BaseItem
        {
            ItemManager<T> target = new ItemManager<T>(); // TODO: 初始化为适当的值
            int actual;
            actual = target.Count;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void CountTest()
        {
            Assert.Inconclusive( "没有找到能够满足 T 的类型约束的相应类型参数。请以适当的类型参数来调用 CountTestHelper<T>()。" );
        }

        /// <summary>
        ///ToArray 的测试
        ///</summary>
        public void ToArrayTestHelper<T>()
            where T : BaseItem
        {
            ItemManager<T> target = new ItemManager<T>(); // TODO: 初始化为适当的值
            T[] expected = null; // TODO: 初始化为适当的值
            T[] actual;
            actual = target.ToArray();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void ToArrayTest()
        {
            Assert.Inconclusive( "没有找到能够满足 T 的类型约束的相应类型参数。请以适当的类型参数来调用 ToArrayTestHelper<T>()。" );
        }

        /// <summary>
        ///RemoveItem 的测试
        ///</summary>
        public void RemoveItemTestHelper<T>()
            where T : BaseItem
        {
            ItemManager<T> target = new ItemManager<T>(); // TODO: 初始化为适当的值
            long itemId = 0; // TODO: 初始化为适当的值
            target.RemoveItem( itemId );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        [TestMethod()]
        public void RemoveItemTest()
        {
            Assert.Inconclusive( "没有找到能够满足 T 的类型约束的相应类型参数。请以适当的类型参数来调用 RemoveItemTestHelper<T>()。" );
        }

        /// <summary>
        ///GetItem 的测试
        ///</summary>
        public void GetItemTestHelper<T>()
            where T : BaseItem
        {
            ItemManager<T> target = new ItemManager<T>(); // TODO: 初始化为适当的值
            long itemId = 0; // TODO: 初始化为适当的值
            T expected = default( T ); // TODO: 初始化为适当的值
            T actual;
            actual = target.GetItem( itemId );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void GetItemTest()
        {
            Assert.Inconclusive( "没有找到能够满足 T 的类型约束的相应类型参数。请以适当的类型参数来调用 GetItemTestHelper<T>()。" );
        }

        /// <summary>
        ///AddItem 的测试
        ///</summary>
        public void AddItemTestHelper<T>()
            where T : BaseItem
        {
            ItemManager<T> target = new ItemManager<T>(); // TODO: 初始化为适当的值
            long itemId = 0; // TODO: 初始化为适当的值
            T itemT = default( T ); // TODO: 初始化为适当的值
            target.AddItem( itemId, itemT );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        [TestMethod()]
        public void AddItemTest()
        {
            Assert.Inconclusive( "没有找到能够满足 T 的类型约束的相应类型参数。请以适当的类型参数来调用 AddItemTestHelper<T>()。" );
        }

        /// <summary>
        ///ItemManager`1 构造函数 的测试
        ///</summary>
        public void ItemManagerConstructorTest1Helper<T>()
            where T : BaseItem
        {
            ItemManager<T> target = new ItemManager<T>();
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        [TestMethod()]
        public void ItemManagerConstructorTest1()
        {
            Assert.Inconclusive( "没有找到能够满足 T 的类型约束的相应类型参数。请以适当的类型参数来调用 ItemManagerConstructorTest1Helper<T>()。" );
        }

        /// <summary>
        ///ItemManager`1 构造函数 的测试
        ///</summary>
        public void ItemManagerConstructorTestHelper<T>()
            where T : BaseItem
        {
            int iCapacity = 0; // TODO: 初始化为适当的值
            ItemManager<T> target = new ItemManager<T>( iCapacity );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        [TestMethod()]
        public void ItemManagerConstructorTest()
        {
            Assert.Inconclusive( "没有找到能够满足 T 的类型约束的相应类型参数。请以适当的类型参数来调用 ItemManagerConstructorTestHelper<T>()。" );
        }
    }
}
