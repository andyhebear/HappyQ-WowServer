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
using System.Globalization;
using System.Reflection;
using Demo.Mmose.Core.Common;
#endregion

namespace Demo.Mmose.Core.Server.Language
{
    /// <summary>
    /// 替换其它语言的全局的字符串
    /// </summary>
    [MultiThreadedSupport( "zh-CHS", "当前的类所有成员都是不能改变的字符串数据,支持多线程操作" )]
    public class LanguageString
    {
        #region zh-CHS 内部静态成员变量 | en Internal Static Member Variables
        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 全局显示信息的字符串
        /// </summary>
        private static LanguageString s_LanguageString = new LanguageString();
        #endregion
        /// <summary>
        /// 全局显示信息的字符串
        /// </summary>
        public static LanguageString SingletonInstance
        {
            get { return s_LanguageString; }
        }
        #endregion

        #region zh-CHS 内部静态方法 | en Internal Static Methods
        /// <summary>
        /// 
        /// </summary>
        internal static void LoadLanguageFromAssembly( string strLanguageFile )
        {
            Assembly assembly = LanguageStringFromAssembly.LoadLanguageFromAssembly( strLanguageFile, ref s_LanguageString );
            LanguageStringFromFile.LoadLanguageFile( assembly, ref s_LanguageString );
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private LanguageExceptionString m_LanguageExceptionString = new LanguageExceptionString();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public LanguageExceptionString ExceptionString
        {
            get { return m_LanguageExceptionString; }
        }
        #endregion

        ////////////////////////////////////////////////////////////
        // Version - 0.0.1.0   Time - 0:25 2007-12-7 
        
        #region zh-CHS CultureInfo属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private CultureInfo m_CultureInfo = new CultureInfo( "zh-CN", false );
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public CultureInfo CultureInfo
        {
            get { return m_CultureInfo; }
            set { m_CultureInfo = value; }
        }
        #endregion

        #region zh-CHS BaseWorld | en BaseWorld
        /// <summary>
        /// 
        /// </summary>
        public string BaseWorldString001 = "游戏世界: 开始保存游戏世界数据中......";

        /// <summary>
        /// 
        /// </summary>
        public string BaseWorldString002 = "游戏世界: 游戏世界数据保存调用完毕.";

        /// <summary>
        /// 
        /// </summary>
        public string BaseWorldString003 = "游戏世界: 游戏世界数据正在保存中,请稍候再试......";
        #endregion

        #region zh-CHS OneServer | en OneServer
        /// <summary>
        /// 
        /// </summary>
        public string OneServerString001 = "核心 主线程";

        /// <summary>
        /// 
        /// </summary>
        public string OneServerString002 = "当前有程序已经运行,等待程序结束......";

        /// <summary>
        /// 
        /// </summary>
        public string OneServerString003 = "Mmose 版本 {0}.{1}, 生成 {2}.{3} (c) DemoSoft Team";
        
        /// <summary>
        /// 
        /// </summary>
        public string OneServerString004 = "核心: 运行的.NET框架版本 {0}.{1}.{2}";

         /// <summary>
        /// 
        /// </summary>
        public string OneServerString005 = "核心: 运行的参数: {0}";

        /// <summary>
        /// 
        /// </summary>
        public string OneServerString006 = "核心: 处理器{0}个-优化在<{1}>";

        /// <summary>
        /// 
        /// </summary>
        public string OneServerString007 = "脚本: 一个或多个脚本编译失败 或者 没有找到脚本文件";

        /// <summary>
        /// 
        /// </summary>
        public string OneServerString008 = "脚本: - 按下任意键退出或按下( R )键再次尝试";

        /// <summary>
        /// 
        /// </summary>
        public string OneServerString009 = "命令({0}) : Restart - 重启程序";

        /// <summary>
        /// 
        /// </summary>
        public string OneServerString010 = "命令({0}) : Closelog - 日志服务功能 没有开启";

        /// <summary>
        /// 
        /// </summary>
        public string OneServerString011 = "命令({0}) : Closelog - 关闭日志";

        /// <summary>
        /// 
        /// </summary>
        public string OneServerString012 = "命令({0}) : Closelog - 日志已是关闭状态";

        /// <summary>
        /// 
        /// </summary>
        public string OneServerString013 = "命令({0}) : Closelog - 日志服务功能 没有开启";

        /// <summary>
        /// 
        /// </summary>
        public string OneServerString014 = "命令({0}) : OpenLog - 开启日志";

        /// <summary>
        /// 
        /// </summary>
        public string OneServerString015 = "命令({0}) : OpenLog - 日志已是开启状态";

        /// <summary>
        /// 
        /// </summary>
        public string OneServerString016 = "命令({0}) : TimeInfo - 显示时间片信息";

        /// <summary>
        /// 
        /// </summary>
        public string OneServerString017 = "命令({0}) : SaveWorld - 保存游戏世界数据";

        /// <summary>
        /// 
        /// </summary>
        public string OneServerString018 = "命令({0}) : Help - 命令帮助";

        /// <summary>
        /// 
        /// </summary>
        public string OneServerString019 = "命令帮助 : OpenLog - 开启日志";

        /// <summary>
        /// 
        /// </summary>
        public string OneServerString020 = "命令帮助 : Closelog - 关闭日志";

        /// <summary>
        /// 
        /// </summary>
        public string OneServerString021 = "命令帮助 : Restart - 重启程序";

        /// <summary>
        /// 
        /// </summary>
        public string OneServerString022 = "命令帮助 : TimeInfo - 显示时间片信息";

        /// <summary>
        /// 
        /// </summary>
        public string OneServerString023 = "命令帮助 : SaveWorld - 保存游戏世界数据";

        /// <summary>
        /// 
        /// </summary>
        public string OneServerString024 = "命令帮助 : Quit - 退出程序";

        /// <summary>
        /// 
        /// </summary>
        public string OneServerString025 = "命令帮助 : Exit - 退出程序";

        /// <summary>
        /// 
        /// </summary>
        public string OneServerString026 = "命令({0}) : Quit - 退出程序";

        /// <summary>
        /// 
        /// </summary>
        public string OneServerString027 = "命令({0}) : Exit - 退出程序";

        /// <summary>
        /// 
        /// </summary>
        public string OneServerString028 = "命令({0}) : 未知的无效命令";

        /// <summary>
        /// 
        /// </summary>
        public string OneServerString029 = "注册线程: 注册入服务的线程全部退出完毕!";

        /// <summary>
        /// 
        /// </summary>
        public string OneServerString030 = ">>>致命错误<<< :";

        /// <summary>
        /// 
        /// </summary>
        public string OneServerString031 = ">>>致命警告<<< :";

        /// <summary>
        /// 
        /// </summary>
        public string OneServerString032 = "致命的异常错误, 按任意键退出!";

        /// <summary>
        /// 
        /// </summary>
        public string OneServerString033 = "核心: 主服务程序退出中...";

        /// <summary>
        /// 
        /// </summary>
        public string OneServerString034 = "核心: 主服务程序退出完成.";
        #endregion

        #region zh-CHS Zone | en Zone
        /// <summary>
        /// 
        /// </summary>
        public string ZoneString001 = "Zone： 没有有效初始化!";

        /// <summary>
        /// 
        /// </summary>
        public string ZoneString002 = "Zone： 监听端口 {0} 失败!";

        /// <summary>
        /// 
        /// </summary>
        public string ZoneString003 = "Zone： 监听IP地址与端口 {0} 失败!";

        /// <summary>
        /// 
        /// </summary>
        public string ZoneString004 = "Zone： 连接ZoneCluster服务端({0}) 错误!";

        /// <summary>
        /// 
        /// </summary>
        public string ZoneString005 = "Zone： 无法登陆ZoneCluster服务器 错误！";
        #endregion

        #region zh-CHS ZoneCluster | en ZoneCluster
        /// <summary>
        /// 
        /// </summary>
        public string ZoneClusterString001 = "ZoneCluster： 没有有效初始化!";

        /// <summary>
        /// 
        /// </summary>
        public string ZoneClusterString002 = "ZoneCluster： 监听端口 {0} 失败!";

        /// <summary>
        /// 
        /// </summary>
        public string ZoneClusterString003 = "ZoneCluster： 监听IP地址与端口 {0} 失败!";

        /// <summary>
        /// 
        /// </summary>
        public string ZoneClusterString004 = "ZoneCluster： 连接Domain服务端({0}) 错误!";

        /// <summary>
        /// 
        /// </summary>
        public string ZoneClusterString005 = "ZoneCluster： 无法登陆Domain服务器 错误！";
        #endregion

        #region zh-CHS Domain | en Domain
        /// <summary>
        /// 
        /// </summary>
        public string DomainString001 = "Domain： 没有有效初始化!";

        /// <summary>
        /// 
        /// </summary>
        public string DomainString002 = "Domain： 监听端口 {0} 失败!";

        /// <summary>
        /// 
        /// </summary>
        public string DomainString003 = "Domain： 监听IP地址与端口 {0} 失败!";
        #endregion

        #region zh-CHS ScriptCompiler | en ScriptCompiler
        /// <summary>
        /// 
        /// </summary>
        public string ScriptCompilerString001 = "脚本编译信息文件 {0} 没有找到";

        /// <summary>
        /// 
        /// </summary>
        public string ScriptCompilerString002 = "脚本编译信息文件 {0} 读取错误";

        /// <summary>
        /// 
        /// </summary>
        public string ScriptCompilerString003 = "脚本编译信息文件 {0} 无法找到需要的XML信息";

        /// <summary>
        /// 
        /// </summary>
        public string ScriptCompilerString004 = "脚本编译信息文件 {0} 无法找到需要的XML信息";

        /// <summary>
        /// 
        /// </summary>
        public string ScriptCompilerString005 = "脚本编译信息文件 {0} 无法找到需要的XML信息";

        /// <summary>
        /// 
        /// </summary>
        public string ScriptCompilerString006 = "脚本: 开始编译 C# 脚本...";

        /// <summary>
        /// 
        /// </summary>
        public string ScriptCompilerString007 = "脚本: 完成 C# (读取无任何改变的缓存文件)";

        /// <summary>
        /// 
        /// </summary>
        public string ScriptCompilerString008 = "脚本: 没有找到 C# 的脚本文件!";

        /// <summary>
        /// 
        /// </summary>
        public string ScriptCompilerString009 = "脚本: 完成 C# (读取无任何改变的缓存文件)";

        /// <summary>
        /// 
        /// </summary>
        public string ScriptCompilerString010 = "脚本: 开始编译 VB.NET 脚本...";

        /// <summary>
        /// 
        /// </summary>
        public string ScriptCompilerString011 = "脚本: 完成 VB.NET (读取无任何改变的缓存文件)";

        /// <summary>
        /// 
        /// </summary>
        public string ScriptCompilerString012 = "脚本: 没有找到 VB.NET 的脚本文件!";

        /// <summary>
        /// 
        /// </summary>
        public string ScriptCompilerString013 = "脚本: 完成 VB.NET (读取无任何改变的缓存文件)";

        /// <summary>
        /// 
        /// </summary>
        public string ScriptCompilerString014 = "脚本: 失败 ({0} 错误, {1} 警告)";

        /// <summary>
        /// 
        /// </summary>
        public string ScriptCompilerString015 = "脚本: 完成 ({0} 错误, {1} 警告)";

        /// <summary>
        /// 
        /// </summary>
        public string ScriptCompilerString016 = "警告: ";

        /// <summary>
        /// 
        /// </summary>
        public string ScriptCompilerString017 = "    {0}: 行 {1}: {3}";

        /// <summary>
        /// 
        /// </summary>
        public string ScriptCompilerString018 = "错误: ";

        /// <summary>
        /// 
        /// </summary>
        public string ScriptCompilerString019 = "    {0}: ( 行 {1} 列 {2} ) {3}";

        /// <summary>
        /// 
        /// </summary>
        public string ScriptCompilerString020 = "脚本: 完成 (0 错误, 0 警告)";
        #endregion

        #region zh-CHS Listener | en Listener
        /// <summary>
        /// 
        /// </summary>
        public string ListenerString001 = "新监听： 端口 {0} ";

        /// <summary>
        /// 
        /// </summary>
        public string ListenerString002 = "新监听： 地址 {0} ";

        /// <summary>
        /// 
        /// </summary>
        public string ListenerString003 = "新连接: {0}  [在线连接数 {1}] [总连接数 {2}]";

        /// <summary>
        /// 
        /// </summary>
        public string ListenerString004 = "新连接: {0} 无法通过验证被断开! [在线连接数 {1}] [总连接数 {2}]";
        #endregion

        #region zh-CHS Connecter | en Connecter
        /// <summary>
        /// 
        /// </summary>
        public string ConnecterString001 = "新连出: {0} ";
        #endregion

        #region zh-CHS NetState | en NetState
        /// <summary>
        /// 
        /// </summary>
        public string NetStateString001 = "连接检查: {0}已不再活动,断开客户...";

        /// <summary>
        /// 
        /// </summary>
        public string NetStateString002 = "断开连接: {0} 已经断开连接";
        #endregion

        #region zh-CHS PacketReader | en PacketReader
        /// <summary>
        /// 
        /// </summary>
        public string PacketReaderString001 = "客户端:  {0}  未经处理过的信息包 长度 = 0x{1:X4}  ID = 0x{2:X4}";

        /// <summary>
        /// 
        /// </summary>
        public string PacketReaderString002 = "--------------------------------------------------------------------------";
        #endregion

        #region zh-CHS FileLogger | en FileLogger
        /// <summary>
        /// 
        /// </summary>
        public string FileLoggerString001 = ">>>日志开始于 {0}";
        #endregion

        #region zh-CHS MultiTextWriter | en MultiTextWriter
        /// <summary>
        /// 
        /// </summary>
        public string MultiTextWriterString001 = "你须至少指定一个控制台调试输出信息的数据输出流";
        #endregion

        #region zh-CHS IOCPThreadPool | en CallbackThreadPool
        /// <summary>
        /// 
        /// </summary>
        public string IOCPThreadPoolString001 = "游戏世界 线程(IOCP)-";
        #endregion

        #region zh-CHS TimerThread | en TimerThread
        /// <summary>
        /// 
        /// </summary>
        public string TimerThreadString001 = "主时间片 线程";

        /// <summary>
        /// 
        /// </summary>
        public string TimerThreadString002 = "时间片优先级: {0}";

        /// <summary>
        /// 
        /// </summary>
        public string TimerThreadString003 = ">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>";

        /// <summary>
        /// 
        /// </summary>
        public string TimerThreadString004 = "类型: {0}; 数量: {1}; 百分比: {2}%";

        /// <summary>
        /// 
        /// </summary>
        public string TimerThreadString005 = "-------------------------------";

        /// <summary>
        /// 
        /// </summary>
        public string TimerThreadString006 = ">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>";

        /// <summary>
        /// 
        /// </summary>
        public string TimerThreadString007 = "时间片: 处理时间片的主线程已启动!";
        #endregion

        #region zh-CHS BaseItem | en BaseItem
        /// <summary>
        /// 
        /// </summary>
        public string BaseItemString001 = "道具: 开始保存道具({0})数据中......";

        /// <summary>
        /// 
        /// </summary>
        public string BaseItemString002 = "道具: 道具({0})数据保存完毕.";
        #endregion

        #region zh-CHS BaseCreature | en BaseCreature
        /// <summary>
        /// 
        /// </summary>
        public string BaseCreatureString001 = "invalid";

        /// <summary>
        /// 
        /// </summary>
        public string BaseCreatureString002 = "invalid";
        #endregion

        ////////////////////////////////////////////////////////////
        // Version - 0.0.1.?   Time - ???
    }
}
#endregion

