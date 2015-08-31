using Demo.Mmose.Core.Entity.Character;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Network;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 BaseCharacterTest 的测试类，旨在
    ///包含所有 BaseCharacterTest 单元测试
    ///</summary>
    [TestClass()]
    public class BaseCharacterTest
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
        ///NetState 的测试
        ///</summary>
        [TestMethod()]
        public void NetStateTest()
        {
            BaseCharacter target = CreateBaseCharacter(); // TODO: 初始化为适当的值
            NetState expected = null; // TODO: 初始化为适当的值
            NetState actual;
            target.NetState = expected;
            actual = target.NetState;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        internal virtual BaseCharacter_Accessor CreateBaseCharacter_Accessor()
        {
            // TODO: 实例化相应的具体类。
            BaseCharacter_Accessor target = null;
            return target;
        }

        /// <summary>
        ///BaseCharacterState 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void BaseCharacterStateTest()
        {
            PrivateObject param0 = null; // TODO: 初始化为适当的值
            BaseCharacter_Accessor target = new BaseCharacter_Accessor( param0 ); // TODO: 初始化为适当的值
            BaseCharacterState expected = null; // TODO: 初始化为适当的值
            BaseCharacterState actual;
            target.BaseCharacterState = expected;
            actual = target.BaseCharacterState;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        internal virtual BaseCharacter CreateBaseCharacter()
        {
            // TODO: 实例化相应的具体类。
            BaseCharacter target = null;
            return target;
        }

        /// <summary>
        ///AccessLevel 的测试
        ///</summary>
        [TestMethod()]
        public void AccessLevelTest()
        {
            BaseCharacter target = CreateBaseCharacter(); // TODO: 初始化为适当的值
            AccessLevel expected = new AccessLevel(); // TODO: 初始化为适当的值
            AccessLevel actual;
            target.AccessLevel = expected;
            actual = target.AccessLevel;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }
    }
}
