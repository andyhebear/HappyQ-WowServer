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

#endregion

using System;
namespace Demo.Mmose.Core.Util
{
    /// <summary>
    /// 
    /// </summary>
    public static class ByteChange
    {
        #region Convert FLOAT UINT INT
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fValue"></param>
        /// <returns></returns>
        public static uint FloatToUint( float fValue )
        {
            CONVERT_FLOAT_INT_UINT convertFloat = new CONVERT_FLOAT_INT_UINT();
            convertFloat.fFloat = fValue;

            return convertFloat.uiUint;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fValue"></param>
        /// <returns></returns>
        public static uint ChangeToUint( this float fValue )
        {
            return FloatToUint( fValue );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fValue"></param>
        /// <returns></returns>
        public static int FloatToInt( float fValue )
        {
            CONVERT_FLOAT_INT_UINT convertFloat = new CONVERT_FLOAT_INT_UINT();
            convertFloat.fFloat = fValue;

            return convertFloat.iInt;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fValue"></param>
        /// <returns></returns>
        public static int ChangeToInt( this float fValue )
        {
            return FloatToInt( fValue );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uiValue"></param>
        /// <returns></returns>
        public static float UintToFloat( uint uiValue )
        {
            CONVERT_FLOAT_INT_UINT convertFloat = new CONVERT_FLOAT_INT_UINT();
            convertFloat.uiUint = uiValue;

            return convertFloat.fFloat;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uiValue"></param>
        /// <returns></returns>
        public static float ChangeToFloat( this uint uiValue )
        {
            return UintToFloat( uiValue );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uiValue"></param>
        /// <returns></returns>
        public static float IntToFloat( int iValue )
        {
            CONVERT_FLOAT_INT_UINT convertFloat = new CONVERT_FLOAT_INT_UINT();
            convertFloat.iInt = iValue;

            return convertFloat.fFloat;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uiValue"></param>
        /// <returns></returns>
        public static float ChangeToFloat( this int iValue )
        {
            return IntToFloat( iValue );
        }
        #endregion

        #region Convert DOUBLE LONG ULONG
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fValue"></param>
        /// <returns></returns>
        public static long DoubleToLong( double dValue )
        {
            CONVERT_DOUBLE_LONG_ULONG convertDouble = new CONVERT_DOUBLE_LONG_ULONG();
            convertDouble.dDouble = dValue;

            return convertDouble.lLong;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fValue"></param>
        /// <returns></returns>
        public static long ChangeToLong( this double dValue )
        {
            return DoubleToLong( dValue );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uiValue"></param>
        /// <returns></returns>
        public static ulong DoubleToUlong( double dValue )
        {
            CONVERT_DOUBLE_LONG_ULONG convertDouble = new CONVERT_DOUBLE_LONG_ULONG();
            convertDouble.dDouble = dValue;

            return convertDouble.ulUlong;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uiValue"></param>
        /// <returns></returns>
        public static ulong ChangeToUlong( this double dValue )
        {
            return DoubleToUlong( dValue );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fValue"></param>
        /// <returns></returns>
        public static double LongToDouble( long lValue )
        {
            CONVERT_DOUBLE_LONG_ULONG convertDouble = new CONVERT_DOUBLE_LONG_ULONG();
            convertDouble.lLong = lValue;

            return convertDouble.dDouble;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fValue"></param>
        /// <returns></returns>
        public static double ChangeToDouble( this long lValue )
        {
            return LongToDouble( lValue );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uiValue"></param>
        /// <returns></returns>
        public static double UlongToDouble( ulong ulValue )
        {
            CONVERT_DOUBLE_LONG_ULONG convertDouble = new CONVERT_DOUBLE_LONG_ULONG();
            convertDouble.ulUlong = ulValue;

            return convertDouble.dDouble;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uiValue"></param>
        /// <returns></returns>
        public static double ChangeToDouble( this ulong ulValue )
        {
            return UlongToDouble( ulValue );
        }
        #endregion
    }
}
#endregion