using Demo.Mmose.Core.Entity.Creature;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 UpdatedCreatureTemplateEventArgsTest 的测试类，旨在
    ///包含所有 UpdatedCreatureTemplateEventArgsTest 单元测试
    ///</summary>
    [TestClass()]
    public class UpdatedCreatureTemplateEventArgsTest
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
        ///OldCreatureTemplate 的测试
        ///</summary>
        [TestMethod()]
        public void OldCreatureTemplateTest()
        {
            BaseCreatureTemplate creatureTemplate = null; // TODO: 初始化为适当的值
            BaseCreature creature = null; // TODO: 初始化为适当的值
            UpdatedCreatureTemplateEventArgs target = new UpdatedCreatureTemplateEventArgs( creatureTemplate, creature ); // TODO: 初始化为适当的值
            BaseCreatureTemplate actual;
            actual = target.OldCreatureTemplate;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///UpdatedCreatureTemplateEventArgs 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void UpdatedCreatureTemplateEventArgsConstructorTest()
        {
            BaseCreatureTemplate creatureTemplate = null; // TODO: 初始化为适当的值
            BaseCreature creature = null; // TODO: 初始化为适当的值
            UpdatedCreatureTemplateEventArgs target = new UpdatedCreatureTemplateEventArgs( creatureTemplate, creature );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
