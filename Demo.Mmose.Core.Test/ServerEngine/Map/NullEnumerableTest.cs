using Demo.Mmose.Core.Map;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Collections;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 NullEnumerableTest 的测试类，旨在
    ///包含所有 NullEnumerableTest 单元测试
    ///</summary>
    [TestClass()]
    public class NullEnumerableTest
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
        public void SingletonInstanceTestHelper<T>()
        {
            NullEnumerable<T> actual;
            actual = NullEnumerable<T>.SingletonInstance;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void SingletonInstanceTest()
        {
            SingletonInstanceTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///System.Collections.IEnumerable.GetEnumerator 的测试
        ///</summary>
        public void GetEnumeratorTest1Helper<T>()
        {
            IEnumerable target = new NullEnumerable<T>(); // TODO: 初始化为适当的值
            IEnumerator expected = null; // TODO: 初始化为适当的值
            IEnumerator actual;
            actual = target.GetEnumerator();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void GetEnumeratorTest1()
        {
            GetEnumeratorTest1Helper<GenericParameterHelper>();
        }

        /// <summary>
        ///GetEnumerator 的测试
        ///</summary>
        public void GetEnumeratorTestHelper<T>()
        {
            NullEnumerable<T> target = new NullEnumerable<T>(); // TODO: 初始化为适当的值
            IEnumerator<T> expected = null; // TODO: 初始化为适当的值
            IEnumerator<T> actual;
            actual = target.GetEnumerator();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void GetEnumeratorTest()
        {
            GetEnumeratorTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///NullEnumerable`1 构造函数 的测试
        ///</summary>
        public void NullEnumerableConstructorTest1Helper<T>()
        {
            NullEnumerable<T> target = new NullEnumerable<T>();
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        [TestMethod()]
        public void NullEnumerableConstructorTest1()
        {
            NullEnumerableConstructorTest1Helper<GenericParameterHelper>();
        }

        /// <summary>
        ///NullEnumerable 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void NullEnumerableConstructorTest()
        {
            NullEnumerable target = new NullEnumerable();
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
