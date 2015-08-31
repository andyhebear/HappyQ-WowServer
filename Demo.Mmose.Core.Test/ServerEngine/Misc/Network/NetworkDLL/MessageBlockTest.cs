using Demo.Mmose.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 MessageBlockTest 的测试类，旨在
    ///包含所有 MessageBlockTest 单元测试
    ///</summary>
    [TestClass()]
    public class MessageBlockTest
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
        ///WriteLength 的测试
        ///</summary>
        [TestMethod()]
        public void WriteLengthTest()
        {
            MessageBlock target = new MessageBlock(); // TODO: 初始化为适当的值
            int actual;
            actual = target.WriteLength;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Value 的测试
        ///</summary>
        [TestMethod()]
        public void ValueTest()
        {
            MessageBlock target = new MessageBlock(); // TODO: 初始化为适当的值
            IntPtr expected = new IntPtr(); // TODO: 初始化为适当的值
            IntPtr actual;
            target.Handle = expected;
            actual = target.Handle;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Size 的测试
        ///</summary>
        [TestMethod()]
        public void SizeTest()
        {
            MessageBlock target = new MessageBlock(); // TODO: 初始化为适当的值
            int actual;
            actual = target.Size;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ReadLength 的测试
        ///</summary>
        [TestMethod()]
        public void ReadLengthTest()
        {
            MessageBlock target = new MessageBlock(); // TODO: 初始化为适当的值
            int actual;
            actual = target.ReadLength;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Length 的测试
        ///</summary>
        [TestMethod()]
        public void LengthTest()
        {
            MessageBlock target = new MessageBlock(); // TODO: 初始化为适当的值
            int actual;
            actual = target.Length;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///WritePointer 的测试
        ///</summary>
        [TestMethod()]
        public void WritePointerTest1()
        {
            MessageBlock target = new MessageBlock(); // TODO: 初始化为适当的值
            int writeLength = 0; // TODO: 初始化为适当的值
            target.WritePointer( writeLength );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///WritePointer 的测试
        ///</summary>
        [TestMethod()]
        public void WritePointerTest()
        {
            MessageBlock target = new MessageBlock(); // TODO: 初始化为适当的值
            IntPtr expected = new IntPtr(); // TODO: 初始化为适当的值
            IntPtr actual;
            actual = target.WritePointer();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ResetPointer 的测试
        ///</summary>
        [TestMethod()]
        public void ResetPointerTest()
        {
            MessageBlock target = new MessageBlock(); // TODO: 初始化为适当的值
            target.ResetPointer();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///ReadPointer 的测试
        ///</summary>
        [TestMethod()]
        public void ReadPointerTest1()
        {
            MessageBlock target = new MessageBlock(); // TODO: 初始化为适当的值
            IntPtr expected = new IntPtr(); // TODO: 初始化为适当的值
            IntPtr actual;
            actual = target.ReadPointer();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ReadPointer 的测试
        ///</summary>
        [TestMethod()]
        public void ReadPointerTest()
        {
            MessageBlock target = new MessageBlock(); // TODO: 初始化为适当的值
            int readLength = 0; // TODO: 初始化为适当的值
            target.ReadPointer( readLength );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///MessageBlock_WritePointerLength 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void MessageBlock_WritePointerLengthTest()
        {
            int writeLength = 0; // TODO: 初始化为适当的值
            IntPtr pMessageBlock = new IntPtr(); // TODO: 初始化为适当的值
            MessageBlock_Accessor.MessageBlock_WritePointerLength( writeLength, pMessageBlock );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///MessageBlock_WritePointer 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void MessageBlock_WritePointerTest()
        {
            IntPtr pMessageBlock = new IntPtr(); // TODO: 初始化为适当的值
            IntPtr expected = new IntPtr(); // TODO: 初始化为适当的值
            IntPtr actual;
            actual = MessageBlock_Accessor.MessageBlock_WritePointer( pMessageBlock );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///MessageBlock_WriteLength 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void MessageBlock_WriteLengthTest()
        {
            IntPtr pMessageBlock = new IntPtr(); // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = MessageBlock_Accessor.MessageBlock_WriteLength( pMessageBlock );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///MessageBlock_Size 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void MessageBlock_SizeTest()
        {
            IntPtr pMessageBlock = new IntPtr(); // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = MessageBlock_Accessor.MessageBlock_Size( pMessageBlock );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///MessageBlock_ResetPointer 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void MessageBlock_ResetPointerTest()
        {
            IntPtr pMessageBlock = new IntPtr(); // TODO: 初始化为适当的值
            MessageBlock_Accessor.MessageBlock_ResetPointer( pMessageBlock );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///MessageBlock_ReadPointerLength 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void MessageBlock_ReadPointerLengthTest()
        {
            int readLength = 0; // TODO: 初始化为适当的值
            IntPtr pMessageBlock = new IntPtr(); // TODO: 初始化为适当的值
            MessageBlock_Accessor.MessageBlock_ReadPointerLength( readLength, pMessageBlock );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///MessageBlock_ReadPointer 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void MessageBlock_ReadPointerTest()
        {
            IntPtr pMessageBlock = new IntPtr(); // TODO: 初始化为适当的值
            IntPtr expected = new IntPtr(); // TODO: 初始化为适当的值
            IntPtr actual;
            actual = MessageBlock_Accessor.MessageBlock_ReadPointer( pMessageBlock );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///MessageBlock_ReadLength 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void MessageBlock_ReadLengthTest()
        {
            IntPtr pMessageBlock = new IntPtr(); // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = MessageBlock_Accessor.MessageBlock_ReadLength( pMessageBlock );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///MessageBlock_Length 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void MessageBlock_LengthTest()
        {
            IntPtr pMessageBlock = new IntPtr(); // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = MessageBlock_Accessor.MessageBlock_Length( pMessageBlock );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///MessageBlock_BasePointer 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void MessageBlock_BasePointerTest()
        {
            IntPtr pMessageBlock = new IntPtr(); // TODO: 初始化为适当的值
            IntPtr expected = new IntPtr(); // TODO: 初始化为适当的值
            IntPtr actual;
            actual = MessageBlock_Accessor.MessageBlock_BasePointer( pMessageBlock );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///BasePointer 的测试
        ///</summary>
        [TestMethod()]
        public void BasePointerTest()
        {
            MessageBlock target = new MessageBlock(); // TODO: 初始化为适当的值
            IntPtr expected = new IntPtr(); // TODO: 初始化为适当的值
            IntPtr actual;
            actual = target.BasePointer();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///MessageBlock 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void MessageBlockConstructorTest()
        {
            MessageBlock target = new MessageBlock();
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
