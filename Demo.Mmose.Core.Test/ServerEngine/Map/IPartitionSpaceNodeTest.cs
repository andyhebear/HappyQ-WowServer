using Demo.Mmose.Core.Map;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 IPartitionSpaceNodeTest 的测试类，旨在
    ///包含所有 IPartitionSpaceNodeTest 单元测试
    ///</summary>
    [TestClass()]
    public class IPartitionSpaceNodeTest
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
        ///ProcessPartitionSpaceNode 的测试
        ///</summary>
        [TestMethod()]
        public void ProcessPartitionSpaceNodeTest()
        {
            IPartitionSpaceNode target = CreateIPartitionSpaceNode(); // TODO: 初始化为适当的值
            object sender = null; // TODO: 初始化为适当的值
            PartitionSpaceNodeEventArgs eventArgs = null; // TODO: 初始化为适当的值
            target.ProcessPartitionSpaceNode( sender, eventArgs );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///InitSpaceNode 的测试
        ///</summary>
        [TestMethod()]
        public void InitSpaceNodeTest()
        {
            IPartitionSpaceNode target = CreateIPartitionSpaceNode(); // TODO: 初始化为适当的值
            object sender = null; // TODO: 初始化为适当的值
            SpaceNodeEventArgs eventArgs = null; // TODO: 初始化为适当的值
            target.InitSpaceNode( sender, eventArgs );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///DeactivateSpaceNode 的测试
        ///</summary>
        [TestMethod()]
        public void DeactivateSpaceNodeTest()
        {
            IPartitionSpaceNode target = CreateIPartitionSpaceNode(); // TODO: 初始化为适当的值
            object sender = null; // TODO: 初始化为适当的值
            DeactivateSpaceNodeEventArgs eventArgs = null; // TODO: 初始化为适当的值
            target.DeactivateSpaceNode( sender, eventArgs );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        internal virtual IPartitionSpaceNode CreateIPartitionSpaceNode()
        {
            // TODO: 实例化相应的具体类。
            IPartitionSpaceNode target = null;
            return target;
        }

        /// <summary>
        ///ActivateSpaceNode 的测试
        ///</summary>
        [TestMethod()]
        public void ActivateSpaceNodeTest()
        {
            IPartitionSpaceNode target = CreateIPartitionSpaceNode(); // TODO: 初始化为适当的值
            object sender = null; // TODO: 初始化为适当的值
            ActivateSpaceNodeEventArgs eventArgs = null; // TODO: 初始化为适当的值
            target.ActivateSpaceNode( sender, eventArgs );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }
    }
}
