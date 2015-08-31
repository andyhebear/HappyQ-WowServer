using Demo.Mmose.Core.Entity.GameObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Demo.Mmose.Core.Common;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 BaseGameObjectTest 的测试类，旨在
    ///包含所有 BaseGameObjectTest 单元测试
    ///</summary>
    [TestClass()]
    public class BaseGameObjectTest
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
        ///Name 的测试
        ///</summary>
        [TestMethod()]
        public void NameTest()
        {
            BaseGameObject target = new BaseGameObject(); // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            target.Name = expected;
            actual = target.Name;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///BaseGameObjectState 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void BaseGameObjectStateTest()
        {
            BaseGameObject_Accessor target = new BaseGameObject_Accessor(); // TODO: 初始化为适当的值
            BaseGameObjectState expected = null; // TODO: 初始化为适当的值
            BaseGameObjectState actual;
            target.BaseGameObjectState = expected;
            actual = target.BaseGameObjectState;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToString 的测试
        ///</summary>
        [TestMethod()]
        public void ToStringTest()
        {
            BaseGameObject target = new BaseGameObject(); // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = target.ToString();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///DefaultGameObjectInit 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void DefaultGameObjectInitTest()
        {
            BaseGameObject_Accessor target = new BaseGameObject_Accessor(); // TODO: 初始化为适当的值
            target.DefaultGameObjectInit();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///CreateNewGameObjectInstance 的测试
        ///</summary>
        [TestMethod()]
        public void CreateNewGameObjectInstanceTest()
        {
            BaseGameObject target = new BaseGameObject(); // TODO: 初始化为适当的值
            BaseGameObject expected = null; // TODO: 初始化为适当的值
            BaseGameObject actual;
            actual = target.CreateNewGameObjectInstance();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///CompareTo 的测试
        ///</summary>
        [TestMethod()]
        public void CompareToTest()
        {
            BaseGameObject target = new BaseGameObject(); // TODO: 初始化为适当的值
            BaseGameObject other = null; // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = target.CompareTo( other );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///BaseGameObject 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void BaseGameObjectConstructorTest1()
        {
            BaseGameObject target = new BaseGameObject();
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        /// <summary>
        ///BaseGameObject 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void BaseGameObjectConstructorTest()
        {
            Serial serial = new Serial(); // TODO: 初始化为适当的值
            BaseGameObject target = new BaseGameObject( serial );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        /// <summary>
        ///Name 的测试
        ///</summary>
        [TestMethod()]
        public void NameTest1()
        {
            BaseGameObject target = new BaseGameObject(); // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            target.Name = expected;
            actual = target.Name;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///BaseGameObjectState 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void BaseGameObjectStateTest1()
        {
            BaseGameObject_Accessor target = new BaseGameObject_Accessor(); // TODO: 初始化为适当的值
            BaseGameObjectState expected = null; // TODO: 初始化为适当的值
            BaseGameObjectState actual;
            target.BaseGameObjectState = expected;
            actual = target.BaseGameObjectState;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToString 的测试
        ///</summary>
        [TestMethod()]
        public void ToStringTest1()
        {
            BaseGameObject target = new BaseGameObject(); // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = target.ToString();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///DefaultGameObjectInit 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void DefaultGameObjectInitTest1()
        {
            BaseGameObject_Accessor target = new BaseGameObject_Accessor(); // TODO: 初始化为适当的值
            target.DefaultGameObjectInit();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///CreateNewGameObjectInstance 的测试
        ///</summary>
        [TestMethod()]
        public void CreateNewGameObjectInstanceTest1()
        {
            BaseGameObject target = new BaseGameObject(); // TODO: 初始化为适当的值
            BaseGameObject expected = null; // TODO: 初始化为适当的值
            BaseGameObject actual;
            actual = target.CreateNewGameObjectInstance();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///CompareTo 的测试
        ///</summary>
        [TestMethod()]
        public void CompareToTest1()
        {
            BaseGameObject target = new BaseGameObject(); // TODO: 初始化为适当的值
            BaseGameObject other = null; // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = target.CompareTo( other );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///BaseGameObject 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void BaseGameObjectConstructorTest3()
        {
            BaseGameObject target = new BaseGameObject();
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        /// <summary>
        ///BaseGameObject 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void BaseGameObjectConstructorTest2()
        {
            Serial serial = new Serial(); // TODO: 初始化为适当的值
            BaseGameObject target = new BaseGameObject( serial );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
