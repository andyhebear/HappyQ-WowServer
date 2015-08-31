using Demo.Mmose.Core.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 ResultTest 的测试类，旨在
    ///包含所有 ResultTest 单元测试
    ///</summary>
    [TestClass()]
    public class ResultTest
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
        ///Success 的测试
        ///</summary>
        public void SuccessTestHelper<T>()
        {
            Result<T> target = new Result<T>(); // TODO: 初始化为适当的值
            bool actual;
            actual = target.Success;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void SuccessTest()
        {
            SuccessTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///Return 的测试
        ///</summary>
        public void ReturnTestHelper<T>()
        {
            Result<T> target = new Result<T>(); // TODO: 初始化为适当的值
            T actual;
            actual = target.Return;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void ReturnTest()
        {
            ReturnTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///ErrorInfo 的测试
        ///</summary>
        public void ErrorInfoTestHelper<T>()
        {
            Result<T> target = new Result<T>(); // TODO: 初始化为适当的值
            string actual;
            actual = target.ErrorInfo;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void ErrorInfoTest()
        {
            ErrorInfoTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///Instance 的测试
        ///</summary>
        public void InstanceTest2Helper<T>()
        {
            T resultT = default( T ); // TODO: 初始化为适当的值
            Result<T> expected = new Result<T>(); // TODO: 初始化为适当的值
            Result<T> actual;
            actual = Result<T>.Instance( resultT );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void InstanceTest2()
        {
            InstanceTest2Helper<GenericParameterHelper>();
        }

        /// <summary>
        ///Instance 的测试
        ///</summary>
        public void InstanceTest1Helper<T>()
        {
            string strErrorInfo = string.Empty; // TODO: 初始化为适当的值
            Result<T> expected = new Result<T>(); // TODO: 初始化为适当的值
            Result<T> actual;
            actual = Result<T>.Instance( strErrorInfo );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void InstanceTest1()
        {
            InstanceTest1Helper<GenericParameterHelper>();
        }

        /// <summary>
        ///Instance 的测试
        ///</summary>
        public void InstanceTestHelper<T>()
        {
            string strAboveErrorInfo = string.Empty; // TODO: 初始化为适当的值
            string strErrorInfo = string.Empty; // TODO: 初始化为适当的值
            Result<T> expected = new Result<T>(); // TODO: 初始化为适当的值
            Result<T> actual;
            actual = Result<T>.Instance( strAboveErrorInfo, strErrorInfo );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void InstanceTest()
        {
            InstanceTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///Result`1 构造函数 的测试
        ///</summary>
        public void ResultConstructorTest1Helper<T>()
        {
            T resultT = default( T ); // TODO: 初始化为适当的值
            Result_Accessor<T> target = new Result_Accessor<T>( resultT );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void ResultConstructorTest1()
        {
            ResultConstructorTest1Helper<GenericParameterHelper>();
        }

        /// <summary>
        ///Result`1 构造函数 的测试
        ///</summary>
        public void ResultConstructorTestHelper<T>()
        {
            string strErrorInfo = string.Empty; // TODO: 初始化为适当的值
            Result_Accessor<T> target = new Result_Accessor<T>( strErrorInfo );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void ResultConstructorTest()
        {
            ResultConstructorTestHelper<GenericParameterHelper>();
        }
    }
}
