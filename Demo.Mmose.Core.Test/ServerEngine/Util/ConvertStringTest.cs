using Demo.Mmose.Core.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System;
using System.Net;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 ConvertStringTest 的测试类，旨在
    ///包含所有 ConvertStringTest 单元测试
    ///</summary>
    [TestClass()]
    public class ConvertStringTest
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
        ///UTF8 的测试
        ///</summary>
        [TestMethod()]
        public void UTF8Test()
        {
            Encoding actual;
            actual = ConvertString.UTF8;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToTimeSpan 的测试
        ///</summary>
        [TestMethod()]
        public void ToTimeSpanTest()
        {
            string strValue = string.Empty; // TODO: 初始化为适当的值
            TimeSpan expected = new TimeSpan(); // TODO: 初始化为适当的值
            TimeSpan actual;
            actual = ConvertString.ToTimeSpan( strValue );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToLong64 的测试
        ///</summary>
        [TestMethod()]
        public void ToLong64Test()
        {
            string strValue = string.Empty; // TODO: 初始化为适当的值
            long expected = 0; // TODO: 初始化为适当的值
            long actual;
            actual = ConvertString.ToLong64( strValue );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToIPAddress 的测试
        ///</summary>
        [TestMethod()]
        public void ToIPAddressTest()
        {
            string strValue = string.Empty; // TODO: 初始化为适当的值
            IPAddress expected = null; // TODO: 初始化为适当的值
            IPAddress actual;
            actual = ConvertString.ToIPAddress( strValue );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToInt32 的测试
        ///</summary>
        [TestMethod()]
        public void ToInt32Test()
        {
            string strValue = string.Empty; // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = ConvertString.ToInt32( strValue );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToDouble 的测试
        ///</summary>
        [TestMethod()]
        public void ToDoubleTest()
        {
            string strValue = string.Empty; // TODO: 初始化为适当的值
            double expected = 0F; // TODO: 初始化为适当的值
            double actual;
            actual = ConvertString.ToDouble( strValue );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToDateTime 的测试
        ///</summary>
        [TestMethod()]
        public void ToDateTimeTest()
        {
            string strValue = string.Empty; // TODO: 初始化为适当的值
            DateTime expected = new DateTime(); // TODO: 初始化为适当的值
            DateTime actual;
            actual = ConvertString.ToDateTime( strValue );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToByteArray 的测试
        ///</summary>
        [TestMethod()]
        public void ToByteArrayTest1()
        {
            string byteString = string.Empty; // TODO: 初始化为适当的值
            byte[] expected = null; // TODO: 初始化为适当的值
            byte[] actual;
            actual = ConvertString.ToByteArray( byteString );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToByteArray 的测试
        ///</summary>
        [TestMethod()]
        public void ToByteArrayTest()
        {
            string byteString = string.Empty; // TODO: 初始化为适当的值
            Encoding encoding = null; // TODO: 初始化为适当的值
            byte[] expected = null; // TODO: 初始化为适当的值
            byte[] actual;
            actual = ConvertString.ToByteArray( byteString, encoding );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToBoolean 的测试
        ///</summary>
        [TestMethod()]
        public void ToBooleanTest()
        {
            string strValue = string.Empty; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = ConvertString.ToBoolean( strValue );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ConvertToTimeSpan 的测试
        ///</summary>
        [TestMethod()]
        public void ConvertToTimeSpanTest()
        {
            string strValue = string.Empty; // TODO: 初始化为适当的值
            TimeSpan expected = new TimeSpan(); // TODO: 初始化为适当的值
            TimeSpan actual;
            actual = ConvertString.ConvertToTimeSpan( strValue );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ConvertToLong64 的测试
        ///</summary>
        [TestMethod()]
        public void ConvertToLong64Test()
        {
            string strValue = string.Empty; // TODO: 初始化为适当的值
            long expected = 0; // TODO: 初始化为适当的值
            long actual;
            actual = ConvertString.ConvertToLong64( strValue );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ConvertToIPAddress 的测试
        ///</summary>
        [TestMethod()]
        public void ConvertToIPAddressTest()
        {
            string strValue = string.Empty; // TODO: 初始化为适当的值
            IPAddress expected = null; // TODO: 初始化为适当的值
            IPAddress actual;
            actual = ConvertString.ConvertToIPAddress( strValue );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ConvertToInt32 的测试
        ///</summary>
        [TestMethod()]
        public void ConvertToInt32Test()
        {
            string strValue = string.Empty; // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = ConvertString.ConvertToInt32( strValue );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ConvertToDouble 的测试
        ///</summary>
        [TestMethod()]
        public void ConvertToDoubleTest()
        {
            string strValue = string.Empty; // TODO: 初始化为适当的值
            double expected = 0F; // TODO: 初始化为适当的值
            double actual;
            actual = ConvertString.ConvertToDouble( strValue );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ConvertToDateTime 的测试
        ///</summary>
        [TestMethod()]
        public void ConvertToDateTimeTest()
        {
            string strValue = string.Empty; // TODO: 初始化为适当的值
            DateTime expected = new DateTime(); // TODO: 初始化为适当的值
            DateTime actual;
            actual = ConvertString.ConvertToDateTime( strValue );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ConvertToBoolean 的测试
        ///</summary>
        [TestMethod()]
        public void ConvertToBooleanTest()
        {
            string strValue = string.Empty; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = ConvertString.ConvertToBoolean( strValue );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Concat 的测试
        ///</summary>
        [TestMethod()]
        public void ConcatTest()
        {
            StringBuilder stringBuilder = null; // TODO: 初始化为适当的值
            StringBuilder stringBuilderExpected = null; // TODO: 初始化为适当的值
            string strString = string.Empty; // TODO: 初始化为适当的值
            string strString2 = string.Empty; // TODO: 初始化为适当的值
            ConvertString.Concat( ref stringBuilder, strString, strString2 );
            Assert.AreEqual( stringBuilderExpected, stringBuilder );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Coalition 的测试
        ///</summary>
        [TestMethod()]
        public void CoalitionTest()
        {
            string strString = string.Empty; // TODO: 初始化为适当的值
            StringBuilder stringBuilder = null; // TODO: 初始化为适当的值
            StringBuilder stringBuilderExpected = null; // TODO: 初始化为适当的值
            string strString2 = string.Empty; // TODO: 初始化为适当的值
            ConvertString.Coalition( strString, ref stringBuilder, strString2 );
            Assert.AreEqual( stringBuilderExpected, stringBuilder );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }
    }
}
