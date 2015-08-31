using Demo.Mmose.Core.Common.Component;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 ComponentMessageTest 的测试类，旨在
    ///包含所有 ComponentMessageTest 单元测试
    ///</summary>
    [TestClass()]
    public class ComponentMessageTest
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
        ///Value 的测试
        ///</summary>
        [TestMethod()]
        public void ValueTest()
        {
            ComponentMessage target = new ComponentMessage(); // TODO: 初始化为适当的值
            long actual;
            actual = target.Value;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Context 的测试
        ///</summary>
        [TestMethod()]
        public void ContextTest()
        {
            ComponentMessage target = new ComponentMessage(); // TODO: 初始化为适当的值
            object actual;
            actual = target.Context;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToString 的测试
        ///</summary>
        [TestMethod()]
        public void ToStringTest()
        {
            ComponentMessage target = new ComponentMessage(); // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = target.ToString();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_Inequality 的测试
        ///</summary>
        [TestMethod()]
        public void op_InequalityTest()
        {
            ComponentMessage ComponentMessageA = new ComponentMessage(); // TODO: 初始化为适当的值
            ComponentMessage ComponentMessageB = new ComponentMessage(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = ( ComponentMessageA != ComponentMessageB );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_Implicit 的测试
        ///</summary>
        [TestMethod()]
        public void op_ImplicitTest1()
        {
            long lComponentMessage = 0; // TODO: 初始化为适当的值
            ComponentMessage expected = new ComponentMessage(); // TODO: 初始化为适当的值
            ComponentMessage actual;
            actual = lComponentMessage;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_Implicit 的测试
        ///</summary>
        [TestMethod()]
        public void op_ImplicitTest()
        {
            string strComponentMessage = string.Empty; // TODO: 初始化为适当的值
            ComponentMessage expected = new ComponentMessage(); // TODO: 初始化为适当的值
            ComponentMessage actual;
            actual = strComponentMessage;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_Explicit 的测试
        ///</summary>
        [TestMethod()]
        public void op_ExplicitTest1()
        {
            ComponentMessage componentMessage = new ComponentMessage(); // TODO: 初始化为适当的值
            long expected = 0; // TODO: 初始化为适当的值
            long actual;
            actual = ( (long)( componentMessage ) );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_Explicit 的测试
        ///</summary>
        [TestMethod()]
        public void op_ExplicitTest()
        {
            ComponentMessage componentMessage = new ComponentMessage(); // TODO: 初始化为适当的值
            ulong expected = 0; // TODO: 初始化为适当的值
            ulong actual;
            actual = ( (ulong)( componentMessage ) );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_Equality 的测试
        ///</summary>
        [TestMethod()]
        public void op_EqualityTest()
        {
            ComponentMessage ComponentMessageA = new ComponentMessage(); // TODO: 初始化为适当的值
            ComponentMessage ComponentMessageB = new ComponentMessage(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = ( ComponentMessageA == ComponentMessageB );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GetHashCode 的测试
        ///</summary>
        [TestMethod()]
        public void GetHashCodeTest()
        {
            ComponentMessage target = new ComponentMessage(); // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = target.GetHashCode();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Equals 的测试
        ///</summary>
        [TestMethod()]
        public void EqualsTest()
        {
            ComponentMessage target = new ComponentMessage(); // TODO: 初始化为适当的值
            object xObject = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.Equals( xObject );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///CompareTo 的测试
        ///</summary>
        [TestMethod()]
        public void CompareToTest1()
        {
            ComponentMessage target = new ComponentMessage(); // TODO: 初始化为适当的值
            ComponentMessage otherComponentMessage = new ComponentMessage(); // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = target.CompareTo( otherComponentMessage );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///CompareTo 的测试
        ///</summary>
        [TestMethod()]
        public void CompareToTest()
        {
            ComponentMessage target = new ComponentMessage(); // TODO: 初始化为适当的值
            object otherObject = null; // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = target.CompareTo( otherObject );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ComponentMessage 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void ComponentMessageConstructorTest3()
        {
            string strComponentMessage = string.Empty; // TODO: 初始化为适当的值
            ComponentMessage target = new ComponentMessage( strComponentMessage );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        /// <summary>
        ///ComponentMessage 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void ComponentMessageConstructorTest2()
        {
            long lComponentMessage = 0; // TODO: 初始化为适当的值
            ComponentMessage target = new ComponentMessage( lComponentMessage );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        /// <summary>
        ///ComponentMessage 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void ComponentMessageConstructorTest1()
        {
            string strComponentMessage = string.Empty; // TODO: 初始化为适当的值
            object context = null; // TODO: 初始化为适当的值
            ComponentMessage target = new ComponentMessage( strComponentMessage, context );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        /// <summary>
        ///ComponentMessage 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void ComponentMessageConstructorTest()
        {
            long lComponentMessage = 0; // TODO: 初始化为适当的值
            object context = null; // TODO: 初始化为适当的值
            ComponentMessage target = new ComponentMessage( lComponentMessage, context );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
