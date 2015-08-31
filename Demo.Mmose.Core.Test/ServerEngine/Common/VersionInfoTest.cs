using Demo.Mmose.Core.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 VersionInfoTest 的测试类，旨在
    ///包含所有 VersionInfoTest 单元测试
    ///</summary>
    [TestClass()]
    public class VersionInfoTest
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
        ///SourceString 的测试
        ///</summary>
        [TestMethod()]
        public void SourceStringTest()
        {
            string strFormat = string.Empty; // TODO: 初始化为适当的值
            VersionInfo target = new VersionInfo( strFormat ); // TODO: 初始化为适当的值
            string actual;
            actual = target.SourceString;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Revision 的测试
        ///</summary>
        [TestMethod()]
        public void RevisionTest()
        {
            string strFormat = string.Empty; // TODO: 初始化为适当的值
            VersionInfo target = new VersionInfo( strFormat ); // TODO: 初始化为适当的值
            int actual;
            actual = target.Revision;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Patch 的测试
        ///</summary>
        [TestMethod()]
        public void PatchTest()
        {
            string strFormat = string.Empty; // TODO: 初始化为适当的值
            VersionInfo target = new VersionInfo( strFormat ); // TODO: 初始化为适当的值
            int actual;
            actual = target.Patch;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Minor 的测试
        ///</summary>
        [TestMethod()]
        public void MinorTest()
        {
            string strFormat = string.Empty; // TODO: 初始化为适当的值
            VersionInfo target = new VersionInfo( strFormat ); // TODO: 初始化为适当的值
            int actual;
            actual = target.Minor;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Major 的测试
        ///</summary>
        [TestMethod()]
        public void MajorTest()
        {
            string strFormat = string.Empty; // TODO: 初始化为适当的值
            VersionInfo target = new VersionInfo( strFormat ); // TODO: 初始化为适当的值
            int actual;
            actual = target.Major;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToString 的测试
        ///</summary>
        [TestMethod()]
        public void ToStringTest()
        {
            string strFormat = string.Empty; // TODO: 初始化为适当的值
            VersionInfo target = new VersionInfo( strFormat ); // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = target.ToString();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_LessThanOrEqual 的测试
        ///</summary>
        [TestMethod()]
        public void op_LessThanOrEqualTest()
        {
            VersionInfo xClientVersion = null; // TODO: 初始化为适当的值
            VersionInfo yClientVersion = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = ( xClientVersion <= yClientVersion );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_LessThan 的测试
        ///</summary>
        [TestMethod()]
        public void op_LessThanTest()
        {
            VersionInfo xClientVersion = null; // TODO: 初始化为适当的值
            VersionInfo yClientVersion = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = ( xClientVersion < yClientVersion );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_Inequality 的测试
        ///</summary>
        [TestMethod()]
        public void op_InequalityTest()
        {
            VersionInfo xClientVersion = null; // TODO: 初始化为适当的值
            VersionInfo yClientVersion = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = ( xClientVersion != yClientVersion );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_GreaterThanOrEqual 的测试
        ///</summary>
        [TestMethod()]
        public void op_GreaterThanOrEqualTest()
        {
            VersionInfo xClientVersion = null; // TODO: 初始化为适当的值
            VersionInfo yClientVersion = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = ( xClientVersion >= yClientVersion );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_GreaterThan 的测试
        ///</summary>
        [TestMethod()]
        public void op_GreaterThanTest()
        {
            VersionInfo xClientVersion = null; // TODO: 初始化为适当的值
            VersionInfo yClientVersion = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = ( xClientVersion > yClientVersion );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_Equality 的测试
        ///</summary>
        [TestMethod()]
        public void op_EqualityTest()
        {
            VersionInfo xClientVersion = null; // TODO: 初始化为适当的值
            VersionInfo yClientVersion = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = ( xClientVersion == yClientVersion );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IsNull 的测试
        ///</summary>
        [TestMethod()]
        public void IsNullTest()
        {
            object xObject = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = VersionInfo.IsNull( xObject );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GetHashCode 的测试
        ///</summary>
        [TestMethod()]
        public void GetHashCodeTest()
        {
            string strFormat = string.Empty; // TODO: 初始化为适当的值
            VersionInfo target = new VersionInfo( strFormat ); // TODO: 初始化为适当的值
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
            string strFormat = string.Empty; // TODO: 初始化为适当的值
            VersionInfo target = new VersionInfo( strFormat ); // TODO: 初始化为适当的值
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
        public void CompareToTest()
        {
            string strFormat = string.Empty; // TODO: 初始化为适当的值
            VersionInfo target = new VersionInfo( strFormat ); // TODO: 初始化为适当的值
            object xObject = null; // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = target.CompareTo( xObject );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Compare 的测试
        ///</summary>
        [TestMethod()]
        public void CompareTest1()
        {
            string strFormat = string.Empty; // TODO: 初始化为适当的值
            VersionInfo target = new VersionInfo( strFormat ); // TODO: 初始化为适当的值
            object xObject = null; // TODO: 初始化为适当的值
            object yObject = null; // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = target.Compare( xObject, yObject );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Compare 的测试
        ///</summary>
        [TestMethod()]
        public void CompareTest()
        {
            VersionInfo xClientVersion = null; // TODO: 初始化为适当的值
            VersionInfo yClientVersion = null; // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = VersionInfo.Compare( xClientVersion, yClientVersion );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///VersionInfo 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void VersionInfoConstructorTest1()
        {
            int iMajor = 0; // TODO: 初始化为适当的值
            int iMinor = 0; // TODO: 初始化为适当的值
            int iRevision = 0; // TODO: 初始化为适当的值
            int iPatch = 0; // TODO: 初始化为适当的值
            VersionInfo target = new VersionInfo( iMajor, iMinor, iRevision, iPatch );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        /// <summary>
        ///VersionInfo 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void VersionInfoConstructorTest()
        {
            string strFormat = string.Empty; // TODO: 初始化为适当的值
            VersionInfo target = new VersionInfo( strFormat );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
