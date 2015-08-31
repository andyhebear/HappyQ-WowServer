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
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Xml.Linq;
using Demo.Mmose.Core.Collections;
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Server.Language;
using Demo.Mmose.Core.Server;
using Demo.Mmose.Core.Util;
using Microsoft.CSharp;
using Microsoft.VisualBasic;
#endregion

namespace Demo.Mmose.Core.Scripts
{
    /// <summary>
    /// 实时编译脚本(C#或VB-源码)的类
    /// </summary>
    public class ScriptCompiler
    {
        // "Scripts.config" File
        // ----------------------------------------------------------------------------------------
        //<?xml version="1.0" encoding="utf-8"?>
        //<Mmose.Script Author="H.Q.Cai" ScriptName="My.ScriptName" Version="0.0.1.0">

        //  <Assemblies>
        //    <Assembly>System.dll</Assembly>
        //    <Assembly>System.Xml.dll</Assembly>
        //    <Assembly>System.Data.dll</Assembly>
        //    <Assembly>Demo.Mmose.Core.dll</Assembly>
        //    <Assembly>C:\Program Files\Reference Assemblies\Microsoft\Framework\v3.5\System.Core.dll</Assembly>
        //    <Assembly>C:\Program Files\Reference Assemblies\Microsoft\Framework\v3.5\System.Xml.Linq.dll</Assembly>
        //    <Assembly>C:\Program Files\Reference Assemblies\Microsoft\Framework\v3.5\System.Data.DataSetExtensions.dll</Assembly>
        //  </Assemblies>

        //</Mmose.Script>
        // ----------------------------------------------------------------------------------------

        #region zh-CHS 共有静态属性 | en Public Static Properties
        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 额外附加的引用集的名称的列表
        /// </summary>
        private static List<string> s_AdditionalReferences = new List<string>();
        /// <summary>
        /// 额外附加的引用集的名称的数组
        /// </summary>
        private static string[] s_AdditionalReferenceArray = new string[0];
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public static string[] AdditionalReferences
        {
            get { return s_AdditionalReferenceArray; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 编译后主程序所引用集的数组
        /// </summary>
        private static ScriptAssemblyInfo[] s_ScriptAssemblyInfoArray = new ScriptAssemblyInfo[0];
        #endregion
        /// <summary>
        /// 给出编译后的引用集的数组
        /// </summary>
        public static ScriptAssemblyInfo[] ScriptAssemblyInfos
        {
            get { return s_ScriptAssemblyInfoArray; }
        }
        #endregion

        #region zh-CHS 共有静态方法 | en Public Static Methods
        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static MultiDictionary<string, ScriptAssemblyInfo> s_ScriptAssemblyInfos = new MultiDictionary<string, ScriptAssemblyInfo>( false );
        /// <summary>
        /// 
        /// </summary>
        private static SpinLock s_LockScriptAssemblyInfos = new SpinLock();
        /// <summary>
        /// 
        /// </summary>
        private static ScriptAssemblyInfo[] s_NullArray = new ScriptAssemblyInfo[0];
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strScriptName"></param>
        /// <returns></returns>
        public static ScriptAssemblyInfo[] GetScriptAssemblyInfo( string strScriptName )
        {
            ScriptAssemblyInfo[] returnArray = s_NullArray;

            do
            {
                s_LockScriptAssemblyInfos.Enter();
                {
                    IEnumerable<ScriptAssemblyInfo> valueEnumerable = null;
                    s_ScriptAssemblyInfos.TryEnumerateValuesForKey(strScriptName, out valueEnumerable);

                    if (valueEnumerable == null)
                        break;

                    List<ScriptAssemblyInfo> listValue = new List<ScriptAssemblyInfo>();

                    foreach (ScriptAssemblyInfo scriptAssemblyInfo in valueEnumerable)
                        listValue.Add( scriptAssemblyInfo );

                    returnArray = listValue.ToArray();
                }
                s_LockScriptAssemblyInfos.Exit();

            } while ( false );

            return returnArray;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strScriptName"></param>
        /// <param name="scriptVersion"></param>
        /// <returns></returns>
        public static ScriptAssemblyInfo GetScriptAssemblyInfo( string strScriptName, VersionInfo scriptVersion )
        {
            ScriptAssemblyInfo returnValue = null;

            do
            {
                s_LockScriptAssemblyInfos.Enter();
                {
                    IEnumerable<ScriptAssemblyInfo> valueEnumerable = null;
                    s_ScriptAssemblyInfos.TryEnumerateValuesForKey(strScriptName, out valueEnumerable);

                    if (valueEnumerable == null)
                        break;

                    foreach (ScriptAssemblyInfo scriptAssemblyInfo in valueEnumerable)
                    {
                        if ( scriptAssemblyInfo.Version == scriptVersion )
                        {
                            returnValue = scriptAssemblyInfo;
                            break;
                        }
                    }
                }
                s_LockScriptAssemblyInfos.Exit();

            } while ( false );

            return returnValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strScriptName"></param>
        /// <returns></returns>
        public static ScriptAssemblyInfo GetLastNewScriptAssemblyInfo( string strScriptName )
        {
            ScriptAssemblyInfo returnMaxValue = null;

            do
            {
                s_LockScriptAssemblyInfos.Enter();
                {
                    IEnumerable<ScriptAssemblyInfo> valueEnumerable = null;
                    s_ScriptAssemblyInfos.TryEnumerateValuesForKey(strScriptName, out valueEnumerable);

                    if (valueEnumerable == null)
                        break;

                    ScriptAssemblyInfo maxScriptAssemblyInfo = null;
                    VersionInfo compareVersion = null;

                    bool isFirstVersion = true;

                    foreach (ScriptAssemblyInfo scriptAssemblyInfo in valueEnumerable)
                    {
                        if ( isFirstVersion == true )
                        {
                            maxScriptAssemblyInfo = scriptAssemblyInfo;
                            compareVersion = scriptAssemblyInfo.Version;

                            isFirstVersion = false;

                            continue;
                        }

                        if ( scriptAssemblyInfo.Version > compareVersion )
                            maxScriptAssemblyInfo = scriptAssemblyInfo;
                    }

                    returnMaxValue = maxScriptAssemblyInfo;
                }
                s_LockScriptAssemblyInfos.Exit();

            } while ( false );

            return returnMaxValue;
        }

        /// <summary>
        /// 编译指定目录的脚本
        /// </summary>
        public static bool Compile( bool bDebug, bool bCache, string strAssemblyDirectory, string strScriptDirectory )
        {
            EnsureDirectory( strAssemblyDirectory );

            ScriptAssemblyInfo scriptAssemblyInfo = new ScriptAssemblyInfo();

            const string SCRIPT_CONFIG_NAME = "/Scripts.config";
            string strAssembliePath = strScriptDirectory + SCRIPT_CONFIG_NAME;

            if ( File.Exists( strAssembliePath ) == false )
            {
                LOGs.WriteLine( LogMessageType.MSG_ERROR, LanguageString.SingletonInstance.ScriptCompilerString001, strAssembliePath );
                return false;
            }
            else
            {
                // 以下是获取脚本里面的信息
                XDocument documentConfig = XDocument.Load( strAssembliePath );
                if ( documentConfig == null )
                {
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, LanguageString.SingletonInstance.ScriptCompilerString002, strAssembliePath );
                    return false;
                }

                XElement elementRoot = documentConfig.Element( (XName)"Mmose.Script" );
                if ( elementRoot == null )
                {
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, LanguageString.SingletonInstance.ScriptCompilerString003, strAssembliePath );
                    return false;
                }

                XAttribute attributeScriptName = elementRoot.Attribute( (XName)"ScriptName" );
                if ( attributeScriptName == null )
                {
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, LanguageString.SingletonInstance.ScriptCompilerString004, strAssembliePath );
                    return false;
                }
                else
                    scriptAssemblyInfo.SetScriptName( attributeScriptName.Value );

                XAttribute attributeVersion = elementRoot.Attribute( (XName)"Version" );
                if ( attributeVersion == null )
                {
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, LanguageString.SingletonInstance.ScriptCompilerString005, strAssembliePath );
                    return false;
                }
                else
                    scriptAssemblyInfo.SetVersion( new VersionInfo( attributeVersion.Value ) );
            }

            // 以下是C#脚本的编译
            if ( CompileCSScripts( bDebug, bCache, strAssemblyDirectory, strScriptDirectory, ref scriptAssemblyInfo ) == false )
                return false;

            // 以下是VB脚本的编译
            if ( CompileVBScripts( bDebug, bCache, strAssemblyDirectory, strScriptDirectory, ref scriptAssemblyInfo ) == false )
                return false;

            if ( scriptAssemblyInfo.ScriptAssembly.Length <= 0 )
                return false;

            List<MethodInfo> invokeList = new List<MethodInfo>();

            foreach ( Assembly assembly in scriptAssemblyInfo.ScriptAssembly )
            {
                Type[] types = assembly.GetTypes();

                foreach ( Type type in types )
                {
                    // 以下是添加脚本class里面的静态的Initialize方法
                    if ( type.GetInterface( "INeedInitialize", true ) != null )
                    {
                        MethodInfo methodInfo = type.GetMethod( "Initialize", BindingFlags.Static | BindingFlags.Public );

                        if ( methodInfo != null )
                            invokeList.Add( methodInfo );
                    }
                }
            }

            // 以下是排序脚本class里面的静态的Initialize方法
            invokeList.Sort( new CallPriorityComparer() );

            // 以下是调用脚本class里面的静态的Initialize方法
            foreach ( var invoke in invokeList )
                invoke.Invoke( null, null );

            s_LockScriptAssemblyInfos.Enter();
            {
                // 创建新的ScriptAssemblyInfo数组,添加数据,交换数组数据,不需要锁定,没有引用时自动会回收数据
                ScriptAssemblyInfo[] tempScriptAssemblyInfoArray = new ScriptAssemblyInfo[s_ScriptAssemblyInfoArray.Length + 1];

                for ( int iIndex = 0; iIndex < s_ScriptAssemblyInfoArray.Length; ++iIndex )
                    tempScriptAssemblyInfoArray[iIndex] = s_ScriptAssemblyInfoArray[iIndex];

                tempScriptAssemblyInfoArray[s_ScriptAssemblyInfoArray.Length] = scriptAssemblyInfo;

                s_ScriptAssemblyInfoArray = tempScriptAssemblyInfoArray;

                s_ScriptAssemblyInfos.Add( scriptAssemblyInfo.ScriptName, scriptAssemblyInfo );
            }
            s_LockScriptAssemblyInfos.Exit();

            return true;
        }
        #endregion

        #region zh-CHS 静态的私有方法 | en Private Static Method
        /// <summary>
        /// 编译C#的源码
        /// </summary>
        private static bool CompileCSScripts( bool bDebug, bool bCache, string strAssemblyDirectory, string strScriptDirectory, ref ScriptAssemblyInfo scriptAssemblyInfo )
        {
            LOGs.WriteLine( LogMessageType.MSG_INFO, LanguageString.SingletonInstance.ScriptCompilerString006 );

            string[] strFiles = GetScripts( strScriptDirectory, "*.cs" );

            string strFilePath = strAssemblyDirectory + "/Scripts.CS.dll";

            if ( strFiles.Length <= 0 )
            {
                if ( bCache && File.Exists( strFilePath ) )
                {
                    Assembly assembly = Assembly.LoadFile( Path.GetFullPath( strFilePath ) );

                    scriptAssemblyInfo.AddScriptAssembly( assembly );
                    scriptAssemblyInfo.AddHashCode( assembly, new byte[0] );
                    scriptAssemblyInfo.AddScriptFiles( assembly, strFiles );

                    if ( s_AdditionalReferences.Contains( assembly.Location ) == false )
                    {
                        s_AdditionalReferences.Add( assembly.Location );
                        s_AdditionalReferenceArray = s_AdditionalReferences.ToArray();
                    }

                    LOGs.WriteLine( LogMessageType.MSG_INFO, LanguageString.SingletonInstance.ScriptCompilerString007 );
                    return true;
                }
                else
                {
                    LOGs.WriteLine( LogMessageType.MSG_WARNING, LanguageString.SingletonInstance.ScriptCompilerString008 );
                    return false;
                }
            }

            string strHashFilePath = strAssemblyDirectory + "/Scripts.CS.hash";

            if ( File.Exists( strFilePath ) )
            {
                if ( bCache && File.Exists( strHashFilePath ) )
                {
                    byte[] byteHashCode = GetHashCode( strFilePath, strFiles, bDebug );

                    using ( FileStream fileStream = new FileStream( strHashFilePath, FileMode.Open, FileAccess.Read, FileShare.Read ) )
                    {
                        using ( BinaryReader binaryReader = new BinaryReader( fileStream ) )
                        {
                            byte[] bytes = binaryReader.ReadBytes( byteHashCode.Length );

                            if ( bytes.Length == byteHashCode.Length )
                            {
                                bool bValid = true;

                                for ( int iIndex = 0; iIndex < bytes.Length; ++iIndex )
                                {
                                    if ( bytes[iIndex] != byteHashCode[iIndex] )
                                    {
                                        bValid = false;
                                        break;
                                    }
                                }

                                if ( bValid )
                                {
                                    Assembly assembly = Assembly.LoadFile( Path.GetFullPath( strFilePath ) );

                                    scriptAssemblyInfo.AddScriptAssembly( assembly );
                                    scriptAssemblyInfo.AddHashCode( assembly, byteHashCode );
                                    scriptAssemblyInfo.AddScriptFiles( assembly, strFiles );

                                    if ( s_AdditionalReferences.Contains( assembly.Location ) == false )
                                    {
                                        s_AdditionalReferences.Add( assembly.Location );
                                        s_AdditionalReferenceArray = s_AdditionalReferences.ToArray();
                                    }

                                    LOGs.WriteLine( LogMessageType.MSG_INFO, LanguageString.SingletonInstance.ScriptCompilerString009 );

                                    return true;
                                }
                            }
                        }
                    }
                }
            }

            DeleteFiles( strAssemblyDirectory, "Scripts.CS*.dll" );

            using ( CSharpCodeProvider csharpCodeProvider = new CSharpCodeProvider( new Dictionary<string, string>() { { "CompilerVersion", "v3.5" } } ) )
            {
                string strUnusedPath = GetUnusedPath( strAssemblyDirectory, "Scripts.CS" );

                CompilerParameters compilerParameters = new CompilerParameters( GetReferenceAssemblies( strScriptDirectory ), strUnusedPath, bDebug );

                string strDefines = GetDefines();

                if ( strDefines != string.Empty )
                    compilerParameters.CompilerOptions = strDefines;

                if ( OneServer.HaltOnWarning == true )
                    compilerParameters.WarningLevel = 4;
                
                CompilerResults compilerResults = csharpCodeProvider.CompileAssemblyFromFile( compilerParameters, strFiles );

                Display( strScriptDirectory, compilerResults );

                if ( compilerResults.Errors.Count > 0 )
                    return false;

                // 开始HashCode
                byte[] byteHashCode = GetHashCode( strUnusedPath, strFiles, bDebug );

                using ( FileStream fileStream = new FileStream( strHashFilePath, FileMode.Create, FileAccess.Write, FileShare.None ) )
                {
                    using ( BinaryWriter binaryWriter = new BinaryWriter( fileStream ) )
                        binaryWriter.Write( byteHashCode, 0, byteHashCode.Length );
                }

                Assembly assembly = Assembly.LoadFile( Path.GetFullPath( strUnusedPath ) );

                scriptAssemblyInfo.AddScriptAssembly( assembly );
                scriptAssemblyInfo.AddHashCode( assembly, byteHashCode );
                scriptAssemblyInfo.AddScriptFiles( assembly, strFiles );

                if ( s_AdditionalReferences.Contains( assembly.Location ) == false )
                {
                    s_AdditionalReferences.Add( assembly.Location );
                    s_AdditionalReferenceArray = s_AdditionalReferences.ToArray();
                }

                return true;
            }
        }

        /// <summary>
        /// 编译VB的源码
        /// </summary>
        private static bool CompileVBScripts( bool bDebug, bool bCache, string strAssemblyDirectory, string strScriptDirectory, ref ScriptAssemblyInfo scriptAssemblyInfo )
        {
            LOGs.WriteLine( LogMessageType.MSG_INFO, LanguageString.SingletonInstance.ScriptCompilerString010 );

            string[] strFiles = GetScripts( strScriptDirectory, "*.vb" );

            string strFilePath = strAssemblyDirectory + "/Scripts.VB.dll";

            if ( strFiles.Length <= 0 )
            {
                if ( bCache && File.Exists( strFilePath ) )
                {
                    Assembly assembly = Assembly.LoadFile( Path.GetFullPath( strFilePath ) );

                    scriptAssemblyInfo.AddScriptAssembly( assembly );
                    scriptAssemblyInfo.AddHashCode( assembly, new byte[0] );
                    scriptAssemblyInfo.AddScriptFiles( assembly, strFiles );

                    if ( s_AdditionalReferences.Contains( assembly.Location ) == false )
                    {
                        s_AdditionalReferences.Add( assembly.Location );
                        s_AdditionalReferenceArray = s_AdditionalReferences.ToArray();
                    }

                    LOGs.WriteLine( LogMessageType.MSG_INFO, LanguageString.SingletonInstance.ScriptCompilerString011 );
                    return true;
                }
                else
                {
                    LOGs.WriteLine( LogMessageType.MSG_WARNING, LanguageString.SingletonInstance.ScriptCompilerString012 );
                    return true;
                }
            }

            string strHashFilePath = strAssemblyDirectory + "/Scripts.CS.hash";

            if ( File.Exists( strFilePath ) )
            {
                if ( bCache && File.Exists( strHashFilePath ) )
                {
                    byte[] byteHashCode = GetHashCode( strFilePath, strFiles, bDebug );

                    using ( FileStream fileStream = new FileStream( strHashFilePath, FileMode.Open, FileAccess.Read, FileShare.Read ) )
                    {
                        using ( BinaryReader binaryReader = new BinaryReader( fileStream ) )
                        {
                            byte[] bytes = binaryReader.ReadBytes( byteHashCode.Length );

                            if ( bytes.Length == byteHashCode.Length )
                            {
                                bool bValid = true;

                                for ( int iIndex = 0; iIndex < bytes.Length; ++iIndex )
                                {
                                    if ( bytes[iIndex] != byteHashCode[iIndex] )
                                    {
                                        bValid = false;
                                        break;
                                    }
                                }

                                if ( bValid )
                                {
                                    Assembly assembly = Assembly.LoadFile( Path.GetFullPath( strFilePath ) );

                                    scriptAssemblyInfo.AddScriptAssembly( assembly );
                                    scriptAssemblyInfo.AddHashCode( assembly, byteHashCode );
                                    scriptAssemblyInfo.AddScriptFiles( assembly, strFiles );

                                    if ( s_AdditionalReferences.Contains( assembly.Location ) == false )
                                    {
                                        s_AdditionalReferences.Add( assembly.Location );
                                        s_AdditionalReferenceArray = s_AdditionalReferences.ToArray();
                                    }

                                    LOGs.WriteLine( LogMessageType.MSG_INFO, LanguageString.SingletonInstance.ScriptCompilerString013 );

                                    return true;
                                }
                            }
                        }
                    }
                }
            }

            DeleteFiles( strAssemblyDirectory, "Scripts.VB*.dll" );

            using ( VBCodeProvider provider = new VBCodeProvider( new Dictionary<string, string>() { { "CompilerVersion", "v3.5" } } ) )
            {
                string strUnusedPath = GetUnusedPath( strAssemblyDirectory, "Scripts.VB" );

                CompilerParameters compilerParameters = new CompilerParameters( GetReferenceAssemblies( strScriptDirectory ), strUnusedPath, bDebug );

                string strDefines = GetDefines();

                if ( strDefines != string.Empty )
                    compilerParameters.CompilerOptions = strDefines;

                if ( OneServer.HaltOnWarning == true )
                    compilerParameters.WarningLevel = 4;

                CompilerResults compilerResults = provider.CompileAssemblyFromFile( compilerParameters, strFiles );

                Display( strScriptDirectory, compilerResults );

                if ( compilerResults.Errors.Count > 0 )
                    return false;

                // 开始HashCode
                byte[] byteHashCode = GetHashCode( strUnusedPath, strFiles, bDebug );

                using ( FileStream fileStream = new FileStream( strHashFilePath, FileMode.Create, FileAccess.Write, FileShare.None ) )
                {
                    using ( BinaryWriter binaryWriter = new BinaryWriter( fileStream ) )
                        binaryWriter.Write( byteHashCode, 0, byteHashCode.Length );
                }

                Assembly assembly = Assembly.LoadFile( Path.GetFullPath( strUnusedPath ) );

                scriptAssemblyInfo.AddScriptAssembly( assembly );
                scriptAssemblyInfo.AddHashCode( assembly, byteHashCode );
                scriptAssemblyInfo.AddScriptFiles( assembly, strFiles );

                if ( s_AdditionalReferences.Contains( assembly.Location ) == false )
                {
                    s_AdditionalReferences.Add( assembly.Location );
                    s_AdditionalReferenceArray = s_AdditionalReferences.ToArray();
                }

                return true;
            }
        }

        /// <summary>
        /// 显示编译后的信息
        /// </summary>
        private static void Display( string strScriptDirectory, CompilerResults compilerResults )
        {
            if ( compilerResults.Errors.Count > 0 )
            {
                Dictionary<string, List<CompilerError>> dictionaryErrors = new Dictionary<string, List<CompilerError>>( compilerResults.Errors.Count, StringComparer.OrdinalIgnoreCase );
                Dictionary<string, List<CompilerError>> dictionaryWarnings = new Dictionary<string, List<CompilerError>>( compilerResults.Errors.Count, StringComparer.OrdinalIgnoreCase );

                foreach ( CompilerError compilerError in compilerResults.Errors )
                {
                    Dictionary<string, List<CompilerError>> table = ( compilerError.IsWarning ? dictionaryWarnings : dictionaryErrors );

                    List<CompilerError> list = null;
                    table.TryGetValue( compilerError.FileName, out list );

                    if ( list == null )
                        table[compilerError.FileName] = list = new List<CompilerError>();

                    list.Add( compilerError );
                }

                if ( dictionaryErrors.Count > 0 )
                    LOGs.WriteLine( LogMessageType.MSG_FATALERROR, LanguageString.SingletonInstance.ScriptCompilerString014, dictionaryErrors.Count, dictionaryWarnings.Count );
                else
                    LOGs.WriteLine( LogMessageType.MSG_NOTICE, LanguageString.SingletonInstance.ScriptCompilerString015, dictionaryErrors.Count, dictionaryWarnings.Count );

                string strScriptRoot = Path.GetFullPath( strScriptDirectory + Path.DirectorySeparatorChar );
                Uri scriptRootUri = new Uri( strScriptRoot );

                if ( dictionaryWarnings.Count > 0 )
                    LOGs.WriteLine( LogMessageType.MSG_WARNING, LanguageString.SingletonInstance.ScriptCompilerString016 );

                foreach ( KeyValuePair<string, List<CompilerError>> keyValuePair in dictionaryWarnings )
                {
                    string strFileName = keyValuePair.Key;
                    List<CompilerError> list = keyValuePair.Value;

                    string strFullPath = strFileName;
                    string strUsedPath = strFileName;

                    // 可能引用集错误的信息，所以文件名为空
                    if ( strFileName != string.Empty )
                    {
                        strFullPath = Path.GetFullPath( strFileName );
                        strUsedPath = Uri.UnescapeDataString( scriptRootUri.MakeRelativeUri( new Uri( strFullPath ) ).OriginalString );
                    }

                    LOGs.WriteLine( LogMessageType.MSG_WARNING, " + {0}:", strUsedPath );

                    foreach ( CompilerError compilerError in list )
                        LOGs.WriteLine( LogMessageType.MSG_WARNING, LanguageString.SingletonInstance.ScriptCompilerString017, compilerError.ErrorNumber, compilerError.Line, compilerError.Column, compilerError.ErrorText );
                }

                if ( dictionaryErrors.Count > 0 )
                    LOGs.WriteLine( LogMessageType.MSG_ERROR, LanguageString.SingletonInstance.ScriptCompilerString018 );

                foreach ( KeyValuePair<string, List<CompilerError>> keyValuePair in dictionaryErrors )
                {
                    string strFileName = keyValuePair.Key;
                    List<CompilerError> list = keyValuePair.Value;

                    string strFullPath = strFileName;
                    string strUsedPath = strFileName;

                    // 可能引用集错误的信息，所以文件名为空
                    if ( strFileName != string.Empty )
                    {
                        strFullPath = Path.GetFullPath( strFileName );
                        strUsedPath = Uri.UnescapeDataString( scriptRootUri.MakeRelativeUri( new Uri( strFullPath ) ).OriginalString );
                    }

                    LOGs.WriteLine( LogMessageType.MSG_ERROR, " + {0}:", strUsedPath );

                    foreach ( CompilerError compilerError in list )
                        LOGs.WriteLine( LogMessageType.MSG_ERROR, LanguageString.SingletonInstance.ScriptCompilerString019, compilerError.ErrorNumber, compilerError.Line, compilerError.Column, compilerError.ErrorText );
                }
            }
            else
            {
                LOGs.WriteLine( LogMessageType.MSG_NOTICE, LanguageString.SingletonInstance.ScriptCompilerString020 );
            }
        }

        /// <summary>
        /// 给出所有附加的引用集的名称列表
        /// </summary>
        private static string[] GetReferenceAssemblies( string strDirectory )
        {
            List<string> listAssemblies = new List<string>();

            string strPath = strDirectory + "/Scripts.config";

            if ( File.Exists( strPath ) )
            {
                XDocument assembliesXML = null;
                try
                {
                    assembliesXML = XDocument.Load( strPath );
                }
                catch ( Exception )
                {
                }

                if ( assembliesXML != null )
                {
                    var assemblies = from assembliesInfo in assembliesXML.Elements( "Mmose.Script" ).Elements( "Assemblies" ).Elements( "Assembly" ) select assembliesInfo;

                    foreach ( var assembly in assemblies )
                        listAssemblies.Add( assembly.Value );
                }
            }

            listAssemblies.Add( OneServer.ExePath );
            listAssemblies.AddRange( s_AdditionalReferences );

            return listAssemblies.ToArray();
        }

        /// <summary>
        /// 给出定义(用于编译器的附加命令行参数 - /D(定义的一个或多个符号的名称))
        /// </summary>
        private static string GetDefines()
        {
            StringBuilder stringBuilder = new StringBuilder();

            // /define
            stringBuilder.Append( "/define:" );

            // These two defines are legacy, ie, depreciated.
            if ( OneServer.Is64Bit == true )
            {
                stringBuilder.Append( "x64" );
                stringBuilder.Append( ';' );
            }

            stringBuilder.Append( "Framework_3_5" );
            stringBuilder.Append( ';' );

            //////////////////////////////////////////////////////////////////////////
            stringBuilder.Append( " " );
            //////////////////////////////////////////////////////////////////////////

            // /nowarn
            stringBuilder.Append( "/nowarn:" );

            stringBuilder.Append( "436" );
            stringBuilder.Append( ',' );

            //////////////////////////////////////////////////////////////////////////
            stringBuilder.Append( " " );
            //////////////////////////////////////////////////////////////////////////

            return stringBuilder.ToString();
        }

        /// <summary>
        /// 给出某个文件的SHA1的Hash值(计算脚本文件的时间来得到Hash值)
        /// </summary>
        private static byte[] GetHashCode( string strCompiledFile, string[] strScriptFiles, bool bDebug )
        {
            using ( MemoryStream memoryStream = new MemoryStream() )
            {
                using ( BinaryWriter binaryWriter = new BinaryWriter( memoryStream ) )
                {
                    FileInfo fileInfo = new FileInfo( strCompiledFile );

                    binaryWriter.Write( fileInfo.LastWriteTimeUtc.Ticks );

                    foreach ( string strScriptFile in strScriptFiles )
                    {
                        fileInfo = new FileInfo( strScriptFile );

                        binaryWriter.Write( fileInfo.LastWriteTimeUtc.Ticks );
                    }

                    binaryWriter.Write( bDebug );

                    memoryStream.Position = 0;

                    using ( SHA1 Sha1 = SHA1.Create() )
                    {
                        return Sha1.ComputeHash( memoryStream );
                    }
                }
            }
        }

        /// <summary>
        /// 给出目录唯一的路径文件的名称
        /// </summary>
        private static string GetUnusedPath( string strDirectory, string strName )
        {
            string strPath = String.Format( strDirectory + "/{0}.dll", strName );

            for ( int iIndex = 2; File.Exists( strPath ) && iIndex <= int.MaxValue; ++iIndex )
                strPath = String.Format( strDirectory + "/{0}.{1}.dll", strName, iIndex );

            return strPath;
        }

        /// <summary>
        /// 删除目录里面的文件
        /// </summary>
        private static void DeleteFiles( string strDirectory, string strMask )
        {
            try
            {
                string[] strFiles = Directory.GetFiles( strDirectory, strMask );

                foreach ( string strFile in strFiles )
                {
                    try { File.Delete( strFile ); }
                    catch { }
                }
            }
            catch { }
        }

        /// <summary>
        /// 确保目录的存在
        /// </summary>
        private static void EnsureDirectory( string strDirectory )
        {
            if ( Directory.Exists( strDirectory ) == false )
                Directory.CreateDirectory( strDirectory );
        }

        /// <summary>
        /// 给出目录的全部文件
        /// </summary>
        private static string[] GetScripts( string strScriptDirectory, string strFilter )
        {
            List<string> listFiles = new List<string>();

            GetScripts( ref listFiles, strScriptDirectory, strFilter );

            return listFiles.ToArray();
        }

        /// <summary>
        /// 给出目录的全部文件
        /// </summary>
        private static void GetScripts( ref List<string> listString, string strPath, string strFilter )
        {
            foreach ( string strDir in Directory.GetDirectories( strPath ) )
                GetScripts( ref listString, strDir, strFilter );

            listString.AddRange( Directory.GetFiles( strPath, strFilter ) );
        }
        #endregion
    }
}
#endregion

