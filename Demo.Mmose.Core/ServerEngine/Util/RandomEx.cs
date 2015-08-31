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
using System;
using System.Collections.Generic;
#endregion

namespace Demo.Mmose.Core.Util
{
    /// <summary>
    /// 
    /// </summary>
    public static class RandomEx
    {
        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static Random s_Random = new Random();
        #endregion

        #region zh-CHS 共有静态方法 | en Public Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static double RandomDouble()
        {
            return s_Random.NextDouble();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool RandomBool()
        {
            return ( s_Random.Next( 2 ) == 0 );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iCount"></param>
        /// <returns></returns>
        public static int Random( int iMaxValue )
        {
            return s_Random.Next( iMaxValue );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="intList"></param>
        /// <returns></returns>
        public static T RandomArray<T>( T[] arrayT )
        {
            return arrayT[s_Random.Next( arrayT.Length )];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="intList"></param>
        /// <returns></returns>
        public static T RandomList<T>( List<T> listT )
        {
            return listT[s_Random.Next( listT.Count )];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="intList"></param>
        /// <returns></returns>
        public static void RandomInBytes( ref byte[] bufferRandom )
        {
            s_Random.NextBytes( bufferRandom );
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iMinValue"></param>
        /// <param name="iMaxValue"></param>
        /// <returns></returns>
        public static int RandomMinMax( int iMinValue, int iMaxValue )
        {
            if ( iMinValue > iMaxValue )
            {
                int iCopy = iMinValue;
                iMinValue = iMaxValue;
                iMaxValue = iCopy;
            }
            else if ( iMinValue == iMaxValue )
                return iMinValue;

            return s_Random.Next( iMinValue, iMaxValue );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iFrom"></param>
        /// <param name="iCount"></param>
        /// <returns></returns>
        public static int Random( int iBaseValue, int iAppendMaxValue )
        {
            if ( iAppendMaxValue == 0 )
                return iBaseValue;
            else if ( iAppendMaxValue > 0 )
                return iBaseValue + s_Random.Next( iAppendMaxValue );
            else
                return iBaseValue - s_Random.Next( -iAppendMaxValue );
        }
        #endregion
    }
}
#endregion