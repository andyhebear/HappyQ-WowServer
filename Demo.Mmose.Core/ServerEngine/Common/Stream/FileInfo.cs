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
    /// 提供创建、复制、删除、移动和打开文件的实例方法，并且帮助创建 FileInfo 对象。无法继承此类。
    /// </summary>
    public sealed class FileInfo : FileSystemInfo 
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化 System.IO.FileSystemInfo 类的新实例。
        /// </summary>
        public FileInfo()
        {
        }

        /// <summary>
        /// 初始化 System.IO.FileSystemInfo 类的新实例。
        /// </summary>
        /// <param name="fileName"> 新文件的完全限定名或相对文件名。</param>
        public FileInfo( string fileName )
        {
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        /// <summary>
        /// 获取父目录的实例。
        /// </summary>
        /// <returns>表示此文件父目录的 System.IO.DirectoryInfo 对象。</returns>
        /// <exception cref="System.IO.DirectoryNotFoundException">指定的路径无效，比如在未映射的驱动器上。</exception>
        /// <exception cref="System.Security.SecurityException">调用方没有所要求的权限。</exception>
        public DirectoryInfo Directory
        {
            get { return new DirectoryInfo(); }
        }

        /// <summary>
        /// 获取表示目录的完整路径的字符串。
        /// </summary>
        /// <returns>表示目录的完整路径的字符串。</returns>
        /// <exception cref="System.Security.SecurityException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.ArgumentNullException">为目录名传入 null。</exception>
       public string DirectoryName
        {
            get { return string.Empty; }
        }

        /// <summary>
        /// 获取指示文件是否存在的值。
        /// </summary>
        /// <returns>如果该文件存在，则为 true；如果该文件不存在或如果该文件是目录，则为 false。</returns>
        public override bool Exists
        {
            get { return false; }
        }

        /// <summary>
        /// 获取或设置确定当前文件是否为只读的值。
        /// </summary>
        /// <returns>如果当前文件为只读，则为 true；否则为 false。</returns>
        /// <exception cref="System.IO.FileNotFoundException">找不到当前 System.IO.FileInfo 对象所描述的文件。</exception>
        /// <exception cref="System.IO.IOException">打开文件时发生了 I/O 错误。</exception>
        /// <exception cref="System.UnauthorizedAccessException">当前 System.IO.FileInfo 对象描述的文件是只读文件。- 或 - 在当前平台上不支持此操作。- 或 - 调用方没有所要求的权限。</exception>
        public bool IsReadOnly
        {
            get { return false; }
            set
            {
                 //= value;
            }
        }

        /// <summary>
        /// 获取当前文件的大小。
        /// </summary>
        /// <returns>当前文件的大小。</returns>
        /// <exception cref="System.IO.IOException">System.IO.FileSystemInfo.Refresh() 无法更新文件或目录的状态。</exception>
        /// <exception cref="System.IO.FileNotFoundException">文件不存在。- 或 - 为一个目录调用 Length 属性。</exception>
        public long Length
        {
            get { return 0; }
        }

        /// <summary>
        /// 获取文件名。
        /// </summary>
        /// <returns>文件名。</returns>
        public override string Name
        {
            get { return string.Empty; }
        }
        #endregion

        #region zh-CHS 共有方法 | en Public Methods
        /// <summary>
        /// 创建一个 System.IO.StreamWriter，它向 System.IO.FileInfo 的此实例表示的文件追加文本。
        /// </summary>
        /// <returns>新的 StreamWriter。</returns>
        public StreamWriter AppendText()
        {
            return new StreamWriter();
        }

        /// <summary>
        /// 将现有文件复制到新文件，不允许改写现有文件。
        /// </summary>
        /// <param name="destFileName">要复制到的新文件的名称。</param>
        /// <returns>带有完全限定路径的新文件。</returns>
        /// <exception cref="System.ArgumentException">destFileName 为空，仅包含空白，或包含无效字符。</exception>
        /// <exception cref="System.UnauthorizedAccessException">传入了一个目录路径，或者正在将文件移动到另一个驱动器。</exception>
        /// <exception cref="System.NotSupportedException">destFileName 的字符串中间包含一个冒号 (:)。</exception>
        /// <exception cref="System.ArgumentNullException">destFileName 为 null。</exception>
        /// <exception cref="System.IO.IOException">发生错误或目标文件已经存在。</exception>
        /// <exception cref="System.Security.SecurityException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260 个字符。</exception>
        public FileInfo CopyTo( string destFileName )
        {
            return new FileInfo();
        }

        /// <summary>
        /// 将现有文件复制到新文件，允许改写现有文件。
        /// </summary>
        /// <param name="destFileName">要复制到的新文件的名称。</param>
        /// <param name="overwrite">若为 true，则允许改写现有文件；否则为 false。</param>
        /// <returns>新文件，或者如果 overwrite 为 true，则为现有文件的改写。如果文件存在，且 overwrite 为 false，则会发生 System.IO.IOException。</returns>
        /// <exception cref="System.ArgumentException">destFileName 为空，仅包含空白，或包含无效字符。</exception>
        /// <exception cref="System.UnauthorizedAccessException">传入了一个目录路径，或者正在将文件移动到另一个驱动器。</exception>
        /// <exception cref="System.NotSupportedException">destFileName 的字符串中间包含一个冒号 (:)。</exception>
        /// <exception cref="System.IO.IOException">发生错误，或者目标文件已经存在，并且 overwrite 为 false。</exception>
        /// <exception cref="System.ArgumentNullException"> destFileName 为 null。</exception>
        /// <exception cref="System.Security.SecurityException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260 个字符。</exception>
        public FileInfo CopyTo( string destFileName, bool overwrite )
        {
            return new FileInfo();
        }

        /// <summary>
        /// 创建文件。
        /// </summary>
        /// <returns>新文件。</returns>
        public FileStream Create()
        {
            return new FileStream();
        }

        /// <summary>
        /// 创建写入新文本文件的 System.IO.StreamWriter。
        /// </summary>
        /// <returns>新的 StreamWriter。</returns>
        /// <exception cref="System.UnauthorizedAccessException">文件名为目录。</exception>
        /// <exception cref="System.Security.SecurityException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.IO.IOException">磁盘为只读。</exception>
        public StreamWriter CreateText()
        {
            return new StreamWriter();
        }

        /// <summary>
        /// 使用 System.IO.FileInfo.Encrypt() 方法解密由当前帐户加密的文件。
        /// </summary>
        /// <exception cref="System.PlatformNotSupportedException">当前操作系统不是 Microsoft Windows NT 或更高版本。</exception>
        /// <exception cref="System.IO.FileNotFoundException">找不到当前 System.IO.FileInfo 对象所描述的文件。</exception>
        /// <exception cref="System.IO.IOException">打开文件时发生了 I/O 错误。</exception>
        /// <exception cref="System.NotSupportedException">文件系统不是 NTFS。</exception>
        /// <exception cref="System.IO.DriveNotFoundException">指定了无效的驱动器。</exception>
        /// <exception cref="System.UnauthorizedAccessException">当前 System.IO.FileInfo 对象描述的文件是只读文件。- 或 - 在当前平台上不支持此操作。- 或 - 调用方没有所要求的权限。</exception>
        public void Decrypt()
        {
        }

        /// <summary>
        /// 永久删除文件。
        /// </summary>
        /// <exception cref="System.UnauthorizedAccessException">路径是目录。</exception>
        /// <exception cref="System.IO.IOException">目标文件已打开或内存映射到运行 Microsoft Windows NT 的计算机上。</exception>
        /// <exception cref="System.Security.SecurityException">调用方没有所要求的权限。</exception>
        public override void Delete()
        {
        }

        /// <summary>
        /// 将某个文件加密，使得只有加密该文件的帐户才能将其解密。
        /// </summary>
        /// <exception cref="System.PlatformNotSupportedException">当前操作系统不是 Microsoft Windows NT 或更高版本。</exception>
        /// <exception cref="System.IO.FileNotFoundException">找不到当前 System.IO.FileInfo 对象所描述的文件。</exception>
        /// <exception cref="System.IO.IOException">打开文件时发生了 I/O 错误。</exception>
        /// <exception cref="System.NotSupportedException">文件系统不是 NTFS。</exception>
        /// <exception cref="System.IO.DriveNotFoundException">指定了无效的驱动器。</exception>
        /// <exception cref="System.UnauthorizedAccessException">当前 System.IO.FileInfo 对象描述的文件是只读文件。- 或 - 在当前平台上不支持此操作。- 或 - 调用方没有所要求的权限。</exception>
        public void Encrypt()
        {
        }

        //
        // 摘要:
        //     获取 System.Security.AccessControl.FileSecurity 对象，该对象封装当前 System.IO.FileInfo
        //     对象所描述的文件的访问控制列表 (ACL) 项。
        //
        // 返回结果:
        //     一个 System.Security.AccessControl.FileSecurity 对象，该对象封装当前文件的访问控制规则。
        //
        // 异常:
        //   System.Security.AccessControl.PrivilegeNotHeldException:
        //     当前系统帐户没有管理特权。
        //
        //   System.PlatformNotSupportedException:
        //     当前操作系统不是 Microsoft Windows 2000 或更高版本。
        //
        //   System.IO.IOException:
        //     打开文件时发生了 I/O 错误。
        //
        //   System.UnauthorizedAccessException:
        //     在当前平台上不支持此操作。- 或 - 调用方没有所要求的权限。
        //
        //   System.SystemException:
        //     未能找到文件。
        //public FileSecurity GetAccessControl()
        //{
        //}

        //
        // 摘要:
        //     获取 System.Security.AccessControl.FileSecurity 对象，该对象封装当前 System.IO.FileInfo
        //     对象所描述的文件的指定类型的访问控制列表 (ACL) 项。
        //
        // 参数:
        //   includeSections:
        //     System.Security.AccessControl.AccessControlSections 值之一，该值指定要检索的访问控制项组。
        //
        // 返回结果:
        //     一个 System.Security.AccessControl.FileSecurity 对象，该对象封装当前文件的访问控制规则。
        //
        // 异常:
        //   System.Security.AccessControl.PrivilegeNotHeldException:
        //     当前系统帐户没有管理特权。
        //
        //   System.PlatformNotSupportedException:
        //     当前操作系统不是 Microsoft Windows 2000 或更高版本。
        //
        //   System.IO.IOException:
        //     打开文件时发生了 I/O 错误。
        //
        //   System.UnauthorizedAccessException:
        //     在当前平台上不支持此操作。- 或 - 调用方没有所要求的权限。
        //
        //   System.SystemException:
        //     未能找到文件。
        //public FileSecurity GetAccessControl( AccessControlSections includeSections )
        //{
        //}

        /// <summary>
        /// 将指定文件移到新位置，并提供指定新文件名的选项。
        /// </summary>
        /// <param name="destFileName">要将文件移动到的路径，可以指定另一个文件名。</param>
        /// <exception cref="System.IO.IOException">发生 I/O 错误，如目标文件已经存在或目标设备未准备好。</exception>
        /// <exception cref="System.ArgumentException">destFileName 为空，仅包含空白，或包含无效字符。</exception>
        /// <exception cref="System.IO.FileNotFoundException">找不到该文件。</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">指定的路径无效，比如在未映射的驱动器上。</exception>
        /// <exception cref="System.UnauthorizedAccessException">destFileName 为只读，或者是一个目录。</exception>
        /// <exception cref="System.NotSupportedException">destFileName 的字符串中间包含一个冒号 (:)。</exception>
        /// <exception cref="System.ArgumentNullException">destFileName 为 null。</exception>
        /// <exception cref="System.Security.SecurityException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260 个字符。</exception>
        public void MoveTo( string destFileName )
        {
        }

        /// <summary>
        /// 在指定的模式中打开文件。
        /// </summary>
        /// <param name="mode">一个 System.IO.FileMode 常数，它指定打开文件所采用的模式（例如 Open 或 Append）。</param>
        /// <returns>在指定模式中打开、具有读/写访问权限且不共享的文件。</returns>
        /// <exception cref="System.UnauthorizedAccessException">此文件是只读文件，或者是一个目录。</exception>
        /// <exception cref="System.IO.FileNotFoundException">找不到该文件。</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">指定的路径无效，比如在未映射的驱动器上。</exception>
        /// <exception cref="System.IO.IOException">该文件已打开。</exception>
        public FileStream Open( FileMode mode )
        {
            return new FileStream();
        }

        /// <summary>
        /// 用读、写或读/写访问权限在指定模式下打开文件。
        /// </summary>
        /// <param name="mode">一个 System.IO.FileMode 常数，它指定打开文件所采用的模式（例如 Open 或 Append）。</param>
        /// <param name="access">一个 System.IO.FileAccess 常数，它指定是使用 Read、Write 还是 ReadWrite 文件访问权限来打开文件。</param>
        /// <returns>用指定模式和访问权限打开且不共享的 System.IO.FileStream 对象。</returns>
        /// <exception cref="System.IO.IOException">该文件已打开。</exception>
        /// <exception cref="System.IO.FileNotFoundException">找不到该文件。</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">指定的路径无效，比如在未映射的驱动器上。</exception>
        /// <exception cref="System.ArgumentNullException">一个或多个参数为 null。</exception>
        /// <exception cref="System.ArgumentException">path 为空，或者只包含空白。</exception>
        /// <exception cref="System.Security.SecurityException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.UnauthorizedAccessException">path 为只读，或者是一个目录。</exception>
        public FileStream Open( FileMode mode, FileAccess access )
        {
            return new FileStream();
        }

        /// <summary>
        /// 用读、写或读/写访问权限和指定的共享选项在指定的模式中打开文件。
        /// </summary>
        /// <param name="mode">一个 System.IO.FileMode 常数，它指定打开文件所采用的模式（例如 Open 或 Append）。</param>
        /// <param name="access">一个 System.IO.FileAccess 常数，它指定是使用 Read、Write 还是 ReadWrite 文件访问权限来打开文件。</param>
        /// <param name="share">一个 System.IO.FileShare 常数，它指定其他 FileStream 对象对此文件拥有的访问类型。</param>
        /// <returns>用指定的模式、访问权限和共享选项打开的 System.IO.FileStream 对象。</returns>
        /// <exception cref="System.IO.IOException">该文件已打开。</exception>
        /// <exception cref="System.IO.FileNotFoundException">找不到该文件。</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">指定的路径无效，比如在未映射的驱动器上。</exception>
        /// <exception cref="System.ArgumentNullException">一个或多个参数为 null。</exception>
        /// <exception cref="System.ArgumentException">path 为空，或者只包含空白。</exception>
        /// <exception cref="System.Security.SecurityException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.UnauthorizedAccessException">path 为只读，或者是一个目录。</exception>
        public FileStream Open( FileMode mode, FileAccess access, FileShare share )
        {
            return new FileStream();
        }

        /// <summary>
        /// 创建只读 System.IO.FileStream。
        /// </summary>
        /// <returns>新的只读 System.IO.FileStream 对象。</returns>
        /// <exception cref="System.IO.IOException">该文件已打开。</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">指定的路径无效，比如在未映射的驱动器上。</exception>
        /// <exception cref="System.UnauthorizedAccessException"> path 为只读，或者是一个目录。</exception>
        public FileStream OpenRead()
        {
            return new FileStream();
        }

        /// <summary>
        /// 创建使用 UTF8 编码、从现有文本文件中进行读取的 System.IO.StreamReader。
        /// </summary>
        /// <returns>使用 UTF8 编码的新 StreamReader。</returns>
        /// <exception cref="System.IO.FileNotFoundException">找不到该文件。</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">指定的路径无效，比如在未映射的驱动器上。</exception>
        /// <exception cref="System.Security.SecurityException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.UnauthorizedAccessException">path 为只读，或者是一个目录。</exception>
        public StreamReader OpenText()
        {
            return new StreamReader();
        }

        /// <summary>
        /// 创建只写 System.IO.FileStream。
        /// </summary>
        /// <returns>新的只写不共享的 System.IO.FileStream 对象。</returns>
        /// <exception cref="System.IO.DirectoryNotFoundException">指定的路径无效，比如在未映射的驱动器上。</exception>
        /// <exception cref="System.UnauthorizedAccessException">path 为只读，或者是一个目录。</exception>
        public FileStream OpenWrite()
        {
            return new FileStream();
        }

        /// <summary>
        /// 使用当前 System.IO.FileInfo 对象所描述的文件替换指定文件的内容，这一过程将删除原始文件，并创建被替换文件的备份。
        /// </summary>
        /// <param name="destinationFileName">要替换为当前文件的文件的名称。</param>
        /// <param name="destinationBackupFileName">文件的名称，该文件用于创建 destFileName 参数所描述的文件的备份。</param>
        /// <returns>一个 System.IO.FileInfo 对象，该对象封装有关 destFileName 参数所描述的文件的信息。</returns>
        /// <exception cref="System.ArgumentNullException">destFileName 参数为 null。</exception>
        /// <exception cref="System.PlatformNotSupportedException">当前操作系统不是 Microsoft Windows NT 或更高版本。</exception>
        /// <exception cref="System.ArgumentException">destFileName 参数描述的路径不是合法的形式。- 或 -destBackupFileName 参数描述的路径不是合法的形式。</exception>
        /// <exception cref="System.IO.FileNotFoundException">找不到当前 System.IO.FileInfo 对象所描述的文件。- 或 -找不到 destBackupFileName 参数所描述的文件。</exception>
        public FileInfo Replace( string destinationFileName, string destinationBackupFileName )
        {
            return new FileInfo();
        }

        /// <summary>
        /// 使用当前 System.IO.FileInfo 对象所描述的文件替换指定文件的内容，这一过程将删除原始文件，并创建被替换文件的备份。还指定是否忽略合并错误。
        /// </summary>
        /// <param name="destinationFileName">要替换为当前文件的文件的名称。</param>
        /// <param name="destinationBackupFileName">文件的名称，该文件用于创建 destFileName 参数所描述的文件的备份。</param>
        /// <param name="ignoreMetadataErrors">若要忽略从被替换文件到替换文件的合并错误（例如属性和 ACL），请设置为 true；否则设置为 false。</param>
        /// <returns>一个 System.IO.FileInfo 对象，该对象封装有关 destFileName 参数所描述的文件的信息。</returns>
        /// <exception cref="System.ArgumentNullException">destFileName 参数为 null。</exception>
        /// <exception cref="System.PlatformNotSupportedException">当前操作系统不是 Microsoft Windows NT 或更高版本。</exception>
        /// <exception cref="System.ArgumentException">destFileName 参数描述的路径不是合法的形式。- 或 -destBackupFileName 参数描述的路径不是合法的形式。</exception>
        /// <exception cref="System.IO.FileNotFoundException">找不到当前 System.IO.FileInfo 对象所描述的文件。- 或 -找不到 destBackupFileName 参数所描述的文件。</exception>
        public FileInfo Replace( string destinationFileName, string destinationBackupFileName, bool ignoreMetadataErrors )
        {
            return new FileInfo();
        }

        /// <summary>
        /// 将 System.Security.AccessControl.FileSecurity 对象所描述的访问控制列表 (ACL) 项应用于当前 System.IO.FileInfo 对象所描述的文件。
        /// </summary>
        /// <param name="fileSecurity">一个 System.Security.AccessControl.FileSecurity 对象，该对象描述要应用于当前文件的访问控制列表 (ACL) 项。</param>
        /// <exception cref="System.SystemException">未能找到或修改文件。</exception>
        /// <exception cref="System.ArgumentNullException">fileSecurity 参数为 null。</exception>
        /// <exception cref="System.PlatformNotSupportedException">当前操作系统不是 Microsoft Windows 2000 或更高版本。</exception>
        /// <exception cref="System.UnauthorizedAccessException">当前进程不具有打开该文件的权限。</exception>
        public void SetAccessControl( FileSecurity fileSecurity )
        {
        }

        /// <summary>
        /// 以字符串形式返回路径。
        /// </summary>
        /// <returns>表示路径的字符串。</returns>
        public override string ToString()
        {
            return string.Empty;
        }
        #endregion
    }
}
#endregion

