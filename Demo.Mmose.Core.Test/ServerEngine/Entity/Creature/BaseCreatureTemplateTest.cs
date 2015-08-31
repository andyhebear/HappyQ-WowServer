using Demo.Mmose.Core.Entity.Creature;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Demo.Mmose.Core.Common;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 BaseCreatureTemplateTest 的测试类，旨在
    ///包含所有 BaseCreatureTemplateTest 单元测试
    ///</summary>
    [TestClass()]
    public class BaseCreatureTemplateTest
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

        internal virtual BaseCreatureTemplate CreateBaseCreatureTemplate()
        {
            // TODO: 实例化相应的具体类。
            BaseCreatureTemplate target = null;
            return target;
        }

        /// <summary>
        ///Serial 的测试
        ///</summary>
        [TestMethod()]
        public void SerialTest()
        {
            BaseCreatureTemplate target = CreateBaseCreatureTemplate(); // TODO: 初始化为适当的值
            Serial expected = new Serial(); // TODO: 初始化为适当的值
            Serial actual;
            target.Serial = expected;
            actual = target.Serial;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        internal virtual BaseCreatureTemplate_Accessor CreateBaseCreatureTemplate_Accessor()
        {
            // TODO: 实例化相应的具体类。
            BaseCreatureTemplate_Accessor target = null;
            return target;
        }

        /// <summary>
        ///DefaultCreatureInit 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void DefaultCreatureInitTest()
        {
            PrivateObject param0 = null; // TODO: 初始化为适当的值
            BaseCreatureTemplate_Accessor target = new BaseCreatureTemplate_Accessor( param0 ); // TODO: 初始化为适当的值
            target.DefaultCreatureInit();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }
    }
}
