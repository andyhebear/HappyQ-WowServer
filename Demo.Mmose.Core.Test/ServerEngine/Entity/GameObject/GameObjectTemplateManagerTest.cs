using Demo.Mmose.Core.Entity.GameObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 GameObjectTemplateManagerTest 的测试类，旨在
    ///包含所有 GameObjectTemplateManagerTest 单元测试
    ///</summary>
    [TestClass()]
    public class GameObjectTemplateManagerTest
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
            where T : BaseGameObjectTemplate
        {
            GameObjectTemplateManager<T> target = new GameObjectTemplateManager<T>(); // TODO: 初始化为适当的值
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
            where T : BaseGameObjectTemplate
        {
            GameObjectTemplateManager<T> target = new GameObjectTemplateManager<T>(); // TODO: 初始化为适当的值
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
            where T : BaseGameObjectTemplate
        {
            GameObjectTemplateManager<T> target = new GameObjectTemplateManager<T>(); // TODO: 初始化为适当的值
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
            where T : BaseGameObjectTemplate
        {
            GameObjectTemplateManager<T> target = new GameObjectTemplateManager<T>(); // TODO: 初始化为适当的值
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
            where T : BaseGameObjectTemplate
        {
            GameObjectTemplateManager<T> target = new GameObjectTemplateManager<T>(); // TODO: 初始化为适当的值
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
        ///GameObjectTemplateManager`1 构造函数 的测试
        ///</summary>
        public void GameObjectTemplateManagerConstructorTest1Helper<T>()
            where T : BaseGameObjectTemplate
        {
            GameObjectTemplateManager<T> target = new GameObjectTemplateManager<T>();
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        [TestMethod()]
        public void GameObjectTemplateManagerConstructorTest1()
        {
            Assert.Inconclusive( "没有找到能够满足 T 的类型约束的相应类型参数。请以适当的类型参数来调用 GameObjectTemplateManagerConstructorTest1Hel" +
                    "per<T>()。" );
        }

        /// <summary>
        ///GameObjectTemplateManager`1 构造函数 的测试
        ///</summary>
        public void GameObjectTemplateManagerConstructorTestHelper<T>()
            where T : BaseGameObjectTemplate
        {
            int iCapacity = 0; // TODO: 初始化为适当的值
            GameObjectTemplateManager<T> target = new GameObjectTemplateManager<T>( iCapacity );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        [TestMethod()]
        public void GameObjectTemplateManagerConstructorTest()
        {
            Assert.Inconclusive( "没有找到能够满足 T 的类型约束的相应类型参数。请以适当的类型参数来调用 GameObjectTemplateManagerConstructorTestHelp" +
                    "er<T>()。" );
        }

        /// <summary>
        ///Count 的测试
        ///</summary>
        public void CountTest1Helper<T>()
            where T : BaseGameObjectTemplate
        {
            GameObjectTemplateManager<T> target = new GameObjectTemplateManager<T>(); // TODO: 初始化为适当的值
            int actual;
            actual = target.Count;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void CountTest1()
        {
            Assert.Inconclusive( "没有找到能够满足 T 的类型约束的相应类型参数。请以适当的类型参数来调用 CountTest1Helper<T>()。" );
        }

        /// <summary>
        ///ToArray 的测试
        ///</summary>
        public void ToArrayTest1Helper<T>()
            where T : BaseGameObjectTemplate
        {
            GameObjectTemplateManager<T> target = new GameObjectTemplateManager<T>(); // TODO: 初始化为适当的值
            T[] expected = null; // TODO: 初始化为适当的值
            T[] actual;
            actual = target.ToArray();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void ToArrayTest1()
        {
            Assert.Inconclusive( "没有找到能够满足 T 的类型约束的相应类型参数。请以适当的类型参数来调用 ToArrayTest1Helper<T>()。" );
        }

        /// <summary>
        ///RemoveCreatureTemplate 的测试
        ///</summary>
        public void RemoveCreatureTemplateTest1Helper<T>()
            where T : BaseGameObjectTemplate
        {
            GameObjectTemplateManager<T> target = new GameObjectTemplateManager<T>(); // TODO: 初始化为适当的值
            long iCreatureId = 0; // TODO: 初始化为适当的值
            target.RemoveCreatureTemplate( iCreatureId );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        [TestMethod()]
        public void RemoveCreatureTemplateTest1()
        {
            Assert.Inconclusive( "没有找到能够满足 T 的类型约束的相应类型参数。请以适当的类型参数来调用 RemoveCreatureTemplateTest1Helper<T>()。" );
        }

        /// <summary>
        ///GetCreatureTemplate 的测试
        ///</summary>
        public void GetCreatureTemplateTest1Helper<T>()
            where T : BaseGameObjectTemplate
        {
            GameObjectTemplateManager<T> target = new GameObjectTemplateManager<T>(); // TODO: 初始化为适当的值
            long iCreatureId = 0; // TODO: 初始化为适当的值
            T expected = default( T ); // TODO: 初始化为适当的值
            T actual;
            actual = target.GetCreatureTemplate( iCreatureId );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void GetCreatureTemplateTest1()
        {
            Assert.Inconclusive( "没有找到能够满足 T 的类型约束的相应类型参数。请以适当的类型参数来调用 GetCreatureTemplateTest1Helper<T>()。" );
        }

        /// <summary>
        ///AddCreatureTemplate 的测试
        ///</summary>
        public void AddCreatureTemplateTest1Helper<T>()
            where T : BaseGameObjectTemplate
        {
            GameObjectTemplateManager<T> target = new GameObjectTemplateManager<T>(); // TODO: 初始化为适当的值
            long iCreatureId = 0; // TODO: 初始化为适当的值
            T creatureT = default( T ); // TODO: 初始化为适当的值
            target.AddCreatureTemplate( iCreatureId, creatureT );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        [TestMethod()]
        public void AddCreatureTemplateTest1()
        {
            Assert.Inconclusive( "没有找到能够满足 T 的类型约束的相应类型参数。请以适当的类型参数来调用 AddCreatureTemplateTest1Helper<T>()。" );
        }

        /// <summary>
        ///GameObjectTemplateManager`1 构造函数 的测试
        ///</summary>
        public void GameObjectTemplateManagerConstructorTest3Helper<T>()
            where T : BaseGameObjectTemplate
        {
            GameObjectTemplateManager<T> target = new GameObjectTemplateManager<T>();
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        [TestMethod()]
        public void GameObjectTemplateManagerConstructorTest3()
        {
            Assert.Inconclusive( "没有找到能够满足 T 的类型约束的相应类型参数。请以适当的类型参数来调用 GameObjectTemplateManagerConstructorTest3Hel" +
                    "per<T>()。" );
        }

        /// <summary>
        ///GameObjectTemplateManager`1 构造函数 的测试
        ///</summary>
        public void GameObjectTemplateManagerConstructorTest2Helper<T>()
            where T : BaseGameObjectTemplate
        {
            int iCapacity = 0; // TODO: 初始化为适当的值
            GameObjectTemplateManager<T> target = new GameObjectTemplateManager<T>( iCapacity );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        [TestMethod()]
        public void GameObjectTemplateManagerConstructorTest2()
        {
            Assert.Inconclusive( "没有找到能够满足 T 的类型约束的相应类型参数。请以适当的类型参数来调用 GameObjectTemplateManagerConstructorTest2Hel" +
                    "per<T>()。" );
        }
    }
}
