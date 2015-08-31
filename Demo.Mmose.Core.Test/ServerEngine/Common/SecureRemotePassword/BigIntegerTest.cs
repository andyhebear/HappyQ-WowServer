using Demo.Mmose.Core.Common.Srp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 BigIntegerTest 的测试类，旨在
    ///包含所有 BigIntegerTest 单元测试
    ///</summary>
    [TestClass()]
    public class BigIntegerTest
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
        ///DataLength 的测试
        ///</summary>
        [TestMethod()]
        public void DataLengthTest()
        {
            BigInteger target = new BigInteger(); // TODO: 初始化为适当的值
            int actual;
            actual = target.DataLength;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///UnsetBit 的测试
        ///</summary>
        [TestMethod()]
        public void UnsetBitTest()
        {
            BigInteger target = new BigInteger(); // TODO: 初始化为适当的值
            uint bitNum = 0; // TODO: 初始化为适当的值
            target.UnsetBit( bitNum );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///ToString 的测试
        ///</summary>
        [TestMethod()]
        public void ToStringTest1()
        {
            BigInteger target = new BigInteger(); // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = target.ToString();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToString 的测试
        ///</summary>
        [TestMethod()]
        public void ToStringTest()
        {
            BigInteger target = new BigInteger(); // TODO: 初始化为适当的值
            int radix = 0; // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = target.ToString( radix );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToHexString 的测试
        ///</summary>
        [TestMethod()]
        public void ToHexStringTest()
        {
            BigInteger target = new BigInteger(); // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = target.ToHexString();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Sqrt 的测试
        ///</summary>
        [TestMethod()]
        public void SqrtTest()
        {
            BigInteger target = new BigInteger(); // TODO: 初始化为适当的值
            BigInteger expected = null; // TODO: 初始化为适当的值
            BigInteger actual;
            actual = target.Sqrt();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///SolovayStrassenTest 的测试
        ///</summary>
        [TestMethod()]
        public void SolovayStrassenTestTest()
        {
            BigInteger target = new BigInteger(); // TODO: 初始化为适当的值
            int confidence = 0; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.SolovayStrassenTest( confidence );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///SingleByteDivide 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void SingleByteDivideTest()
        {
            BigInteger bi1 = null; // TODO: 初始化为适当的值
            BigInteger bi2 = null; // TODO: 初始化为适当的值
            BigInteger outQuotient = null; // TODO: 初始化为适当的值
            BigInteger outRemainder = null; // TODO: 初始化为适当的值
            BigInteger_Accessor.SingleByteDivide( bi1, bi2, outQuotient, outRemainder );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///ShiftRight 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void ShiftRightTest()
        {
            uint[] buffer = null; // TODO: 初始化为适当的值
            int shiftVal = 0; // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = BigInteger_Accessor.ShiftRight( buffer, shiftVal );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ShiftLeft 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void ShiftLeftTest()
        {
            uint[] buffer = null; // TODO: 初始化为适当的值
            int shiftVal = 0; // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = BigInteger_Accessor.ShiftLeft( buffer, shiftVal );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///SetValue 的测试
        ///</summary>
        [TestMethod()]
        public void SetValueTest()
        {
            BigInteger target = new BigInteger(); // TODO: 初始化为适当的值
            BigInteger bi = null; // TODO: 初始化为适当的值
            target.SetValue( bi );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///SetBit 的测试
        ///</summary>
        [TestMethod()]
        public void SetBitTest()
        {
            BigInteger target = new BigInteger(); // TODO: 初始化为适当的值
            uint bitNum = 0; // TODO: 初始化为适当的值
            target.SetBit( bitNum );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Reverse 的测试
        ///</summary>
        public void ReverseTest1Helper<T>()
        {
            T[] buffer = null; // TODO: 初始化为适当的值
            int length = 0; // TODO: 初始化为适当的值
            BigInteger_Accessor.Reverse<T>( buffer, length );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void ReverseTest1()
        {
            ReverseTest1Helper<GenericParameterHelper>();
        }

        /// <summary>
        ///Reverse 的测试
        ///</summary>
        public void ReverseTestHelper<T>()
        {
            T[] buffer = null; // TODO: 初始化为适当的值
            BigInteger_Accessor.Reverse<T>( buffer );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void ReverseTest()
        {
            ReverseTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///RabinMillerTest 的测试
        ///</summary>
        [TestMethod()]
        public void RabinMillerTestTest()
        {
            BigInteger target = new BigInteger(); // TODO: 初始化为适当的值
            int confidence = 0; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.RabinMillerTest( confidence );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_UnaryNegation 的测试
        ///</summary>
        [TestMethod()]
        public void op_UnaryNegationTest()
        {
            BigInteger bi1 = null; // TODO: 初始化为适当的值
            BigInteger expected = null; // TODO: 初始化为适当的值
            BigInteger actual;
            actual = -( bi1 );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_Subtraction 的测试
        ///</summary>
        [TestMethod()]
        public void op_SubtractionTest4()
        {
            BigInteger bi1 = null; // TODO: 初始化为适当的值
            long bi2 = 0; // TODO: 初始化为适当的值
            BigInteger expected = null; // TODO: 初始化为适当的值
            BigInteger actual;
            actual = ( bi1 - bi2 );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_Subtraction 的测试
        ///</summary>
        [TestMethod()]
        public void op_SubtractionTest3()
        {
            BigInteger bi1 = null; // TODO: 初始化为适当的值
            int bi2 = 0; // TODO: 初始化为适当的值
            BigInteger expected = null; // TODO: 初始化为适当的值
            BigInteger actual;
            actual = ( bi1 - bi2 );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_Subtraction 的测试
        ///</summary>
        [TestMethod()]
        public void op_SubtractionTest2()
        {
            BigInteger bi1 = null; // TODO: 初始化为适当的值
            uint bi2 = 0; // TODO: 初始化为适当的值
            BigInteger expected = null; // TODO: 初始化为适当的值
            BigInteger actual;
            actual = ( bi1 - bi2 );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_Subtraction 的测试
        ///</summary>
        [TestMethod()]
        public void op_SubtractionTest1()
        {
            BigInteger bi1 = null; // TODO: 初始化为适当的值
            ulong bi2 = 0; // TODO: 初始化为适当的值
            BigInteger expected = null; // TODO: 初始化为适当的值
            BigInteger actual;
            actual = ( bi1 - bi2 );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_Subtraction 的测试
        ///</summary>
        [TestMethod()]
        public void op_SubtractionTest()
        {
            BigInteger bi1 = null; // TODO: 初始化为适当的值
            BigInteger bi2 = null; // TODO: 初始化为适当的值
            BigInteger expected = null; // TODO: 初始化为适当的值
            BigInteger actual;
            actual = ( bi1 - bi2 );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_RightShift 的测试
        ///</summary>
        [TestMethod()]
        public void op_RightShiftTest()
        {
            BigInteger bi1 = null; // TODO: 初始化为适当的值
            int shiftVal = 0; // TODO: 初始化为适当的值
            BigInteger expected = null; // TODO: 初始化为适当的值
            BigInteger actual;
            actual = ( bi1 >> shiftVal );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_OnesComplement 的测试
        ///</summary>
        [TestMethod()]
        public void op_OnesComplementTest()
        {
            BigInteger bi1 = null; // TODO: 初始化为适当的值
            BigInteger expected = null; // TODO: 初始化为适当的值
            BigInteger actual;
            actual = ~( bi1 );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_Multiply 的测试
        ///</summary>
        [TestMethod()]
        public void op_MultiplyTest4()
        {
            BigInteger bi1 = null; // TODO: 初始化为适当的值
            long bi2 = 0; // TODO: 初始化为适当的值
            BigInteger expected = null; // TODO: 初始化为适当的值
            BigInteger actual;
            actual = ( bi1 * bi2 );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_Multiply 的测试
        ///</summary>
        [TestMethod()]
        public void op_MultiplyTest3()
        {
            BigInteger bi1 = null; // TODO: 初始化为适当的值
            BigInteger bi2 = null; // TODO: 初始化为适当的值
            BigInteger expected = null; // TODO: 初始化为适当的值
            BigInteger actual;
            actual = ( bi1 * bi2 );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_Multiply 的测试
        ///</summary>
        [TestMethod()]
        public void op_MultiplyTest2()
        {
            BigInteger bi1 = null; // TODO: 初始化为适当的值
            int bi2 = 0; // TODO: 初始化为适当的值
            BigInteger expected = null; // TODO: 初始化为适当的值
            BigInteger actual;
            actual = ( bi1 * bi2 );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_Multiply 的测试
        ///</summary>
        [TestMethod()]
        public void op_MultiplyTest1()
        {
            BigInteger bi1 = null; // TODO: 初始化为适当的值
            uint bi2 = 0; // TODO: 初始化为适当的值
            BigInteger expected = null; // TODO: 初始化为适当的值
            BigInteger actual;
            actual = ( bi1 * bi2 );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_Multiply 的测试
        ///</summary>
        [TestMethod()]
        public void op_MultiplyTest()
        {
            BigInteger bi1 = null; // TODO: 初始化为适当的值
            ulong bi2 = 0; // TODO: 初始化为适当的值
            BigInteger expected = null; // TODO: 初始化为适当的值
            BigInteger actual;
            actual = ( bi1 * bi2 );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_Modulus 的测试
        ///</summary>
        [TestMethod()]
        public void op_ModulusTest8()
        {
            BigInteger bi1 = null; // TODO: 初始化为适当的值
            BigInteger bi2 = null; // TODO: 初始化为适当的值
            BigInteger expected = null; // TODO: 初始化为适当的值
            BigInteger actual;
            actual = ( bi1 % bi2 );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_Modulus 的测试
        ///</summary>
        [TestMethod()]
        public void op_ModulusTest7()
        {
            BigInteger bi1 = null; // TODO: 初始化为适当的值
            long bi2 = 0; // TODO: 初始化为适当的值
            BigInteger expected = null; // TODO: 初始化为适当的值
            BigInteger actual;
            actual = ( bi1 % bi2 );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_Modulus 的测试
        ///</summary>
        [TestMethod()]
        public void op_ModulusTest6()
        {
            BigInteger bi1 = null; // TODO: 初始化为适当的值
            ulong bi2 = 0; // TODO: 初始化为适当的值
            BigInteger expected = null; // TODO: 初始化为适当的值
            BigInteger actual;
            actual = ( bi1 % bi2 );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_Modulus 的测试
        ///</summary>
        [TestMethod()]
        public void op_ModulusTest5()
        {
            BigInteger bi1 = null; // TODO: 初始化为适当的值
            int bi2 = 0; // TODO: 初始化为适当的值
            BigInteger expected = null; // TODO: 初始化为适当的值
            BigInteger actual;
            actual = ( bi1 % bi2 );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_Modulus 的测试
        ///</summary>
        [TestMethod()]
        public void op_ModulusTest4()
        {
            ulong bi1 = 0; // TODO: 初始化为适当的值
            BigInteger bi2 = null; // TODO: 初始化为适当的值
            BigInteger expected = null; // TODO: 初始化为适当的值
            BigInteger actual;
            actual = ( bi1 % bi2 );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_Modulus 的测试
        ///</summary>
        [TestMethod()]
        public void op_ModulusTest3()
        {
            int bi1 = 0; // TODO: 初始化为适当的值
            BigInteger bi2 = null; // TODO: 初始化为适当的值
            BigInteger expected = null; // TODO: 初始化为适当的值
            BigInteger actual;
            actual = ( bi1 % bi2 );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_Modulus 的测试
        ///</summary>
        [TestMethod()]
        public void op_ModulusTest2()
        {
            uint bi1 = 0; // TODO: 初始化为适当的值
            BigInteger bi2 = null; // TODO: 初始化为适当的值
            BigInteger expected = null; // TODO: 初始化为适当的值
            BigInteger actual;
            actual = ( bi1 % bi2 );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_Modulus 的测试
        ///</summary>
        [TestMethod()]
        public void op_ModulusTest1()
        {
            BigInteger bi1 = null; // TODO: 初始化为适当的值
            uint bi2 = 0; // TODO: 初始化为适当的值
            BigInteger expected = null; // TODO: 初始化为适当的值
            BigInteger actual;
            actual = ( bi1 % bi2 );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_Modulus 的测试
        ///</summary>
        [TestMethod()]
        public void op_ModulusTest()
        {
            long bi1 = 0; // TODO: 初始化为适当的值
            BigInteger bi2 = null; // TODO: 初始化为适当的值
            BigInteger expected = null; // TODO: 初始化为适当的值
            BigInteger actual;
            actual = ( bi1 % bi2 );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_LessThanOrEqual 的测试
        ///</summary>
        [TestMethod()]
        public void op_LessThanOrEqualTest4()
        {
            BigInteger bi1 = null; // TODO: 初始化为适当的值
            ulong bi2 = 0; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = ( bi1 <= bi2 );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_LessThanOrEqual 的测试
        ///</summary>
        [TestMethod()]
        public void op_LessThanOrEqualTest3()
        {
            BigInteger bi1 = null; // TODO: 初始化为适当的值
            long bi2 = 0; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = ( bi1 <= bi2 );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_LessThanOrEqual 的测试
        ///</summary>
        [TestMethod()]
        public void op_LessThanOrEqualTest2()
        {
            BigInteger bi1 = null; // TODO: 初始化为适当的值
            BigInteger bi2 = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = ( bi1 <= bi2 );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_LessThanOrEqual 的测试
        ///</summary>
        [TestMethod()]
        public void op_LessThanOrEqualTest1()
        {
            BigInteger bi1 = null; // TODO: 初始化为适当的值
            int bi2 = 0; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = ( bi1 <= bi2 );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_LessThanOrEqual 的测试
        ///</summary>
        [TestMethod()]
        public void op_LessThanOrEqualTest()
        {
            BigInteger bi1 = null; // TODO: 初始化为适当的值
            uint bi2 = 0; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = ( bi1 <= bi2 );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_LessThan 的测试
        ///</summary>
        [TestMethod()]
        public void op_LessThanTest4()
        {
            BigInteger bi1 = null; // TODO: 初始化为适当的值
            ulong bi2 = 0; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = ( bi1 < bi2 );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_LessThan 的测试
        ///</summary>
        [TestMethod()]
        public void op_LessThanTest3()
        {
            BigInteger bi1 = null; // TODO: 初始化为适当的值
            long bi2 = 0; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = ( bi1 < bi2 );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_LessThan 的测试
        ///</summary>
        [TestMethod()]
        public void op_LessThanTest2()
        {
            BigInteger bi1 = null; // TODO: 初始化为适当的值
            uint bi2 = 0; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = ( bi1 < bi2 );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_LessThan 的测试
        ///</summary>
        [TestMethod()]
        public void op_LessThanTest1()
        {
            BigInteger bi1 = null; // TODO: 初始化为适当的值
            int bi2 = 0; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = ( bi1 < bi2 );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_LessThan 的测试
        ///</summary>
        [TestMethod()]
        public void op_LessThanTest()
        {
            BigInteger bi1 = null; // TODO: 初始化为适当的值
            BigInteger bi2 = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = ( bi1 < bi2 );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_LeftShift 的测试
        ///</summary>
        [TestMethod()]
        public void op_LeftShiftTest()
        {
            BigInteger bi1 = null; // TODO: 初始化为适当的值
            int shiftVal = 0; // TODO: 初始化为适当的值
            BigInteger expected = null; // TODO: 初始化为适当的值
            BigInteger actual;
            actual = ( bi1 << shiftVal );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_Inequality 的测试
        ///</summary>
        [TestMethod()]
        public void op_InequalityTest4()
        {
            BigInteger bi1 = null; // TODO: 初始化为适当的值
            long bi2 = 0; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = ( bi1 != bi2 );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_Inequality 的测试
        ///</summary>
        [TestMethod()]
        public void op_InequalityTest3()
        {
            BigInteger bi1 = null; // TODO: 初始化为适当的值
            uint bi2 = 0; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = ( bi1 != bi2 );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_Inequality 的测试
        ///</summary>
        [TestMethod()]
        public void op_InequalityTest2()
        {
            BigInteger bi1 = null; // TODO: 初始化为适当的值
            ulong bi2 = 0; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = ( bi1 != bi2 );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_Inequality 的测试
        ///</summary>
        [TestMethod()]
        public void op_InequalityTest1()
        {
            BigInteger bi1 = null; // TODO: 初始化为适当的值
            int bi2 = 0; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = ( bi1 != bi2 );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_Inequality 的测试
        ///</summary>
        [TestMethod()]
        public void op_InequalityTest()
        {
            BigInteger bi1 = null; // TODO: 初始化为适当的值
            BigInteger bi2 = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = ( bi1 != bi2 );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_Increment 的测试
        ///</summary>
        [TestMethod()]
        public void op_IncrementTest()
        {
            BigInteger bi1 = null; // TODO: 初始化为适当的值
            BigInteger expected = null; // TODO: 初始化为适当的值
            BigInteger actual;
            actual = ++( bi1 );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_GreaterThanOrEqual 的测试
        ///</summary>
        [TestMethod()]
        public void op_GreaterThanOrEqualTest4()
        {
            BigInteger bi1 = null; // TODO: 初始化为适当的值
            ulong bi2 = 0; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = ( bi1 >= bi2 );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_GreaterThanOrEqual 的测试
        ///</summary>
        [TestMethod()]
        public void op_GreaterThanOrEqualTest3()
        {
            BigInteger bi1 = null; // TODO: 初始化为适当的值
            BigInteger bi2 = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = ( bi1 >= bi2 );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_GreaterThanOrEqual 的测试
        ///</summary>
        [TestMethod()]
        public void op_GreaterThanOrEqualTest2()
        {
            BigInteger bi1 = null; // TODO: 初始化为适当的值
            int bi2 = 0; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = ( bi1 >= bi2 );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_GreaterThanOrEqual 的测试
        ///</summary>
        [TestMethod()]
        public void op_GreaterThanOrEqualTest1()
        {
            BigInteger bi1 = null; // TODO: 初始化为适当的值
            long bi2 = 0; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = ( bi1 >= bi2 );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_GreaterThanOrEqual 的测试
        ///</summary>
        [TestMethod()]
        public void op_GreaterThanOrEqualTest()
        {
            BigInteger bi1 = null; // TODO: 初始化为适当的值
            uint bi2 = 0; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = ( bi1 >= bi2 );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_GreaterThan 的测试
        ///</summary>
        [TestMethod()]
        public void op_GreaterThanTest4()
        {
            BigInteger bi1 = null; // TODO: 初始化为适当的值
            uint bi2 = 0; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = ( bi1 > bi2 );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_GreaterThan 的测试
        ///</summary>
        [TestMethod()]
        public void op_GreaterThanTest3()
        {
            BigInteger bi1 = null; // TODO: 初始化为适当的值
            ulong bi2 = 0; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = ( bi1 > bi2 );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_GreaterThan 的测试
        ///</summary>
        [TestMethod()]
        public void op_GreaterThanTest2()
        {
            BigInteger bi1 = null; // TODO: 初始化为适当的值
            int bi2 = 0; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = ( bi1 > bi2 );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_GreaterThan 的测试
        ///</summary>
        [TestMethod()]
        public void op_GreaterThanTest1()
        {
            BigInteger bi1 = null; // TODO: 初始化为适当的值
            BigInteger bi2 = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = ( bi1 > bi2 );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_GreaterThan 的测试
        ///</summary>
        [TestMethod()]
        public void op_GreaterThanTest()
        {
            BigInteger bi1 = null; // TODO: 初始化为适当的值
            long bi2 = 0; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = ( bi1 > bi2 );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_Explicit 的测试
        ///</summary>
        [TestMethod()]
        public void op_ExplicitTest3()
        {
            ulong value = 0; // TODO: 初始化为适当的值
            BigInteger expected = null; // TODO: 初始化为适当的值
            BigInteger actual;
            actual = ( (BigInteger)( value ) );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_Explicit 的测试
        ///</summary>
        [TestMethod()]
        public void op_ExplicitTest2()
        {
            uint value = 0; // TODO: 初始化为适当的值
            BigInteger expected = null; // TODO: 初始化为适当的值
            BigInteger actual;
            actual = ( (BigInteger)( value ) );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_Explicit 的测试
        ///</summary>
        [TestMethod()]
        public void op_ExplicitTest1()
        {
            int value = 0; // TODO: 初始化为适当的值
            BigInteger expected = null; // TODO: 初始化为适当的值
            BigInteger actual;
            actual = ( (BigInteger)( value ) );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_Explicit 的测试
        ///</summary>
        [TestMethod()]
        public void op_ExplicitTest()
        {
            long value = 0; // TODO: 初始化为适当的值
            BigInteger expected = null; // TODO: 初始化为适当的值
            BigInteger actual;
            actual = ( (BigInteger)( value ) );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_ExclusiveOr 的测试
        ///</summary>
        [TestMethod()]
        public void op_ExclusiveOrTest()
        {
            BigInteger bi1 = null; // TODO: 初始化为适当的值
            BigInteger bi2 = null; // TODO: 初始化为适当的值
            BigInteger expected = null; // TODO: 初始化为适当的值
            BigInteger actual;
            actual = ( bi1 ^ bi2 );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_Equality 的测试
        ///</summary>
        [TestMethod()]
        public void op_EqualityTest4()
        {
            BigInteger bi1 = null; // TODO: 初始化为适当的值
            int bi2 = 0; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = ( bi1 == bi2 );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_Equality 的测试
        ///</summary>
        [TestMethod()]
        public void op_EqualityTest3()
        {
            BigInteger bi1 = null; // TODO: 初始化为适当的值
            ulong bi2 = 0; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = ( bi1 == bi2 );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_Equality 的测试
        ///</summary>
        [TestMethod()]
        public void op_EqualityTest2()
        {
            BigInteger bi1 = null; // TODO: 初始化为适当的值
            long bi2 = 0; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = ( bi1 == bi2 );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_Equality 的测试
        ///</summary>
        [TestMethod()]
        public void op_EqualityTest1()
        {
            BigInteger bi1 = null; // TODO: 初始化为适当的值
            uint bi2 = 0; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = ( bi1 == bi2 );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_Equality 的测试
        ///</summary>
        [TestMethod()]
        public void op_EqualityTest()
        {
            BigInteger bi1 = null; // TODO: 初始化为适当的值
            BigInteger bi2 = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = ( bi1 == bi2 );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_Division 的测试
        ///</summary>
        [TestMethod()]
        public void op_DivisionTest4()
        {
            BigInteger bi1 = null; // TODO: 初始化为适当的值
            ulong bi2 = 0; // TODO: 初始化为适当的值
            BigInteger expected = null; // TODO: 初始化为适当的值
            BigInteger actual;
            actual = ( bi1 / bi2 );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_Division 的测试
        ///</summary>
        [TestMethod()]
        public void op_DivisionTest3()
        {
            BigInteger bi1 = null; // TODO: 初始化为适当的值
            uint bi2 = 0; // TODO: 初始化为适当的值
            BigInteger expected = null; // TODO: 初始化为适当的值
            BigInteger actual;
            actual = ( bi1 / bi2 );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_Division 的测试
        ///</summary>
        [TestMethod()]
        public void op_DivisionTest2()
        {
            BigInteger bi1 = null; // TODO: 初始化为适当的值
            int bi2 = 0; // TODO: 初始化为适当的值
            BigInteger expected = null; // TODO: 初始化为适当的值
            BigInteger actual;
            actual = ( bi1 / bi2 );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_Division 的测试
        ///</summary>
        [TestMethod()]
        public void op_DivisionTest1()
        {
            BigInteger bi1 = null; // TODO: 初始化为适当的值
            BigInteger bi2 = null; // TODO: 初始化为适当的值
            BigInteger expected = null; // TODO: 初始化为适当的值
            BigInteger actual;
            actual = ( bi1 / bi2 );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_Division 的测试
        ///</summary>
        [TestMethod()]
        public void op_DivisionTest()
        {
            BigInteger bi1 = null; // TODO: 初始化为适当的值
            long bi2 = 0; // TODO: 初始化为适当的值
            BigInteger expected = null; // TODO: 初始化为适当的值
            BigInteger actual;
            actual = ( bi1 / bi2 );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_Decrement 的测试
        ///</summary>
        [TestMethod()]
        public void op_DecrementTest()
        {
            BigInteger bi1 = null; // TODO: 初始化为适当的值
            BigInteger expected = null; // TODO: 初始化为适当的值
            BigInteger actual;
            actual = --( bi1 );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_BitwiseOr 的测试
        ///</summary>
        [TestMethod()]
        public void op_BitwiseOrTest()
        {
            BigInteger bi1 = null; // TODO: 初始化为适当的值
            BigInteger bi2 = null; // TODO: 初始化为适当的值
            BigInteger expected = null; // TODO: 初始化为适当的值
            BigInteger actual;
            actual = ( bi1 | bi2 );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_BitwiseAnd 的测试
        ///</summary>
        [TestMethod()]
        public void op_BitwiseAndTest()
        {
            BigInteger bi1 = null; // TODO: 初始化为适当的值
            BigInteger bi2 = null; // TODO: 初始化为适当的值
            BigInteger expected = null; // TODO: 初始化为适当的值
            BigInteger actual;
            actual = ( bi1 & bi2 );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_Addition 的测试
        ///</summary>
        [TestMethod()]
        public void op_AdditionTest4()
        {
            BigInteger bi1 = null; // TODO: 初始化为适当的值
            uint bi2 = 0; // TODO: 初始化为适当的值
            BigInteger expected = null; // TODO: 初始化为适当的值
            BigInteger actual;
            actual = ( bi1 + bi2 );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_Addition 的测试
        ///</summary>
        [TestMethod()]
        public void op_AdditionTest3()
        {
            BigInteger bi1 = null; // TODO: 初始化为适当的值
            int bi2 = 0; // TODO: 初始化为适当的值
            BigInteger expected = null; // TODO: 初始化为适当的值
            BigInteger actual;
            actual = ( bi1 + bi2 );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_Addition 的测试
        ///</summary>
        [TestMethod()]
        public void op_AdditionTest2()
        {
            BigInteger bi1 = null; // TODO: 初始化为适当的值
            long bi2 = 0; // TODO: 初始化为适当的值
            BigInteger expected = null; // TODO: 初始化为适当的值
            BigInteger actual;
            actual = ( bi1 + bi2 );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_Addition 的测试
        ///</summary>
        [TestMethod()]
        public void op_AdditionTest1()
        {
            BigInteger bi1 = null; // TODO: 初始化为适当的值
            BigInteger bi2 = null; // TODO: 初始化为适当的值
            BigInteger expected = null; // TODO: 初始化为适当的值
            BigInteger actual;
            actual = ( bi1 + bi2 );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_Addition 的测试
        ///</summary>
        [TestMethod()]
        public void op_AdditionTest()
        {
            BigInteger bi1 = null; // TODO: 初始化为适当的值
            ulong bi2 = 0; // TODO: 初始化为适当的值
            BigInteger expected = null; // TODO: 初始化为适当的值
            BigInteger actual;
            actual = ( bi1 + bi2 );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///MultiByteDivide 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void MultiByteDivideTest()
        {
            BigInteger bi1 = null; // TODO: 初始化为适当的值
            BigInteger bi2 = null; // TODO: 初始化为适当的值
            BigInteger outQuotient = null; // TODO: 初始化为适当的值
            BigInteger outRemainder = null; // TODO: 初始化为适当的值
            BigInteger_Accessor.MultiByteDivide( bi1, bi2, outQuotient, outRemainder );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///ModPow 的测试
        ///</summary>
        [TestMethod()]
        public void ModPowTest()
        {
            BigInteger target = new BigInteger(); // TODO: 初始化为适当的值
            BigInteger exp = null; // TODO: 初始化为适当的值
            BigInteger n = null; // TODO: 初始化为适当的值
            BigInteger expected = null; // TODO: 初始化为适当的值
            BigInteger actual;
            actual = target.ModPow( exp, n );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ModInverse 的测试
        ///</summary>
        [TestMethod()]
        public void ModInverseTest()
        {
            BigInteger target = new BigInteger(); // TODO: 初始化为适当的值
            BigInteger modulus = null; // TODO: 初始化为适当的值
            BigInteger expected = null; // TODO: 初始化为适当的值
            BigInteger actual;
            actual = target.ModInverse( modulus );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Min 的测试
        ///</summary>
        [TestMethod()]
        public void MinTest()
        {
            BigInteger target = new BigInteger(); // TODO: 初始化为适当的值
            BigInteger bi = null; // TODO: 初始化为适当的值
            BigInteger expected = null; // TODO: 初始化为适当的值
            BigInteger actual;
            actual = target.Min( bi );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Max 的测试
        ///</summary>
        [TestMethod()]
        public void MaxTest()
        {
            BigInteger target = new BigInteger(); // TODO: 初始化为适当的值
            BigInteger bi = null; // TODO: 初始化为适当的值
            BigInteger expected = null; // TODO: 初始化为适当的值
            BigInteger actual;
            actual = target.Max( bi );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///LucasStrongTestHelper 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void LucasStrongTestHelperTest()
        {
            BigInteger thisVal = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = BigInteger_Accessor.LucasStrongTestHelper( thisVal );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///LucasStrongTest 的测试
        ///</summary>
        [TestMethod()]
        public void LucasStrongTestTest()
        {
            BigInteger target = new BigInteger(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.LucasStrongTest();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///LucasSequenceHelper 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void LucasSequenceHelperTest()
        {
            BigInteger P = null; // TODO: 初始化为适当的值
            BigInteger Q = null; // TODO: 初始化为适当的值
            BigInteger k = null; // TODO: 初始化为适当的值
            BigInteger n = null; // TODO: 初始化为适当的值
            BigInteger constant = null; // TODO: 初始化为适当的值
            int s = 0; // TODO: 初始化为适当的值
            BigInteger[] expected = null; // TODO: 初始化为适当的值
            BigInteger[] actual;
            actual = BigInteger_Accessor.LucasSequenceHelper( P, Q, k, n, constant, s );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///LucasSequence 的测试
        ///</summary>
        [TestMethod()]
        public void LucasSequenceTest()
        {
            BigInteger P = null; // TODO: 初始化为适当的值
            BigInteger Q = null; // TODO: 初始化为适当的值
            BigInteger k = null; // TODO: 初始化为适当的值
            BigInteger n = null; // TODO: 初始化为适当的值
            BigInteger[] expected = null; // TODO: 初始化为适当的值
            BigInteger[] actual;
            actual = BigInteger.LucasSequence( P, Q, k, n );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///LongValue 的测试
        ///</summary>
        [TestMethod()]
        public void LongValueTest()
        {
            BigInteger target = new BigInteger(); // TODO: 初始化为适当的值
            long expected = 0; // TODO: 初始化为适当的值
            long actual;
            actual = target.LongValue();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///LeastSignificantByte 的测试
        ///</summary>
        [TestMethod()]
        public void LeastSignificantByteTest()
        {
            BigInteger target = new BigInteger(); // TODO: 初始化为适当的值
            byte expected = 0; // TODO: 初始化为适当的值
            byte actual;
            actual = target.LeastSignificantByte();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Jacobi 的测试
        ///</summary>
        [TestMethod()]
        public void JacobiTest()
        {
            BigInteger a = null; // TODO: 初始化为适当的值
            BigInteger b = null; // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = BigInteger.Jacobi( a, b );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IsProbablePrime 的测试
        ///</summary>
        [TestMethod()]
        public void IsProbablePrimeTest1()
        {
            BigInteger target = new BigInteger(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.IsProbablePrime();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IsProbablePrime 的测试
        ///</summary>
        [TestMethod()]
        public void IsProbablePrimeTest()
        {
            BigInteger target = new BigInteger(); // TODO: 初始化为适当的值
            int confidence = 0; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.IsProbablePrime( confidence );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IntValue 的测试
        ///</summary>
        [TestMethod()]
        public void IntValueTest()
        {
            BigInteger target = new BigInteger(); // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = target.IntValue();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GetHashCode 的测试
        ///</summary>
        [TestMethod()]
        public void GetHashCodeTest()
        {
            BigInteger target = new BigInteger(); // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = target.GetHashCode();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GetBytesBE 的测试
        ///</summary>
        [TestMethod()]
        public void GetBytesBETest1()
        {
            BigInteger target = new BigInteger(); // TODO: 初始化为适当的值
            byte[] expected = null; // TODO: 初始化为适当的值
            byte[] actual;
            actual = target.GetBytesBE();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GetBytesBE 的测试
        ///</summary>
        [TestMethod()]
        public void GetBytesBETest()
        {
            BigInteger target = new BigInteger(); // TODO: 初始化为适当的值
            int numBytes = 0; // TODO: 初始化为适当的值
            byte[] expected = null; // TODO: 初始化为适当的值
            byte[] actual;
            actual = target.GetBytesBE( numBytes );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GetBytes 的测试
        ///</summary>
        [TestMethod()]
        public void GetBytesTest1()
        {
            BigInteger target = new BigInteger(); // TODO: 初始化为适当的值
            byte[] expected = null; // TODO: 初始化为适当的值
            byte[] actual;
            actual = target.GetBytes();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GetBytes 的测试
        ///</summary>
        [TestMethod()]
        public void GetBytesTest()
        {
            BigInteger target = new BigInteger(); // TODO: 初始化为适当的值
            int numBytes = 0; // TODO: 初始化为适当的值
            byte[] expected = null; // TODO: 初始化为适当的值
            byte[] actual;
            actual = target.GetBytes( numBytes );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GenRandomBits 的测试
        ///</summary>
        [TestMethod()]
        public void GenRandomBitsTest()
        {
            BigInteger target = new BigInteger(); // TODO: 初始化为适当的值
            int bits = 0; // TODO: 初始化为适当的值
            Random rand = null; // TODO: 初始化为适当的值
            target.GenRandomBits( bits, rand );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///GenPseudoPrime 的测试
        ///</summary>
        [TestMethod()]
        public void GenPseudoPrimeTest()
        {
            int bits = 0; // TODO: 初始化为适当的值
            int confidence = 0; // TODO: 初始化为适当的值
            Random rand = null; // TODO: 初始化为适当的值
            BigInteger expected = null; // TODO: 初始化为适当的值
            BigInteger actual;
            actual = BigInteger.GenPseudoPrime( bits, confidence, rand );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GenCoPrime 的测试
        ///</summary>
        [TestMethod()]
        public void GenCoPrimeTest()
        {
            BigInteger target = new BigInteger(); // TODO: 初始化为适当的值
            int bits = 0; // TODO: 初始化为适当的值
            Random rand = null; // TODO: 初始化为适当的值
            BigInteger expected = null; // TODO: 初始化为适当的值
            BigInteger actual;
            actual = target.GenCoPrime( bits, rand );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GCD 的测试
        ///</summary>
        [TestMethod()]
        public void GCDTest()
        {
            BigInteger target = new BigInteger(); // TODO: 初始化为适当的值
            BigInteger bi = null; // TODO: 初始化为适当的值
            BigInteger expected = null; // TODO: 初始化为适当的值
            BigInteger actual;
            actual = target.GCD( bi );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///FermatLittleTest 的测试
        ///</summary>
        [TestMethod()]
        public void FermatLittleTestTest()
        {
            BigInteger target = new BigInteger(); // TODO: 初始化为适当的值
            int confidence = 0; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.FermatLittleTest( confidence );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Equals 的测试
        ///</summary>
        [TestMethod()]
        public void EqualsTest()
        {
            BigInteger target = new BigInteger(); // TODO: 初始化为适当的值
            object o = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.Equals( o );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ByteValue 的测试
        ///</summary>
        [TestMethod()]
        public void ByteValueTest()
        {
            BigInteger target = new BigInteger(); // TODO: 初始化为适当的值
            byte expected = 0; // TODO: 初始化为适当的值
            byte actual;
            actual = target.ByteValue();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///BitCount 的测试
        ///</summary>
        [TestMethod()]
        public void BitCountTest()
        {
            BigInteger target = new BigInteger(); // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = target.BitCount();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///BarrettReduction 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void BarrettReductionTest()
        {
            BigInteger x = null; // TODO: 初始化为适当的值
            BigInteger n = null; // TODO: 初始化为适当的值
            BigInteger constant = null; // TODO: 初始化为适当的值
            BigInteger expected = null; // TODO: 初始化为适当的值
            BigInteger actual;
            actual = BigInteger_Accessor.BarrettReduction( x, n, constant );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Abs 的测试
        ///</summary>
        [TestMethod()]
        public void AbsTest()
        {
            BigInteger target = new BigInteger(); // TODO: 初始化为适当的值
            BigInteger expected = null; // TODO: 初始化为适当的值
            BigInteger actual;
            actual = target.Abs();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///BigInteger 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void BigIntegerConstructorTest7()
        {
            BigInteger bi = null; // TODO: 初始化为适当的值
            BigInteger target = new BigInteger( bi );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        /// <summary>
        ///BigInteger 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void BigIntegerConstructorTest6()
        {
            BigInteger target = new BigInteger();
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        /// <summary>
        ///BigInteger 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void BigIntegerConstructorTest5()
        {
            long value = 0; // TODO: 初始化为适当的值
            BigInteger target = new BigInteger( value );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        /// <summary>
        ///BigInteger 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void BigIntegerConstructorTest4()
        {
            ulong value = 0; // TODO: 初始化为适当的值
            BigInteger target = new BigInteger( value );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        /// <summary>
        ///BigInteger 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void BigIntegerConstructorTest3()
        {
            byte[] inData = null; // TODO: 初始化为适当的值
            int inLen = 0; // TODO: 初始化为适当的值
            BigInteger target = new BigInteger( inData, inLen );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        /// <summary>
        ///BigInteger 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void BigIntegerConstructorTest2()
        {
            uint[] inData = null; // TODO: 初始化为适当的值
            BigInteger target = new BigInteger( inData );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        /// <summary>
        ///BigInteger 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void BigIntegerConstructorTest1()
        {
            string value = string.Empty; // TODO: 初始化为适当的值
            int radix = 0; // TODO: 初始化为适当的值
            BigInteger target = new BigInteger( value, radix );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        /// <summary>
        ///BigInteger 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void BigIntegerConstructorTest()
        {
            byte[] inData = null; // TODO: 初始化为适当的值
            BigInteger target = new BigInteger( inData );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
