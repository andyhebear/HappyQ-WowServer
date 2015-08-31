using Demo.Mmose.Core.Network;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 IExtendDataTest 的测试类，旨在
    ///包含所有 IExtendDataTest 单元测试
    ///</summary>
    [TestClass()]
    public class IExtendDataTest
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
        ///Data 的测试
        ///</summary>
        public void DataTestHelper<T>()
        {
            IExtendData<T> target = CreateIExtendData<T>(); // TODO: 初始化为适当的值
            T expected = default( T ); // TODO: 初始化为适当的值
            T actual;
            target.Data = expected;
            actual = target.Data;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        internal virtual IExtendData<T> CreateIExtendData<T>()
        {
            // TODO: 实例化相应的具体类。
            IExtendData<T> target = null;
            return target;
        }

        [TestMethod()]
        public void DataTest()
        {
            DataTestHelper<GenericParameterHelper>();
        }
    }
}
