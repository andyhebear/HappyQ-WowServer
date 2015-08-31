using Demo.Mmose.Core.Common.Component;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Demo.Mmose.Core.Test
{
    
    
    /// <summary>
    ///这是 ComponentIdTest 的测试类，旨在
    ///包含所有 ComponentIdTest 单元测试
    ///</summary>
    [TestClass()]
    public class ComponentIdTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
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
            ComponentId target = new ComponentId(); // TODO: 初始化为适当的值
            long actual;
            actual = target.Value;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToString 的测试
        ///</summary>
        [TestMethod()]
        public void ToStringTest()
        {
            ComponentId target = new ComponentId(); // TODO: 初始化为适当的值
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
            ComponentId ComponentIdA = new ComponentId(); // TODO: 初始化为适当的值
            ComponentId ComponentIdB = new ComponentId(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = ( ComponentIdA != ComponentIdB );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_Implicit 的测试
        ///</summary>
        [TestMethod()]
        public void op_ImplicitTest1()
        {
            long lComponentId = 0; // TODO: 初始化为适当的值
            ComponentId expected = new ComponentId(); // TODO: 初始化为适当的值
            ComponentId actual;
            actual = lComponentId;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_Implicit 的测试
        ///</summary>
        [TestMethod()]
        public void op_ImplicitTest()
        {
            string strComponentId = string.Empty; // TODO: 初始化为适当的值
            ComponentId expected = new ComponentId(); // TODO: 初始化为适当的值
            ComponentId actual;
            actual = strComponentId;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_Explicit 的测试
        ///</summary>
        [TestMethod()]
        public void op_ExplicitTest1()
        {
            ComponentId componentId = new ComponentId(); // TODO: 初始化为适当的值
            ulong expected = 0; // TODO: 初始化为适当的值
            ulong actual;
            actual = ( (ulong)( componentId ) );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_Explicit 的测试
        ///</summary>
        [TestMethod()]
        public void op_ExplicitTest()
        {
            ComponentId componentId = new ComponentId(); // TODO: 初始化为适当的值
            long expected = 0; // TODO: 初始化为适当的值
            long actual;
            actual = ( (long)( componentId ) );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_Equality 的测试
        ///</summary>
        [TestMethod()]
        public void op_EqualityTest()
        {
            ComponentId ComponentIdA = new ComponentId(); // TODO: 初始化为适当的值
            ComponentId ComponentIdB = new ComponentId(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = ( ComponentIdA == ComponentIdB );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GetHashCode 的测试
        ///</summary>
        [TestMethod()]
        public void GetHashCodeTest()
        {
            ComponentId target = new ComponentId(); // TODO: 初始化为适当的值
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
            ComponentId target = new ComponentId(); // TODO: 初始化为适当的值
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
            ComponentId target = new ComponentId(); // TODO: 初始化为适当的值
            ComponentId otherComponentId = new ComponentId(); // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = target.CompareTo( otherComponentId );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///CompareTo 的测试
        ///</summary>
        [TestMethod()]
        public void CompareToTest()
        {
            ComponentId target = new ComponentId(); // TODO: 初始化为适当的值
            object otherObject = null; // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = target.CompareTo( otherObject );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ComponentId 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void ComponentIdConstructorTest1()
        {
            long lComponentId = 0; // TODO: 初始化为适当的值
            ComponentId target = new ComponentId( lComponentId );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        /// <summary>
        ///ComponentId 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void ComponentIdConstructorTest()
        {
            string strComponentId = string.Empty; // TODO: 初始化为适当的值
            ComponentId target = new ComponentId( strComponentId );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
