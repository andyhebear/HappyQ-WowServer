using Demo.Mmose.Core.Network;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 PacketProfileTest 的测试类，旨在
    ///包含所有 PacketProfileTest 单元测试
    ///</summary>
    [TestClass()]
    public class PacketProfileTest
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
        ///TotalProcTime 的测试
        ///</summary>
        [TestMethod()]
        public void TotalProcTimeTest()
        {
            PrivateObject param0 = null; // TODO: 初始化为适当的值
            PacketProfile_Accessor target = new PacketProfile_Accessor( param0 ); // TODO: 初始化为适当的值
            TimeSpan actual;
            actual = target.TotalProcTime;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///TotalByteLength 的测试
        ///</summary>
        [TestMethod()]
        public void TotalByteLengthTest()
        {
            PrivateObject param0 = null; // TODO: 初始化为适当的值
            PacketProfile_Accessor target = new PacketProfile_Accessor( param0 ); // TODO: 初始化为适当的值
            long actual;
            actual = target.TotalByteLength;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///PeakProcTime 的测试
        ///</summary>
        [TestMethod()]
        public void PeakProcTimeTest()
        {
            PrivateObject param0 = null; // TODO: 初始化为适当的值
            PacketProfile_Accessor target = new PacketProfile_Accessor( param0 ); // TODO: 初始化为适当的值
            TimeSpan actual;
            actual = target.PeakProcTime;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Outgoing 的测试
        ///</summary>
        [TestMethod()]
        public void OutgoingTest()
        {
            PrivateObject param0 = null; // TODO: 初始化为适当的值
            PacketProfile_Accessor target = new PacketProfile_Accessor( param0 ); // TODO: 初始化为适当的值
            bool actual;
            actual = target.Outgoing;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Count 的测试
        ///</summary>
        [TestMethod()]
        public void CountTest()
        {
            PrivateObject param0 = null; // TODO: 初始化为适当的值
            PacketProfile_Accessor target = new PacketProfile_Accessor( param0 ); // TODO: 初始化为适当的值
            long actual;
            actual = target.Count;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Constructed 的测试
        ///</summary>
        [TestMethod()]
        public void ConstructedTest()
        {
            PrivateObject param0 = null; // TODO: 初始化为适当的值
            PacketProfile_Accessor target = new PacketProfile_Accessor( param0 ); // TODO: 初始化为适当的值
            long actual;
            actual = target.Constructed;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///AverageProcTime 的测试
        ///</summary>
        [TestMethod()]
        public void AverageProcTimeTest()
        {
            PrivateObject param0 = null; // TODO: 初始化为适当的值
            PacketProfile_Accessor target = new PacketProfile_Accessor( param0 ); // TODO: 初始化为适当的值
            TimeSpan actual;
            actual = target.AverageProcTime;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///AverageByteLength 的测试
        ///</summary>
        [TestMethod()]
        public void AverageByteLengthTest()
        {
            PrivateObject param0 = null; // TODO: 初始化为适当的值
            PacketProfile_Accessor target = new PacketProfile_Accessor( param0 ); // TODO: 初始化为适当的值
            double actual;
            actual = target.AverageByteLength;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///RegConstruct 的测试
        ///</summary>
        [TestMethod()]
        public void RegConstructTest()
        {
            PrivateObject param0 = null; // TODO: 初始化为适当的值
            PacketProfile_Accessor target = new PacketProfile_Accessor( param0 ); // TODO: 初始化为适当的值
            target.RegConstruct();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Record 的测试
        ///</summary>
        [TestMethod()]
        public void RecordTest()
        {
            PrivateObject param0 = null; // TODO: 初始化为适当的值
            PacketProfile_Accessor target = new PacketProfile_Accessor( param0 ); // TODO: 初始化为适当的值
            long iByteLength = 0; // TODO: 初始化为适当的值
            TimeSpan processTime = new TimeSpan(); // TODO: 初始化为适当的值
            target.Record( iByteLength, processTime );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///GetOutgoingProfile 的测试
        ///</summary>
        [TestMethod()]
        public void GetOutgoingProfileTest()
        {
            long iPacketID = 0; // TODO: 初始化为适当的值
            PacketProfile expected = null; // TODO: 初始化为适当的值
            PacketProfile actual;
            actual = PacketProfile.GetOutgoingProfile( iPacketID );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GetIncomingProfile 的测试
        ///</summary>
        [TestMethod()]
        public void GetIncomingProfileTest()
        {
            long iPacketID = 0; // TODO: 初始化为适当的值
            PacketProfile expected = null; // TODO: 初始化为适当的值
            PacketProfile actual;
            actual = PacketProfile.GetIncomingProfile( iPacketID );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///PacketProfile 构造函数 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void PacketProfileConstructorTest()
        {
            bool bOutgoing = false; // TODO: 初始化为适当的值
            PacketProfile_Accessor target = new PacketProfile_Accessor( bOutgoing );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
