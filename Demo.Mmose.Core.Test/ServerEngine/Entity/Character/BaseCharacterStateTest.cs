using Demo.Mmose.Core.Entity.Character;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Network;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 BaseCharacterStateTest 的测试类，旨在
    ///包含所有 BaseCharacterStateTest 单元测试
    ///</summary>
    [TestClass()]
    public class BaseCharacterStateTest
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
            BaseCharacterState actual;
            actual = BaseCharacterState.SingletonInstance;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IsUpdateNetState 的测试
        ///</summary>
        [TestMethod()]
        public void IsUpdateNetStateTest()
        {
            BaseCharacterState target = new BaseCharacterState(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            target.IsUpdateNetState = expected;
            actual = target.IsUpdateNetState;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IsUpdateAccessLevel 的测试
        ///</summary>
        [TestMethod()]
        public void IsUpdateAccessLevelTest()
        {
            BaseCharacterState target = new BaseCharacterState(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            target.IsUpdateAccessLevel = expected;
            actual = target.IsUpdateAccessLevel;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///RestoreAll 的测试
        ///</summary>
        [TestMethod()]
        public void RestoreAllTest()
        {
            BaseCharacterState target = new BaseCharacterState(); // TODO: 初始化为适当的值
            target.RestoreAll();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnUpdatingNetState 的测试
        ///</summary>
        [TestMethod()]
        public void OnUpdatingNetStateTest()
        {
            BaseCharacterState target = new BaseCharacterState(); // TODO: 初始化为适当的值
            NetState netState = null; // TODO: 初始化为适当的值
            BaseCharacter creature = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.OnUpdatingNetState( netState, creature );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnUpdatingAccessLevel 的测试
        ///</summary>
        [TestMethod()]
        public void OnUpdatingAccessLevelTest()
        {
            BaseCharacterState target = new BaseCharacterState(); // TODO: 初始化为适当的值
            AccessLevel accessLevel = new AccessLevel(); // TODO: 初始化为适当的值
            BaseCharacter creature = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.OnUpdatingAccessLevel( accessLevel, creature );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnUpdatedNetState 的测试
        ///</summary>
        [TestMethod()]
        public void OnUpdatedNetStateTest()
        {
            BaseCharacterState target = new BaseCharacterState(); // TODO: 初始化为适当的值
            NetState netState = null; // TODO: 初始化为适当的值
            BaseCharacter creature = null; // TODO: 初始化为适当的值
            target.OnUpdatedNetState( netState, creature );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnUpdatedAccessLevel 的测试
        ///</summary>
        [TestMethod()]
        public void OnUpdatedAccessLevelTest()
        {
            BaseCharacterState target = new BaseCharacterState(); // TODO: 初始化为适当的值
            AccessLevel accessLevel = new AccessLevel(); // TODO: 初始化为适当的值
            BaseCharacter creature = null; // TODO: 初始化为适当的值
            target.OnUpdatedAccessLevel( accessLevel, creature );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///BaseCharacterState 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void BaseCharacterStateConstructorTest()
        {
            BaseCharacterState target = new BaseCharacterState();
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
