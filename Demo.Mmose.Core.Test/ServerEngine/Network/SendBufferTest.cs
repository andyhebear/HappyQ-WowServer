using Demo.Mmose.Core.Network;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 SendBufferTest 的测试类，旨在
    ///包含所有 SendBufferTest 单元测试
    ///</summary>
    [TestClass()]
    public class SendBufferTest
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
        ///SpareSpace 的测试
        ///</summary>
        [TestMethod()]
        public void SpareSpaceTest()
        {
            SendBuffer target = new SendBuffer(); // TODO: 初始化为适当的值
            long actual;
            actual = target.SpareSpace;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Length 的测试
        ///</summary>
        [TestMethod()]
        public void LengthTest()
        {
            SendBuffer target = new SendBuffer(); // TODO: 初始化为适当的值
            long actual;
            actual = target.Length;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IsNull 的测试
        ///</summary>
        [TestMethod()]
        public void IsNullTest()
        {
            SendBuffer target = new SendBuffer(); // TODO: 初始化为适当的值
            bool actual;
            actual = target.IsNull;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IsFull 的测试
        ///</summary>
        [TestMethod()]
        public void IsFullTest()
        {
            SendBuffer target = new SendBuffer(); // TODO: 初始化为适当的值
            bool actual;
            actual = target.IsFull;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Buffer 的测试
        ///</summary>
        [TestMethod()]
        public void BufferTest()
        {
            SendBuffer target = new SendBuffer(); // TODO: 初始化为适当的值
            byte[] actual;
            actual = target.Buffer;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Write 的测试
        ///</summary>
        [TestMethod()]
        public void WriteTest()
        {
            SendBuffer target = new SendBuffer(); // TODO: 初始化为适当的值
            byte[] byteBuffer = null; // TODO: 初始化为适当的值
            long lOffset = 0; // TODO: 初始化为适当的值
            long lLength = 0; // TODO: 初始化为适当的值
            long expected = 0; // TODO: 初始化为适当的值
            long actual;
            actual = target.Write( byteBuffer, lOffset, lLength );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Release 的测试
        ///</summary>
        [TestMethod()]
        public void ReleaseTest()
        {
            SendBuffer target = new SendBuffer(); // TODO: 初始化为适当的值
            target.Release();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Instance 的测试
        ///</summary>
        [TestMethod()]
        public void InstanceTest()
        {
            SendBuffer expected = new SendBuffer(); // TODO: 初始化为适当的值
            SendBuffer actual;
            actual = SendBuffer.Instance();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///SendBuffer 构造函数 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void SendBufferConstructorTest()
        {
            byte[] buffer = null; // TODO: 初始化为适当的值
            SendBuffer_Accessor target = new SendBuffer_Accessor( buffer );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
