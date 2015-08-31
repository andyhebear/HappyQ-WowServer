#region zh-CHS 2006 - 2008 DemoSoft 团队 | en 2006 - 2008 DemoSoft Team

//     NOTES
// ---------------
//
// This file is a part of the MMOSE(Massively Multiplayer Online Server Engine) for .NET.
//
//                              2006-2008 DemoSoft Team
//
//
// First Version : by H.Q.Cai - mailto:caihuanqing@hotmail.com

/***************************************************************************
 *
 *   This program is free software; you can redistribute it and/or modify
 *   it under the terms of the GNU Lesser General Public License as published
 *   by the Free Software Foundation; either version 2.1 of the License, or
 *   (at your option) any later version.
 *
 ***************************************************************************/

#region zh-CHS 包含名字空间 | en Include namespace
using System.Text;
#endregion

namespace Demo.Mmose.Core.Common
{
    /// <summary>
    /// 
    /// </summary>
    public struct ConsoleProgressBar
    {
        #region zh-CHS 共有静态属性 | en Public Static Properties

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static char m_Empty = ' ';
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public static char Empty
        {
            get { return m_Empty; }
            set { m_Empty = value; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static char m_Fill = '*';
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public static char Fill
        {
            get { return m_Fill; }
            set { m_Fill = value; }
        }

        #endregion

        #region zh-CHS 共有属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_IndicatingPos;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public int IndicatingPos
        {
            get { return m_IndicatingPos; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static int m_IndicatingLength;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public static int IndicatingLength
        {
            get { return m_IndicatingLength; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_iStepPos;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public int StepPos
        {
            get { return m_iStepPos; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_iMaximumStep;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public int MaximumStep
        {
            get { return m_iMaximumStep; }
        }

        #endregion

        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strName"></param>
        /// <param name="iMaximum"></param>
        public ConsoleProgressBar( int iMaximumStep )
        {
            m_iMaximumStep = iMaximumStep;
            if ( m_iMaximumStep <= 0 )
                m_iMaximumStep = 1;

            m_IndicatingPos = 0;
            m_IndicatingLength = 50;

            m_iStepPos = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strName"></param>
        /// <param name="iMaximum"></param>
        public ConsoleProgressBar( int iMaximumStep, int iIndicatingLength )
            : this( iMaximumStep )
        {
            m_IndicatingLength = iIndicatingLength;

            if ( m_IndicatingLength <= 10 )
                m_IndicatingLength = 10;
        }
        #endregion

        #region zh-CHS 共有方法 | en Public Methods

        /// <summary>
        /// 
        /// </summary>
        public void BeginStep( string strBeginString )
        {
            if ( m_iStepPos == 0 )
                LOGs.WriteLine( LogMessageType.MSG_NOTICE, strBeginString );
        }

        /// <summary>
        /// 
        /// </summary>
        public void Step()
        {
            if ( m_iMaximumStep <= 0 )
                return;

            if ( m_IndicatingPos == 0 )
            {
                StringBuilder strBuilder = new StringBuilder();
                strBuilder.Append( "[000%]" );

                strBuilder.Append( '[' );
                for ( int iIndex = 0; iIndex < m_IndicatingLength; iIndex++ )
                    strBuilder.Append( m_Empty );
                strBuilder.Append( "]" );

                LOGs.WriteLine( LogMessageType.MSG_LOAD, strBuilder.ToString() );
            }
            else if ( m_IndicatingPos >= 50 )
                return;

            m_iStepPos++;

            int iSN = ( m_iStepPos * m_IndicatingLength ) / m_iMaximumStep;
            if ( iSN > m_IndicatingPos )
            {
                StringBuilder strBuilder = new StringBuilder();

                strBuilder.Append( "[{0:000}%]" );

                strBuilder.Append( "[" );

                int iIndex;
                for ( iIndex = 0; iIndex < iSN; iIndex++ )
                    strBuilder.Append( m_Fill );

                for ( ; iIndex < m_IndicatingLength; iIndex++ )
                    strBuilder.Append( m_Empty );

                float fPercent = ( ( (float)iSN / (float)m_IndicatingLength ) * 100 );

                strBuilder.Append( "]" );

                LOGs.WriteLine( LogMessageType.MSG_LOAD, string.Format( strBuilder.ToString(), (int)fPercent ) );

                m_IndicatingPos = iSN;
            }

            if ( m_IndicatingPos >= 50 )
            {
                StringBuilder strBuilder = new StringBuilder();
                strBuilder.Append( "[100%]" );

                strBuilder.Append( "[" );

                for ( int iIndex = 0; iIndex < m_IndicatingLength; iIndex++ )
                    strBuilder.Append( m_Fill );

                strBuilder.Append( "]" );

                LOGs.WriteLine( LogMessageType.MSG_INFO, strBuilder.ToString() );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void EndStep( string strEndString )
        {
            if ( m_IndicatingPos < 50 )
            {
                m_IndicatingPos = 50;

                StringBuilder strBuilder = new StringBuilder();
                strBuilder.Append( "[100%]" );

                strBuilder.Append( "[" );

                for ( int iIndex = 0; iIndex < m_IndicatingLength; iIndex++ )
                    strBuilder.Append( m_Fill );

                strBuilder.Append( "]" );

                LOGs.WriteLine( LogMessageType.MSG_INFO, strBuilder.ToString() );
            }

            LOGs.WriteLine( LogMessageType.MSG_NOTICE, strEndString );
        }

        #endregion
    }
}
#endregion