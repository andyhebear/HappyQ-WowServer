using Demo.Mmose.Core.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 ConvertByteArrayTest 的测试类，旨在
    ///包含所有 ConvertByteArrayTest 单元测试
    ///</summary>
    [TestClass()]
    public class ConvertByteArrayTest
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
        ///ToUShort 的测试
        ///</summary>
        [TestMethod()]
        public void ToUShortTest1()
        {
            byte[] ushortBuffer = null; // TODO: 初始化为适当的值
            int iBufferIndex = 0; // TODO: 初始化为适当的值
            ushort expected = 0; // TODO: 初始化为适当的值
            ushort actual;
            actual = ConvertByteArray.ToUShort( ushortBuffer, iBufferIndex );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToUShort 的测试
        ///</summary>
        [TestMethod()]
        public void ToUShortTest()
        {
            byte[] ushortBuffer = null; // TODO: 初始化为适当的值
            ushort expected = 0; // TODO: 初始化为适当的值
            ushort actual;
            actual = ConvertByteArray.ToUShort( ushortBuffer );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToULong 的测试
        ///</summary>
        [TestMethod()]
        public void ToULongTest1()
        {
            byte[] ulongBuffer = null; // TODO: 初始化为适当的值
            int iBufferIndex = 0; // TODO: 初始化为适当的值
            ulong expected = 0; // TODO: 初始化为适当的值
            ulong actual;
            actual = ConvertByteArray.ToULong( ulongBuffer, iBufferIndex );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToULong 的测试
        ///</summary>
        [TestMethod()]
        public void ToULongTest()
        {
            byte[] ulongBuffer = null; // TODO: 初始化为适当的值
            ulong expected = 0; // TODO: 初始化为适当的值
            ulong actual;
            actual = ConvertByteArray.ToULong( ulongBuffer );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToUInt 的测试
        ///</summary>
        [TestMethod()]
        public void ToUIntTest1()
        {
            byte[] uintBuffer = null; // TODO: 初始化为适当的值
            uint expected = 0; // TODO: 初始化为适当的值
            uint actual;
            actual = ConvertByteArray.ToUInt( uintBuffer );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToUInt 的测试
        ///</summary>
        [TestMethod()]
        public void ToUIntTest()
        {
            byte[] uintBuffer = null; // TODO: 初始化为适当的值
            int iBufferIndex = 0; // TODO: 初始化为适当的值
            uint expected = 0; // TODO: 初始化为适当的值
            uint actual;
            actual = ConvertByteArray.ToUInt( uintBuffer, iBufferIndex );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToString 的测试
        ///</summary>
        [TestMethod()]
        public void ToStringTest3()
        {
            byte[] byteString = null; // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = ConvertByteArray.ToString( byteString );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToString 的测试
        ///</summary>
        [TestMethod()]
        public void ToStringTest2()
        {
            byte[] byteString = null; // TODO: 初始化为适当的值
            Encoding encoding = null; // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = ConvertByteArray.ToString( byteString, encoding );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToString 的测试
        ///</summary>
        [TestMethod()]
        public void ToStringTest1()
        {
            byte[] byteString = null; // TODO: 初始化为适当的值
            long iOffset = 0; // TODO: 初始化为适当的值
            long iSize = 0; // TODO: 初始化为适当的值
            Encoding encoding = null; // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = ConvertByteArray.ToString( byteString, iOffset, iSize, encoding );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToString 的测试
        ///</summary>
        [TestMethod()]
        public void ToStringTest()
        {
            byte[] byteString = null; // TODO: 初始化为适当的值
            long iOffset = 0; // TODO: 初始化为适当的值
            long iSize = 0; // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = ConvertByteArray.ToString( byteString, iOffset, iSize );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToShort 的测试
        ///</summary>
        [TestMethod()]
        public void ToShortTest1()
        {
            byte[] shortBuffer = null; // TODO: 初始化为适当的值
            short expected = 0; // TODO: 初始化为适当的值
            short actual;
            actual = ConvertByteArray.ToShort( shortBuffer );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToShort 的测试
        ///</summary>
        [TestMethod()]
        public void ToShortTest()
        {
            byte[] shortBuffer = null; // TODO: 初始化为适当的值
            int iBufferIndex = 0; // TODO: 初始化为适当的值
            short expected = 0; // TODO: 初始化为适当的值
            short actual;
            actual = ConvertByteArray.ToShort( shortBuffer, iBufferIndex );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToSByte 的测试
        ///</summary>
        [TestMethod()]
        public void ToSByteTest1()
        {
            byte[] sbyteBuffer = null; // TODO: 初始化为适当的值
            int iBufferIndex = 0; // TODO: 初始化为适当的值
            sbyte expected = 0; // TODO: 初始化为适当的值
            sbyte actual;
            actual = ConvertByteArray.ToSByte( sbyteBuffer, iBufferIndex );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToSByte 的测试
        ///</summary>
        [TestMethod()]
        public void ToSByteTest()
        {
            byte[] sbyteBuffer = null; // TODO: 初始化为适当的值
            sbyte expected = 0; // TODO: 初始化为适当的值
            sbyte actual;
            actual = ConvertByteArray.ToSByte( sbyteBuffer );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToLong 的测试
        ///</summary>
        [TestMethod()]
        public void ToLongTest1()
        {
            byte[] longBuffer = null; // TODO: 初始化为适当的值
            int iBufferIndex = 0; // TODO: 初始化为适当的值
            long expected = 0; // TODO: 初始化为适当的值
            long actual;
            actual = ConvertByteArray.ToLong( longBuffer, iBufferIndex );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToLong 的测试
        ///</summary>
        [TestMethod()]
        public void ToLongTest()
        {
            byte[] longBuffer = null; // TODO: 初始化为适当的值
            long expected = 0; // TODO: 初始化为适当的值
            long actual;
            actual = ConvertByteArray.ToLong( longBuffer );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToInt 的测试
        ///</summary>
        [TestMethod()]
        public void ToIntTest1()
        {
            byte[] intBuffer = null; // TODO: 初始化为适当的值
            int iBufferIndex = 0; // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = ConvertByteArray.ToInt( intBuffer, iBufferIndex );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToInt 的测试
        ///</summary>
        [TestMethod()]
        public void ToIntTest()
        {
            byte[] intBuffer = null; // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = ConvertByteArray.ToInt( intBuffer );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToChar 的测试
        ///</summary>
        [TestMethod()]
        public void ToCharTest1()
        {
            byte[] charBuffer = null; // TODO: 初始化为适当的值
            char expected = '\0'; // TODO: 初始化为适当的值
            char actual;
            actual = ConvertByteArray.ToChar( charBuffer );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToChar 的测试
        ///</summary>
        [TestMethod()]
        public void ToCharTest()
        {
            byte[] charBuffer = null; // TODO: 初始化为适当的值
            int iBufferIndex = 0; // TODO: 初始化为适当的值
            char expected = '\0'; // TODO: 初始化为适当的值
            char actual;
            actual = ConvertByteArray.ToChar( charBuffer, iBufferIndex );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToByteArray 的测试
        ///</summary>
        [TestMethod()]
        public void ToByteArrayTest19()
        {
            short iShort = 0; // TODO: 初始化为适当的值
            byte[] byteBuffer = null; // TODO: 初始化为适当的值
            byte[] byteBufferExpected = null; // TODO: 初始化为适当的值
            int iBufferIndex = 0; // TODO: 初始化为适当的值
            ConvertByteArray.ToByteArray( iShort, ref byteBuffer, iBufferIndex );
            Assert.AreEqual( byteBufferExpected, byteBuffer );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///ToByteArray 的测试
        ///</summary>
        [TestMethod()]
        public void ToByteArrayTest18()
        {
            long iLong = 0; // TODO: 初始化为适当的值
            byte[] expected = null; // TODO: 初始化为适当的值
            byte[] actual;
            actual = ConvertByteArray.ToByteArray( iLong );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToByteArray 的测试
        ///</summary>
        [TestMethod()]
        public void ToByteArrayTest17()
        {
            ushort iUShort = 0; // TODO: 初始化为适当的值
            byte[] expected = null; // TODO: 初始化为适当的值
            byte[] actual;
            actual = ConvertByteArray.ToByteArray( iUShort );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToByteArray 的测试
        ///</summary>
        [TestMethod()]
        public void ToByteArrayTest16()
        {
            int iInt = 0; // TODO: 初始化为适当的值
            byte[] expected = null; // TODO: 初始化为适当的值
            byte[] actual;
            actual = ConvertByteArray.ToByteArray( iInt );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToByteArray 的测试
        ///</summary>
        [TestMethod()]
        public void ToByteArrayTest15()
        {
            ulong iULong = 0; // TODO: 初始化为适当的值
            byte[] expected = null; // TODO: 初始化为适当的值
            byte[] actual;
            actual = ConvertByteArray.ToByteArray( iULong );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToByteArray 的测试
        ///</summary>
        [TestMethod()]
        public void ToByteArrayTest14()
        {
            ulong iULong = 0; // TODO: 初始化为适当的值
            byte[] byteBuffer = null; // TODO: 初始化为适当的值
            byte[] byteBufferExpected = null; // TODO: 初始化为适当的值
            int iBufferIndex = 0; // TODO: 初始化为适当的值
            ConvertByteArray.ToByteArray( iULong, ref byteBuffer, iBufferIndex );
            Assert.AreEqual( byteBufferExpected, byteBuffer );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///ToByteArray 的测试
        ///</summary>
        [TestMethod()]
        public void ToByteArrayTest13()
        {
            sbyte iSByte = 0; // TODO: 初始化为适当的值
            byte[] byteBuffer = null; // TODO: 初始化为适当的值
            byte[] byteBufferExpected = null; // TODO: 初始化为适当的值
            int iBufferIndex = 0; // TODO: 初始化为适当的值
            ConvertByteArray.ToByteArray( iSByte, ref byteBuffer, iBufferIndex );
            Assert.AreEqual( byteBufferExpected, byteBuffer );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///ToByteArray 的测试
        ///</summary>
        [TestMethod()]
        public void ToByteArrayTest12()
        {
            short iShort = 0; // TODO: 初始化为适当的值
            byte[] expected = null; // TODO: 初始化为适当的值
            byte[] actual;
            actual = ConvertByteArray.ToByteArray( iShort );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToByteArray 的测试
        ///</summary>
        [TestMethod()]
        public void ToByteArrayTest11()
        {
            sbyte iSByte = 0; // TODO: 初始化为适当的值
            byte[] expected = null; // TODO: 初始化为适当的值
            byte[] actual;
            actual = ConvertByteArray.ToByteArray( iSByte );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToByteArray 的测试
        ///</summary>
        [TestMethod()]
        public void ToByteArrayTest10()
        {
            char cChar = '\0'; // TODO: 初始化为适当的值
            byte[] byteBuffer = null; // TODO: 初始化为适当的值
            byte[] byteBufferExpected = null; // TODO: 初始化为适当的值
            int iBufferIndex = 0; // TODO: 初始化为适当的值
            ConvertByteArray.ToByteArray( cChar, ref byteBuffer, iBufferIndex );
            Assert.AreEqual( byteBufferExpected, byteBuffer );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///ToByteArray 的测试
        ///</summary>
        [TestMethod()]
        public void ToByteArrayTest9()
        {
            byte iByte = 0; // TODO: 初始化为适当的值
            byte[] expected = null; // TODO: 初始化为适当的值
            byte[] actual;
            actual = ConvertByteArray.ToByteArray( iByte );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToByteArray 的测试
        ///</summary>
        [TestMethod()]
        public void ToByteArrayTest8()
        {
            byte iByte = 0; // TODO: 初始化为适当的值
            byte[] byteBuffer = null; // TODO: 初始化为适当的值
            byte[] byteBufferExpected = null; // TODO: 初始化为适当的值
            int iBufferIndex = 0; // TODO: 初始化为适当的值
            ConvertByteArray.ToByteArray( iByte, ref byteBuffer, iBufferIndex );
            Assert.AreEqual( byteBufferExpected, byteBuffer );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///ToByteArray 的测试
        ///</summary>
        [TestMethod()]
        public void ToByteArrayTest7()
        {
            string strString = string.Empty; // TODO: 初始化为适当的值
            byte[] expected = null; // TODO: 初始化为适当的值
            byte[] actual;
            actual = ConvertByteArray.ToByteArray( strString );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToByteArray 的测试
        ///</summary>
        [TestMethod()]
        public void ToByteArrayTest6()
        {
            char cChar = '\0'; // TODO: 初始化为适当的值
            byte[] expected = null; // TODO: 初始化为适当的值
            byte[] actual;
            actual = ConvertByteArray.ToByteArray( cChar );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToByteArray 的测试
        ///</summary>
        [TestMethod()]
        public void ToByteArrayTest5()
        {
            ushort iUShort = 0; // TODO: 初始化为适当的值
            byte[] byteBuffer = null; // TODO: 初始化为适当的值
            byte[] byteBufferExpected = null; // TODO: 初始化为适当的值
            int iBufferIndex = 0; // TODO: 初始化为适当的值
            ConvertByteArray.ToByteArray( iUShort, ref byteBuffer, iBufferIndex );
            Assert.AreEqual( byteBufferExpected, byteBuffer );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///ToByteArray 的测试
        ///</summary>
        [TestMethod()]
        public void ToByteArrayTest4()
        {
            string strString = string.Empty; // TODO: 初始化为适当的值
            Encoding encoding = null; // TODO: 初始化为适当的值
            byte[] expected = null; // TODO: 初始化为适当的值
            byte[] actual;
            actual = ConvertByteArray.ToByteArray( strString, encoding );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToByteArray 的测试
        ///</summary>
        [TestMethod()]
        public void ToByteArrayTest3()
        {
            long iLong = 0; // TODO: 初始化为适当的值
            byte[] byteBuffer = null; // TODO: 初始化为适当的值
            byte[] byteBufferExpected = null; // TODO: 初始化为适当的值
            int iBufferIndex = 0; // TODO: 初始化为适当的值
            ConvertByteArray.ToByteArray( iLong, ref byteBuffer, iBufferIndex );
            Assert.AreEqual( byteBufferExpected, byteBuffer );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///ToByteArray 的测试
        ///</summary>
        [TestMethod()]
        public void ToByteArrayTest2()
        {
            uint iUInt = 0; // TODO: 初始化为适当的值
            byte[] byteBuffer = null; // TODO: 初始化为适当的值
            byte[] byteBufferExpected = null; // TODO: 初始化为适当的值
            int iBufferIndex = 0; // TODO: 初始化为适当的值
            ConvertByteArray.ToByteArray( iUInt, ref byteBuffer, iBufferIndex );
            Assert.AreEqual( byteBufferExpected, byteBuffer );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///ToByteArray 的测试
        ///</summary>
        [TestMethod()]
        public void ToByteArrayTest1()
        {
            int iInt = 0; // TODO: 初始化为适当的值
            byte[] byteBuffer = null; // TODO: 初始化为适当的值
            byte[] byteBufferExpected = null; // TODO: 初始化为适当的值
            int iBufferIndex = 0; // TODO: 初始化为适当的值
            ConvertByteArray.ToByteArray( iInt, ref byteBuffer, iBufferIndex );
            Assert.AreEqual( byteBufferExpected, byteBuffer );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///ToByteArray 的测试
        ///</summary>
        [TestMethod()]
        public void ToByteArrayTest()
        {
            uint iUInt = 0; // TODO: 初始化为适当的值
            byte[] expected = null; // TODO: 初始化为适当的值
            byte[] actual;
            actual = ConvertByteArray.ToByteArray( iUInt );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToByte 的测试
        ///</summary>
        [TestMethod()]
        public void ToByteTest1()
        {
            byte[] byteBuffer = null; // TODO: 初始化为适当的值
            byte expected = 0; // TODO: 初始化为适当的值
            byte actual;
            actual = ConvertByteArray.ToByte( byteBuffer );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToByte 的测试
        ///</summary>
        [TestMethod()]
        public void ToByteTest()
        {
            byte[] byteBuffer = null; // TODO: 初始化为适当的值
            int iBufferIndex = 0; // TODO: 初始化为适当的值
            byte expected = 0; // TODO: 初始化为适当的值
            byte actual;
            actual = ConvertByteArray.ToByte( byteBuffer, iBufferIndex );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToArrayInByte 的测试
        ///</summary>
        [TestMethod()]
        public void ToArrayInByteTest19()
        {
            char cChar = '\0'; // TODO: 初始化为适当的值
            byte[] byteBuffer = null; // TODO: 初始化为适当的值
            byte[] byteBufferExpected = null; // TODO: 初始化为适当的值
            int iBufferIndex = 0; // TODO: 初始化为适当的值
            ConvertByteArray.ToArrayInByte( cChar, ref byteBuffer, iBufferIndex );
            Assert.AreEqual( byteBufferExpected, byteBuffer );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///ToArrayInByte 的测试
        ///</summary>
        [TestMethod()]
        public void ToArrayInByteTest18()
        {
            char cChar = '\0'; // TODO: 初始化为适当的值
            byte[] expected = null; // TODO: 初始化为适当的值
            byte[] actual;
            actual = ConvertByteArray.ToArrayInByte( cChar );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToArrayInByte 的测试
        ///</summary>
        [TestMethod()]
        public void ToArrayInByteTest17()
        {
            byte iByte = 0; // TODO: 初始化为适当的值
            byte[] byteBuffer = null; // TODO: 初始化为适当的值
            byte[] byteBufferExpected = null; // TODO: 初始化为适当的值
            int iBufferIndex = 0; // TODO: 初始化为适当的值
            ConvertByteArray.ToArrayInByte( iByte, ref byteBuffer, iBufferIndex );
            Assert.AreEqual( byteBufferExpected, byteBuffer );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///ToArrayInByte 的测试
        ///</summary>
        [TestMethod()]
        public void ToArrayInByteTest16()
        {
            ushort iUShort = 0; // TODO: 初始化为适当的值
            byte[] byteBuffer = null; // TODO: 初始化为适当的值
            byte[] byteBufferExpected = null; // TODO: 初始化为适当的值
            int iBufferIndex = 0; // TODO: 初始化为适当的值
            ConvertByteArray.ToArrayInByte( iUShort, ref byteBuffer, iBufferIndex );
            Assert.AreEqual( byteBufferExpected, byteBuffer );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///ToArrayInByte 的测试
        ///</summary>
        [TestMethod()]
        public void ToArrayInByteTest15()
        {
            byte iByte = 0; // TODO: 初始化为适当的值
            byte[] expected = null; // TODO: 初始化为适当的值
            byte[] actual;
            actual = ConvertByteArray.ToArrayInByte( iByte );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToArrayInByte 的测试
        ///</summary>
        [TestMethod()]
        public void ToArrayInByteTest14()
        {
            ulong iULong = 0; // TODO: 初始化为适当的值
            byte[] byteBuffer = null; // TODO: 初始化为适当的值
            byte[] byteBufferExpected = null; // TODO: 初始化为适当的值
            int iBufferIndex = 0; // TODO: 初始化为适当的值
            ConvertByteArray.ToArrayInByte( iULong, ref byteBuffer, iBufferIndex );
            Assert.AreEqual( byteBufferExpected, byteBuffer );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///ToArrayInByte 的测试
        ///</summary>
        [TestMethod()]
        public void ToArrayInByteTest13()
        {
            int iInt = 0; // TODO: 初始化为适当的值
            byte[] byteBuffer = null; // TODO: 初始化为适当的值
            byte[] byteBufferExpected = null; // TODO: 初始化为适当的值
            int iBufferIndex = 0; // TODO: 初始化为适当的值
            ConvertByteArray.ToArrayInByte( iInt, ref byteBuffer, iBufferIndex );
            Assert.AreEqual( byteBufferExpected, byteBuffer );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///ToArrayInByte 的测试
        ///</summary>
        [TestMethod()]
        public void ToArrayInByteTest12()
        {
            int iInt = 0; // TODO: 初始化为适当的值
            byte[] expected = null; // TODO: 初始化为适当的值
            byte[] actual;
            actual = ConvertByteArray.ToArrayInByte( iInt );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToArrayInByte 的测试
        ///</summary>
        [TestMethod()]
        public void ToArrayInByteTest11()
        {
            ulong iULong = 0; // TODO: 初始化为适当的值
            byte[] expected = null; // TODO: 初始化为适当的值
            byte[] actual;
            actual = ConvertByteArray.ToArrayInByte( iULong );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToArrayInByte 的测试
        ///</summary>
        [TestMethod()]
        public void ToArrayInByteTest10()
        {
            ushort iUShort = 0; // TODO: 初始化为适当的值
            byte[] expected = null; // TODO: 初始化为适当的值
            byte[] actual;
            actual = ConvertByteArray.ToArrayInByte( iUShort );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToArrayInByte 的测试
        ///</summary>
        [TestMethod()]
        public void ToArrayInByteTest9()
        {
            long iLong = 0; // TODO: 初始化为适当的值
            byte[] byteBuffer = null; // TODO: 初始化为适当的值
            byte[] byteBufferExpected = null; // TODO: 初始化为适当的值
            int iBufferIndex = 0; // TODO: 初始化为适当的值
            ConvertByteArray.ToArrayInByte( iLong, ref byteBuffer, iBufferIndex );
            Assert.AreEqual( byteBufferExpected, byteBuffer );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///ToArrayInByte 的测试
        ///</summary>
        [TestMethod()]
        public void ToArrayInByteTest8()
        {
            short iShort = 0; // TODO: 初始化为适当的值
            byte[] expected = null; // TODO: 初始化为适当的值
            byte[] actual;
            actual = ConvertByteArray.ToArrayInByte( iShort );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToArrayInByte 的测试
        ///</summary>
        [TestMethod()]
        public void ToArrayInByteTest7()
        {
            short iShort = 0; // TODO: 初始化为适当的值
            byte[] byteBuffer = null; // TODO: 初始化为适当的值
            byte[] byteBufferExpected = null; // TODO: 初始化为适当的值
            int iBufferIndex = 0; // TODO: 初始化为适当的值
            ConvertByteArray.ToArrayInByte( iShort, ref byteBuffer, iBufferIndex );
            Assert.AreEqual( byteBufferExpected, byteBuffer );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///ToArrayInByte 的测试
        ///</summary>
        [TestMethod()]
        public void ToArrayInByteTest6()
        {
            long iLong = 0; // TODO: 初始化为适当的值
            byte[] expected = null; // TODO: 初始化为适当的值
            byte[] actual;
            actual = ConvertByteArray.ToArrayInByte( iLong );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToArrayInByte 的测试
        ///</summary>
        [TestMethod()]
        public void ToArrayInByteTest5()
        {
            string strString = string.Empty; // TODO: 初始化为适当的值
            Encoding encoding = null; // TODO: 初始化为适当的值
            byte[] expected = null; // TODO: 初始化为适当的值
            byte[] actual;
            actual = ConvertByteArray.ToArrayInByte( strString, encoding );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToArrayInByte 的测试
        ///</summary>
        [TestMethod()]
        public void ToArrayInByteTest4()
        {
            uint iUInt = 0; // TODO: 初始化为适当的值
            byte[] byteBuffer = null; // TODO: 初始化为适当的值
            byte[] byteBufferExpected = null; // TODO: 初始化为适当的值
            int iBufferIndex = 0; // TODO: 初始化为适当的值
            ConvertByteArray.ToArrayInByte( iUInt, ref byteBuffer, iBufferIndex );
            Assert.AreEqual( byteBufferExpected, byteBuffer );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///ToArrayInByte 的测试
        ///</summary>
        [TestMethod()]
        public void ToArrayInByteTest3()
        {
            uint iUInt = 0; // TODO: 初始化为适当的值
            byte[] expected = null; // TODO: 初始化为适当的值
            byte[] actual;
            actual = ConvertByteArray.ToArrayInByte( iUInt );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToArrayInByte 的测试
        ///</summary>
        [TestMethod()]
        public void ToArrayInByteTest2()
        {
            sbyte iSByte = 0; // TODO: 初始化为适当的值
            byte[] expected = null; // TODO: 初始化为适当的值
            byte[] actual;
            actual = ConvertByteArray.ToArrayInByte( iSByte );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToArrayInByte 的测试
        ///</summary>
        [TestMethod()]
        public void ToArrayInByteTest1()
        {
            sbyte iSByte = 0; // TODO: 初始化为适当的值
            byte[] byteBuffer = null; // TODO: 初始化为适当的值
            byte[] byteBufferExpected = null; // TODO: 初始化为适当的值
            int iBufferIndex = 0; // TODO: 初始化为适当的值
            ConvertByteArray.ToArrayInByte( iSByte, ref byteBuffer, iBufferIndex );
            Assert.AreEqual( byteBufferExpected, byteBuffer );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///ToArrayInByte 的测试
        ///</summary>
        [TestMethod()]
        public void ToArrayInByteTest()
        {
            string strString = string.Empty; // TODO: 初始化为适当的值
            byte[] expected = null; // TODO: 初始化为适当的值
            byte[] actual;
            actual = ConvertByteArray.ToArrayInByte( strString );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ConvertToUShort 的测试
        ///</summary>
        [TestMethod()]
        public void ConvertToUShortTest1()
        {
            byte[] ushortBuffer = null; // TODO: 初始化为适当的值
            ushort expected = 0; // TODO: 初始化为适当的值
            ushort actual;
            actual = ConvertByteArray.ConvertToUShort( ushortBuffer );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ConvertToUShort 的测试
        ///</summary>
        [TestMethod()]
        public void ConvertToUShortTest()
        {
            byte[] ushortBuffer = null; // TODO: 初始化为适当的值
            int iBufferIndex = 0; // TODO: 初始化为适当的值
            ushort expected = 0; // TODO: 初始化为适当的值
            ushort actual;
            actual = ConvertByteArray.ConvertToUShort( ushortBuffer, iBufferIndex );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ConvertToULong 的测试
        ///</summary>
        [TestMethod()]
        public void ConvertToULongTest1()
        {
            byte[] ulongBuffer = null; // TODO: 初始化为适当的值
            int iBufferIndex = 0; // TODO: 初始化为适当的值
            ulong expected = 0; // TODO: 初始化为适当的值
            ulong actual;
            actual = ConvertByteArray.ConvertToULong( ulongBuffer, iBufferIndex );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ConvertToULong 的测试
        ///</summary>
        [TestMethod()]
        public void ConvertToULongTest()
        {
            byte[] ulongBuffer = null; // TODO: 初始化为适当的值
            ulong expected = 0; // TODO: 初始化为适当的值
            ulong actual;
            actual = ConvertByteArray.ConvertToULong( ulongBuffer );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ConvertToUInt 的测试
        ///</summary>
        [TestMethod()]
        public void ConvertToUIntTest1()
        {
            byte[] uintBuffer = null; // TODO: 初始化为适当的值
            int iBufferIndex = 0; // TODO: 初始化为适当的值
            uint expected = 0; // TODO: 初始化为适当的值
            uint actual;
            actual = ConvertByteArray.ConvertToUInt( uintBuffer, iBufferIndex );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ConvertToUInt 的测试
        ///</summary>
        [TestMethod()]
        public void ConvertToUIntTest()
        {
            byte[] uintBuffer = null; // TODO: 初始化为适当的值
            uint expected = 0; // TODO: 初始化为适当的值
            uint actual;
            actual = ConvertByteArray.ConvertToUInt( uintBuffer );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ConvertToString 的测试
        ///</summary>
        [TestMethod()]
        public void ConvertToStringTest3()
        {
            byte[] byteString = null; // TODO: 初始化为适当的值
            long iOffset = 0; // TODO: 初始化为适当的值
            long iSize = 0; // TODO: 初始化为适当的值
            Encoding encoding = null; // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = ConvertByteArray.ConvertToString( byteString, iOffset, iSize, encoding );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ConvertToString 的测试
        ///</summary>
        [TestMethod()]
        public void ConvertToStringTest2()
        {
            byte[] byteString = null; // TODO: 初始化为适当的值
            long iOffset = 0; // TODO: 初始化为适当的值
            long iSize = 0; // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = ConvertByteArray.ConvertToString( byteString, iOffset, iSize );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ConvertToString 的测试
        ///</summary>
        [TestMethod()]
        public void ConvertToStringTest1()
        {
            byte[] byteString = null; // TODO: 初始化为适当的值
            Encoding encoding = null; // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = ConvertByteArray.ConvertToString( byteString, encoding );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ConvertToString 的测试
        ///</summary>
        [TestMethod()]
        public void ConvertToStringTest()
        {
            byte[] byteString = null; // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = ConvertByteArray.ConvertToString( byteString );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ConvertToShort 的测试
        ///</summary>
        [TestMethod()]
        public void ConvertToShortTest1()
        {
            byte[] shortBuffer = null; // TODO: 初始化为适当的值
            short expected = 0; // TODO: 初始化为适当的值
            short actual;
            actual = ConvertByteArray.ConvertToShort( shortBuffer );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ConvertToShort 的测试
        ///</summary>
        [TestMethod()]
        public void ConvertToShortTest()
        {
            byte[] shortBuffer = null; // TODO: 初始化为适当的值
            int iBufferIndex = 0; // TODO: 初始化为适当的值
            short expected = 0; // TODO: 初始化为适当的值
            short actual;
            actual = ConvertByteArray.ConvertToShort( shortBuffer, iBufferIndex );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ConvertToSByte 的测试
        ///</summary>
        [TestMethod()]
        public void ConvertToSByteTest1()
        {
            byte[] sbyteBuffer = null; // TODO: 初始化为适当的值
            sbyte expected = 0; // TODO: 初始化为适当的值
            sbyte actual;
            actual = ConvertByteArray.ConvertToSByte( sbyteBuffer );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ConvertToSByte 的测试
        ///</summary>
        [TestMethod()]
        public void ConvertToSByteTest()
        {
            byte[] sbyteBuffer = null; // TODO: 初始化为适当的值
            int iBufferIndex = 0; // TODO: 初始化为适当的值
            sbyte expected = 0; // TODO: 初始化为适当的值
            sbyte actual;
            actual = ConvertByteArray.ConvertToSByte( sbyteBuffer, iBufferIndex );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ConvertToLong 的测试
        ///</summary>
        [TestMethod()]
        public void ConvertToLongTest1()
        {
            byte[] longBuffer = null; // TODO: 初始化为适当的值
            long expected = 0; // TODO: 初始化为适当的值
            long actual;
            actual = ConvertByteArray.ConvertToLong( longBuffer );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ConvertToLong 的测试
        ///</summary>
        [TestMethod()]
        public void ConvertToLongTest()
        {
            byte[] longBuffer = null; // TODO: 初始化为适当的值
            int iBufferIndex = 0; // TODO: 初始化为适当的值
            long expected = 0; // TODO: 初始化为适当的值
            long actual;
            actual = ConvertByteArray.ConvertToLong( longBuffer, iBufferIndex );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ConvertToInt 的测试
        ///</summary>
        [TestMethod()]
        public void ConvertToIntTest1()
        {
            byte[] intBuffer = null; // TODO: 初始化为适当的值
            int iBufferIndex = 0; // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = ConvertByteArray.ConvertToInt( intBuffer, iBufferIndex );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ConvertToInt 的测试
        ///</summary>
        [TestMethod()]
        public void ConvertToIntTest()
        {
            byte[] intBuffer = null; // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = ConvertByteArray.ConvertToInt( intBuffer );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ConvertToChar 的测试
        ///</summary>
        [TestMethod()]
        public void ConvertToCharTest1()
        {
            byte[] charBuffer = null; // TODO: 初始化为适当的值
            int iBufferIndex = 0; // TODO: 初始化为适当的值
            char expected = '\0'; // TODO: 初始化为适当的值
            char actual;
            actual = ConvertByteArray.ConvertToChar( charBuffer, iBufferIndex );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ConvertToChar 的测试
        ///</summary>
        [TestMethod()]
        public void ConvertToCharTest()
        {
            byte[] charBuffer = null; // TODO: 初始化为适当的值
            char expected = '\0'; // TODO: 初始化为适当的值
            char actual;
            actual = ConvertByteArray.ConvertToChar( charBuffer );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ConvertToByte 的测试
        ///</summary>
        [TestMethod()]
        public void ConvertToByteTest1()
        {
            byte[] byteBuffer = null; // TODO: 初始化为适当的值
            int iBufferIndex = 0; // TODO: 初始化为适当的值
            byte expected = 0; // TODO: 初始化为适当的值
            byte actual;
            actual = ConvertByteArray.ConvertToByte( byteBuffer, iBufferIndex );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ConvertToByte 的测试
        ///</summary>
        [TestMethod()]
        public void ConvertToByteTest()
        {
            byte[] byteBuffer = null; // TODO: 初始化为适当的值
            byte expected = 0; // TODO: 初始化为适当的值
            byte actual;
            actual = ConvertByteArray.ConvertToByte( byteBuffer );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Concat 的测试
        ///</summary>
        [TestMethod()]
        public void ConcatTest1()
        {
            byte[] bufferA = null; // TODO: 初始化为适当的值
            long iOffsetA = 0; // TODO: 初始化为适当的值
            long iSizeA = 0; // TODO: 初始化为适当的值
            byte[] bufferB = null; // TODO: 初始化为适当的值
            long iOffsetB = 0; // TODO: 初始化为适当的值
            long iSizeB = 0; // TODO: 初始化为适当的值
            byte[] expected = null; // TODO: 初始化为适当的值
            byte[] actual;
            actual = ConvertByteArray.Concat( bufferA, iOffsetA, iSizeA, bufferB, iOffsetB, iSizeB );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Concat 的测试
        ///</summary>
        [TestMethod()]
        public void ConcatTest()
        {
            byte[] bufferA = null; // TODO: 初始化为适当的值
            byte[] bufferB = null; // TODO: 初始化为适当的值
            byte[] expected = null; // TODO: 初始化为适当的值
            byte[] actual;
            actual = ConvertByteArray.Concat( bufferA, bufferB );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Coalition 的测试
        ///</summary>
        [TestMethod()]
        public void CoalitionTest1()
        {
            byte[] thisBuffer = null; // TODO: 初始化为适当的值
            long iThisOffset = 0; // TODO: 初始化为适当的值
            long iThisSize = 0; // TODO: 初始化为适当的值
            byte[] bufferB = null; // TODO: 初始化为适当的值
            long iOffsetB = 0; // TODO: 初始化为适当的值
            long iSizeB = 0; // TODO: 初始化为适当的值
            byte[] expected = null; // TODO: 初始化为适当的值
            byte[] actual;
            actual = ConvertByteArray.Coalition( thisBuffer, iThisOffset, iThisSize, bufferB, iOffsetB, iSizeB );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Coalition 的测试
        ///</summary>
        [TestMethod()]
        public void CoalitionTest()
        {
            byte[] thisBuffer = null; // TODO: 初始化为适当的值
            byte[] concatBuffer = null; // TODO: 初始化为适当的值
            byte[] expected = null; // TODO: 初始化为适当的值
            byte[] actual;
            actual = ConvertByteArray.Coalition( thisBuffer, concatBuffer );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }
    }
}
