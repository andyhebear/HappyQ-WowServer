using Demo.Mmose.Core.Entity.Item;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 ItemTemplateManagerTest 的测试类，旨在
    ///包含所有 ItemTemplateManagerTest 单元测试
    ///</summary>
    [TestClass()]
    public class ItemTemplateManagerTest
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
            where T : BaseItemTemplate
        {
            ItemTemplateManager<T> target = new ItemTemplateManager<T>(); // TODO: 初始化为适当的值
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
            where T : BaseItemTemplate
        {
            ItemTemplateManager<T> target = new ItemTemplateManager<T>(); // TODO: 初始化为适当的值
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
        ///RemoveItemTemplate 的测试
        ///</summary>
        public void RemoveItemTemplateTestHelper<T>()
            where T : BaseItemTemplate
        {
            ItemTemplateManager<T> target = new ItemTemplateManager<T>(); // TODO: 初始化为适当的值
            long itemTemplateId = 0; // TODO: 初始化为适当的值
            target.RemoveItemTemplate( itemTemplateId );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        [TestMethod()]
        public void RemoveItemTemplateTest()
        {
            Assert.Inconclusive( "没有找到能够满足 T 的类型约束的相应类型参数。请以适当的类型参数来调用 RemoveItemTemplateTestHelper<T>()。" );
        }

        /// <summary>
        ///GetItemTemplate 的测试
        ///</summary>
        public void GetItemTemplateTestHelper<T>()
            where T : BaseItemTemplate
        {
            ItemTemplateManager<T> target = new ItemTemplateManager<T>(); // TODO: 初始化为适当的值
            long itemTemplateId = 0; // TODO: 初始化为适当的值
            T expected = default( T ); // TODO: 初始化为适当的值
            T actual;
            actual = target.GetItemTemplate( itemTemplateId );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void GetItemTemplateTest()
        {
            Assert.Inconclusive( "没有找到能够满足 T 的类型约束的相应类型参数。请以适当的类型参数来调用 GetItemTemplateTestHelper<T>()。" );
        }

        /// <summary>
        ///AddItemTemplate 的测试
        ///</summary>
        public void AddItemTemplateTestHelper<T>()
            where T : BaseItemTemplate
        {
            ItemTemplateManager<T> target = new ItemTemplateManager<T>(); // TODO: 初始化为适当的值
            long itemTemplateId = 0; // TODO: 初始化为适当的值
            T itemTemplateT = default( T ); // TODO: 初始化为适当的值
            target.AddItemTemplate( itemTemplateId, itemTemplateT );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        [TestMethod()]
        public void AddItemTemplateTest()
        {
            Assert.Inconclusive( "没有找到能够满足 T 的类型约束的相应类型参数。请以适当的类型参数来调用 AddItemTemplateTestHelper<T>()。" );
        }

        /// <summary>
        ///ItemTemplateManager`1 构造函数 的测试
        ///</summary>
        public void ItemTemplateManagerConstructorTest1Helper<T>()
            where T : BaseItemTemplate
        {
            ItemTemplateManager<T> target = new ItemTemplateManager<T>();
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        [TestMethod()]
        public void ItemTemplateManagerConstructorTest1()
        {
            Assert.Inconclusive( "没有找到能够满足 T 的类型约束的相应类型参数。请以适当的类型参数来调用 ItemTemplateManagerConstructorTest1Helper<T>" +
                    "()。" );
        }

        /// <summary>
        ///ItemTemplateManager`1 构造函数 的测试
        ///</summary>
        public void ItemTemplateManagerConstructorTestHelper<T>()
            where T : BaseItemTemplate
        {
            int iCapacity = 0; // TODO: 初始化为适当的值
            ItemTemplateManager<T> target = new ItemTemplateManager<T>( iCapacity );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        [TestMethod()]
        public void ItemTemplateManagerConstructorTest()
        {
            Assert.Inconclusive( "没有找到能够满足 T 的类型约束的相应类型参数。请以适当的类型参数来调用 ItemTemplateManagerConstructorTestHelper<T>(" +
                    ")。" );
        }
    }
}
