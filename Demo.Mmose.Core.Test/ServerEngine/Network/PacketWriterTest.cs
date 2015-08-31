using Demo.Mmose.Core.Network;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 PacketWriterTest 的测试类，旨在
    ///包含所有 PacketWriterTest 单元测试
    ///</summary>
    [TestClass()]
    public class PacketWriterTest
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
        ///Stream 的测试
        ///</summary>
        [TestMethod()]
        public void StreamTest()
        {
            PacketWriter target = new PacketWriter(); // TODO: 初始化为适当的值
            MemoryStream actual;
            actual = target.Stream;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Position 的测试
        ///</summary>
        [TestMethod()]
        public void PositionTest()
        {
            PacketWriter target = new PacketWriter(); // TODO: 初始化为适当的值
            long expected = 0; // TODO: 初始化为适当的值
            long actual;
            target.Position = expected;
            actual = target.Position;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Length 的测试
        ///</summary>
        [TestMethod()]
        public void LengthTest()
        {
            PacketWriter target = new PacketWriter(); // TODO: 初始化为适当的值
            long actual;
            actual = target.Length;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///WriteUTF8Null 的测试
        ///</summary>
        [TestMethod()]
        public void WriteUTF8NullTest()
        {
            PacketWriter target = new PacketWriter(); // TODO: 初始化为适当的值
            string strValue = string.Empty; // TODO: 初始化为适当的值
            target.WriteUTF8Null( strValue );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///WriteUTF8Fixed 的测试
        ///</summary>
        [TestMethod()]
        public void WriteUTF8FixedTest()
        {
            PacketWriter target = new PacketWriter(); // TODO: 初始化为适当的值
            string strValue = string.Empty; // TODO: 初始化为适当的值
            int iLength = 0; // TODO: 初始化为适当的值
            target.WriteUTF8Fixed( strValue, iLength );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///WriteLittleUniNull 的测试
        ///</summary>
        [TestMethod()]
        public void WriteLittleUniNullTest()
        {
            PacketWriter target = new PacketWriter(); // TODO: 初始化为适当的值
            string strValue = string.Empty; // TODO: 初始化为适当的值
            target.WriteLittleUniNull( strValue );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///WriteLittleUniFixed 的测试
        ///</summary>
        [TestMethod()]
        public void WriteLittleUniFixedTest()
        {
            PacketWriter target = new PacketWriter(); // TODO: 初始化为适当的值
            string strValue = string.Empty; // TODO: 初始化为适当的值
            int iSize = 0; // TODO: 初始化为适当的值
            target.WriteLittleUniFixed( strValue, iSize );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///WriteBigUniNull 的测试
        ///</summary>
        [TestMethod()]
        public void WriteBigUniNullTest()
        {
            PacketWriter target = new PacketWriter(); // TODO: 初始化为适当的值
            string strValue = string.Empty; // TODO: 初始化为适当的值
            target.WriteBigUniNull( strValue );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///WriteBigUniFixed 的测试
        ///</summary>
        [TestMethod()]
        public void WriteBigUniFixedTest()
        {
            PacketWriter target = new PacketWriter(); // TODO: 初始化为适当的值
            string strValue = string.Empty; // TODO: 初始化为适当的值
            int iSize = 0; // TODO: 初始化为适当的值
            target.WriteBigUniFixed( strValue, iSize );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///WriteAsciiNull 的测试
        ///</summary>
        [TestMethod()]
        public void WriteAsciiNullTest()
        {
            PacketWriter target = new PacketWriter(); // TODO: 初始化为适当的值
            string strValue = string.Empty; // TODO: 初始化为适当的值
            target.WriteAsciiNull( strValue );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///WriteAsciiFixed 的测试
        ///</summary>
        [TestMethod()]
        public void WriteAsciiFixedTest()
        {
            PacketWriter target = new PacketWriter(); // TODO: 初始化为适当的值
            string strValue = string.Empty; // TODO: 初始化为适当的值
            int iSize = 0; // TODO: 初始化为适当的值
            target.WriteAsciiFixed( strValue, iSize );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Write 的测试
        ///</summary>
        [TestMethod()]
        public void WriteTest11()
        {
            PacketWriter target = new PacketWriter(); // TODO: 初始化为适当的值
            float floatValue = 0F; // TODO: 初始化为适当的值
            target.Write( floatValue );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Write 的测试
        ///</summary>
        [TestMethod()]
        public void WriteTest10()
        {
            PacketWriter target = new PacketWriter(); // TODO: 初始化为适当的值
            ulong ulongValue = 0; // TODO: 初始化为适当的值
            target.Write( ulongValue );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Write 的测试
        ///</summary>
        [TestMethod()]
        public void WriteTest9()
        {
            PacketWriter target = new PacketWriter(); // TODO: 初始化为适当的值
            long longValue = 0; // TODO: 初始化为适当的值
            target.Write( longValue );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Write 的测试
        ///</summary>
        [TestMethod()]
        public void WriteTest8()
        {
            PacketWriter target = new PacketWriter(); // TODO: 初始化为适当的值
            sbyte sbyteValue = 0; // TODO: 初始化为适当的值
            target.Write( sbyteValue );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Write 的测试
        ///</summary>
        [TestMethod()]
        public void WriteTest7()
        {
            PacketWriter target = new PacketWriter(); // TODO: 初始化为适当的值
            int intValue = 0; // TODO: 初始化为适当的值
            target.Write( intValue );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Write 的测试
        ///</summary>
        [TestMethod()]
        public void WriteTest6()
        {
            PacketWriter target = new PacketWriter(); // TODO: 初始化为适当的值
            uint uintValue = 0; // TODO: 初始化为适当的值
            target.Write( uintValue );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Write 的测试
        ///</summary>
        [TestMethod()]
        public void WriteTest5()
        {
            PacketWriter target = new PacketWriter(); // TODO: 初始化为适当的值
            short shortValue = 0; // TODO: 初始化为适当的值
            target.Write( shortValue );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Write 的测试
        ///</summary>
        [TestMethod()]
        public void WriteTest4()
        {
            PacketWriter target = new PacketWriter(); // TODO: 初始化为适当的值
            ushort ushortValue = 0; // TODO: 初始化为适当的值
            target.Write( ushortValue );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Write 的测试
        ///</summary>
        [TestMethod()]
        public void WriteTest3()
        {
            PacketWriter target = new PacketWriter(); // TODO: 初始化为适当的值
            byte[] byteBuffer = null; // TODO: 初始化为适当的值
            int iOffset = 0; // TODO: 初始化为适当的值
            int iSize = 0; // TODO: 初始化为适当的值
            target.Write( byteBuffer, iOffset, iSize );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Write 的测试
        ///</summary>
        [TestMethod()]
        public void WriteTest2()
        {
            PacketWriter target = new PacketWriter(); // TODO: 初始化为适当的值
            bool bValue = false; // TODO: 初始化为适当的值
            target.Write( bValue );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Write 的测试
        ///</summary>
        [TestMethod()]
        public void WriteTest1()
        {
            PacketWriter target = new PacketWriter(); // TODO: 初始化为适当的值
            double doubleValue = 0F; // TODO: 初始化为适当的值
            target.Write( doubleValue );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Write 的测试
        ///</summary>
        [TestMethod()]
        public void WriteTest()
        {
            PacketWriter target = new PacketWriter(); // TODO: 初始化为适当的值
            byte byteValue = 0; // TODO: 初始化为适当的值
            target.Write( byteValue );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///ToArray 的测试
        ///</summary>
        [TestMethod()]
        public void ToArrayTest()
        {
            PacketWriter target = new PacketWriter(); // TODO: 初始化为适当的值
            byte[] expected = null; // TODO: 初始化为适当的值
            byte[] actual;
            actual = target.ToArray();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///SetLength 的测试
        ///</summary>
        [TestMethod()]
        public void SetLengthTest()
        {
            PacketWriter target = new PacketWriter(); // TODO: 初始化为适当的值
            long iLength = 0; // TODO: 初始化为适当的值
            target.SetLength( iLength );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Seek 的测试
        ///</summary>
        [TestMethod()]
        public void SeekTest()
        {
            PacketWriter target = new PacketWriter(); // TODO: 初始化为适当的值
            long iOffset = 0; // TODO: 初始化为适当的值
            Demo.Mmose.Core.Network.SeekOrigin seekOrigin = new Demo.Mmose.Core.Network.SeekOrigin(); // TODO: 初始化为适当的值
            long expected = 0; // TODO: 初始化为适当的值
            long actual;
            actual = target.Seek( iOffset, seekOrigin );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Release 的测试
        ///</summary>
        [TestMethod()]
        public void ReleaseTest()
        {
            PacketWriter target = new PacketWriter(); // TODO: 初始化为适当的值
            target.Release();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Instance 的测试
        ///</summary>
        [TestMethod()]
        public void InstanceTest1()
        {
            PacketWriter expected = null; // TODO: 初始化为适当的值
            PacketWriter actual;
            actual = PacketWriter.Instance();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Instance 的测试
        ///</summary>
        [TestMethod()]
        public void InstanceTest()
        {
            long iCapacity = 0; // TODO: 初始化为适当的值
            PacketWriter expected = null; // TODO: 初始化为适当的值
            PacketWriter actual;
            actual = PacketWriter.Instance( iCapacity );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Fill 的测试
        ///</summary>
        [TestMethod()]
        public void FillTest()
        {
            PacketWriter target = new PacketWriter(); // TODO: 初始化为适当的值
            byte fillValue = 0; // TODO: 初始化为适当的值
            long iLength = 0; // TODO: 初始化为适当的值
            target.Fill( fillValue, iLength );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///PacketWriter 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void PacketWriterConstructorTest1()
        {
            PacketWriter target = new PacketWriter();
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        /// <summary>
        ///PacketWriter 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void PacketWriterConstructorTest()
        {
            long iCapacity = 0; // TODO: 初始化为适当的值
            PacketWriter target = new PacketWriter( iCapacity );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
