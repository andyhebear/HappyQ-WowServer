using Demo.Mmose.Core.Server.Language;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 LanguageStringFromFile_SetStringHandlerTest 的测试类，旨在
    ///包含所有 LanguageStringFromFile_SetStringHandlerTest 单元测试
    ///</summary>
    [TestClass()]
    public class LanguageStringFromFile_SetStringHandlerTest
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
        ///RemoveHandler 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void RemoveHandlerTest()
        {
            LanguageStringFromFile_Accessor.SetStringHandler target = new LanguageStringFromFile_Accessor.SetStringHandler(); // TODO: 初始化为适当的值
            string strResourceName = string.Empty; // TODO: 初始化为适当的值
            target.RemoveHandler( strResourceName );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///GetHandler 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void GetHandlerTest()
        {
            LanguageStringFromFile_Accessor.SetStringHandler target = new LanguageStringFromFile_Accessor.SetStringHandler(); // TODO: 初始化为适当的值
            string strResourceName = string.Empty; // TODO: 初始化为适当的值
            LanguageStringFromFile_Accessor.SetStringEventHandler expected = null; // TODO: 初始化为适当的值
            LanguageStringFromFile_Accessor.SetStringEventHandler actual;
            actual = target.GetHandler( strResourceName );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///SetStringHandler 构造函数 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void LanguageStringFromFile_SetStringHandlerConstructorTest()
        {
            LanguageStringFromFile_Accessor.SetStringHandler target = new LanguageStringFromFile_Accessor.SetStringHandler();
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
