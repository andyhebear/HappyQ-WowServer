using Demo.Mmose.Core.Entity.GameObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Demo.Mmose.Core.Common;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 BaseGameObjectTemplateTest 的测试类，旨在
    ///包含所有 BaseGameObjectTemplateTest 单元测试
    ///</summary>
    [TestClass()]
    public class BaseGameObjectTemplateTest
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
        ///Serial 的测试
        ///</summary>
        [TestMethod()]
        public void SerialTest()
        {
            BaseGameObjectTemplate target = new BaseGameObjectTemplate(); // TODO: 初始化为适当的值
            Serial expected = new Serial(); // TODO: 初始化为适当的值
            Serial actual;
            target.Serial = expected;
            actual = target.Serial;
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
            BaseGameObjectTemplate_Accessor target = new BaseGameObjectTemplate_Accessor(); // TODO: 初始化为适当的值
            target.DefaultGameObjectInit();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///BaseGameObjectTemplate 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void BaseGameObjectTemplateConstructorTest1()
        {
            BaseGameObjectTemplate target = new BaseGameObjectTemplate();
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        /// <summary>
        ///BaseGameObjectTemplate 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void BaseGameObjectTemplateConstructorTest()
        {
            Serial serial = new Serial(); // TODO: 初始化为适当的值
            BaseGameObjectTemplate target = new BaseGameObjectTemplate( serial );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        /// <summary>
        ///Serial 的测试
        ///</summary>
        [TestMethod()]
        public void SerialTest1()
        {
            BaseGameObjectTemplate target = new BaseGameObjectTemplate(); // TODO: 初始化为适当的值
            Serial expected = new Serial(); // TODO: 初始化为适当的值
            Serial actual;
            target.Serial = expected;
            actual = target.Serial;
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
            BaseGameObjectTemplate_Accessor target = new BaseGameObjectTemplate_Accessor(); // TODO: 初始化为适当的值
            target.DefaultGameObjectInit();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///BaseGameObjectTemplate 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void BaseGameObjectTemplateConstructorTest3()
        {
            BaseGameObjectTemplate target = new BaseGameObjectTemplate();
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        /// <summary>
        ///BaseGameObjectTemplate 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void BaseGameObjectTemplateConstructorTest2()
        {
            Serial serial = new Serial(); // TODO: 初始化为适当的值
            BaseGameObjectTemplate target = new BaseGameObjectTemplate( serial );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
