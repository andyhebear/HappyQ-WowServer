using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Reflection;
using System.Diagnostics;
using System.Globalization;
using System.Collections.Generic;
using Demo.Mmose.Core.Server.Language;

namespace Demo.Mmose.Core.Language
{
    /// <summary>
    /// 
    /// </summary>
    public static class Language
    {
        /// <summary>
        /// 
        /// </summary>
        public static void SetLanguageString( ref LanguageString globalString )
        {
            globalString.CultureInfo = new CultureInfo( "zh-CN", false );

            ////////////////////////////////////////////////////////////
            // Version - 0.0.1.0   Time - 0:25 2007-12-7 
            
            #region zh-CHS BaseWorld | en BaseWorld
            globalString.BaseWorldString001 = "游戏世界: 开始保存游戏世界数据中......";
            globalString.BaseWorldString002 = "游戏世界: 游戏世界数据保存调用完毕.";
            globalString.BaseWorldString003 = "游戏世界: 游戏世界数据正在保存中,请稍候再试......";
            #endregion

            #region zh-CHS OneServer | en OneServer
            globalString.OneServerString001 = "核心 主线程";
            globalString.OneServerString002 = "当前有程序已经运行,等待程序结束......";
            globalString.OneServerString003 = "Mmose 版本 {0}.{1}, 生成 {2}.{3} (c) DemoSoft Team";
            globalString.OneServerString004 = "核心: 运行的.NET框架版本 {0}.{1}.{2}";
            globalString.OneServerString005 = "核心: 运行的参数: {0}";
            globalString.OneServerString006 = "核心: 处理器{0}个-优化在<{1}>";
            globalString.OneServerString007 = "脚本: 一个或多个脚本编译失败 或者 没有找到脚本文件";
            globalString.OneServerString008 = "脚本: - 按下任意键退出或按下( R )键再次尝试";
            globalString.OneServerString009 = "命令({0}) : Restart - 重启程序";
            globalString.OneServerString010 = "命令({0}) : Closelog - 日志服务功能 没有开启";
            globalString.OneServerString011 = "命令({0}) : Closelog - 关闭日志";
            globalString.OneServerString012 = "命令({0}) : Closelog - 日志已是关闭状态";
            globalString.OneServerString013 = "命令({0}) : Closelog - 日志服务功能 没有开启";
            globalString.OneServerString014 = "命令({0}) : OpenLog - 开启日志";
            globalString.OneServerString015 = "命令({0}) : OpenLog - 日志已是开启状态";
            globalString.OneServerString016 = "命令({0}) : TimeInfo - 显示时间片信息";
            globalString.OneServerString017 = "命令({0}) : SaveWorld - 保存游戏世界数据";
            globalString.OneServerString018 = "命令({0}) : Help - 命令帮助";
            globalString.OneServerString019 = "命令帮助 : OpenLog - 开启日志";
            globalString.OneServerString020 = "命令帮助 : Closelog - 关闭日志";
            globalString.OneServerString021 = "命令帮助 : Restart - 重启程序";
            globalString.OneServerString022 = "命令帮助 : TimeInfo - 显示时间片信息";
            globalString.OneServerString023 = "命令帮助 : SaveWorld - 保存游戏世界数据";
            globalString.OneServerString024 = "命令帮助 : Quit - 退出程序";
            globalString.OneServerString025 = "命令帮助 : Exit - 退出程序";
            globalString.OneServerString026 = "命令({0}) : Quit - 退出程序";
            globalString.OneServerString027 = "命令({0}) : Exit - 退出程序";
            globalString.OneServerString028 = "命令({0}) : 未知的无效命令";
            globalString.OneServerString029 = "注册线程: 注册入服务的线程全部退出完毕!";
            globalString.OneServerString030 = ">>>致命错误<<< :";
            globalString.OneServerString031 = ">>>致命警告<<< :";
            globalString.OneServerString032 = "致命的异常错误, 按任意键退出!";
            globalString.OneServerString033 = "核心: 主服务程序退出中...";
            globalString.OneServerString034 = "核心: 主服务程序退出完成.";
            #endregion

            #region zh-CHS Zone | en Zone
            globalString.ZoneString001 = "Zone： 没有有效初始化!";
            globalString.ZoneString002 = "Zone： 监听端口 {0} 失败!";
            globalString.ZoneString003 = "Zone： 监听IP地址与端口 {0} 失败!";
            globalString.ZoneString004 = "Zone： 连接ZoneCluster服务端({0}) 错误!";
            globalString.ZoneString005 = "Zone： 无法登陆ZoneCluster服务器 错误！";
            #endregion

            #region zh-CHS ZoneCluster | en ZoneCluster
            globalString.ZoneClusterString001 = "ZoneCluster： 没有有效初始化!";
            globalString.ZoneClusterString002 = "ZoneCluster： 监听端口 {0} 失败!";
            globalString.ZoneClusterString003 = "ZoneCluster： 监听IP地址与端口 {0} 失败!";
            globalString.ZoneClusterString004 = "ZoneCluster： 连接Domain服务端({0}) 错误!";
            #endregion

            #region zh-CHS Domain | en Domain
            globalString.DomainString001 = "Domain： 没有有效初始化!";
            globalString.DomainString002 = "Domain： 监听端口 {0} 失败!";
            globalString.DomainString003 = "Domain： 监听IP地址与端口 {0} 失败!";
            #endregion

            #region zh-CHS ScriptCompiler | en ScriptCompiler
            globalString.ScriptCompilerString001 = "脚本编译信息文件 {0} 没有找到";
            globalString.ScriptCompilerString002 = "脚本编译信息文件 {0} 读取错误";
            globalString.ScriptCompilerString003 = "脚本编译信息文件 {0} 无法找到需要的XML信息";
            globalString.ScriptCompilerString004 = "脚本编译信息文件 {0} 无法找到需要的XML信息";
            globalString.ScriptCompilerString005 = "脚本编译信息文件 {0} 无法找到需要的XML信息";
            globalString.ScriptCompilerString006 = "脚本: 开始编译 C# 脚本...";
            globalString.ScriptCompilerString007 = "脚本: 完成 C# (读取无任何改变的缓存文件)";
            globalString.ScriptCompilerString008 = "脚本: 没有找到 C# 的脚本文件!";
            globalString.ScriptCompilerString009 = "脚本: 完成 C# (读取无任何改变的缓存文件)";
            globalString.ScriptCompilerString010 = "脚本: 开始编译 VB.NET 脚本...";
            globalString.ScriptCompilerString011 = "脚本: 完成 VB.NET (读取无任何改变的缓存文件)";
            globalString.ScriptCompilerString012 = "脚本: 没有找到 VB.NET 的脚本文件!";
            globalString.ScriptCompilerString013 = "脚本: 完成 VB.NET (读取无任何改变的缓存文件)";
            globalString.ScriptCompilerString014 = "脚本: 失败 ({0} 错误, {1} 警告)";
            globalString.ScriptCompilerString015 = "脚本: 完成 ({0} 错误, {1} 警告)";
            globalString.ScriptCompilerString016 = "警告: ";
            globalString.ScriptCompilerString017 = "    {0}: 行 {1}: {3}";
            globalString.ScriptCompilerString018 = "错误: ";
            globalString.ScriptCompilerString019 = "    {0}: ( 行 {1} 列 {2} ) {3}";
            globalString.ScriptCompilerString020 = "脚本: 完成 (0 错误, 0 警告)";
            #endregion

            #region zh-CHS Listener | en Listener
            globalString.ListenerString001 = "新监听： 端口 {0} ";
            globalString.ListenerString002 = "新监听： 地址 {0} ";
            globalString.ListenerString003 = "新连接: {0}  [在线连接数 {1}] [总连接数 {2}]";
            globalString.ListenerString004 = "新连接: {0} 无法通过验证被断开! [在线连接数 {1}] [总连接数 {2}]";
            #endregion

            #region zh-CHS Connecter | en Connecter
            globalString.ConnecterString001 = "新连出: {0} ";
            #endregion

            #region zh-CHS NetState | en NetState
            globalString.NetStateString001 = "连接检查: {0}已不再活动,断开客户...";
            globalString.NetStateString002 = "断开连接: {0} 已经断开连接";
            #endregion

            #region zh-CHS PacketReader | en PacketReader
            globalString.PacketReaderString001 = "客户端:  {0}  未经处理过的信息包 长度 = 0x{1:X4}  ID = 0x{2:X4}";
            globalString.PacketReaderString002 = "--------------------------------------------------------------------------";
            #endregion

            #region zh-CHS FileLogger | en FileLogger
            globalString.FileLoggerString001 = ">>>日志开始于 {0}";
            #endregion

            #region zh-CHS MultiTextWriter | en MultiTextWriter
            globalString.MultiTextWriterString001 = "你须至少指定一个控制台调试输出信息的数据输出流";
            #endregion

            #region zh-CHS CallbackThreadPool | en CallbackThreadPool
            globalString.CallbackThreadPoolString001 = "游戏世界 线程(IOCP)-";
            #endregion

            #region zh-CHS TimerThread | en TimerThread
            globalString.TimerThreadString001 = "主时间片 线程";
            globalString.TimerThreadString002 = "时间片优先级: {0}";
            globalString.TimerThreadString003 = ">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>";
            globalString.TimerThreadString004 = "类型: {0}; 数量: {1}; 百分比: {2}%";
            globalString.TimerThreadString005 = "-------------------------------";
            globalString.TimerThreadString006 = ">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>";
            globalString.TimerThreadString007 = "时间片: 处理时间片的主线程已启动!";
            #endregion

            #region zh-CHS BaseItem | en BaseItem
            globalString.BaseItemString001 = "invalid";
            globalString.BaseItemString002 = "invalid";
            #endregion

            #region zh-CHS BaseCreature | en BaseCreature
            globalString.BaseCreatureString001 = "invalid";
            globalString.BaseCreatureString002 = "invalid";
            #endregion

            ////////////////////////////////////////////////////////////
            // Version - 0.0.1.?   Time - ???
        }
    }
}
