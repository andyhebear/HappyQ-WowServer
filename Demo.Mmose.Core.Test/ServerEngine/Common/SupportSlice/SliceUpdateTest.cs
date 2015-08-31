using Demo.Mmose.Core.Common.SupportSlice;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 SliceUpdateTest 的测试类，旨在
    ///包含所有 SliceUpdateTest 单元测试
    ///</summary>
    [TestClass()]
    public class SliceUpdateTest
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
        ///MultiThreadedCall 的测试
        ///</summary>
        public void MultiThreadedCallTestHelper<T>()
            where T : ISupportSlice
        {
            bool bMultiThreadedCall = false; // TODO: 初始化为适当的值
            SliceUpdate<T> target = new SliceUpdate<T>( bMultiThreadedCall ); // TODO: 初始化为适当的值
            bool actual;
            actual = target.MultiThreadedCall;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void MultiThreadedCallTest()
        {
            Assert.Inconclusive( "没有找到能够满足 T 的类型约束的相应类型参数。请以适当的类型参数来调用 MultiThreadedCallTestHelper<T>()。" );
        }

        /// <summary>
        ///UpdateSlice 的测试
        ///</summary>
        public void UpdateSliceTestHelper<T>()
            where T : ISupportSlice
        {
            bool bMultiThreadedCall = false; // TODO: 初始化为适当的值
            SliceUpdate<T> target = new SliceUpdate<T>( bMultiThreadedCall ); // TODO: 初始化为适当的值
            T dataT = default( T ); // TODO: 初始化为适当的值
            target.UpdateSlice( dataT );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        [TestMethod()]
        public void UpdateSliceTest()
        {
            Assert.Inconclusive( "没有找到能够满足 T 的类型约束的相应类型参数。请以适当的类型参数来调用 UpdateSliceTestHelper<T>()。" );
        }

        /// <summary>
        ///Slice 的测试
        ///</summary>
        public void SliceTestHelper<T>()
            where T : ISupportSlice
        {
            bool bMultiThreadedCall = false; // TODO: 初始化为适当的值
            SliceUpdate<T> target = new SliceUpdate<T>( bMultiThreadedCall ); // TODO: 初始化为适当的值
            target.Slice();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        [TestMethod()]
        public void SliceTest()
        {
            Assert.Inconclusive( "没有找到能够满足 T 的类型约束的相应类型参数。请以适当的类型参数来调用 SliceTestHelper<T>()。" );
        }

        /// <summary>
        ///SliceUpdate`1 构造函数 的测试
        ///</summary>
        public void SliceUpdateConstructorTestHelper<T>()
            where T : ISupportSlice
        {
            bool bMultiThreadedCall = false; // TODO: 初始化为适当的值
            SliceUpdate<T> target = new SliceUpdate<T>( bMultiThreadedCall );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        [TestMethod()]
        public void SliceUpdateConstructorTest()
        {
            Assert.Inconclusive( "没有找到能够满足 T 的类型约束的相应类型参数。请以适当的类型参数来调用 SliceUpdateConstructorTestHelper<T>()。" );
        }
    }
}
