using Demo.Mmose.Core.World.ZoneClusterWorld;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Demo.Mmose.Core.World;
using Demo.Mmose.Core.Network;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 ZoneCluster_ZoneIDTest 的测试类，旨在
    ///包含所有 ZoneCluster_ZoneIDTest 单元测试
    ///</summary>
    [TestClass()]
    public class ZoneCluster_ZoneIDTest
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
        ///ToArray 的测试
        ///</summary>
        public void ToArrayTestHelper<WorldT>()
            where WorldT : BaseWorld, new()
        {
            ZoneCluster_Accessor<WorldT>.ZoneID target = new ZoneCluster_Accessor<WorldT>.ZoneID(); // TODO: 初始化为适当的值
            NetState[] expected = null; // TODO: 初始化为适当的值
            NetState[] actual;
            actual = target.ToArray();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void ToArrayTest()
        {
            Assert.Inconclusive( "没有找到能够满足 WorldT 的类型约束的相应类型参数。请以适当的类型参数来调用 ToArrayTestHelper<WorldT>()。" );
        }

        /// <summary>
        ///ZoneID 构造函数 的测试
        ///</summary>
        public void ZoneCluster_ZoneIDConstructorTestHelper<WorldT>()
            where WorldT : BaseWorld, new()
        {
            ZoneCluster<WorldT>.ZoneID target = new ZoneCluster<WorldT>.ZoneID();
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        [TestMethod()]
        public void ZoneCluster_ZoneIDConstructorTest()
        {
            Assert.Inconclusive( "没有找到能够满足 WorldT 的类型约束的相应类型参数。请以适当的类型参数来调用 ZoneCluster_ZoneIDConstructorTestHelper" +
                    "<WorldT>()。" );
        }
    }
}
