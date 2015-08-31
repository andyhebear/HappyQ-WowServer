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
using System.Diagnostics;
using System.IO;
using System.Reflection;
#endregion

namespace Demo.Mmose.Core.Server.Language
{
    /// <summary>
    /// 
    /// </summary>
    internal class LanguageStringFromAssembly
    {
        #region zh-CHS 内部静态方法 | en Internal Static Methods
        /// <summary>
        /// 
        /// </summary>
        public static Assembly LoadLanguageFromAssembly( string strLanguageFile, ref LanguageString globalString )
        {
            Assembly returnAssembly = null;
            bool isSetLanguage = false;
            do
            {
                if ( strLanguageFile == null )
                    break;

                const string LANGUAGE_FILE_NAME = "./Demo.Mmose.Core.Language.Dll";

                if ( strLanguageFile == string.Empty )
                {
                    strLanguageFile = LANGUAGE_FILE_NAME;

                    if ( File.Exists( strLanguageFile ) == false )
                        break;
                }

                Assembly assembly = Assembly.LoadFile( Path.GetFullPath( strLanguageFile ) );
                if ( assembly == null )
                    break;
                else
                    returnAssembly = assembly;

                Type[] types = assembly.GetTypes();

                const string TYPE_NAME = "Demo.Mmose.Core.Language.Language";
                const string METHOD_NAME = "SetLanguageString";

                for ( int iIndex = 0; iIndex < types.Length; iIndex++ )
                {
                    Type type = types[iIndex];

                    if ( type.FullName != TYPE_NAME )
                        continue;

                    MethodInfo methodInfo = type.GetMethod( METHOD_NAME, BindingFlags.Static | BindingFlags.Public );
                    if ( methodInfo == null )
                        break;

                    object[] parameters = new object[1];
                    parameters[0] = globalString;
                    methodInfo.Invoke( null, parameters ); // call SetLanguageString(...)
                }
            } while ( false );

            if ( isSetLanguage == false )
                SetDefaultLanguageString( ref globalString );

            return returnAssembly;
        }

        /// <summary>
        /// 
        /// </summary>
        private static void SetDefaultLanguageString( ref LanguageString globalString )
        {
            // none
        }
        #endregion
    }
}
#endregion