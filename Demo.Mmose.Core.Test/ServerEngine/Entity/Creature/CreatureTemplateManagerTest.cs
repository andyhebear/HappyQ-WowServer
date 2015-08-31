using Demo.Mmose.Core.Entity.Creature;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 CreatureTemplateManagerTest 的测试类，旨在
    ///包含所有 CreatureTemplateManagerTest 单元测试
    ///</summary>
    [TestClass()]
    public class CreatureTemplateManagerTest
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
            where T : BaseCreatureTemplate
        {
            CreatureTemplateManager<T> target = new CreatureTemplateManager<T>(); // TODO: 初始化为适当的值
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
            where T : BaseCreatureTemplate
        {
            CreatureTemplateManager<T> target = new CreatureTemplateManager<T>(); // TODO: 初始化为适当的值
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
        ///RemoveCreatureTemplate 的测试
        ///</summary>
        public void RemoveCreatureTemplateTestHelper<T>()
            where T : BaseCreatureTemplate
        {
            CreatureTemplateManager<T> target = new CreatureTemplateManager<T>(); // TODO: 初始化为适当的值
            long iCreatureId = 0; // TODO: 初始化为适当的值
            target.RemoveCreatureTemplate( iCreatureId );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        [TestMethod()]
        public void RemoveCreatureTemplateTest()
        {
            Assert.Inconclusive( "没有找到能够满足 T 的类型约束的相应类型参数。请以适当的类型参数来调用 RemoveCreatureTemplateTestHelper<T>()。" );
        }

        /// <summary>
        ///GetCreatureTemplate 的测试
        ///</summary>
        public void GetCreatureTemplateTestHelper<T>()
            where T : BaseCreatureTemplate
        {
            CreatureTemplateManager<T> target = new CreatureTemplateManager<T>(); // TODO: 初始化为适当的值
            long iCreatureId = 0; // TODO: 初始化为适当的值
            T expected = default( T ); // TODO: 初始化为适当的值
            T actual;
            actual = target.GetCreatureTemplate( iCreatureId );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void GetCreatureTemplateTest()
        {
            Assert.Inconclusive( "没有找到能够满足 T 的类型约束的相应类型参数。请以适当的类型参数来调用 GetCreatureTemplateTestHelper<T>()。" );
        }

        /// <summary>
        ///AddCreatureTemplate 的测试
        ///</summary>
        public void AddCreatureTemplateTestHelper<T>()
            where T : BaseCreatureTemplate
        {
            CreatureTemplateManager<T> target = new CreatureTemplateManager<T>(); // TODO: 初始化为适当的值
            long iCreatureId = 0; // TODO: 初始化为适当的值
            T creatureT = default( T ); // TODO: 初始化为适当的值
            target.AddCreatureTemplate( iCreatureId, creatureT );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        [TestMethod()]
        public void AddCreatureTemplateTest()
        {
            Assert.Inconclusive( "没有找到能够满足 T 的类型约束的相应类型参数。请以适当的类型参数来调用 AddCreatureTemplateTestHelper<T>()。" );
        }

        /// <summary>
        ///CreatureTemplateManager`1 构造函数 的测试
        ///</summary>
        public void CreatureTemplateManagerConstructorTest1Helper<T>()
            where T : BaseCreatureTemplate
        {
            CreatureTemplateManager<T> target = new CreatureTemplateManager<T>();
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        [TestMethod()]
        public void CreatureTemplateManagerConstructorTest1()
        {
            Assert.Inconclusive( "没有找到能够满足 T 的类型约束的相应类型参数。请以适当的类型参数来调用 CreatureTemplateManagerConstructorTest1Helpe" +
                    "r<T>()。" );
        }

        /// <summary>
        ///CreatureTemplateManager`1 构造函数 的测试
        ///</summary>
        public void CreatureTemplateManagerConstructorTestHelper<T>()
            where T : BaseCreatureTemplate
        {
            int iCapacity = 0; // TODO: 初始化为适当的值
            CreatureTemplateManager<T> target = new CreatureTemplateManager<T>( iCapacity );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        [TestMethod()]
        public void CreatureTemplateManagerConstructorTest()
        {
            Assert.Inconclusive( "没有找到能够满足 T 的类型约束的相应类型参数。请以适当的类型参数来调用 CreatureTemplateManagerConstructorTestHelper" +
                    "<T>()。" );
        }
    }
}
