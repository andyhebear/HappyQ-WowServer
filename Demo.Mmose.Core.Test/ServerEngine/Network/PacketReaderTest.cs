using Demo.Mmose.Core.Network;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 PacketReaderTest 的测试类，旨在
    ///包含所有 PacketReaderTest 单元测试
    ///</summary>
    [TestClass()]
    public class PacketReaderTest
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
        ///Size 的测试
        ///</summary>
        [TestMethod()]
        public void SizeTest()
        {
            byte[] byteData = null; // TODO: 初始化为适当的值
            long iSize = 0; // TODO: 初始化为适当的值
            long iOffset = 0; // TODO: 初始化为适当的值
            PacketReader target = new PacketReader( byteData, iSize, iOffset ); // TODO: 初始化为适当的值
            long actual;
            actual = target.Size;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Position 的测试
        ///</summary>
        [TestMethod()]
        public void PositionTest()
        {
            byte[] byteData = null; // TODO: 初始化为适当的值
            long iSize = 0; // TODO: 初始化为适当的值
            long iOffset = 0; // TODO: 初始化为适当的值
            PacketReader target = new PacketReader( byteData, iSize, iOffset ); // TODO: 初始化为适当的值
            long actual;
            actual = target.Position;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Buffer 的测试
        ///</summary>
        [TestMethod()]
        public void BufferTest()
        {
            byte[] byteData = null; // TODO: 初始化为适当的值
            long iSize = 0; // TODO: 初始化为适当的值
            long iOffset = 0; // TODO: 初始化为适当的值
            PacketReader target = new PacketReader( byteData, iSize, iOffset ); // TODO: 初始化为适当的值
            byte[] actual;
            actual = target.Buffer;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Trace 的测试
        ///</summary>
        [TestMethod()]
        public void TraceTest()
        {
            byte[] byteData = null; // TODO: 初始化为适当的值
            long iSize = 0; // TODO: 初始化为适当的值
            long iOffset = 0; // TODO: 初始化为适当的值
            PacketReader target = new PacketReader( byteData, iSize, iOffset ); // TODO: 初始化为适当的值
            NetState netState = null; // TODO: 初始化为适当的值
            target.Trace( netState );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Seek 的测试
        ///</summary>
        [TestMethod()]
        public void SeekTest()
        {
            byte[] byteData = null; // TODO: 初始化为适当的值
            long iSize = 0; // TODO: 初始化为适当的值
            long iOffset = 0; // TODO: 初始化为适当的值
            PacketReader target = new PacketReader( byteData, iSize, iOffset ); // TODO: 初始化为适当的值
            long iOffset1 = 0; // TODO: 初始化为适当的值
            SeekOrigin seekOrigin = new SeekOrigin(); // TODO: 初始化为适当的值
            long expected = 0; // TODO: 初始化为适当的值
            long actual;
            actual = target.Seek( iOffset1, seekOrigin );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ReadUTF8StringSafe 的测试
        ///</summary>
        [TestMethod()]
        public void ReadUTF8StringSafeTest1()
        {
            byte[] byteData = null; // TODO: 初始化为适当的值
            long iSize = 0; // TODO: 初始化为适当的值
            long iOffset = 0; // TODO: 初始化为适当的值
            PacketReader target = new PacketReader( byteData, iSize, iOffset ); // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = target.ReadUTF8StringSafe();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ReadUTF8StringSafe 的测试
        ///</summary>
        [TestMethod()]
        public void ReadUTF8StringSafeTest()
        {
            byte[] byteData = null; // TODO: 初始化为适当的值
            long iSize = 0; // TODO: 初始化为适当的值
            long iOffset = 0; // TODO: 初始化为适当的值
            PacketReader target = new PacketReader( byteData, iSize, iOffset ); // TODO: 初始化为适当的值
            long iFixedLength = 0; // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = target.ReadUTF8StringSafe( iFixedLength );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ReadUTF8String 的测试
        ///</summary>
        [TestMethod()]
        public void ReadUTF8StringTest1()
        {
            byte[] byteData = null; // TODO: 初始化为适当的值
            long iSize = 0; // TODO: 初始化为适当的值
            long iOffset = 0; // TODO: 初始化为适当的值
            PacketReader target = new PacketReader( byteData, iSize, iOffset ); // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = target.ReadUTF8String();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ReadUTF8String 的测试
        ///</summary>
        [TestMethod()]
        public void ReadUTF8StringTest()
        {
            byte[] byteData = null; // TODO: 初始化为适当的值
            long iSize = 0; // TODO: 初始化为适当的值
            long iOffset = 0; // TODO: 初始化为适当的值
            PacketReader target = new PacketReader( byteData, iSize, iOffset ); // TODO: 初始化为适当的值
            long iFixedLength = 0; // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = target.ReadUTF8String( iFixedLength );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ReadUnicodeStringSafe 的测试
        ///</summary>
        [TestMethod()]
        public void ReadUnicodeStringSafeTest1()
        {
            byte[] byteData = null; // TODO: 初始化为适当的值
            long iSize = 0; // TODO: 初始化为适当的值
            long iOffset = 0; // TODO: 初始化为适当的值
            PacketReader target = new PacketReader( byteData, iSize, iOffset ); // TODO: 初始化为适当的值
            long iFixedLength = 0; // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = target.ReadUnicodeStringSafe( iFixedLength );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ReadUnicodeStringSafe 的测试
        ///</summary>
        [TestMethod()]
        public void ReadUnicodeStringSafeTest()
        {
            byte[] byteData = null; // TODO: 初始化为适当的值
            long iSize = 0; // TODO: 初始化为适当的值
            long iOffset = 0; // TODO: 初始化为适当的值
            PacketReader target = new PacketReader( byteData, iSize, iOffset ); // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = target.ReadUnicodeStringSafe();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ReadUnicodeStringLESafe 的测试
        ///</summary>
        [TestMethod()]
        public void ReadUnicodeStringLESafeTest1()
        {
            byte[] byteData = null; // TODO: 初始化为适当的值
            long iSize = 0; // TODO: 初始化为适当的值
            long iOffset = 0; // TODO: 初始化为适当的值
            PacketReader target = new PacketReader( byteData, iSize, iOffset ); // TODO: 初始化为适当的值
            long iFixedLength = 0; // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = target.ReadUnicodeStringLESafe( iFixedLength );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ReadUnicodeStringLESafe 的测试
        ///</summary>
        [TestMethod()]
        public void ReadUnicodeStringLESafeTest()
        {
            byte[] byteData = null; // TODO: 初始化为适当的值
            long iSize = 0; // TODO: 初始化为适当的值
            long iOffset = 0; // TODO: 初始化为适当的值
            PacketReader target = new PacketReader( byteData, iSize, iOffset ); // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = target.ReadUnicodeStringLESafe();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ReadUnicodeStringLE 的测试
        ///</summary>
        [TestMethod()]
        public void ReadUnicodeStringLETest1()
        {
            byte[] byteData = null; // TODO: 初始化为适当的值
            long iSize = 0; // TODO: 初始化为适当的值
            long iOffset = 0; // TODO: 初始化为适当的值
            PacketReader target = new PacketReader( byteData, iSize, iOffset ); // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = target.ReadUnicodeStringLE();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ReadUnicodeStringLE 的测试
        ///</summary>
        [TestMethod()]
        public void ReadUnicodeStringLETest()
        {
            byte[] byteData = null; // TODO: 初始化为适当的值
            long iSize = 0; // TODO: 初始化为适当的值
            long iOffset = 0; // TODO: 初始化为适当的值
            PacketReader target = new PacketReader( byteData, iSize, iOffset ); // TODO: 初始化为适当的值
            long iFixedLength = 0; // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = target.ReadUnicodeStringLE( iFixedLength );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ReadUnicodeString 的测试
        ///</summary>
        [TestMethod()]
        public void ReadUnicodeStringTest1()
        {
            byte[] byteData = null; // TODO: 初始化为适当的值
            long iSize = 0; // TODO: 初始化为适当的值
            long iOffset = 0; // TODO: 初始化为适当的值
            PacketReader target = new PacketReader( byteData, iSize, iOffset ); // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = target.ReadUnicodeString();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ReadUnicodeString 的测试
        ///</summary>
        [TestMethod()]
        public void ReadUnicodeStringTest()
        {
            byte[] byteData = null; // TODO: 初始化为适当的值
            long iSize = 0; // TODO: 初始化为适当的值
            long iOffset = 0; // TODO: 初始化为适当的值
            PacketReader target = new PacketReader( byteData, iSize, iOffset ); // TODO: 初始化为适当的值
            long iFixedLength = 0; // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = target.ReadUnicodeString( iFixedLength );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ReadULong64 的测试
        ///</summary>
        [TestMethod()]
        public void ReadULong64Test()
        {
            byte[] byteData = null; // TODO: 初始化为适当的值
            long iSize = 0; // TODO: 初始化为适当的值
            long iOffset = 0; // TODO: 初始化为适当的值
            PacketReader target = new PacketReader( byteData, iSize, iOffset ); // TODO: 初始化为适当的值
            ulong expected = 0; // TODO: 初始化为适当的值
            ulong actual;
            actual = target.ReadULong64();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ReadUInt32 的测试
        ///</summary>
        [TestMethod()]
        public void ReadUInt32Test()
        {
            byte[] byteData = null; // TODO: 初始化为适当的值
            long iSize = 0; // TODO: 初始化为适当的值
            long iOffset = 0; // TODO: 初始化为适当的值
            PacketReader target = new PacketReader( byteData, iSize, iOffset ); // TODO: 初始化为适当的值
            uint expected = 0; // TODO: 初始化为适当的值
            uint actual;
            actual = target.ReadUInt32();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ReadUInt16 的测试
        ///</summary>
        [TestMethod()]
        public void ReadUInt16Test()
        {
            byte[] byteData = null; // TODO: 初始化为适当的值
            long iSize = 0; // TODO: 初始化为适当的值
            long iOffset = 0; // TODO: 初始化为适当的值
            PacketReader target = new PacketReader( byteData, iSize, iOffset ); // TODO: 初始化为适当的值
            ushort expected = 0; // TODO: 初始化为适当的值
            ushort actual;
            actual = target.ReadUInt16();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ReadStringSafe 的测试
        ///</summary>
        [TestMethod()]
        public void ReadStringSafeTest1()
        {
            byte[] byteData = null; // TODO: 初始化为适当的值
            long iSize = 0; // TODO: 初始化为适当的值
            long iOffset = 0; // TODO: 初始化为适当的值
            PacketReader target = new PacketReader( byteData, iSize, iOffset ); // TODO: 初始化为适当的值
            long fixedLength = 0; // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = target.ReadStringSafe( fixedLength );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ReadStringSafe 的测试
        ///</summary>
        [TestMethod()]
        public void ReadStringSafeTest()
        {
            byte[] byteData = null; // TODO: 初始化为适当的值
            long iSize = 0; // TODO: 初始化为适当的值
            long iOffset = 0; // TODO: 初始化为适当的值
            PacketReader target = new PacketReader( byteData, iSize, iOffset ); // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = target.ReadStringSafe();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ReadString 的测试
        ///</summary>
        [TestMethod()]
        public void ReadStringTest1()
        {
            byte[] byteData = null; // TODO: 初始化为适当的值
            long iSize = 0; // TODO: 初始化为适当的值
            long iOffset = 0; // TODO: 初始化为适当的值
            PacketReader target = new PacketReader( byteData, iSize, iOffset ); // TODO: 初始化为适当的值
            long fixedLength = 0; // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = target.ReadString( fixedLength );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ReadString 的测试
        ///</summary>
        [TestMethod()]
        public void ReadStringTest()
        {
            byte[] byteData = null; // TODO: 初始化为适当的值
            long iSize = 0; // TODO: 初始化为适当的值
            long iOffset = 0; // TODO: 初始化为适当的值
            PacketReader target = new PacketReader( byteData, iSize, iOffset ); // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = target.ReadString();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ReadSByte 的测试
        ///</summary>
        [TestMethod()]
        public void ReadSByteTest()
        {
            byte[] byteData = null; // TODO: 初始化为适当的值
            long iSize = 0; // TODO: 初始化为适当的值
            long iOffset = 0; // TODO: 初始化为适当的值
            PacketReader target = new PacketReader( byteData, iSize, iOffset ); // TODO: 初始化为适当的值
            sbyte expected = 0; // TODO: 初始化为适当的值
            sbyte actual;
            actual = target.ReadSByte();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ReadLong64 的测试
        ///</summary>
        [TestMethod()]
        public void ReadLong64Test()
        {
            byte[] byteData = null; // TODO: 初始化为适当的值
            long iSize = 0; // TODO: 初始化为适当的值
            long iOffset = 0; // TODO: 初始化为适当的值
            PacketReader target = new PacketReader( byteData, iSize, iOffset ); // TODO: 初始化为适当的值
            long expected = 0; // TODO: 初始化为适当的值
            long actual;
            actual = target.ReadLong64();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ReadInt32 的测试
        ///</summary>
        [TestMethod()]
        public void ReadInt32Test()
        {
            byte[] byteData = null; // TODO: 初始化为适当的值
            long iSize = 0; // TODO: 初始化为适当的值
            long iOffset = 0; // TODO: 初始化为适当的值
            PacketReader target = new PacketReader( byteData, iSize, iOffset ); // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = target.ReadInt32();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ReadInt16 的测试
        ///</summary>
        [TestMethod()]
        public void ReadInt16Test()
        {
            byte[] byteData = null; // TODO: 初始化为适当的值
            long iSize = 0; // TODO: 初始化为适当的值
            long iOffset = 0; // TODO: 初始化为适当的值
            PacketReader target = new PacketReader( byteData, iSize, iOffset ); // TODO: 初始化为适当的值
            short expected = 0; // TODO: 初始化为适当的值
            short actual;
            actual = target.ReadInt16();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ReadFloat 的测试
        ///</summary>
        [TestMethod()]
        public void ReadFloatTest()
        {
            byte[] byteData = null; // TODO: 初始化为适当的值
            long iSize = 0; // TODO: 初始化为适当的值
            long iOffset = 0; // TODO: 初始化为适当的值
            PacketReader target = new PacketReader( byteData, iSize, iOffset ); // TODO: 初始化为适当的值
            float expected = 0F; // TODO: 初始化为适当的值
            float actual;
            actual = target.ReadFloat();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ReadByte 的测试
        ///</summary>
        [TestMethod()]
        public void ReadByteTest()
        {
            byte[] byteData = null; // TODO: 初始化为适当的值
            long iSize = 0; // TODO: 初始化为适当的值
            long iOffset = 0; // TODO: 初始化为适当的值
            PacketReader target = new PacketReader( byteData, iSize, iOffset ); // TODO: 初始化为适当的值
            byte expected = 0; // TODO: 初始化为适当的值
            byte actual;
            actual = target.ReadByte();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ReadBuffer 的测试
        ///</summary>
        [TestMethod()]
        public void ReadBufferTest()
        {
            byte[] byteData = null; // TODO: 初始化为适当的值
            long iSize = 0; // TODO: 初始化为适当的值
            long iOffset = 0; // TODO: 初始化为适当的值
            PacketReader target = new PacketReader( byteData, iSize, iOffset ); // TODO: 初始化为适当的值
            byte[] byteBuffer = null; // TODO: 初始化为适当的值
            byte[] byteBufferExpected = null; // TODO: 初始化为适当的值
            long ibyteBufferOffset = 0; // TODO: 初始化为适当的值
            long iReadSize = 0; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.ReadBuffer( ref byteBuffer, ibyteBufferOffset, iReadSize );
            Assert.AreEqual( byteBufferExpected, byteBuffer );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ReadBoolean 的测试
        ///</summary>
        [TestMethod()]
        public void ReadBooleanTest()
        {
            byte[] byteData = null; // TODO: 初始化为适当的值
            long iSize = 0; // TODO: 初始化为适当的值
            long iOffset = 0; // TODO: 初始化为适当的值
            PacketReader target = new PacketReader( byteData, iSize, iOffset ); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.ReadBoolean();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IsSafeChar 的测试
        ///</summary>
        [TestMethod()]
        public void IsSafeCharTest()
        {
            long cChar = 0; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = PacketReader.IsSafeChar( cChar );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GetPacketLength 的测试
        ///</summary>
        [TestMethod()]
        public void GetPacketLengthTest()
        {
            byte[] byteData = null; // TODO: 初始化为适当的值
            long iSize = 0; // TODO: 初始化为适当的值
            long iOffset = 0; // TODO: 初始化为适当的值
            PacketReader target = new PacketReader( byteData, iSize, iOffset ); // TODO: 初始化为适当的值
            long expected = 0; // TODO: 初始化为适当的值
            long actual;
            actual = target.GetPacketLength();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GetPacketID 的测试
        ///</summary>
        [TestMethod()]
        public void GetPacketIDTest()
        {
            byte[] byteData = null; // TODO: 初始化为适当的值
            long iSize = 0; // TODO: 初始化为适当的值
            long iOffset = 0; // TODO: 初始化为适当的值
            PacketReader target = new PacketReader( byteData, iSize, iOffset ); // TODO: 初始化为适当的值
            long expected = 0; // TODO: 初始化为适当的值
            long actual;
            actual = target.GetPacketID();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GetPacketHead 的测试
        ///</summary>
        public void GetPacketHeadTestHelper<PacketHeadT>()
        {
            byte[] byteData = null; // TODO: 初始化为适当的值
            long iSize = 0; // TODO: 初始化为适当的值
            long iOffset = 0; // TODO: 初始化为适当的值
            PacketReader target = new PacketReader( byteData, iSize, iOffset ); // TODO: 初始化为适当的值
            EventHandler<PacketHeadInfoEventArgs<PacketHeadT>> eventHandler = null; // TODO: 初始化为适当的值
            PacketHeadT expected = default( PacketHeadT ); // TODO: 初始化为适当的值
            PacketHeadT actual;
            actual = target.GetPacketHead<PacketHeadT>( eventHandler );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void GetPacketHeadTest()
        {
            GetPacketHeadTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///PacketReader 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void PacketReaderConstructorTest2()
        {
            byte[] byteData = null; // TODO: 初始化为适当的值
            long iSize = 0; // TODO: 初始化为适当的值
            long iOffset = 0; // TODO: 初始化为适当的值
            PacketReader target = new PacketReader( byteData, iSize, iOffset );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        /// <summary>
        ///PacketReader 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void PacketReaderConstructorTest1()
        {
            byte[] byteData = null; // TODO: 初始化为适当的值
            long iSize = 0; // TODO: 初始化为适当的值
            long iOffset = 0; // TODO: 初始化为适当的值
            EventHandler<PacketLengthInfoEventArgs> eventPacketLength = null; // TODO: 初始化为适当的值
            PacketReader target = new PacketReader( byteData, iSize, iOffset, eventPacketLength );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        /// <summary>
        ///PacketReader 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void PacketReaderConstructorTest()
        {
            byte[] byteData = null; // TODO: 初始化为适当的值
            long iSize = 0; // TODO: 初始化为适当的值
            long iOffset = 0; // TODO: 初始化为适当的值
            EventHandler<PacketIdInfoEventArgs> eventPacketID = null; // TODO: 初始化为适当的值
            PacketReader target = new PacketReader( byteData, iSize, iOffset, eventPacketID );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
