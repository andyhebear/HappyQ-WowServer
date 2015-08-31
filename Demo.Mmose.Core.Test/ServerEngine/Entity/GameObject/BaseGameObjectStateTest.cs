using Demo.Mmose.Core.Entity.GameObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 BaseGameObjectStateTest 的测试类，旨在
    ///包含所有 BaseGameObjectStateTest 单元测试
    ///</summary>
    [TestClass()]
    public class BaseGameObjectStateTest
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
        [TestMethod()]
        public void SingletonInstanceTest()
        {
            BaseGameObjectState actual;
            actual = BaseGameObjectState.SingletonInstance;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IsUpdateName 的测试
        ///</summary>
        [TestMethod()]
        public void IsUpdateNameTest()
        {
            BaseGameObjectState target = new BaseGameObjectState(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            target.IsUpdateName = expected;
            actual = target.IsUpdateName;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///RestoreAll 的测试
        ///</summary>
        [TestMethod()]
        public void RestoreAllTest()
        {
            BaseGameObjectState target = new BaseGameObjectState(); // TODO: 初始化为适当的值
            target.RestoreAll();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnUpdatingName 的测试
        ///</summary>
        [TestMethod()]
        public void OnUpdatingNameTest()
        {
            BaseGameObjectState target = new BaseGameObjectState(); // TODO: 初始化为适当的值
            string strName = string.Empty; // TODO: 初始化为适当的值
            BaseGameObject creature = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.OnUpdatingName( strName, creature );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnUpdatedName 的测试
        ///</summary>
        [TestMethod()]
        public void OnUpdatedNameTest()
        {
            BaseGameObjectState target = new BaseGameObjectState(); // TODO: 初始化为适当的值
            string strName = string.Empty; // TODO: 初始化为适当的值
            BaseGameObject creature = null; // TODO: 初始化为适当的值
            target.OnUpdatedName( strName, creature );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///BaseGameObjectState 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void BaseGameObjectStateConstructorTest()
        {
            BaseGameObjectState target = new BaseGameObjectState();
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        /// <summary>
        ///SingletonInstance 的测试
        ///</summary>
        [TestMethod()]
        public void SingletonInstanceTest1()
        {
            BaseGameObjectState actual;
            actual = BaseGameObjectState.SingletonInstance;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IsUpdateName 的测试
        ///</summary>
        [TestMethod()]
        public void IsUpdateNameTest1()
        {
            BaseGameObjectState target = new BaseGameObjectState(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            target.IsUpdateName = expected;
            actual = target.IsUpdateName;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///RestoreAll 的测试
        ///</summary>
        [TestMethod()]
        public void RestoreAllTest1()
        {
            BaseGameObjectState target = new BaseGameObjectState(); // TODO: 初始化为适当的值
            target.RestoreAll();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnUpdatingName 的测试
        ///</summary>
        [TestMethod()]
        public void OnUpdatingNameTest1()
        {
            BaseGameObjectState target = new BaseGameObjectState(); // TODO: 初始化为适当的值
            string strName = string.Empty; // TODO: 初始化为适当的值
            BaseGameObject creature = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.OnUpdatingName( strName, creature );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnUpdatedName 的测试
        ///</summary>
        [TestMethod()]
        public void OnUpdatedNameTest1()
        {
            BaseGameObjectState target = new BaseGameObjectState(); // TODO: 初始化为适当的值
            string strName = string.Empty; // TODO: 初始化为适当的值
            BaseGameObject creature = null; // TODO: 初始化为适当的值
            target.OnUpdatedName( strName, creature );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///BaseGameObjectState 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void BaseGameObjectStateConstructorTest1()
        {
            BaseGameObjectState target = new BaseGameObjectState();
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
