using Demo.Mmose.Core.Scripts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 CallPriorityComparerTest 的测试类，旨在
    ///包含所有 CallPriorityComparerTest 单元测试
    ///</summary>
    [TestClass()]
    public class CallPriorityComparerTest
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
        ///GetPriority 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void GetPriorityTest()
        {
            CallPriorityComparer_Accessor target = new CallPriorityComparer_Accessor(); // TODO: 初始化为适当的值
            MethodInfo methodInfo = null; // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = target.GetPriority( methodInfo );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Compare 的测试
        ///</summary>
        [TestMethod()]
        public void CompareTest()
        {
            CallPriorityComparer target = new CallPriorityComparer(); // TODO: 初始化为适当的值
            MethodInfo methodInfoX = null; // TODO: 初始化为适当的值
            MethodInfo methodInfoY = null; // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = target.Compare( methodInfoX, methodInfoY );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///CallPriorityComparer 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void CallPriorityComparerConstructorTest()
        {
            CallPriorityComparer target = new CallPriorityComparer();
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
