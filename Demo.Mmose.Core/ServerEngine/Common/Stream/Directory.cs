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
using System.IO;
using System.Security.AccessControl;
#endregion

namespace Demo.Mmose.Core.Common.Stream
{
    /// <summary>
    /// 公开用于创建、移动和枚举通过目录和子目录的静态方法。无法继承此类。
    /// </summary>
    public static class Directory
    {
        #region zh-CHS 共有静态方法 | en Public Static Methods
        /// <summary>
        /// 按 path 的指定创建所有目录和子目录。
        /// </summary>
        /// <param name="path">要创建的目录路径。</param>
        /// <returns>由 path 指定的 System.IO.DirectoryInfo。</returns>
        /// <exception cref="System.UnauthorizedAccessException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.IO.IOException">由 path 指定的目录是只读的或不为空。- 或 -存在具有相同名称和 path 指定的位置的文件。</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">指定的路径无效（例如，它位于未映射的驱动器上）。</exception>
        /// <exception cref="System.ArgumentNullException">path 为 null。</exception>
        /// <exception cref="System.ArgumentException">path 是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。</exception>
        /// <exception cref="System.NotSupportedException">试图创建只有冒号字符 (:) 的目录。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260个字符。</exception>
        public static DirectoryInfo CreateDirectory( string path )
        {
            return new DirectoryInfo();
        }

        /// <summary>
        /// 创建指定路径中的所有目录，并应用指定的 Windows 安全性。
        /// </summary>
        /// <param name="path">要创建的目录。</param>
        /// <param name="directorySecurity">要应用于此目录的访问控制。</param>
        /// <returns>表示新创建的目录的 System.IO.DirectoryInfo 对象。</returns>
        /// <exception cref="System.UnauthorizedAccessException">调用方没有所要求的权限</exception>
        /// <exception cref="System.NotSupportedException">试图创建只使用冒号字符 (:) 的目录。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260个字符。</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">指定的路径无效（例如，它位于未映射的驱动器上）。</exception>
        /// <exception cref="System.ArgumentNullException">path 为 null。</exception>
        /// <exception cref="System.ArgumentException">path 是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。</exception>
        /// <exception cref="System.IO.IOException">由 path 指定的目录是只读的或不为空。 - 或 -存在具有相同名称和 path 指定的位置的文件。- 或 -该目录为应用程序的当前工作目录。</exception>
        public static DirectoryInfo CreateDirectory( string path, DirectorySecurity directorySecurity )
        {
            return new DirectoryInfo();
        }

        /// <summary>
        /// 从指定路径删除空目录。
        /// </summary>
        /// <param name="path">要移除的空目录的名称。此目录必须为可写或为空。</param>
        /// <exception cref="System.UnauthorizedAccessException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.ArgumentException">path 是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">指定的路径无效（例如，它位于未映射的驱动器上）。</exception>
        /// <exception cref="System.ArgumentNullException">path 为 null。</exception>
        /// <exception cref="System.IO.IOException">存在具有相同名称且位置由 path 指定的文件。- 或 -该目录为应用程序的当前工作目录。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260个字符。</exception>
        public static void Delete( string path )
        {
        }

        /// <summary>
        /// 删除指定的目录并（如果指示）删除该目录中的任何子目录。
        /// </summary>
        /// <param name="path">要移除的目录的名称。</param>
        /// <param name="recursive">若要移除 path 中的目录、子目录和文件，则为 true；否则为 false。</param>
        /// <exception cref="System.UnauthorizedAccessException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.IO.IOException">存在具有相同名称且位置由 path 指定的文件。- 或 -path 指定的目录是只读的，或者 recursive 是 false 并且 path不是空目录。- 或 -该目录为应用程序的当前工作目录。</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">指定的路径无效（例如，它位于未映射的驱动器上）。</exception>
        /// <exception cref="System.ArgumentNullException">path 为 null。</exception>
        /// <exception cref="System.ArgumentException">path 是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260 个字符。</exception>
        public static void Delete( string path, bool recursive )
        {
        }

        /// <summary>
        /// 确定给定路径是否引用磁盘上的现有目录。
        /// </summary>
        /// <param name="path">要测试的路径。</param>
        /// <returns>如果 path 引用现有目录，则为 true；否则为 false。</returns>
        public static bool Exists( string path )
        {
            return false;
        }

        //
        // 摘要:
        //     获取一个 System.Security.AccessControl.DirectorySecurity 对象，该对象封装指定目录的访问控制列表
        //     (ACL) 项。
        //
        // 参数:
        //   path:
        //     包含 System.Security.AccessControl.DirectorySecurity 对象的目录的路径，该对象描述文件的访问控制列表
        //     (ACL) 信息。
        //
        // 返回结果:
        //     一个 System.Security.AccessControl.DirectorySecurity 对象，该对象封装 path 参数所描述的文件的访问控制规则。
        //
        // 异常:
        //   System.SystemException:
        //     未能找到目录。
        //
        //   System.PlatformNotSupportedException:
        //     当前操作系统不是 Microsoft Windows 2000 或更高版本。
        //
        //   System.ArgumentNullException:
        //     path 参数为 null。
        //
        //   System.IO.IOException:
        //     打开目录时发生了 I/O 错误。
        //
        //   System.UnauthorizedAccessException:
        //     path 参数指定了一个只读目录。- 或 - 在当前平台上不支持此操作。- 或 - 调用方没有所要求的权限。
        //public static DirectorySecurity GetAccessControl( string path )
        //{
        //}

        //
        // 摘要:
        //     获取一个 System.Security.AccessControl.DirectorySecurity 对象，它封装指定目录的指定类型的访问控制列表
        //     (ACL) 项。
        //
        // 参数:
        //   includeSections:
        //     System.Security.AccessControl.AccessControlSections 值之一，它指定要接收的访问控制列表 (ACL)
        //     信息的类型。
        //
        //   path:
        //     包含 System.Security.AccessControl.DirectorySecurity 对象的目录的路径，该对象描述文件的访问控制列表
        //     (ACL) 信息。
        //
        // 返回结果:
        //     一个 System.Security.AccessControl.DirectorySecurity 对象，该对象封装 path 参数所描述的文件的访问控制规则。
        //
        // 异常:
        //   System.SystemException:
        //     未能找到目录。
        //
        //   System.PlatformNotSupportedException:
        //     当前操作系统不是 Microsoft Windows 2000 或更高版本。
        //
        //   System.ArgumentNullException:
        //     path 参数为 null。
        //
        //   System.IO.IOException:
        //     打开目录时发生了 I/O 错误。
        //
        //   System.UnauthorizedAccessException:
        //     path 参数指定了一个只读目录。- 或 - 在当前平台上不支持此操作。- 或 - 调用方没有所要求的权限。
        //public static DirectorySecurity GetAccessControl( string path, AccessControlSections includeSections )
        //{
        //}

        /// <summary>
        /// 获取目录的创建日期和时间。
        /// </summary>
        /// <param name="path">目录的路径。</param>
        /// <returns>一个 System.DateTime 结构，它设置为指定目录的创建日期和时间。该值用本地时间表示。</returns>
        /// <exception cref="System.UnauthorizedAccessException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.IO.IOException">未找到指定的路径。</exception>
        /// <exception cref="System.ArgumentNullException">path 为 null。</exception>
        /// <exception cref="System.ArgumentException">path 是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260 个字符。</exception>
        public static DateTime GetCreationTime( string path )
        {
            return DateTime.Now;
        }

        /// <summary>
        /// 获取目录创建的日期和时间，其格式为协调通用时间 (UTC)。
        /// </summary>
        /// <param name="path">目录的路径。</param>
        /// <returns>一个 System.DateTime 结构，它设置为指定目录的创建日期和时间。该值用 UTC 时间表示。</returns>
        /// <exception cref="System.UnauthorizedAccessException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.IO.IOException">未找到指定的路径。</exception>
        /// <exception cref="System.ArgumentNullException">path 为 null。</exception>
        /// <exception cref="System.ArgumentException">path 是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260 个字符。</exception>
        public static DateTime GetCreationTimeUtc( string path )
        {
            return DateTime.Now;
        }

        /// <summary>
        /// 获取应用程序的当前工作目录。
        /// </summary>
        /// <returns>包含当前工作目录的路径的字符串。</returns>
        /// <exception cref="System.UnauthorizedAccessException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.NotSupportedException">操作系统为 Windows CE，该系统不具有当前目录功能。此方法在 .NET Compact Framework 中可用，但是当前并不支持。</exception>
        public static string GetCurrentDirectory()
        {
            return string.Empty;
        }

        /// <summary>
        /// 获取指定目录中子目录的名称。
        /// </summary>
        /// <param name="path">为其返回子目录名称的数组的路径。</param>
        /// <returns>一个类型 String 的数组，它包含 path 中子目录的名称。</returns>
        /// <exception cref="System.UnauthorizedAccessException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.IO.IOException">path 是一个文件名。</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">指定的路径无效（例如，它位于未映射的驱动器上）。</exception>
        /// <exception cref="System.ArgumentNullException">path 为 null。</exception>
        /// <exception cref="System.ArgumentException">path 是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260 个字符。</exception>
        public static string[] GetDirectories( string path )
        {
            return new string[0];
        }

        /// <summary>
        /// 从当前目录获取与指定搜索模式匹配的目录的数组。
        /// </summary>
        /// <param name="path">要搜索的路径。</param>
        /// <param name="searchPattern">要与 path 中的文件名匹配的搜索字符串。此参数不能以两个句点（“..”）结束，不能在 System.IO.Path.DirectorySeparatorChar或 System.IO.Path.AltDirectorySeparatorChar 的前面包含两个句点（“..”），也不能包含 System.IO.Path.InvalidPathChars中的任何字符。</param>
        /// <returns>与搜索模式匹配的目录的 String 数组。</returns>
        /// <exception cref="System.ArgumentNullException">path 或 searchPattern 为 null。</exception>
        /// <exception cref="System.ArgumentException">path 是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。- 或 - searchPattern 不包含有效模式。</exception>
        /// <exception cref="System.UnauthorizedAccessException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.IO.IOException">path 是一个文件名。</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">指定的路径无效（例如，它位于未映射的驱动器上）。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260 个字符。</exception>
        public static string[] GetDirectories( string path, string searchPattern )
        {
            return new string[0];
        }

        /// <summary>
        /// 获取当前目录中与指定搜索模式匹配并使用某个值确定是否在子目录中搜索的目录的数组。
        /// </summary>
        /// <param name="path">要搜索的路径。</param>
        /// <param name="searchPattern">要与 path 中的文件名匹配的搜索字符串。此参数不能以两个句点（“..”）结束，不能在 System.IO.Path.DirectorySeparatorChar或 System.IO.Path.AltDirectorySeparatorChar 的前面包含两个句点（“..”），也不能包含 System.IO.Path.InvalidPathChars中的任何字符。</param>
        /// <param name="searchOption">System.IO.SearchOption 值之一，指定搜索操作应包括所有子目录还是仅包括当前目录。</param>
        /// <returns>与搜索模式匹配的目录的 String 数组。</returns>
        /// <exception cref="System.ArgumentNullException">path 或 searchPattern 为 null。</exception>
        /// <exception cref="System.ArgumentException">path 是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。- 或 - searchPattern 不包含有效模式。</exception>
        /// <exception cref="System.UnauthorizedAccessException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.IO.IOException">path 是一个文件名。</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">指定的路径无效（例如，它位于未映射的驱动器上）。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260 个字符。</exception>
        public static string[] GetDirectories( string path, string searchPattern, SearchOption searchOption )
        {
            return new string[0];
        }

        /// <summary>
        /// 返回指定路径的卷信息、根信息或两者同时返回。
        /// </summary>
        /// <param name="path">文件或目录的路径。</param>
        /// <returns>包含指定路径的卷信息、根信息或同时包括这两者的字符串。</returns>
        /// <exception cref="System.UnauthorizedAccessException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.ArgumentNullException">path 为 null。</exception>
        /// <exception cref="System.ArgumentException">path 是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260 个字符。</exception>
        public static string GetDirectoryRoot( string path )
        {
            return string.Empty;
        }

        /// <summary>
        /// 返回指定目录中的文件的名称。
        /// </summary>
        /// <param name="path">将从其检索文件的目录。</param>
        /// <returns>指定目录中文件名的 String 数组。文件名包含完整路径。</returns>
        /// <exception cref="System.UnauthorizedAccessException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.IO.IOException">path 是一个文件名。</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">指定的路径无效（例如，它位于未映射的驱动器上）。</exception>
        /// <exception cref="System.ArgumentNullException">path 为 null。</exception>
        /// <exception cref="System.ArgumentException">path 是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260 个字符。</exception>
        public static string[] GetFiles( string path )
        {
            return new string[0];
        }

        /// <summary>
        /// 返回指定目录中与指定搜索模式匹配的文件的名称。
        /// </summary>
        /// <param name="path">要搜索的目录。</param>
        /// <param name="searchPattern">要与 path 中的文件名匹配的搜索字符串。此参数不能以两个句点（“..”）结束，不能在 System.IO.Path.DirectorySeparatorChar或 System.IO.Path.AltDirectorySeparatorChar 的前面包含两个句点（“..”），也不能包含 System.IO.Path.InvalidPathChars中的任何字符。</param>
        /// <returns>一个 String 数组，它包含指定目录中与指定搜索模式匹配的文件的名称。文件名包含完整路径。</returns>
        /// <exception cref="System.ArgumentNullException">path 或 searchPattern 为 null。</exception>
        /// <exception cref="System.ArgumentException">path 是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。- 或 - searchPattern 不包含有效模式。</exception>
        /// <exception cref="System.UnauthorizedAccessException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">指定的路径无效（例如，它位于未映射的驱动器上）。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260 个字符。</exception>
        public static string[] GetFiles( string path, string searchPattern )
        {
            return new string[0];
        }

        /// <summary>
        /// 返回指定目录中文件的名称，该目录与指定搜索模式匹配并使用某个值确定是否在子目录中搜索。
        /// </summary>
        /// <param name="path">要搜索的目录。</param>
        /// <param name="searchPattern">要与 path 中的文件名匹配的搜索字符串。此参数不能以两个句点（“..”）结束，不能在 System.IO.Path.DirectorySeparatorChar或 System.IO.Path.AltDirectorySeparatorChar 的前面包含两个句点（“..”），也不能包含 System.IO.Path.InvalidPathChars中的任何字符。</param>
        /// <param name="searchOption">System.IO.SearchOption 值之一，指定搜索操作应包括所有子目录还是仅包括当前目录。</param>
        /// <returns>一个 String 数组，它包含指定目录中与指定搜索模式匹配的文件的名称。文件名包含完整路径。</returns>
        /// <exception cref="System.ArgumentNullException">path 或 searchpattern 为 null。</exception>
        /// <exception cref="System.UnauthorizedAccessException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.IO.IOException">path 是一个文件名。</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">指定的路径无效（例如，它位于未映射的驱动器上）。</exception>
        /// <exception cref="System.ArgumentException">path 是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。 - 或 - searchPattern 不包含有效模式。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260 个字符。</exception>
        public static string[] GetFiles( string path, string searchPattern, SearchOption searchOption )
        {
            return new string[0];
        }

        /// <summary>
        /// 返回指定目录中所有文件和子目录的名称。
        /// </summary>
        /// <param name="path">为其返回文件名和子目录名的目录。</param>
        /// <returns>一个 String 数组，它包含指定目录中文件系统项的名称。</returns>
        /// <exception cref="System.UnauthorizedAccessException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.IO.IOException">path 是一个文件名。</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">指定的路径无效（例如，它位于未映射的驱动器上）。</exception>
        /// <exception cref="System.ArgumentNullException">path 为 null。</exception>
        /// <exception cref="System.ArgumentException">path 是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260 个字符。</exception>
        public static string[] GetFileSystemEntries( string path )
        {
            return new string[0];
        }

        /// <summary>
        /// 返回与指定搜索条件匹配的文件系统项的数组。
        /// </summary>
        /// <param name="path">要搜索的路径。</param>
        /// <param name="searchPattern">要与 path 中的文件名匹配的搜索字符串。此 searchPattern 参数不能以两个句点（“..”）结束，不能在 System.IO.Path.DirectorySeparatorChar或 System.IO.Path.AltDirectorySeparatorChar 的前面包含两个句点（“..”），也不能包含 System.IO.Path.InvalidPathChars中的任何字符。</param>
        /// <returns>一个 String 数组，它包含与搜索条件匹配的文件系统项。</returns>
        /// <exception cref="System.ArgumentNullException">path 或 searchPattern 为 null。</exception>
        /// <exception cref="System.ArgumentException">path 是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。- 或 - searchPattern 不包含有效模式。</exception>
        /// <exception cref="System.UnauthorizedAccessException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.IO.IOException">path 是一个文件名。</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">指定的路径无效（例如，它位于未映射的驱动器上）。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260 个字符。</exception>
        public static string[] GetFileSystemEntries( string path, string searchPattern )
        {
            return new string[0];
        }

        /// <summary>
        /// 返回上次访问指定文件或目录的日期和时间。
        /// </summary>
        /// <param name="path">要获取其访问日期和时间信息的文件或目录。</param>
        /// <returns>一个 System.DateTime 结构，它设置为上次访问指定文件或目录的日期和时间。该值用本地时间表示。</returns>
        /// <exception cref="System.UnauthorizedAccessException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.IO.IOException">未找到指定的路径。</exception>
        /// <exception cref="System.ArgumentNullException">path 为 null。</exception>
        /// <exception cref="System.ArgumentException">path 是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260 个字符。</exception>
        /// <exception cref="System.NotSupportedException">path 参数的格式无效。</exception>
        public static DateTime GetLastAccessTime( string path )
        {
            return DateTime.Now;
        }

        /// <summary>
        /// 返回上次访问指定文件或目录的日期和时间，其格式为协调通用时间 (UTC)。
        /// </summary>
        /// <param name="path">要获取其访问日期和时间信息的文件或目录。</param>
        /// <returns>一个 System.DateTime 结构，它设置为上次访问指定文件或目录的日期和时间。该值用 UTC 时间表示。</returns>
        /// <exception cref="System.UnauthorizedAccessException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.IO.IOException">未找到指定的路径。</exception>
        /// <exception cref="System.ArgumentNullException">path 为 null。</exception>
        /// <exception cref="System.ArgumentException">path 是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260 个字符。</exception>
        /// <exception cref="System.NotSupportedException">path 参数的格式无效。</exception>
        public static DateTime GetLastAccessTimeUtc( string path )
        {
            return DateTime.Now;
        }

        /// <summary>
        /// 返回上次写入指定文件或目录的日期和时间。
        /// </summary>
        /// <param name="path">要获取其修改日期和时间信息的文件或目录。</param>
        /// <returns>一个 System.DateTime 结构，它设置为上次写入指定文件或目录的日期和时间。该值用本地时间表示。</returns>
        /// <exception cref="System.UnauthorizedAccessException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.IO.IOException">未找到指定的路径。</exception>
        /// <exception cref="System.ArgumentNullException">path 为 null。</exception>
        /// <exception cref="System.ArgumentException">path 是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260 个字符。</exception>
        public static DateTime GetLastWriteTime( string path )
        {
            return DateTime.Now;
        }

        /// <summary>
        /// 返回上次写入指定文件或目录的日期和时间，其格式为协调通用时间 (UTC)。
        /// </summary>
        /// <param name="path">要获取其修改日期和时间信息的文件或目录。</param>
        /// <returns>一个 System.DateTime 结构，它设置为上次写入指定文件或目录的日期和时间。该值用 UTC 时间表示。</returns>
        /// <exception cref="System.UnauthorizedAccessException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.IO.IOException">未找到指定的路径。</exception>
        /// <exception cref="System.ArgumentNullException">path 为 null。</exception>
        /// <exception cref="System.ArgumentException">path 是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260 个字符。</exception>
        public static DateTime GetLastWriteTimeUtc( string path )
        {
            return DateTime.Now;
        }

        /// <summary>
        /// 检索此计算机上格式为“<驱动器号>:\”的逻辑驱动器的名称。
        /// </summary>
        /// <returns>此计算机上的逻辑驱动器。</returns>
        /// <exception cref="System.UnauthorizedAccessException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.IO.IOException">发生 I/O 错误（例如，磁盘错误）。</exception>
        public static string[] GetLogicalDrives()
        {
            return new string[0];
        }

        /// <summary>
        /// 检索指定路径的父目录，包括绝对路径和相对路径。
        /// </summary>
        /// <param name="path">用于检索父目录的路径。</param>
        /// <returns>父目录；或者如果 path 是根目录，包括 UNC 服务器或共享名的根，则为 null。</returns>
        /// <exception cref="System.UnauthorizedAccessException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">未找到指定的路径。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260 个字符。</exception>
        /// <exception cref="System.ArgumentNullException">path 为 null。</exception>
        /// <exception cref="System.ArgumentException">path 是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。</exception>
        /// <exception cref="System.IO.IOException">path 指定的目录是只读的。</exception>
        public static DirectoryInfo GetParent( string path )
        {
            return new DirectoryInfo();
        }

        /// <summary>
        /// 将文件或目录及其内容移到新位置。
        /// </summary>
        /// <param name="sourceDirName">要移动的文件或目录的路径。</param>
        /// <param name="destDirName">指向 sourceDirName 的新位置的路径。</param>
        /// <exception cref="System.UnauthorizedAccessException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.ArgumentNullException">sourceDirName 或 destDirName 为 null。</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">由 sourceDirName 指定的路径无效（例如，它位于未映射的驱动器上）。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260 个字符。</exception>
        /// <exception cref="System.IO.IOException">试图将一个目录移到不同的卷。 - 或 - destDirName 已存在。 - 或 - sourceDirName 和 destDirName 参数引用相同的文件或目录。</exception>
        /// <exception cref="System.ArgumentException">sourceDirName 或 destDirName 是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。</exception>
        public static void Move( string sourceDirName, string destDirName )
        {
        }

        /// <summary>
        /// 将 System.Security.AccessControl.DirectorySecurity 对象描述的访问控制列表 (ACL) 项应用于指定的目录。
        /// </summary>
        /// <param name="path">要从中添加或移除访问控制列表 (ACL) 项的目录。</param>
        /// <param name="directorySecurity">一个 System.Security.AccessControl.DirectorySecurity 对象，该对象描述要应用于 path 参数所描述的目录的ACL 项。</param>
        /// <exception cref="System.ArgumentException">path 无效。</exception>
        /// <exception cref="System.PlatformNotSupportedException">当前操作系统不是 Microsoft Windows 2000 或更高版本。</exception>
        /// <exception cref="System.ArgumentNullException">directorySecurity 参数为 null。</exception>
        /// <exception cref="System.UnauthorizedAccessException">当前进程不具有打开该文件的权限。</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">未能找到目录。</exception>
        public static void SetAccessControl( string path, DirectorySecurity directorySecurity )
        {
        }

        /// <summary>
        /// 为指定的文件或目录设置创建日期和时间。
        /// </summary>
        /// <param name="path">要设置其创建日期和时间信息的文件或目录。</param>
        /// <param name="creationTime">System.DateTime，它包含要为 path 的创建日期和时间设置的值。该值用本地时间表示。</param>
        /// <exception cref="System.UnauthorizedAccessException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.PlatformNotSupportedException">当前操作系统不是 Microsoft Windows NT 或更高版本。</exception>
        /// <exception cref="System.ArgumentNullException">path 为 null。</exception>
        /// <exception cref="System.IO.FileNotFoundException">未找到指定的路径。</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">creationTime 指定超出该操作允许的日期或时间范围的值。</exception>
        /// <exception cref="System.ArgumentException">path 是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260 个字符。</exception>
        public static void SetCreationTime( string path, DateTime creationTime )
        {
        }

        /// <summary>
        /// 设置指定文件或目录的创建日期和时间，其格式为协调通用时间 (UTC)。
        /// </summary>
        /// <param name="path">要设置其创建日期和时间信息的文件或目录。</param>
        /// <param name="creationTimeUtc">System.DateTime，它包含要为 path 的创建日期和时间设置的值。该值用 UTC 时间表示。</param>
        /// <exception cref="System.UnauthorizedAccessException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.PlatformNotSupportedException">当前操作系统不是 Microsoft Windows NT 或更高版本。</exception>
        /// <exception cref="System.ArgumentNullException">path 为 null。</exception>
        /// <exception cref="System.IO.FileNotFoundException">未找到指定的路径。</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">creationTime 指定超出该操作允许的日期或时间范围的值。</exception>
        /// <exception cref="System.ArgumentException">path 是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260 个字符。</exception>
        public static void SetCreationTimeUtc( string path, DateTime creationTimeUtc )
        {
        }

        /// <summary>
        /// 将应用程序的当前工作目录设置为指定的目录。
        /// </summary>
        /// <param name="path">设置为当前工作目录的路径。</param>
        /// <exception cref="System.ArgumentNullException">path 为 null。</exception>
        /// <exception cref="System.IO.FileNotFoundException">未找到指定的路径。</exception>
        /// <exception cref="System.Security.SecurityException">调用方没有访问未委托的代码所需的权限。</exception>
        /// <exception cref="System.IO.IOException">发生 IO 错误。</exception>
        /// <exception cref="System.ArgumentException">path 是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260 个字符。</exception>
        public static void SetCurrentDirectory( string path )
        {
        }

        /// <summary>
        /// 设置上次访问指定文件或目录的日期和时间。
        /// </summary>
        /// <param name="path">要设置其访问日期和时间信息的文件或目录。</param>
        /// <param name="lastAccessTime">System.DateTime，它包含要为 path 的访问日期和时间设置的值。该值用本地时间表示。</param>
        /// <exception cref="System.UnauthorizedAccessException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.PlatformNotSupportedException">当前操作系统不是 Microsoft Windows NT 或更高版本。</exception>
        /// <exception cref="System.ArgumentNullException">path 为 null。</exception>
        /// <exception cref="System.IO.FileNotFoundException">未找到指定的路径。</exception>
        /// <exception cref="System.ArgumentException">path 是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260 个字符。</exception>
        public static void SetLastAccessTime( string path, DateTime lastAccessTime )
        {
        }

        /// <summary>
        /// 设置上次访问指定文件或目录的日期和时间，其格式为协调通用时间 (UTC)。
        /// </summary>
        /// <param name="path">要设置其访问日期和时间信息的文件或目录。</param>
        /// <param name="lastAccessTimeUtc">System.DateTime，它包含要为 path 的访问日期和时间设置的值。该值用 UTC 时间表示。</param>
        /// <exception cref="System.UnauthorizedAccessException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.PlatformNotSupportedException">当前操作系统不是 Microsoft Windows NT 或更高版本。</exception>
        /// <exception cref="System.ArgumentNullException">path 为 null。</exception>
        /// <exception cref="System.IO.FileNotFoundException">未找到指定的路径。</exception>
        /// <exception cref="System.ArgumentException">path 是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260 个字符。</exception>
        public static void SetLastAccessTimeUtc( string path, DateTime lastAccessTimeUtc )
        {
        }

        /// <summary>
        /// 设置上次写入目录的日期和时间。
        /// </summary>
        /// <param name="path">目录的路径。</param>
        /// <param name="lastWriteTime">上次写入目录的日期和时间。该值用本地时间表示。</param>
        /// <exception cref="System."></exception>
        /// <exception cref="System.UnauthorizedAccessException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.PlatformNotSupportedException">当前操作系统不是 Microsoft Windows NT 或更高版本。</exception>
        /// <exception cref="System.ArgumentNullException">path 为 null。</exception>
        /// <exception cref="System.IO.FileNotFoundException">未找到指定的路径。</exception>
        /// <exception cref="System.ArgumentException">path 是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260 个字符。</exception>
        public static void SetLastWriteTime( string path, DateTime lastWriteTime )
        {
        }

        /// <summary>
        /// 设置上次写入某个目录的日期和时间，其格式为协调通用时间 (UTC)。
        /// </summary>
        /// <param name="path">目录的路径。</param>
        /// <param name="lastWriteTimeUtc">上次写入目录的日期和时间。该值用 UTC 时间表示。</param>
        /// <exception cref="System."></exception>
        /// <exception cref="System.UnauthorizedAccessException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.PlatformNotSupportedException">当前操作系统不是 Microsoft Windows NT 或更高版本。</exception>
        /// <exception cref="System.ArgumentNullException">path 为 null。</exception>
        /// <exception cref="System.IO.FileNotFoundException">未找到指定的路径。</exception>
        /// <exception cref="System.ArgumentException">path 是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260 个字符。</exception>
        public static void SetLastWriteTimeUtc( string path, DateTime lastWriteTimeUtc )
        {
        }
        #endregion
    }
}
#endregion

