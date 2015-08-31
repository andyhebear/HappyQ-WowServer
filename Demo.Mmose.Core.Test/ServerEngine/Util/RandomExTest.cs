using Demo.Mmose.Core.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 RandomExTest 的测试类，旨在
    ///包含所有 RandomExTest 单元测试
    ///</summary>
    [TestClass()]
    public class RandomExTest
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
        ///RandomMinMax 的测试
        ///</summary>
        [TestMethod()]
        public void RandomMinMaxTest()
        {
            int iMinValue = 0; // TODO: 初始化为适当的值
            int iMaxValue = 0; // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = RandomEx.RandomMinMax( iMinValue, iMaxValue );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///RandomList 的测试
        ///</summary>
        public void RandomListTestHelper<T>()
        {
            List<T> listT = null; // TODO: 初始化为适当的值
            T expected = default( T ); // TODO: 初始化为适当的值
            T actual;
            actual = RandomEx.RandomList<T>( listT );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void RandomListTest()
        {
            RandomListTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///RandomInBytes 的测试
        ///</summary>
        [TestMethod()]
        public void RandomInBytesTest()
        {
            byte[] bufferRandom = null; // TODO: 初始化为适当的值
            byte[] bufferRandomExpected = null; // TODO: 初始化为适当的值
            RandomEx.RandomInBytes( ref bufferRandom );
            Assert.AreEqual( bufferRandomExpected, bufferRandom );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///RandomDouble 的测试
        ///</summary>
        [TestMethod()]
        public void RandomDoubleTest()
        {
            double expected = 0F; // TODO: 初始化为适当的值
            double actual;
            actual = RandomEx.RandomDouble();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///RandomBool 的测试
        ///</summary>
        [TestMethod()]
        public void RandomBoolTest()
        {
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = RandomEx.RandomBool();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///RandomArray 的测试
        ///</summary>
        public void RandomArrayTestHelper<T>()
        {
            T[] arrayT = null; // TODO: 初始化为适当的值
            T expected = default( T ); // TODO: 初始化为适当的值
            T actual;
            actual = RandomEx.RandomArray<T>( arrayT );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void RandomArrayTest()
        {
            RandomArrayTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///Random 的测试
        ///</summary>
        [TestMethod()]
        public void RandomTest1()
        {
            int iBaseValue = 0; // TODO: 初始化为适当的值
            int iAppendMaxValue = 0; // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = RandomEx.Random( iBaseValue, iAppendMaxValue );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Random 的测试
        ///</summary>
        [TestMethod()]
        public void RandomTest()
        {
            int iMaxValue = 0; // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = RandomEx.Random( iMaxValue );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }
    }
}
