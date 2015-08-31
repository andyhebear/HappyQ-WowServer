using Demo.Mmose.Core.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 ByteChangeTest 的测试类，旨在
    ///包含所有 ByteChangeTest 单元测试
    ///</summary>
    [TestClass()]
    public class ByteChangeTest
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
        ///UlongToDouble 的测试
        ///</summary>
        [TestMethod()]
        public void UlongToDoubleTest()
        {
            ulong ulValue = 0; // TODO: 初始化为适当的值
            double expected = 0F; // TODO: 初始化为适当的值
            double actual;
            actual = ByteChange.UlongToDouble( ulValue );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///UintToFloat 的测试
        ///</summary>
        [TestMethod()]
        public void UintToFloatTest()
        {
            uint uiValue = 0; // TODO: 初始化为适当的值
            float expected = 0F; // TODO: 初始化为适当的值
            float actual;
            actual = ByteChange.UintToFloat( uiValue );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///LongToDouble 的测试
        ///</summary>
        [TestMethod()]
        public void LongToDoubleTest()
        {
            long lValue = 0; // TODO: 初始化为适当的值
            double expected = 0F; // TODO: 初始化为适当的值
            double actual;
            actual = ByteChange.LongToDouble( lValue );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IntToFloat 的测试
        ///</summary>
        [TestMethod()]
        public void IntToFloatTest()
        {
            int iValue = 0; // TODO: 初始化为适当的值
            float expected = 0F; // TODO: 初始化为适当的值
            float actual;
            actual = ByteChange.IntToFloat( iValue );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///FloatToUint 的测试
        ///</summary>
        [TestMethod()]
        public void FloatToUintTest()
        {
            float fValue = 0F; // TODO: 初始化为适当的值
            uint expected = 0; // TODO: 初始化为适当的值
            uint actual;
            actual = ByteChange.FloatToUint( fValue );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///FloatToInt 的测试
        ///</summary>
        [TestMethod()]
        public void FloatToIntTest()
        {
            float fValue = 0F; // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = ByteChange.FloatToInt( fValue );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///DoubleToUlong 的测试
        ///</summary>
        [TestMethod()]
        public void DoubleToUlongTest()
        {
            double dValue = 0F; // TODO: 初始化为适当的值
            ulong expected = 0; // TODO: 初始化为适当的值
            ulong actual;
            actual = ByteChange.DoubleToUlong( dValue );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///DoubleToLong 的测试
        ///</summary>
        [TestMethod()]
        public void DoubleToLongTest()
        {
            double dValue = 0F; // TODO: 初始化为适当的值
            long expected = 0; // TODO: 初始化为适当的值
            long actual;
            actual = ByteChange.DoubleToLong( dValue );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ChangeToUlong 的测试
        ///</summary>
        [TestMethod()]
        public void ChangeToUlongTest()
        {
            double dValue = 0F; // TODO: 初始化为适当的值
            ulong expected = 0; // TODO: 初始化为适当的值
            ulong actual;
            actual = ByteChange.ChangeToUlong( dValue );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ChangeToUint 的测试
        ///</summary>
        [TestMethod()]
        public void ChangeToUintTest()
        {
            float fValue = 0F; // TODO: 初始化为适当的值
            uint expected = 0; // TODO: 初始化为适当的值
            uint actual;
            actual = ByteChange.ChangeToUint( fValue );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ChangeToLong 的测试
        ///</summary>
        [TestMethod()]
        public void ChangeToLongTest()
        {
            double dValue = 0F; // TODO: 初始化为适当的值
            long expected = 0; // TODO: 初始化为适当的值
            long actual;
            actual = ByteChange.ChangeToLong( dValue );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ChangeToInt 的测试
        ///</summary>
        [TestMethod()]
        public void ChangeToIntTest()
        {
            float fValue = 0F; // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = ByteChange.ChangeToInt( fValue );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ChangeToFloat 的测试
        ///</summary>
        [TestMethod()]
        public void ChangeToFloatTest1()
        {
            int iValue = 0; // TODO: 初始化为适当的值
            float expected = 0F; // TODO: 初始化为适当的值
            float actual;
            actual = ByteChange.ChangeToFloat( iValue );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ChangeToFloat 的测试
        ///</summary>
        [TestMethod()]
        public void ChangeToFloatTest()
        {
            uint uiValue = 0; // TODO: 初始化为适当的值
            float expected = 0F; // TODO: 初始化为适当的值
            float actual;
            actual = ByteChange.ChangeToFloat( uiValue );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ChangeToDouble 的测试
        ///</summary>
        [TestMethod()]
        public void ChangeToDoubleTest1()
        {
            ulong ulValue = 0; // TODO: 初始化为适当的值
            double expected = 0F; // TODO: 初始化为适当的值
            double actual;
            actual = ByteChange.ChangeToDouble( ulValue );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ChangeToDouble 的测试
        ///</summary>
        [TestMethod()]
        public void ChangeToDoubleTest()
        {
            long lValue = 0; // TODO: 初始化为适当的值
            double expected = 0F; // TODO: 初始化为适当的值
            double actual;
            actual = ByteChange.ChangeToDouble( lValue );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }
    }
}
