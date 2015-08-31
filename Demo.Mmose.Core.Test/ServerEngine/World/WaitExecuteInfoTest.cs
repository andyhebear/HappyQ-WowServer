using Demo.Mmose.Core.World;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 WaitExecuteInfoTest 的测试类，旨在
    ///包含所有 WaitExecuteInfoTest 单元测试
    ///</summary>
    [TestClass()]
    public class WaitExecuteInfoTest
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
        ///WaitCallBack 的测试
        ///</summary>
        public void WaitCallBackTestHelper<T>()
        {
            T executeInfo = default( T ); // TODO: 初始化为适当的值
            WaitCallBack<T> waitCallBack = null; // TODO: 初始化为适当的值
            WaitExecuteInfo<T> target = new WaitExecuteInfo<T>( executeInfo, waitCallBack ); // TODO: 初始化为适当的值
            WaitCallBack<T> actual;
            actual = target.WaitCallBack;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void WaitCallBackTest()
        {
            WaitCallBackTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///Data 的测试
        ///</summary>
        public void DataTestHelper<T>()
        {
            T executeInfo = default( T ); // TODO: 初始化为适当的值
            WaitCallBack<T> waitCallBack = null; // TODO: 初始化为适当的值
            WaitExecuteInfo<T> target = new WaitExecuteInfo<T>( executeInfo, waitCallBack ); // TODO: 初始化为适当的值
            T actual;
            actual = target.Data;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void DataTest()
        {
            DataTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///Execute 的测试
        ///</summary>
        public void ExecuteTestHelper<T>()
        {
            T executeInfo = default( T ); // TODO: 初始化为适当的值
            WaitCallBack<T> waitCallBack = null; // TODO: 初始化为适当的值
            WaitExecuteInfo<T> target = new WaitExecuteInfo<T>( executeInfo, waitCallBack ); // TODO: 初始化为适当的值
            target.Execute();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        [TestMethod()]
        public void ExecuteTest()
        {
            ExecuteTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///WaitExecuteInfo`1 构造函数 的测试
        ///</summary>
        public void WaitExecuteInfoConstructorTestHelper<T>()
        {
            T executeInfo = default( T ); // TODO: 初始化为适当的值
            WaitCallBack<T> waitCallBack = null; // TODO: 初始化为适当的值
            WaitExecuteInfo<T> target = new WaitExecuteInfo<T>( executeInfo, waitCallBack );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        [TestMethod()]
        public void WaitExecuteInfoConstructorTest()
        {
            WaitExecuteInfoConstructorTestHelper<GenericParameterHelper>();
        }
    }
}
