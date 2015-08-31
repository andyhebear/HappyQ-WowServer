// CkSFtp.h: interface for the CkSFtp class.
//
//////////////////////////////////////////////////////////////////////

#ifndef _CkSFtp_H
#define _CkSFtp_H

#pragma once

#include "CkString.h"
class CkByteData;
class CkSFtpProgress;
class CkSshKey;
class CkSFtpDir;
#include "CkObject.h"

#pragma pack (push, 8) 

// CLASS: CkSFtp
class CkSFtp  : public CkObject
{
    private:
	CkSFtpProgress *m_callback;

	void *m_impl;
	bool m_utf8;	// If true, all input "const char *" parameters are utf-8, otherwise they are ANSI strings.

	// Don't allow assignment or copying these objects.
	CkSFtp(const CkSFtp &);
	CkSFtp &operator=(const CkSFtp &);

	unsigned long nextIdx(void);
	unsigned long m_resultIdx;
	CkString m_resultString[10];

    public:
	void *getImpl(void) const;

	CkSFtp(void *impl);

	CkSFtp();
	virtual ~CkSFtp();

	// BEGIN PUBLIC INTERFACE
	bool get_Utf8(void) const;
	void put_Utf8(bool b);

	// Error log retrieval and saving (these methods are common to all Chilkat VC++ classes.)
	bool SaveLastError(const char *filename);
    void LastErrorXml(CkString &str);
    void LastErrorHtml(CkString &str);
    void LastErrorText(CkString &str);

    const char *lastErrorText(void);
    const char *lastErrorXml(void);
    const char *lastErrorHtml(void);
	
	CkSFtpProgress *get_EventCallbackObject(void) const;
	void put_EventCallbackObject(CkSFtpProgress *progress);

	// UNLOCKCOMPONENT_BEGIN
	bool UnlockComponent(const char *unlockCode);
	// UNLOCKCOMPONENT_END
	// CONNECTTIMEOUTMS_BEGIN
	int get_ConnectTimeoutMs(void);
	void put_ConnectTimeoutMs(int newVal);
	// CONNECTTIMEOUTMS_END
	// DISCONNECTCODE_BEGIN
	int get_DisconnectCode(void);
	// DISCONNECTCODE_END
	// INITIALIZEFAILCODE_BEGIN
	int get_InitializeFailCode(void);
	// INITIALIZEFAILCODE_END
	// MAXPACKETSIZE_BEGIN
	int get_MaxPacketSize(void);
	void put_MaxPacketSize(int newVal);
	// MAXPACKETSIZE_END
	// IDLETIMEOUTMS_BEGIN
	int get_IdleTimeoutMs(void);
	void put_IdleTimeoutMs(int newVal);
	// IDLETIMEOUTMS_END
	// INITIALIZEFAILREASON_BEGIN
	void get_InitializeFailReason(CkString &str);
	const char *initializeFailReason(void);
	// INITIALIZEFAILREASON_END
	// DISCONNECTREASON_BEGIN
	void get_DisconnectReason(CkString &str);
	const char *disconnectReason(void);
	// DISCONNECTREASON_END
	// VERSION_BEGIN
	void get_Version(CkString &str);
	const char *version(void);
	// VERSION_END
	// ISCONNECTED_BEGIN
	bool get_IsConnected(void);
	// ISCONNECTED_END
	// KEEPSESSIONLOG_BEGIN
	bool get_KeepSessionLog(void);
	void put_KeepSessionLog(bool newVal);
	// KEEPSESSIONLOG_END
	// SESSIONLOG_BEGIN
	void get_SessionLog(CkString &str);
	const char *sessionLog(void);
	// SESSIONLOG_END
	// DISCONNECT_BEGIN
	void Disconnect(void);
	// DISCONNECT_END
	// CONNECT_BEGIN
	bool Connect(const char *hostname, int port);
	// CONNECT_END
	// AUTHENTICATEPK_BEGIN
	bool AuthenticatePk(const char *username, CkSshKey &privateKey);
	// AUTHENTICATEPK_END
	// AUTHENTICATEPW_BEGIN
	bool AuthenticatePw(const char *login, const char *password);
	// AUTHENTICATEPW_END
	// INITIALIZESFTP_BEGIN
	bool InitializeSftp(void);
	// INITIALIZESFTP_END
	// OPENFILE_BEGIN
	bool OpenFile(const char *filename, const char *access, const char *createDisp, CkString &outStr);
	const char *openFile(const char *filename, const char *access, const char *createDisp);
	// OPENFILE_END
	// OPENDIR_BEGIN
	bool OpenDir(const char *path, CkString &outStr);
	const char *openDir(const char *path);
	// OPENDIR_END
	// CLOSEHANDLE_BEGIN
	bool CloseHandle(const char *handle);
	// CLOSEHANDLE_END
	// GETFILESIZE_BEGIN
	unsigned long GetFileSize32(const char *filenameOrHandle, bool bFollowLinks, bool bIsHandle);
	// GETFILESIZE_END
	// GETFILESIZE64_BEGIN
	__int64 GetFileSize64(const char *filenameOrHandle, bool bFollowLinks, bool bIsHandle);
	// GETFILESIZE64_END
	// GETFILESIZESTR_BEGIN
	bool GetFileSizeStr(const char *filenameOrHandle, bool bFollowLinks, bool bIsHandle, CkString &outStr);
	const char *getFileSizeStr(const char *filenameOrHandle, bool bFollowLinks, bool bIsHandle);
	// GETFILESIZESTR_END
	// GETFILELASTACCESS_BEGIN
	bool GetFileLastAccess(const char *filenameOrHandle, bool bFollowLinks, bool bIsHandle, SYSTEMTIME &sysTime);
	// GETFILELASTACCESS_END
	// GETFILELASTMODIFIED_BEGIN
	bool GetFileLastModified(const char *filenameOrHandle, bool bFollowLinks, bool bIsHandle, SYSTEMTIME &sysTime);
	// GETFILELASTMODIFIED_END
	// GETFILECREATETIME_BEGIN
	bool GetFileCreateTime(const char *filenameOrHandle, bool bFollowLinks, bool bIsHandle, SYSTEMTIME &sysTime);
	// GETFILECREATETIME_END
	// GETFILEOWNER_BEGIN
	bool GetFileOwner(const char *filenameOrHandle, bool bFollowLinks, bool bIsHandle, CkString &outStr);
	const char *getFileOwner(const char *filenameOrHandle, bool bFollowLinks, bool bIsHandle);
	// GETFILEOWNER_END
	// GETFILEGROUP_BEGIN
	bool GetFileGroup(const char *filenameOrHandle, bool bFollowLinks, bool bIsHandle, CkString &outStr);
	const char *getFileGroup(const char *filenameOrHandle, bool bFollowLinks, bool bIsHandle);
	// GETFILEGROUP_END
	// GETFILEPERMISSIONS_BEGIN
	int GetFilePermissions(const char *filenameOrHandle, bool bFollowLinks, bool bIsHandle);
	// GETFILEPERMISSIONS_END
	// ADD64_BEGIN
	void Add64(const char *n1, const char *n2, CkString &outStr);
	const char *add64(const char *n1, const char *n2);
	// ADD64_END
	// READFILEBYTES32_BEGIN
	bool ReadFileBytes32(const char *handle, int offset, int numBytes, CkByteData &outBytes);
	// READFILEBYTES32_END
	// READFILEBYTES64_BEGIN
	bool ReadFileBytes64(const char *handle, __int64 offset64, int numBytes, CkByteData &outBytes);
	// READFILEBYTES64_END
	// READFILEBYTES64S_BEGIN
	bool ReadFileBytes64s(const char *handle, const char *offset64, int numBytes, CkByteData &outBytes);
	// READFILEBYTES64S_END
	// READFILETEXT64S_BEGIN
	bool ReadFileText64s(const char *handle, const char *offset64, int numBytes, const char *charset, CkString &outStr);
	const char *readFileText64s(const char *handle, const char *offset64, int numBytes, const char *charset);
	// READFILETEXT64S_END
	// READFILETEXT64_BEGIN
	bool ReadFileText64(const char *handle, __int64 offset64, int numBytes, const char *charset, CkString &outStr);
	const char *readFileText64(const char *handle, __int64 offset64, int numBytes, const char *charset);
	// READFILETEXT64_END
	// READFILETEXT32_BEGIN
	bool ReadFileText32(const char *handle, int offset32, int numBytes, const char *charset, CkString &outStr);
	const char *readFileText32(const char *handle, int offset32, int numBytes, const char *charset);
	// READFILETEXT32_END
	// DOWNLOADFILE_BEGIN
	bool DownloadFile(const char *handle, const char *toFilename);
	// DOWNLOADFILE_END
	// EOF_BEGIN
	bool Eof(const char *handle);
	// EOF_END
	// READFILEBYTES_BEGIN
	bool ReadFileBytes(const char *handle, int numBytes, CkByteData &outBytes);
	// READFILEBYTES_END
	// READFILETEXT_BEGIN
	bool ReadFileText(const char *handle, int numBytes, const char *charset, CkString &outStr);
	const char *readFileText(const char *handle, int numBytes, const char *charset);
	// READFILETEXT_END
	// LASTREADFAILED_BEGIN
	bool LastReadFailed(const char *handle);
	// LASTREADFAILED_END
	// LASTREADNUMBYTES_BEGIN
	int LastReadNumBytes(const char *handle);
	// LASTREADNUMBYTES_END
	// WRITEFILEBYTES_BEGIN
	bool WriteFileBytes(const char *handle, CkByteData &data);
	// WRITEFILEBYTES_END
	// WRITEFILEBYTES32_BEGIN
	bool WriteFileBytes32(const char *handle, int offset, CkByteData &data);
	// WRITEFILEBYTES32_END
	// WRITEFILEBYTES64_BEGIN
	bool WriteFileBytes64(const char *handle, __int64 offset64, CkByteData &data);
	// WRITEFILEBYTES64_END
	// WRITEFILEBYTES64S_BEGIN
	bool WriteFileBytes64s(const char *handle, const char *offset64, CkByteData &data);
	// WRITEFILEBYTES64S_END
	// WRITEFILETEXT_BEGIN
	bool WriteFileText(const char *handle, const char *charset, const char *textData);
	// WRITEFILETEXT_END
	// WRITEFILETEXT32_BEGIN
	bool WriteFileText32(const char *handle, int offset32, const char *charset, const char *textData);
	// WRITEFILETEXT32_END
	// WRITEFILETEXT64_BEGIN
	bool WriteFileText64(const char *handle, __int64 offset64, const char *charset, const char *textData);
	// WRITEFILETEXT64_END
	// WRITEFILETEXT64S_BEGIN
	bool WriteFileText64s(const char *handle, const char *offset64, const char *charset, const char *textData);
	// WRITEFILETEXT64S_END
	// UPLOADFILE_BEGIN
	bool UploadFile(const char *handle, const char *fromFilename);
	// UPLOADFILE_END
	// REALPATH_BEGIN
	bool RealPath(const char *originalPath, const char *composePath, CkString &outStr);
	const char *realPath(const char *originalPath, const char *composePath);
	// REALPATH_END
	// READDIR_BEGIN
	CkSFtpDir *ReadDir(const char *handle);
	// READDIR_END
	// REMOVEFILE_BEGIN
	bool RemoveFile(const char *filename);
	// REMOVEFILE_END
	// REMOVEDIR_BEGIN
	bool RemoveDir(const char *path);
	// REMOVEDIR_END
	// RENAMEFILEORDIR_BEGIN
	bool RenameFileOrDir(const char *oldPath, const char *newPath);
	// RENAMEFILEORDIR_END
	// CREATEDIR_BEGIN
	bool CreateDir(const char *path);
	// CREATEDIR_END
	// SETCREATETIME_BEGIN
	bool SetCreateTime(const char *pathOrHandle, bool bIsHandle, SYSTEMTIME &createTime);
	// SETCREATETIME_END
	// SETLASTMODIFIEDTIME_BEGIN
	bool SetLastModifiedTime(const char *pathOrHandle, bool bIsHandle, SYSTEMTIME &createTime);
	// SETLASTMODIFIEDTIME_END
	// SETLASTACCESSTIME_BEGIN
	bool SetLastAccessTime(const char *pathOrHandle, bool bIsHandle, SYSTEMTIME &createTime);
	// SETLASTACCESSTIME_END
	// SETOWNERANDGROUP_BEGIN
	bool SetOwnerAndGroup(const char *pathOrHandle, bool bIsHandle, const char *owner, const char *group);
	// SETOWNERANDGROUP_END
	// SETPERMISSIONS_BEGIN
	bool SetPermissions(const char *pathOrHandle, bool bIsHandle, int perm);
	// SETPERMISSIONS_END
	// COPYFILEATTR_BEGIN
	bool CopyFileAttr(const char *localFilename, const char *remoteFilenameOrHandle, bool bIsHandle);
	// COPYFILEATTR_END
	// PROTOCOLVERSION_BEGIN
	int get_ProtocolVersion(void);
	// PROTOCOLVERSION_END

	// SFTP_INSERT_POINT

	// END PUBLIC INTERFACE


};
#pragma pack (pop)


#endif


