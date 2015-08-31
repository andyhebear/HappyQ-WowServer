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
using System.Text;
#endregion

namespace Demo.Mmose.Core.Common.Stream
{
    /// <summary>
    /// 提供用于创建、复制、删除、移动和打开文件的静态方法，并协助创建 FileStream 对象。
    /// </summary>
    public class File
    {
        #region zh-CHS 共有静态方法 | en Public Static Methods
        /// <summary>
        /// 打开一个文件，向其中追加指定的字符串，然后关闭该文件。如果文件不存在，此方法创建一个文件，将指定的字符串写入文件，然后关闭该文件。
        /// </summary>
        /// <param name="path">要将指定的字符串追加到的文件。</param>
        /// <param name="contents">要追加到文件中的字符串。</param>
        /// <exception cref="System.ArgumentNullException">path 为 null。</exception>
        /// <exception cref="System.UnauthorizedAccessException">path 指定了一个只读文件。- 或 - 在当前平台上不支持此操作。- 或 - path 指定了一个目录。- 或 - 调用方没有所要求的权限。</exception>
        /// <exception cref="System.NotSupportedException">path 的格式无效。</exception>
        /// <exception cref="System.IO.FileNotFoundException">未找到 path 中指定的文件。</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">指定的路径无效（例如，它位于未映射的驱动器上）。</exception>
        /// <exception cref="System.Security.SecurityException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.ArgumentException">path 是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260 个字符。</exception>
        /// <exception cref="System.IO.IOException">打开文件时发生了 I/O 错误。</exception>
        public static void AppendAllText( string path, string contents )
        {
        }

        /// <summary>
        /// 将指定的字符串追加到文件中，如果文件还不存在则创建该文件。
        /// </summary>
        /// <param name="path">要将指定的字符串追加到的文件。</param>
        /// <param name="contents">要追加到文件中的字符串。</param>
        /// <param name="encoding">要使用的字符编码。</param>
        /// <exception cref="System.ArgumentNullException">path 为 null。</exception>
        /// <exception cref="System.UnauthorizedAccessException">path 指定了一个只读文件。- 或 - 在当前平台上不支持此操作。- 或 - path 指定了一个目录。- 或 - 调用方没有所要求的权限。</exception>
        /// <exception cref="System.NotSupportedException">path 的格式无效。</exception>
        /// <exception cref="System.IO.FileNotFoundException">未找到 path 中指定的文件。</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">指定的路径无效（例如，它位于未映射的驱动器上）。</exception>
        /// <exception cref="System.Security.SecurityException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.ArgumentException">path 是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260 个字符。</exception>
        /// <exception cref="System.IO.IOException">打开文件时发生了 I/O 错误。</exception>
        public static void AppendAllText( string path, string contents, Encoding encoding )
        {
        }

        /// <summary>
        /// 创建一个 System.IO.StreamWriter，它将 UTF-8 编码文本追加到现有文件。
        /// </summary>
        /// <param name="path">要向其中追加内容的文件的路径。</param>
        /// <returns>一个 StreamWriter，它将 UTF-8 编码文本追加到现有文件。</returns>
        /// <exception cref="System.UnauthorizedAccessException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.NotSupportedException">path 的格式无效。</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">指定的路径无效（例如，它位于未映射的驱动器上）。</exception>
        /// <exception cref="System.ArgumentNullException">path 为 null。</exception>
        /// <exception cref="System.ArgumentException">path 是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260</exception>
        public static StreamWriter AppendText( string path )
        {
            return new StreamWriter();
        }

        /// <summary>
        /// 将现有文件复制到新文件。不允许改写同名的文件。
        /// </summary>
        /// <param name="sourceFileName">要复制的文件。</param>
        /// <param name="destFileName">目标文件的名称。它不能是一个目录或现有文件。</param>
        /// <exception cref="System.UnauthorizedAccessException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.IO.IOException">destFileName 是只读的，或者 destFileName 存在并且 overwrite 是 false。- 或 - 出现 I/O 错误。</exception>
        /// <exception cref="System.ArgumentNullException">sourceFileName 或 destFileName 为 null。</exception>
        /// <exception cref="System.NotSupportedException">sourceFileName 或 destFileName 的格式无效。</exception>
        /// <exception cref="System.IO.FileNotFoundException">未找到 sourceFileName。</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">在 sourceFileName 或 destFileName 中指定的路径无效（例如，它位于未映射的驱动器上）。</exception>
        /// <exception cref="System.ArgumentException">sourceFileName 或 destFileName 是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。- 或 - sourceFileName 或 destFileName 指定目录。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260 个字符。</exception>
        public static void Copy( string sourceFileName, string destFileName )
        {
        }

        /// <summary>
        /// 将现有文件复制到新文件。允许改写同名的文件。
        /// </summary>
        /// <param name="sourceFileName">要复制的文件。</param>
        /// <param name="destFileName">目标文件的名称。不能是目录。</param>
        /// <param name="overwrite">如果可以改写目标文件，则为 true；否则为 false。</param>
        /// <exception cref="System.UnauthorizedAccessException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.IO.IOException">destFileName 是只读的，或者 destFileName 存在并且 overwrite 是 false。- 或 - 出现 I/O 错误。</exception>
        /// <exception cref="System.ArgumentNullException">sourceFileName 或 destFileName 为 null。</exception>
        /// <exception cref="System.NotSupportedException">sourceFileName 或 destFileName 的格式无效。</exception>
        /// <exception cref="System.IO.FileNotFoundException">未找到 sourceFileName。</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">在 sourceFileName 或 destFileName 中指定的路径无效（例如，它位于未映射的驱动器上）。</exception>
        /// <exception cref="System.ArgumentException">sourceFileName 或 destFileName 是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。- 或 - sourceFileName 或 destFileName 指定目录。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260 个字符。</exception>
        public static void Copy( string sourceFileName, string destFileName, bool overwrite )
        {
        }

        /// <summary>
        /// 在指定路径中创建文件。
        /// </summary>
        /// <param name="path">要创建的文件的路径及名称。</param>
        /// <returns>一个 System.IO.FileStream，它提供对 path 中指定的文件的读/写访问。</returns>
        /// <exception cref="System.ArgumentNullException">path 为 null。</exception>
        /// <exception cref="System.ArgumentException">path 是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。</exception>
        /// <exception cref="System.NotSupportedException">path 的格式无效。</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">指定的路径无效（例如，它位于未映射的驱动器上）。</exception>
        /// <exception cref="System.UnauthorizedAccessException">调用方没有所要求的权限。- 或 - path 指定了一个只读文件。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260 个字符。</exception>
        /// <exception cref="System.IO.IOException">创建文件时发生了 I/O 错误。</exception>
        public static FileStream Create( string path )
        {
            return new FileStream();
        }

        /// <summary>
        /// 创建或改写指定的文件。
        /// </summary>
        /// <param name="path">文件名。</param>
        /// <param name="bufferSize">用于读取和写入文件的已放入缓冲区的字节数。</param>
        /// <returns>一个具有指定缓冲大小的 System.IO.FileStream，它提供对 path 中指定的文件的读/写访问。</returns>
        /// <exception cref="System.ArgumentNullException">path 为 null。</exception>
        /// <exception cref="System.ArgumentException">path 是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。</exception>
        /// <exception cref="System.NotSupportedException">path 的格式无效。</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">指定的路径无效（例如，它位于未映射的驱动器上）。</exception>
        /// <exception cref="System.UnauthorizedAccessException">调用方没有所要求的权限。- 或 - path 指定了一个只读文件。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260 个字符。</exception>
        /// <exception cref="System.IO.IOException">创建文件时发生了 I/O 错误。</exception>
        public static FileStream Create( string path, int bufferSize )
        {
            return new FileStream();
        }

        /// <summary>
        /// 创建或改写指定的文件，并指定缓冲区大小和一个描述如何创建或改写该文件的 System.IO.FileOptions 值。
        /// </summary>
        /// <param name="path">文件名。</param>
        /// <param name="bufferSize">用于读取和写入文件的已放入缓冲区的字节数。</param>
        /// <param name="options">System.IO.FileOptions 值之一，它描述如何创建或改写该文件。</param>
        /// <returns>具有指定缓冲区大小的新文件。</returns>
        /// <exception cref="System.ArgumentNullException">path 为 null。</exception>
        /// <exception cref="System.ArgumentException">path 是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。</exception>
        /// <exception cref="System.NotSupportedException">path 的格式无效。</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">指定的路径无效（例如，它位于未映射的驱动器上）。</exception>
        /// <exception cref="System.UnauthorizedAccessException">调用方没有所要求的权限。- 或 - path 指定了一个只读文件。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260 个字符。</exception>
        /// <exception cref="System.IO.IOException">创建文件时发生了 I/O 错误。</exception>
        public static FileStream Create( string path, int bufferSize, FileOptions options )
        {
            return new FileStream();
        }

        /// <summary>
        /// 创建或改写具有指定的缓冲区大小、文件选项和文件安全性的指定文件。
        /// </summary>
        /// <param name="path">文件名。</param>
        /// <param name="bufferSize">用于读取和写入文件的已放入缓冲区的字节数。</param>
        /// <param name="options">System.IO.FileOptions 值之一，它描述如何创建或改写该文件。</param>
        /// <param name="fileSecurity">System.Security.AccessControl.FileSecurity 值之一，它确定文件的访问控制和审核安全性。</param>
        /// <returns>具有指定的缓冲区大小、文件选项和文件安全性的新文件。</returns>
        /// <exception cref="System.ArgumentNullException">path 为 null。</exception>
        /// <exception cref="System.ArgumentException">path 是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。</exception>
        /// <exception cref="System.NotSupportedException">path 的格式无效。</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">指定的路径无效（例如，它位于未映射的驱动器上）。</exception>
        /// <exception cref="System.UnauthorizedAccessException">调用方没有所要求的权限。- 或 - path 指定了一个只读文件。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260 个字符。</exception>
        /// <exception cref="System.IO.IOException">创建文件时发生了 I/O 错误。</exception>
        public static FileStream Create( string path, int bufferSize, FileOptions options, FileSecurity fileSecurity )
        {
            return new FileStream();
        }

        /// <summary>
        /// 创建或打开一个文件用于写入 UTF-8 编码的文本。
        /// </summary>
        /// <param name="path">要打开以进行写入的文件。</param>
        /// <returns>一个 System.IO.StreamWriter，它使用 UTF-8 编码写入指定的文件。</returns>
        /// <exception cref="System.UnauthorizedAccessException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.NotSupportedException">path 的格式无效。</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">指定的路径无效（例如，它位于未映射的驱动器上）。</exception>
        /// <exception cref="System.ArgumentNullException">path 为 null。</exception>
        /// <exception cref="System.ArgumentException">path 是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260 个字符。</exception>
        public static StreamWriter CreateText( string path )
        {
            return new StreamWriter();
        }

        /// <summary>
        /// 解密由当前帐户使用 System.IO.File.Encrypt(System.String) 方法加密的文件。
        /// </summary>
        /// <param name="path">描述要解密的文件的路径。</param>
        /// <exception cref="System.PlatformNotSupportedException">当前操作系统不是 Microsoft Windows NT 或更高版本。</exception>
        /// <exception cref="System.ArgumentNullException">path 参数为 null。</exception>
        /// <exception cref="System.IO.IOException">打开文件时发生了 I/O 错误。例如，加密的文件已经打开。</exception>
        /// <exception cref="System.NotSupportedException">文件系统不是 NTFS。</exception>
        /// <exception cref="System.IO.DriveNotFoundException">指定了无效的驱动器。</exception>
        /// <exception cref="System.UnauthorizedAccessException">path 参数指定了一个只读文件。- 或 - 在当前平台上不支持此操作。- 或 - path 参数指定了一个目录。- 或 - 调用方没有所要求的权限。</exception>
        /// <exception cref="System.ArgumentException">path 参数是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260 个字符。</exception>
        /// <exception cref="System.IO.FileNotFoundException">找不到 path 参数所描述的文件。</exception>
        public static void Decrypt( string path )
        {
        }

        /// <summary>
        /// 删除指定的文件。如果指定的文件不存在，则不引发异常。
        /// </summary>
        /// <param name="path">要删除的文件的名称。</param>
        /// <exception cref="System.IO.IOException">指定的文件正在使用中。</exception>
        /// <exception cref="System.ArgumentNullException">path 为 null。</exception>
        /// <exception cref="System.UnauthorizedAccessException">调用方没有所要求的权限。- 或 - path 是一个目录。- 或 - path 指定一个只读文件。</exception>
        /// <exception cref="System.NotSupportedException">path 的格式无效。</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">指定的路径无效（例如，它位于未映射的驱动器上）。</exception>
        /// <exception cref="System.ArgumentException">path 是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260 个字符。</exception>
        public static void Delete( string path )
        {
        }

        /// <summary>
        /// 将某个文件加密，使得只有加密该文件的帐户才能将其解密。
        /// </summary>
        /// <param name="path">描述要加密的文件的路径。</param>
        /// <exception cref="System.PlatformNotSupportedException">当前操作系统不是 Microsoft Windows NT 或更高版本。</exception>
        /// <exception cref="System.ArgumentNullException">path 参数为 null。</exception>
        /// <exception cref="System.IO.IOException">打开文件时发生了 I/O 错误。</exception>
        /// <exception cref="System.NotSupportedException">文件系统不是 NTFS。</exception>
        /// <exception cref="System.IO.DriveNotFoundException">指定了无效的驱动器。</exception>
        /// <exception cref="System.UnauthorizedAccessException">path 参数指定了一个只读文件。- 或 - 在当前平台上不支持此操作。- 或 - path 参数指定了一个目录。- 或 - 调用方没有所要求的权限。</exception>
        /// <exception cref="System.ArgumentException">path 参数是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260 个字符。</exception>
        /// <exception cref="System.IO.FileNotFoundException">找不到 path 参数所描述的文件。</exception>
        public static void Encrypt( string path )
        {
        }

        /// <summary>
        /// 确定指定的文件是否存在。
        /// </summary>
        /// <param name="path">要检查的文件。</param>
        /// <returns>如果调用方具有要求的权限并且 path 包含现有文件的名称，则为 true；否则为 false。如果 path 为 null 或零长度字符串，则此方法也返回false。如果调用方不具有读取指定文件所需的足够权限，则不引发异常并且该方法返回 false，这与 path 是否存在无关。</returns>
        public static bool Exists( string path )
        {
            return true;
        }

        //
        // 摘要:
        //     获取一个 System.Security.AccessControl.FileSecurity 对象，它封装指定文件的访问控制列表 (ACL) 条目。
        //
        // 参数:
        //   path:
        //     一个文件的路径，该文件包含描述文件的访问控制列表 (ACL) 信息的 System.Security.AccessControl.FileSecurity
        //     对象。
        //
        // 返回结果:
        //     一个 System.Security.AccessControl.FileSecurity 对象，它封装由 path 参数描述的文件的访问控制规则。
        //
        // 异常:
        //   System.IO.IOException:
        //     打开文件时发生了 I/O 错误。
        //
        //   System.Runtime.InteropServices.SEHException:
        //     path 参数为 null。
        //
        //   System.UnauthorizedAccessException:
        //     path 参数指定了一个只读文件。- 或 - 在当前平台上不支持此操作。- 或 - path 参数指定了一个目录。- 或 - 调用方没有所要求的权限。
        //
        //   System.SystemException:
        //     未能找到文件。
        //public static FileSecurity GetAccessControl( string path )
        //{
        //}

        //
        // 摘要:
        //     获取一个 System.Security.AccessControl.FileSecurity 对象，它封装特定文件的指定类型的访问控制列表 (ACL)
        //     项。
        //
        // 参数:
        //   includeSections:
        //     System.Security.AccessControl.AccessControlSections 值之一，它指定要接收的访问控制列表 (ACL)
        //     信息的类型。
        //
        //   path:
        //     一个文件的路径，该文件包含描述文件的访问控制列表 (ACL) 信息的 System.Security.AccessControl.FileSecurity
        //     对象。
        //
        // 返回结果:
        //     一个 System.Security.AccessControl.FileSecurity 对象，它封装由 path 参数描述的文件的访问控制规则。
        //
        // 异常:
        //   System.IO.IOException:
        //     打开文件时发生了 I/O 错误。
        //
        //   System.Runtime.InteropServices.SEHException:
        //     path 参数为 null。
        //
        //   System.UnauthorizedAccessException:
        //     path 参数指定了一个只读文件。- 或 - 在当前平台上不支持此操作。- 或 - path 参数指定了一个目录。- 或 - 调用方没有所要求的权限。
        //
        //   System.SystemException:
        //     未能找到文件。
        //public static FileSecurity GetAccessControl( string path, AccessControlSections includeSections )
        //{
        //}

        /// <summary>
        /// 获取在此路径上的文件的 System.IO.FileAttributes。
        /// </summary>
        /// <param name="path">该文件的路径。</param>
        /// <returns>路径上文件的 System.IO.FileAttributes。</returns>
        /// <exception cref="System.IO.DirectoryNotFoundException">path 表示一个目录且它是无效的，例如，位于未映射的驱动器上或无法找到目录。</exception>
        /// <exception cref="System.NotSupportedException">path 的格式无效。</exception>
        /// <exception cref="System.ArgumentException">path 为空，仅包含空白，或包含无效字符。</exception>
        /// <exception cref="System.IO.FileNotFoundException">path 表示一个文件且它是无效的，例如，位于未映射的驱动器上或无法找到文件。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260 个字符。</exception>
        public static FileAttributes GetAttributes( string path )
        {
            return FileAttributes.Archive;
        }

        /// <summary>
        /// 返回指定文件或目录的创建日期和时间。
        /// </summary>
        /// <param name="path">要获取其创建日期和时间信息的文件或目录。</param>
        /// <returns>一个 System.DateTime 结构，它被设置为指定文件或目录的创建日期和时间。该值用本地时间表示。</returns>
        /// <exception cref="System.UnauthorizedAccessException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.IO.IOException">未找到指定的路径。</exception>
        /// <exception cref="System.NotSupportedException">path 的格式无效。</exception>
        /// <exception cref="System.ArgumentNullException">path 为 null。</exception>
        /// <exception cref="System.ArgumentException">path 是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260 个字符。</exception>
        public static DateTime GetCreationTime( string path )
        {
            return DateTime.Now;
        }

        /// <summary>
        /// 返回指定的文件或目录的创建日期及时间，其格式为协调通用时间 (UTC)。
        /// </summary>
        /// <param name="path">要获取其创建日期和时间信息的文件或目录。</param>
        /// <returns>一个 System.DateTime 结构，它被设置为指定文件或目录的创建日期和时间。该值用 UTC 时间表示。</returns>
        /// <exception cref="System.UnauthorizedAccessException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.IO.IOException">未找到指定的路径。</exception>
        /// <exception cref="System.NotSupportedException">path 的格式无效。</exception>
        /// <exception cref="System.ArgumentNullException">path 为 null。</exception>
        /// <exception cref="System.ArgumentException">path 是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260 个字符。</exception>
        public static DateTime GetCreationTimeUtc( string path )
        {
            return DateTime.Now;
        }

        /// <summary>
        /// 返回上次访问指定文件或目录的日期和时间。
        /// </summary>
        /// <param name="path">要获取其访问日期和时间信息的文件或目录。</param>
        /// <returns>一个 System.DateTime 结构，它被设置为上次访问指定文件或目录的日期和时间。该值用本地时间表示。</returns>
        /// <exception cref="System.UnauthorizedAccessException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.IO.IOException">未找到指定的路径。</exception>
        /// <exception cref="System.NotSupportedException">path 的格式无效。</exception>
        /// <exception cref="System.ArgumentNullException">path 为 null。</exception>
        /// <exception cref="System.ArgumentException">path 是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260 个字符。</exception>
        public static DateTime GetLastAccessTime( string path )
        {
            return DateTime.Now;
        }

        /// <summary>
        /// 返回上次访问指定的文件或目录的日期及时间，其格式为协调通用时间 (UTC)。
        /// </summary>
        /// <param name="path">要获取其访问日期和时间信息的文件或目录。</param>
        /// <returns>一个 System.DateTime 结构，它被设置为上次访问指定文件或目录的日期和时间。该值用 UTC 时间表示。</returns>
        /// <exception cref="System.UnauthorizedAccessException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.IO.IOException">未找到指定的路径。</exception>
        /// <exception cref="System.NotSupportedException">path 的格式无效。</exception>
        /// <exception cref="System.ArgumentNullException">path 为 null。</exception>
        /// <exception cref="System.ArgumentException">path 是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260 个字符。</exception>
        public static DateTime GetLastAccessTimeUtc( string path )
        {
            return DateTime.Now;
        }

        /// <summary>
        /// 返回上次写入指定文件或目录的日期和时间。
        /// </summary>
        /// <param name="path">要获取其写入日期和时间信息的文件或目录。</param>
        /// <returns>一个 System.DateTime 结构，它被设置为上次写入指定文件或目录的日期和时间。该值用本地时间表示。</returns>
        /// <exception cref="System.UnauthorizedAccessException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.IO.IOException">未找到指定的路径。</exception>
        /// <exception cref="System.NotSupportedException">path 的格式无效。</exception>
        /// <exception cref="System.ArgumentNullException">path 为 null。</exception>
        /// <exception cref="System.ArgumentException">path 是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260 个字符。</exception>
        public static DateTime GetLastWriteTime( string path )
        {
            return DateTime.Now;
        }

        /// <summary>
        /// 返回上次写入指定的文件或目录的日期和时间，其格式为协调通用时间 (UTC)。
        /// </summary>
        /// <param name="path">要获取其写入日期和时间信息的文件或目录。</param>
        /// <returns>一个 System.DateTime 结构，它被设置为上次写入指定文件或目录的日期和时间。该值用 UTC 时间表示。</returns>
        /// <exception cref="System.UnauthorizedAccessException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.IO.IOException">未找到指定的路径。</exception>
        /// <exception cref="System.NotSupportedException">path 的格式无效。</exception>
        /// <exception cref="System.ArgumentNullException">path 为 null。</exception>
        /// <exception cref="System.ArgumentException">path 是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260 个字符。</exception>
        public static DateTime GetLastWriteTimeUtc( string path )
        {
            return DateTime.Now;
        }

        /// <summary>
        /// 将指定文件移到新位置，并提供指定新文件名的选项。
        /// </summary>
        /// <param name="sourceFileName">文件的新路径。</param>
        /// <param name="destFileName">要移动的文件的名称。</param>
        /// <exception cref="System.UnauthorizedAccessException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.ArgumentNullException">sourceFileName 或 destFileName 为 null。</exception>
        /// <exception cref="System.NotSupportedException">sourceFileName 或 destFileName 的格式无效。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260 个字符。</exception>
        /// <exception cref="System.IO.FileNotFoundException">未找到 sourceFileName。</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">sourceFileName 或 destFileName 中指定的路径无效（例如，它位于未映射的驱动器上）。</exception>
        /// <exception cref="System.ArgumentException">sourceFileName 或 destFileName 是零长度字符串、只包含空白或者包含在 System.IO.Path.InvalidPathChars 中定义的无效字符。</exception>
        /// <exception cref="System.IO.IOException">目标文件已经存在。</exception>
        public static void Move( string sourceFileName, string destFileName )
        {
        }

        /// <summary>
        /// 打开指定路径上的 System.IO.FileStream，具有读/写访问权限。
        /// </summary>
        /// <param name="path">要打开的文件。</param>
        /// <param name="mode">System.IO.FileMode 值，用于指定在文件不存在时是否创建该文件，并确定是保留还是改写现有文件的内容。</param>
        /// <returns>以指定模式打开的指定路径上的 System.IO.FileStream，具有读/写访问权限并且不共享。</returns>
        /// <exception cref="System.ArgumentNullException">path 为 null。</exception>
        /// <exception cref="System.NotSupportedException">path 的格式无效。</exception>
        /// <exception cref="System.IO.FileNotFoundException">未找到 path 中指定的文件。</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">指定的路径无效（例如，它位于未映射的驱动器上）。</exception>
        /// <exception cref="System.ArgumentException">path 是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。- 或 - access 指定了 Read，而 mode 指定了 Create、CreateNew、Truncate 或 Append。</exception>
        /// <exception cref="System.UnauthorizedAccessException">path 指定了一个只读文件，而 access 不为 Read。- 或 - path 指定了一个目录。- 或 - 调用方没有所要求的权限。</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">mode、access 或 share 指定了一个无效值。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260 个字符。</exception>
        /// <exception cref="System.IO.IOException">打开文件时发生了 I/O 错误。</exception>
        public static FileStream Open( string path, FileMode mode )
        {
            return new FileStream();
        }

        /// <summary>
        /// 以指定的模式和访问权限打开指定路径上的 System.IO.FileStream。
        /// </summary>
        /// <param name="path">要打开的文件。</param>
        /// <param name="mode">System.IO.FileMode 值，用于指定在文件不存在时是否创建该文件，并确定是保留还是改写现有文件的内容。</param>
        /// <param name="access">System.IO.FileAccess 值，指定可以对文件执行的操作。</param>
        /// <returns>一个非共享的 System.IO.FileStream，它提供对指定文件的访问，并且具有指定的模式和访问权限。</returns>
        /// <exception cref="System.ArgumentNullException">path 为 null。</exception>
        /// <exception cref="System.NotSupportedException">path 的格式无效。</exception>
        /// <exception cref="System.IO.FileNotFoundException">未找到 path 中指定的文件。</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">指定的路径无效（例如，它位于未映射的驱动器上）。</exception>
        /// <exception cref="System.ArgumentException">path 是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。- 或 - access 指定了 Read，而 mode 指定了 Create、CreateNew、Truncate 或 Append。</exception>
        /// <exception cref="System.UnauthorizedAccessException">path 指定了一个只读文件，而 access 不为 Read。- 或 - path 指定了一个目录。- 或 - 调用方没有所要求的权限。</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">mode、access 或 share 指定了一个无效值。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260 个字符。</exception>
        /// <exception cref="System.IO.IOException">打开文件时发生了 I/O 错误。</exception>
        public static FileStream Open( string path, FileMode mode, FileAccess access )
        {
            return new FileStream();
        }

        /// <summary>
        /// 打开指定路径上的 System.IO.FileStream，具有指定的读、写或读/写访问模式以及指定的共享选项。
        /// </summary>
        /// <param name="path">要打开的文件。</param>
        /// <param name="mode">System.IO.FileMode 值，用于指定在文件不存在时是否创建该文件，并确定是保留还是改写现有文件的内容。</param>
        /// <param name="access">System.IO.FileAccess 值，指定可以对文件执行的操作。</param>
        /// <param name="share">System.IO.FileShare 值，它指定其他线程所具有的对该文件的访问类型。</param>
        /// <returns>指定路径上的 System.IO.FileStream，具有指定的读、写或读/写访问模式以及指定的共享选项。</returns>
        /// <exception cref="System.ArgumentNullException">path 为 null。</exception>
        /// <exception cref="System.NotSupportedException">path 的格式无效。</exception>
        /// <exception cref="System.IO.FileNotFoundException">未找到 path 中指定的文件。</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">指定的路径无效（例如，它位于未映射的驱动器上）。</exception>
        /// <exception cref="System.ArgumentException">path 是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。- 或 - access 指定了 Read，而 mode 指定了 Create、CreateNew、Truncate 或 Append。</exception>
        /// <exception cref="System.UnauthorizedAccessException">path 指定了一个只读文件，而 access 不为 Read。- 或 - path 指定了一个目录。- 或 - 调用方没有所要求的权限。</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">mode、access 或 share 指定了一个无效值。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260 个字符。</exception>
        /// <exception cref="System.IO.IOException">打开文件时发生了 I/O 错误。</exception>
        public static FileStream Open( string path, FileMode mode, FileAccess access, FileShare share )
        {
            return new FileStream();
        }

        /// <summary>
        /// 打开现有文件以进行读取。
        /// </summary>
        /// <param name="path">要打开以进行读取的文件。</param>
        /// <returns>指定路径上的只读 System.IO.FileStream。</returns>
        /// <exception cref="System.UnauthorizedAccessException">path 指定了一个目录。- 或 - 调用方没有所要求的权限。</exception>
        /// <exception cref="System.Security.SecurityException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">指定的路径无效（例如，它位于未映射的驱动器上）。</exception>
        /// <exception cref="System.ArgumentNullException">path 为 null。</exception>
        /// <exception cref="System.UnauthorizedAccessException">path 指定了一个只读文件。- 或 - 在当前平台上不支持此操作。- 或 - path 指定了一个目录。- 或 - 调用方没有所要求的权限。</exception>
        /// <exception cref="System.ArgumentException">path 是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260 个字符。</exception>
        /// <exception cref="System.IO.FileNotFoundException">未找到 path 中指定的文件。</exception>
        public static FileStream OpenRead( string path )
        {
            return new FileStream();
        }

        /// <summary>
        /// 打开现有 UTF-8 编码文本文件以进行读取。
        /// </summary>
        /// <param name="path">要打开以进行读取的文件。</param>
        /// <returns>指定路径上的 System.IO.StreamReader。</returns>
        /// <exception cref="System.ArgumentNullException">path 为 null。</exception>
        /// <exception cref="System.NotSupportedException">path 的格式无效。</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">指定的路径无效（例如，它位于未映射的驱动器上）。</exception>
        /// <exception cref="System.UnauthorizedAccessException">path 指定了一个只读文件。- 或 - 在当前平台上不支持此操作。- 或 - path 指定了一个目录。- 或 - 调用方没有所要求的权限。</exception>
        /// <exception cref="System.Security.SecurityException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.ArgumentException">path 是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260 个字符。</exception>
        /// <exception cref="System.IO.FileNotFoundException">未找到 path 中指定的文件。</exception>
        public static StreamReader OpenText( string path )
        {
            return new StreamReader();
        }

        /// <summary>
        /// 打开现有文件以进行写入。
        /// </summary>
        /// <param name="path">要打开以进行写入的文件。</param>
        /// <returns>具有 System.IO.FileAccess.Write 访问权限的指定路径上的非共享 System.IO.FileStream 对象。</returns>
        /// <exception cref="System."></exception>
        /// <exception cref="System.ArgumentNullException">path 为 null。</exception>
        /// <exception cref="System.NotSupportedException">path 的格式无效。</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">指定的路径无效（例如，它位于未映射的驱动器上）。</exception>
        /// <exception cref="System.UnauthorizedAccessException">path 指定了一个只读文件。- 或 - 在当前平台上不支持此操作。- 或 - path 指定了一个目录。- 或 - 调用方没有所要求的权限。</exception>
        /// <exception cref="System.Security.SecurityException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.ArgumentException">path 是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260 个字符。</exception>
        /// <exception cref="System.IO.FileNotFoundException">未找到 path 中指定的文件。</exception>
        public static FileStream OpenWrite( string path )
        {
            return new FileStream();
        }

        /// <summary>
        /// 打开一个文件，将文件的内容读入一个字符串，然后关闭该文件。
        /// </summary>
        /// <param name="path">要打开以进行读取的文件。</param>
        /// <returns>包含文件内容的字节数组。</returns>
        /// <exception cref="System.ArgumentNullException">path 为 null。</exception>
        /// <exception cref="System.UnauthorizedAccessException">path 指定了一个只读文件。- 或 - 在当前平台上不支持此操作。- 或 - path 指定了一个目录。- 或 - 调用方没有所要求的权限。</exception>
        /// <exception cref="System.NotSupportedException">path 的格式无效。</exception>
        /// <exception cref="System.IO.FileNotFoundException">未找到 path 中指定的文件。</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">指定的路径无效（例如，它位于未映射的驱动器上）。</exception>
        /// <exception cref="System.Security.SecurityException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.ArgumentException">path 是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260 个字符。</exception>
        /// <exception cref="System.IO.IOException">打开文件时发生了 I/O 错误。</exception>
        public static byte[] ReadAllBytes( string path )
        {
            return new byte[0];
        }

        /// <summary>
        /// 打开一个文本文件，读取文件的所有行，然后关闭该文件。
        /// </summary>
        /// <param name="path">要打开以进行读取的文件。</param>
        /// <returns>包含文件所有行的字符串数组。</returns>
        /// <exception cref="System.ArgumentNullException">path 为 null。</exception>
        /// <exception cref="System.UnauthorizedAccessException">path 指定了一个只读文件。- 或 - 在当前平台上不支持此操作。- 或 - path 指定了一个目录。- 或 - 调用方没有所要求的权限。</exception>
        /// <exception cref="System.NotSupportedException">path 的格式无效。</exception>
        /// <exception cref="System.IO.FileNotFoundException">未找到 path 中指定的文件。</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">指定的路径无效（例如，它位于未映射的驱动器上）。</exception>
        /// <exception cref="System.Security.SecurityException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.ArgumentException">path 是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260 个字符。</exception>
        /// <exception cref="System.IO.IOException">打开文件时发生了 I/O 错误。</exception>
        public static string[] ReadAllLines( string path )
        {
            return new string[0];
        }

        /// <summary>
        /// 打开一个文件，使用指定的编码读取文件的所有行，然后关闭该文件。
        /// </summary>
        /// <param name="path">要打开以进行读取的文件。</param>
        /// <param name="encoding">应用到文件内容的编码。</param>
        /// <returns>包含文件所有行的字符串数组。</returns>
        /// <exception cref="System.ArgumentNullException">path 为 null。</exception>
        /// <exception cref="System.UnauthorizedAccessException">path 指定了一个只读文件。- 或 - 在当前平台上不支持此操作。- 或 - path 指定了一个目录。- 或 - 调用方没有所要求的权限。</exception>
        /// <exception cref="System.NotSupportedException">path 的格式无效。</exception>
        /// <exception cref="System.IO.FileNotFoundException">未找到 path 中指定的文件。</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">指定的路径无效（例如，它位于未映射的驱动器上）。</exception>
        /// <exception cref="System.Security.SecurityException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.ArgumentException">path 是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260 个字符。</exception>
        /// <exception cref="System.IO.IOException">打开文件时发生了 I/O 错误。</exception>
        public static string[] ReadAllLines( string path, Encoding encoding )
        {
            return new string[0];
        }

        /// <summary>
        /// 打开一个文本文件，读取文件的所有行，然后关闭该文件。
        /// </summary>
        /// <param name="path">要打开以进行读取的文件。</param>
        /// <returns>包含文件所有行的字符串数组。</returns>
        /// <exception cref="System.ArgumentNullException">path 为 null。</exception>
        /// <exception cref="System.UnauthorizedAccessException">path 指定了一个只读文件。- 或 - 在当前平台上不支持此操作。- 或 - path 指定了一个目录。- 或 - 调用方没有所要求的权限。</exception>
        /// <exception cref="System.NotSupportedException">path 的格式无效。</exception>
        /// <exception cref="System.IO.FileNotFoundException">未找到 path 中指定的文件。</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">指定的路径无效（例如，它位于未映射的驱动器上）。</exception>
        /// <exception cref="System.Security.SecurityException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.ArgumentException">path 是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260 个字符。</exception>
        /// <exception cref="System.IO.IOException">打开文件时发生了 I/O 错误。</exception>
        public static string ReadAllText( string path )
        {
            return string.Empty;
        }

        /// <summary>
        /// 打开一个文件，使用指定的编码读取文件的所有行，然后关闭该文件。
        /// </summary>
        /// <param name="path">要打开以进行读取的文件。</param>
        /// <param name="encoding">应用到文件内容的编码。</param>
        /// <returns>包含文件所有行的字符串数组。</returns>
        /// <exception cref="System.ArgumentNullException">path 为 null。</exception>
        /// <exception cref="System.UnauthorizedAccessException">path 指定了一个只读文件。- 或 - 在当前平台上不支持此操作。- 或 - path 指定了一个目录。- 或 - 调用方没有所要求的权限。</exception>
        /// <exception cref="System.NotSupportedException">path 的格式无效。</exception>
        /// <exception cref="System.IO.FileNotFoundException">未找到 path 中指定的文件。</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">指定的路径无效（例如，它位于未映射的驱动器上）。</exception>
        /// <exception cref="System.Security.SecurityException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.ArgumentException">path 是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260 个字符。</exception>
        /// <exception cref="System.IO.IOException">打开文件时发生了 I/O 错误。</exception>
        public static string ReadAllText( string path, Encoding encoding )
        {
            return string.Empty;
        }

        /// <summary>
        /// 使用其他文件的内容替换指定文件的内容，这一过程将删除原始文件，并创建被替换文件的备份。
        /// </summary>
        /// <param name="sourceFileName">替换由 destinationFileName. 指定的文件的文件名。</param>
        /// <param name="destinationFileName">替换文件的名称。</param>
        /// <param name="destinationBackupFileName">备份文件的名称。</param>
        /// <exception cref="System.IO.IOException">打开文件时发生了 I/O 错误。</exception>
        /// <exception cref="System.ArgumentNullException">destinationFileName 参数为 null。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260 个字符。</exception>
        /// <exception cref="System.IO.DriveNotFoundException">指定了无效的驱动器。</exception>
        /// <exception cref="System.IO.FileNotFoundException">找不到当前 System.IO.FileInfo 对象所描述的文件。- 或 -找不到 destinationBackupFileName 参数所描述的文件。</exception>
        /// <exception cref="System.PlatformNotSupportedException">操作系统是 Windows 98 Second Edition 或更低版本，且文件系统不是 NTFS。</exception>
        /// <exception cref="System.UnauthorizedAccessException">path 参数指定了一个只读文件。- 或 - 在当前平台上不支持此操作。- 或 - path 参数指定了一个目录。- 或 - 调用方没有所要求的权限。</exception>
        /// <exception cref="System.ArgumentException">destinationFileName 参数描述的路径不是合法的格式。- 或 -destinationBackupFileName 参数描述的路径不是合法的格式。</exception>
        public static void Replace( string sourceFileName, string destinationFileName, string destinationBackupFileName )
        {
        }

        /// <summary>
        /// 用其他文件的内容替换指定文件的内容，删除原始文件，并创建被替换文件的备份和（可选）忽略合并错误。
        /// </summary>
        /// <param name="sourceFileName">替换由 destinationFileName. 指定的文件的文件名。</param>
        /// <param name="destinationFileName">替换文件的名称。</param>
        /// <param name="destinationBackupFileName">备份文件的名称。</param>
        /// <param name="ignoreMetadataErrors">如果忽略从被替换文件到替换文件的合并错误（如属性和访问控制列表 (ACL)），则为 true，否则为 false。</param>
        /// <exception cref="System.IO.IOException">打开文件时发生了 I/O 错误。</exception>
        /// <exception cref="System.ArgumentNullException">destinationFileName 参数为 null。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260 个字符。</exception>
        /// <exception cref="System.IO.DriveNotFoundException">指定了无效的驱动器。</exception>
        /// <exception cref="System.IO.FileNotFoundException">找不到当前 System.IO.FileInfo 对象所描述的文件。- 或 -找不到 destinationBackupFileName 参数所描述的文件。</exception>
        /// <exception cref="System.PlatformNotSupportedException">操作系统是 Windows 98 Second Edition 或更低版本，且文件系统不是 NTFS。</exception>
        /// <exception cref="System.UnauthorizedAccessException">path 参数指定了一个只读文件。- 或 - 在当前平台上不支持此操作。- 或 - path 参数指定了一个目录。- 或 - 调用方没有所要求的权限。</exception>
        /// <exception cref="System.ArgumentException">destinationFileName 参数描述的路径不是合法的格式。- 或 -destinationBackupFileName 参数描述的路径不是合法的格式。</exception>
        public static void Replace( string sourceFileName, string destinationFileName, string destinationBackupFileName, bool ignoreMetadataErrors )
        {
        }

        /// <summary>
        /// 对指定的文件应用由 System.Security.AccessControl.FileSecurity 对象描述的访问控制列表 (ACL) 项。
        /// </summary>
        /// <param name="path">在其中添加或移除访问控制列表 (ACL) 项的文件。</param>
        /// <param name="fileSecurity">一个 System.Security.AccessControl.FileSecurity 对象，描述应用于由 path 参数描述的文件的 ACL项。</param>
        /// <exception cref="System.IO.IOException">打开文件时发生了 I/O 错误。</exception>
        /// <exception cref="System.Runtime.InteropServices.SEHException">path 参数为 null。</exception>
        /// <exception cref="System.UnauthorizedAccessException">path 参数指定了一个只读文件。- 或 - 在当前平台上不支持此操作。- 或 - path 参数指定了一个目录。- 或 - 调用方没有所要求的权限。</exception>
        /// <exception cref="System.SystemException">未能找到文件。</exception>
        public static void SetAccessControl( string path, FileSecurity fileSecurity )
        {
        }

        /// <summary>
        /// 设置指定路径上文件的指定的 System.IO.FileAttributes。
        /// </summary>
        /// <param name="path">该文件的路径。</param>
        /// <param name="fileAttributes">所需的 System.IO.FileAttributes，例如 Hidden、ReadOnly、Normal 和 Archive。</param>
        /// <exception cref="System.IO.FileNotFoundException">无法找到该文件。</exception>
        /// <exception cref="System.UnauthorizedAccessException">path 指定了一个只读文件。- 或 - 在当前平台上不支持此操作。- 或 - path 指定了一个目录。- 或 - 调用方没有所要求的权限。</exception>
        /// <exception cref="System.NotSupportedException">path 的格式无效。</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">指定的路径无效（例如，它位于未映射的驱动器上）。</exception>
        /// <exception cref="System.ArgumentException">path 为空、只包含空白、包含无效字符或文件属性无效。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260 个字符。</exception>
        public static void SetAttributes( string path, FileAttributes fileAttributes )
        {
        }

        /// <summary>
        /// 设置创建该文件的日期和时间。
        /// </summary>
        /// <param name="path">System.DateTime，它包含要为 path 的创建日期和时间设置的值。该值用本地时间表示。</param>
        /// <param name="creationTime">要设置其创建日期和时间信息的文件。</param>
        /// <exception cref="System.UnauthorizedAccessException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.ArgumentNullException">path 为 null。</exception>
        /// <exception cref="System.IO.FileNotFoundException">未找到指定的路径。</exception>
        /// <exception cref="System.NotSupportedException">path 的格式无效。</exception>
        /// <exception cref="System.ArgumentException">path 是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260个字符。</exception>
        public static void SetCreationTime( string path, DateTime creationTime )
        {
        }

        /// <summary>
        /// 设置文件创建的日期和时间，其格式为协调通用时间 (UTC)。
        /// </summary>
        /// <param name="path">要设置其创建日期和时间信息的文件。</param>
        /// <param name="creationTimeUtc">System.DateTime，它包含要为 path 的创建日期和时间设置的值。该值用 UTC 时间表示。</param>
        /// <exception cref="System.UnauthorizedAccessException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.ArgumentNullException">path 为 null。</exception>
        /// <exception cref="System.IO.FileNotFoundException">未找到指定的路径。</exception>
        /// <exception cref="System.NotSupportedException">path 的格式无效。</exception>
        /// <exception cref="System.ArgumentException">path 是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260个字符。</exception>
        public static void SetCreationTimeUtc( string path, DateTime creationTimeUtc )
        {
        }

        /// <summary>
        /// 设置上次访问指定文件的日期和时间。
        /// </summary>
        /// <param name="path">要设置其访问日期和时间信息的文件。</param>
        /// <param name="lastAccessTime">System.DateTime，它包含要为 path 的上次访问日期和时间设置的值。该值用本地时间表示。</param>
        /// <exception cref="System.UnauthorizedAccessException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.ArgumentNullException">path 为 null。</exception>
        /// <exception cref="System.IO.FileNotFoundException">未找到指定的路径。</exception>
        /// <exception cref="System.NotSupportedException">path 的格式无效。</exception>
        /// <exception cref="System.ArgumentException">path 是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260个字符。</exception>
        public static void SetLastAccessTime( string path, DateTime lastAccessTime )
        {
        }

        /// <summary>
        /// 设置上次访问指定的文件的日期和时间，其格式为协调通用时间 (UTC)。
        /// </summary>
        /// <param name="path">要设置其访问日期和时间信息的文件。</param>
        /// <param name="lastAccessTimeUtc">System.DateTime，它包含要为 path 的上次访问日期和时间设置的值。该值用 UTC 时间表示。</param>
        /// <exception cref="System.UnauthorizedAccessException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.ArgumentNullException">path 为 null。</exception>
        /// <exception cref="System.IO.FileNotFoundException">未找到指定的路径。</exception>
        /// <exception cref="System.NotSupportedException">path 的格式无效。</exception>
        /// <exception cref="System.ArgumentException">path 是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260个字符。</exception>
        public static void SetLastAccessTimeUtc( string path, DateTime lastAccessTimeUtc )
        {
        }

        /// <summary>
        /// 设置上次写入指定文件的日期和时间。
        /// </summary>
        /// <param name="path">要设置其日期和时间信息的文件。</param>
        /// <param name="lastWriteTime">System.DateTime，它包含要为 path 的上次写入日期和时间设置的值。该值用本地时间表示。</param>
        /// <param name="lastWriteTimeUtc">System.DateTime，它包含要为 path 的上次写入日期和时间设置的值。该值用 UTC 时间表示。</param>
        /// <exception cref="System.UnauthorizedAccessException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.ArgumentNullException">path 为 null。</exception>
        /// <exception cref="System.IO.FileNotFoundException">未找到指定的路径。</exception>
        /// <exception cref="System.NotSupportedException">path 的格式无效。</exception>
        /// <exception cref="System.ArgumentException">path 是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260个字符。</exception>
        public static void SetLastWriteTime( string path, DateTime lastWriteTime )
        {
        }

        /// <summary>
        /// 设置上次写入指定的文件的日期和时间，其格式为协调通用时间 (UTC)。
        /// </summary>
        /// <param name="path">要设置其日期和时间信息的文件。</param>
        /// <param name="lastWriteTimeUtc">System.DateTime，它包含要为 path 的上次写入日期和时间设置的值。该值用 UTC 时间表示。</param>
        /// <exception cref="System.UnauthorizedAccessException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.ArgumentNullException">path 为 null。</exception>
        /// <exception cref="System.IO.FileNotFoundException">未找到指定的路径。</exception>
        /// <exception cref="System.NotSupportedException">path 的格式无效。</exception>
        /// <exception cref="System.ArgumentException">path 是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260个字符。</exception>
        public static void SetLastWriteTimeUtc( string path, DateTime lastWriteTimeUtc )
        {
        }

        /// <summary>
        /// 创建一个新文件，在其中写入指定的字节数组，然后关闭该文件。如果目标文件已存在，则改写该文件。
        /// </summary>
        /// <param name="path">要写入的文件。</param>
        /// <param name="bytes">要写入文件的字节。</param>
        /// <exception cref="System.UnauthorizedAccessException">path 指定了一个只读文件。- 或 - 在当前平台上不支持此操作。- 或 - path 指定了一个目录。- 或 - 调用方没有所要求的权限。</exception>
        /// <exception cref="System.ArgumentNullException">path 为 null 或字节数组为空。</exception>
        /// <exception cref="System.NotSupportedException">path 的格式无效。</exception>
        /// <exception cref="System.IO.FileNotFoundException">未找到 path 中指定的文件。</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">指定的路径无效（例如，它位于未映射的驱动器上）。</exception>
        /// <exception cref="System.Security.SecurityException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.ArgumentException">path 是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260个字符。</exception>
        /// <exception cref="System.IO.IOException">打开文件时发生了 I/O 错误。</exception>
        public static void WriteAllBytes( string path, byte[] bytes )
        {
        }

        /// <summary>
        /// 创建一个新文件，在其中写入指定的字符串数组，然后关闭该文件。如果目标文件已存在，则改写该文件。
        /// </summary>
        /// <param name="path">要写入的文件。</param>
        /// <param name="contents">要写入文件的字符串数组。</param>
        /// <exception cref="System.IO.FileNotFoundException">未找到 path 中指定的文件。</exception>
        /// <exception cref="System.UnauthorizedAccessException">path 指定了一个只读文件。- 或 - 在当前平台上不支持此操作。- 或 - path 指定了一个目录。- 或 - 调用方没有所要求的权限。</exception>
        /// <exception cref="System.NotSupportedException">path 的格式无效。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260 个字符。</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">指定的路径无效（例如，它位于未映射的驱动器上）。</exception>
        /// <exception cref="System.Security.SecurityException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.ArgumentException">path 是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。</exception>
        /// <exception cref="System.ArgumentNullException">path 为 null 或内容字符串为空。</exception>
        /// <exception cref="System.IO.IOException">打开文件时发生了 I/O 错误。</exception>
        public static void WriteAllLines( string path, string[] contents )
        {
        }

        /// <summary>
        /// 创建一个新文件，使用指定的编码在其中写入指定的字符串数组，然后关闭文件。如果目标文件已存在，则改写该文件。
        /// </summary>
        /// <param name="path">要写入的文件。</param>
        /// <param name="contents">要写入文件的字符串数组。</param>
        /// <param name="encoding">一个 System.Text.Encoding 对象，表示应用于字符串数组的字符编码。</param>
        /// <exception cref="System.ArgumentNullException">path 为 null。</exception>
        /// <exception cref="System.UnauthorizedAccessException">path 指定了一个只读文件。- 或 - 在当前平台上不支持此操作。- 或 - path 指定了一个目录。- 或 - 调用方没有所要求的权限。</exception>
        /// <exception cref="System.NotSupportedException">path 的格式无效。</exception>
        /// <exception cref="System.IO.FileNotFoundException">未找到 path 中指定的文件。</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">指定的路径无效（例如，它位于未映射的驱动器上）。</exception>
        /// <exception cref="System.Security.SecurityException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.ArgumentException">path 是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260个字符。</exception>
        /// <exception cref="System.ArgumentNullException">path 为 null 或内容字符串为空。</exception>
        /// <exception cref="System.IO.IOException">打开文件时发生了 I/O 错误。</exception>
        public static void WriteAllLines( string path, string[] contents, Encoding encoding )
        {
        }

        /// <summary>
        /// 创建一个新文件，在其中写入指定的字符串数组，然后关闭该文件。如果目标文件已存在，则改写该文件。
        /// </summary>
        /// <param name="path">要写入的文件。</param>
        /// <param name="contents">要写入文件的字符串数组。</param>
        /// <exception cref="System.ArgumentNullException">path 为 null。</exception>
        /// <exception cref="System.UnauthorizedAccessException">path 指定了一个只读文件。- 或 - 在当前平台上不支持此操作。- 或 - path 指定了一个目录。- 或 - 调用方没有所要求的权限。</exception>
        /// <exception cref="System.NotSupportedException">path 的格式无效。</exception>
        /// <exception cref="System.IO.FileNotFoundException">未找到 path 中指定的文件。</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">指定的路径无效（例如，它位于未映射的驱动器上）。</exception>
        /// <exception cref="System.Security.SecurityException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.ArgumentException">path 是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260个字符。</exception>
        /// <exception cref="System.IO.IOException">打开文件时发生了 I/O 错误。</exception>
        public static void WriteAllText( string path, string contents )
        {
        }

        /// <summary>
        /// 创建一个新文件，使用指定的编码在其中写入指定的字符串数组，然后关闭文件。如果目标文件已存在，则改写该文件。
        /// </summary>
        /// <param name="path">要写入的文件。</param>
        /// <param name="contents">要写入文件的字符串数组。</param>
        /// <param name="encoding">一个 System.Text.Encoding 对象，表示应用于字符串数组的编码。</param>
        /// <exception cref="System.IO.FileNotFoundException">未找到 path 中指定的文件。</exception>
        /// <exception cref="System.UnauthorizedAccessException">path 指定了一个只读文件。- 或 - 在当前平台上不支持此操作。- 或 - path 指定了一个目录。- 或 - 调用方没有所要求的权限。</exception>
        /// <exception cref="System.NotSupportedException">path 的格式无效。</exception>
        /// <exception cref="System.IO.PathTooLongException">指定的路径、文件名或者两者都超出了系统定义的最大长度。例如，在基于 Windows 的平台上，路径必须小于 248 个字符，文件名必须小于 260个字符。</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">指定的路径无效（例如，它位于未映射的驱动器上）。</exception>
        /// <exception cref="System.Security.SecurityException">调用方没有所要求的权限。</exception>
        /// <exception cref="System.ArgumentException">path 是一个零长度字符串，仅包含空白或者包含一个或多个由 System.IO.Path.InvalidPathChars 定义的无效字符。</exception>
        /// <exception cref="System.ArgumentNullException">path 为 null 或内容字符串为空。</exception>
        /// <exception cref="System.IO.IOException">打开文件时发生了 I/O 错误。</exception>
        public static void WriteAllText( string path, string contents, Encoding encoding )
        {
        }
        #endregion
    }
}
#endregion

