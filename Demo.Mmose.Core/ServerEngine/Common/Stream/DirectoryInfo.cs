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
using System.IO;
using System.Security.AccessControl;
#endregion

namespace Demo.Mmose.Core.Common.Stream
{
    /// <summary>
    /// 公开用于创建、移动和枚举目录和子目录的实例方法。无法继承此类。
    /// </summary>
    public sealed class DirectoryInfo : FileSystemInfo
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 在指定的路径中初始化 System.IO.DirectoryInfo 类的新实例。
        /// </summary>
        /// <param name="path">一个字符串，它指定要在其中创建 DirectoryInfo 的路径。</param>
        /// <exception cref="System.ArgumentNullException">path 为 null。</exception>
        /// <exception cref="System.ArgumentException">path 包含无效字符，如 "、&lt、&gt 或 |。</exception>
        /// <exception cref="System.Security.SecurityException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260 个字符。指定的路径、文件名或两者都太长。</exception>
        public DirectoryInfo()
        {
        }

        /// <summary>
        /// 在指定的路径中初始化 System.IO.DirectoryInfo 类的新实例。
        /// </summary>
        /// <param name="path">一个字符串，它指定要在其中创建 DirectoryInfo 的路径。</param>
        /// <exception cref="System.ArgumentNullException">path 为 null。</exception>
        /// <exception cref="System.ArgumentException">path 包含无效字符，如 "、&lt、&gt 或 |。</exception>
        /// <exception cref="System.Security.SecurityException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260 个字符。指定的路径、文件名或两者都太长。</exception>
        public DirectoryInfo( string path )
        {
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        /// <summary>
        /// 获取指示目录是否存在的值。
        /// </summary>
        /// <returns>如果目录存在，则为 true；否则为 false。</returns>
        public override bool Exists
        {
            get { return false; }
        }

        /// <summary>
        /// 获取此 System.IO.DirectoryInfo 实例的名称。
        /// </summary>
        /// <returns>目录名称。</returns>
        public override string Name
        {
            get { return string.Empty; }
        }

        /// <summary>
        /// 获取指定子目录的父目录。
        /// </summary>
        /// <returns>父目录，或者如果路径为空或如果文件路径表示根（如“\”、“C:”或 *“\\server\share”），则为null。</returns>
        /// <exception cref="System.Security.SecurityException">调用方没有所要求的权限。</exception>
        public DirectoryInfo Parent
        {
            get { return new DirectoryInfo(); }
        }

        /// <summary>
        /// 获取路径的根部分。
        /// </summary>
        /// <returns>代表路径的根的 System.IO.DirectoryInfo 对象。</returns>
        /// <exception cref="System.Security.SecurityException">调用方没有所要求的权限。</exception>
        public DirectoryInfo Root
        {
            get { return new DirectoryInfo(); }
        }
        #endregion

        #region zh-CHS 共有方法 | en Public Methods
        /// <summary>
        /// 创建目录。
        /// </summary>
        /// <exception cref="System.IO.IOException">不能创建该目录。</exception>
        public void Create()
        {
        }

        /// <summary>
        /// 使用 System.Security.AccessControl.DirectorySecurity 对象创建目录。
        /// </summary>
        /// <param name="directorySecurity">要应用于此目录的访问控制。</param>
        /// <exception cref="System.UnauthorizedAccessException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.IO.IOException">由 path 指定的目录是只读的或不为空。</exception>
        /// <exception cref="System.ArgumentNullException">path 为 null。</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">指定的路径无效，比如在未映射的驱动器上。</exception>
        /// <exception cref="System.ArgumentException">path 是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260 个字符。</exception>
        /// <exception cref="System.NotSupportedException">试图仅通过冒号 (:) 字符创建目录。</exception>
        public void Create( DirectorySecurity directorySecurity )
        {
        }

        /// <summary>
        /// 在指定路径中创建一个或多个子目录。指定路径可以是相对于 System.IO.DirectoryInfo 类的此实例的路径。
        /// </summary>
        /// <param name="path">指定的路径。它不能是另一个磁盘卷或“统一命名约定”(UNC) 名称。</param>
        /// <returns>在 path 中指定的最后一个目录。</returns>
        /// <exception cref="System.IO.IOException">不能创建子目录。- 或 - 已有文件或目录具有 path 所指定的名称。</exception>
        /// <exception cref="System.ArgumentNullException">path 为 null。</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">指定的路径无效，比如在未映射的驱动器上。</exception>
        /// <exception cref="System.ArgumentException">path 未指定有效文件路径或包含无效的 DirectoryInfo 字符。</exception>
        /// <exception cref="System.Security.SecurityException">调用方不具有创建目录的代码访问权限。- 或 -调用方不具有读取返回的 System.IO.DirectoryInfo 对象描述的目录的代码访问权限。这可能在 path 参数描述现有目录时发生。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260 个字符。指定的路径、文件名或两者都太长。</exception>
        public DirectoryInfo CreateSubdirectory( string path )
        {
            return new DirectoryInfo();
        }

        /// <summary>
        /// 使用指定的安全性在指定的路径上创建一个或多个子目录。指定路径可以是相对于 System.IO.DirectoryInfo 类的此实例的路径。
        /// </summary>
        /// <param name="path">指定的路径。它不能是另一个磁盘卷或“统一命名约定”(UNC) 名称。</param>
        /// <param name="directorySecurity">要应用的安全性。</param>
        /// <returns>在 path 中指定的最后一个目录。</returns>
        /// <exception cref="System.IO.IOException">不能创建子目录。- 或 - 已有文件或目录具有 path 所指定的名称。</exception>
        /// <exception cref="System.ArgumentNullException">path 为 null。</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">指定的路径无效，比如在未映射的驱动器上。</exception>
        /// <exception cref="System.ArgumentException">path 未指定有效文件路径或包含无效的 DirectoryInfo 字符。</exception>
        /// <exception cref="System.Security.SecurityException">调用方不具有创建目录的代码访问权限。- 或 -调用方不具有读取返回的 System.IO.DirectoryInfo 对象描述的目录的代码访问权限。这可能在 path 参数描述现有目录时发生。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260 个字符。指定的路径、文件名或两者都太长。</exception>
        public DirectoryInfo CreateSubdirectory( string path, DirectorySecurity directorySecurity )
        {
            return new DirectoryInfo();
        }

        /// <summary>
        /// 如果此 System.IO.DirectoryInfo 为空，则删除它。
        /// </summary>
        /// <exception cref="System.Security.SecurityException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.IO.IOException">目录不为空。 - 或 -该目录为应用程序的当前工作目录。</exception>
        public override void Delete()
        {
        }

        /// <summary>
        /// 删除 System.IO.DirectoryInfo 的此实例，指定是否要删除子目录和文件。
        /// </summary>
        /// <param name="recursive">若为 true，则删除此目录、其子目录以及所有文件；否则为 false。</param>
        /// <exception cref="System.IO.IOException">目录为只读。- 或 - 此目录包含一个或多个文件或子目录，且 recursive 为 false。- 或 -该目录为应用程序的当前工作目录。</exception>
        /// <exception cref="System..Security.SecurityException">调用方没有所要求的权限。</exception>
        public void Delete( bool recursive )
        {
        }

        //
        // 摘要:
        //     获取 System.Security.AccessControl.DirectorySecurity 对象，该对象封装当前 System.IO.DirectoryInfo
        //     对象所描述的目录的访问控制列表 (ACL) 项。
        //
        // 返回结果:
        //     一个 System.Security.AccessControl.DirectorySecurity 对象，该对象封装此目录的访问控制规则。
        //
        // 异常:
        //   System.PlatformNotSupportedException:
        //     当前操作系统不是 Microsoft Windows 2000 或更高版本。
        //
        //   System.IO.IOException:
        //     打开目录时发生了 I/O 错误。
        //
        //   System.UnauthorizedAccessException:
        //     目录为只读。- 或 - 在当前平台上不支持此操作。- 或 - 调用方没有所要求的权限。
        //
        //   System.SystemException:
        //     未能找到或修改该目录。
        //
        //   System.UnauthorizedAccessException:
        //     当前进程不具有打开该目录的权限。
        //public DirectorySecurity GetAccessControl()
        //{
        //}

        //
        // 摘要:
        //     获取 System.Security.AccessControl.DirectorySecurity 对象，该对象封装当前 System.IO.DirectoryInfo
        //     对象所描述的目录的指定类型的访问控制列表 (ACL) 项。
        //
        // 参数:
        //   includeSections:
        //     System.Security.AccessControl.AccessControlSections 值之一，它指定要接收的访问控制列表 (ACL)
        //     信息的类型。
        //
        // 返回结果:
        //     一个 System.Security.AccessControl.DirectorySecurity 对象，该对象封装 path 参数所描述的文件的访问控制规则。异常异常类型条件System.SystemException未能找到或修改该目录。System.UnauthorizedAccessException当前进程不具有打开该目录的权限。System.IO.IOException打开目录时发生了
        //     I/O 错误。System.PlatformNotSupportedException当前操作系统不是 Microsoft Windows 2000
        //     或更高版本。System.UnauthorizedAccessException目录为只读。- 或 - 在当前平台上不支持此操作。- 或 - 调用方没有所要求的权限。
        //public DirectorySecurity GetAccessControl( AccessControlSections includeSections )
        //{
        //}

        /// <summary>
        /// 返回当前目录的子目录。
        /// </summary>
        /// <returns>System.IO.DirectoryInfo 对象的数组。</returns>
        /// <exception cref="System.IO.DirectoryNotFoundException">封装在 DirectoryInfo 对象中的路径无效，比如在未映射的驱动器上。</exception>
        public DirectoryInfo[] GetDirectories()
        {
            return new DirectoryInfo[0];
        }

        /// <summary>
        /// 返回当前 System.IO.DirectoryInfo 中、与给定搜索条件匹配的目录的数组。
        /// </summary>
        /// <param name="searchPattern">搜索字符串，如用于搜索所有以单词“System”开头的目录的“System*”。</param>
        /// <returns>与 searchPattern 匹配的 DirectoryInfo 类型的数组。</returns>
        /// <exception cref="System.ArgumentNullException">searchPattern 为 null。</exception>
        /// <exception cref="System.Security.SecurityException">调用方没有所要求的权限</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">封装在 DirectoryInfo 对象中的路径无效，比如在未映射的驱动器上。</exception>
        public DirectoryInfo[] GetDirectories( string searchPattern )
        {
            return new DirectoryInfo[0];
        }

        /// <summary>
        /// 返回当前 System.IO.DirectoryInfo 中与给定的搜索条件匹配并使用某个值确定是否在子目录中搜索的目录的数组。
        /// </summary>
        /// <param name="searchPattern">搜索字符串，如用于搜索所有以单词“System”开头的目录的“System*”。</param>
        /// <param name="searchOption">System.IO.SearchOption 枚举的一个值，指定搜索操作是应仅包含当前目录还是应包含所有子目录。</param>
        /// <returns>与 searchPattern 匹配的 DirectoryInfo 类型的数组。</returns>
        /// <exception cref="System.ArgumentNullException">searchPattern 为 null。</exception>
        /// <exception cref="System.Security.SecurityException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">封装在 DirectoryInfo 对象中的路径无效，比如在未映射的驱动器上。</exception>
        public DirectoryInfo[] GetDirectories( string searchPattern, SearchOption searchOption )
        {
            return new DirectoryInfo[0];
        }

        /// <summary>
        /// 返回当前目录的文件列表。
        /// </summary>
        /// <returns>System.IO.FileInfo 类型数组。</returns>
        /// <exception cref="System.IO.DirectoryNotFoundException">该路径无效，比如在未映射的驱动器上。</exception>
        public FileInfo[] GetFiles()
        {
            return new FileInfo[0];
        }

        /// <summary>
        /// 返回当前目录中与给定的 searchPattern 匹配的文件列表。
        /// </summary>
        /// <param name="searchPattern">搜索字符串（如“*.txt”）。</param>
        /// <returns>System.IO.FileInfo 类型数组。</returns>
        /// <exception cref="System.ArgumentNullException">searchPattern 为 null。</exception>
        /// <exception cref="System.Security.SecurityException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">该路径无效，比如在未映射的驱动器上。</exception>
        public FileInfo[] GetFiles( string searchPattern )
        {
            return new FileInfo[0];
        }

        /// <summary>
        /// 返回与给定的 searchPattern 匹配并且使用某个值确定是否在子目录中进行搜索的当前目录的文件列表。
        /// </summary>
        /// <param name="searchPattern">搜索字符串，如用于搜索所有以单词“System”开头的目录的“System*”。</param>
        /// <param name="searchOption">System.IO.SearchOption 枚举的一个值，指定搜索操作是应仅包含当前目录还是应包含所有子目录。</param>
        /// <returns>System.IO.FileInfo 类型数组。</returns>
        /// <exception cref="System.ArgumentNullException">searchPattern 为 null。</exception>
        /// <exception cref="System.Security.SecurityException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">该路径无效，比如在未映射的驱动器上。</exception>
        public FileInfo[] GetFiles( string searchPattern, SearchOption searchOption )
        {
            return new FileInfo[0];
        }

        /// <summary>
        /// 返回表示某个目录中所有文件和子目录的强类型 System.IO.FileSystemInfo 项的数组。
        /// </summary>
        /// <returns>强类型 System.IO.FileSystemInfo 项的数组。</returns>
        /// <exception cref="System.IO.DirectoryNotFoundException">该路径无效，比如在未映射的驱动器上。</exception>
        public FileSystemInfo[] GetFileSystemInfos()
        {
            return new FileInfo[0];
        }

        /// <summary>
        /// 检索表示与指定的搜索条件匹配的文件和子目录的强类型 System.IO.FileSystemInfo 对象的数组。
        /// </summary>
        /// <param name="searchPattern">搜索字符串，如用于搜索所有以单词“System”开头的目录的“System*”。</param>
        /// <returns>与搜索条件匹配的强类型 FileSystemInfo 对象的数组。</returns>
        /// <exception cref="System.IO.DirectoryNotFoundException">指定的路径无效，比如在未映射的驱动器上。</exception>
        /// <exception cref="System.ArgumentNullException">searchPattern 为 null。</exception>
        /// <exception cref="System.Security.SecurityException">调用方没有所要求的权限。</exception>
        public FileSystemInfo[] GetFileSystemInfos( string searchPattern )
        {
            return new FileInfo[0];
        }

        /// <summary>
        /// 将 System.IO.DirectoryInfo 实例及其内容移动到新路径。
        /// </summary>
        /// <param name="destDirName">要将此目录移动到的目标位置的名称和路径。目标不能是另一个具有相同名称的磁盘卷或目录。它可以是您要将此目录作为子目录添加到其中的一个现有目录。</param>
        /// <exception cref="System.ArgumentException">destDirName 是空字符串 ("")。</exception>
        /// <exception cref="System.IO.IOException">试图将目录移动到另一个卷或 destDirName 已经存在。</exception>
        /// <exception cref="System.Security.SecurityException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.ArgumentNullException">destDirName 为null。- 或 - 被移动的目录与目标目录同名。</exception>
        public void MoveTo( string destDirName )
        {
        }

        /// <summary>
        /// 将 System.Security.AccessControl.DirectorySecurity 对象所描述的访问控制列表 (ACL) 项应用于当前 System.IO.DirectoryInfo 对象所描述的目录。
        /// </summary>
        /// <param name="directorySecurity">一个 System.Security.AccessControl.DirectorySecurity 对象，该对象描述要应用于 path 参数所描述的目录的 ACL 项。</param>
        /// <exception cref="System.SystemException">未能找到或修改文件。</exception>
        /// <exception cref="System.PlatformNotSupportedException">当前操作系统不是 Microsoft Windows 2000 或更高版本。</exception>
        /// <exception cref="System.UnauthorizedAccessException">当前进程不具有打开该文件的权限。</exception>
        /// <exception cref="System.ArgumentNullException">directorySecurity 参数为null。</exception>
        public void SetAccessControl( DirectorySecurity directorySecurity )
        {
        }

        /// <summary>
        /// 返回用户所传递的原始路径。
        /// </summary>
        /// <returns>返回用户所传递的原始路径。</returns>
        public override string ToString()
        {
            return string.Empty;
        }
        #endregion
    }
}
#endregion

