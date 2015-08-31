using Demo.Mmose.Core.Map;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Entity.Item;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 ItemMovingInMapEventArgsTest 的测试类，旨在
    ///包含所有 ItemMovingInMapEventArgsTest 单元测试
    ///</summary>
    [TestClass()]
    public class ItemMovingInMapEventArgsTest
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
        ///OldLocation 的测试
        ///</summary>
        [TestMethod()]
        public void OldLocationTest()
        {
            Point3D oldLocation = new Point3D(); // TODO: 初始化为适当的值
            BaseItem item = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            ItemMovingInMapEventArgs target = new ItemMovingInMapEventArgs( oldLocation, item, map ); // TODO: 初始化为适当的值
            Point3D actual;
            actual = target.OldLocation;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Item 的测试
        ///</summary>
        [TestMethod()]
        public void ItemTest()
        {
            Point3D oldLocation = new Point3D(); // TODO: 初始化为适当的值
            BaseItem item = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            ItemMovingInMapEventArgs target = new ItemMovingInMapEventArgs( oldLocation, item, map ); // TODO: 初始化为适当的值
            BaseItem actual;
            actual = target.Item;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IsCancel 的测试
        ///</summary>
        [TestMethod()]
        public void IsCancelTest()
        {
            Point3D oldLocation = new Point3D(); // TODO: 初始化为适当的值
            BaseItem item = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            ItemMovingInMapEventArgs target = new ItemMovingInMapEventArgs( oldLocation, item, map ); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            target.IsCancel = expected;
            actual = target.IsCancel;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ItemMovingInMapEventArgs 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void ItemMovingInMapEventArgsConstructorTest()
        {
            Point3D oldLocation = new Point3D(); // TODO: 初始化为适当的值
            BaseItem item = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            ItemMovingInMapEventArgs target = new ItemMovingInMapEventArgs( oldLocation, item, map );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
