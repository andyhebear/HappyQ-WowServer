// CkSsh.h: interface for the CkSsh class.
//
//////////////////////////////////////////////////////////////////////

#ifndef _CkSsh_H
#define _CkSsh_H

#pragma once

#include "CkString.h"
class CkByteData;
class CkSshProgress;
class CkSshKey;
#include "CkObject.h"

#pragma pack (push, 8) 

// CLASS: CkSsh
class CkSsh  : public CkObject
{
    private:
	CkSshProgress *m_callback;

	void *m_impl;
	bool m_utf8;	// If true, all input "const char *" parameters are utf-8, otherwise they are ANSI strings.

	// Don't allow assignment or copying these objects.
	CkSsh(const CkSsh &);
	CkSsh &operator=(const CkSsh &);

	unsigned long nextIdx(void);
	unsigned long m_resultIdx;
	CkString m_resultString[10];

    public:
	void *getImpl(void) const;

	CkSsh(void *impl);

	CkSsh();
	virtual ~CkSsh();

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
	
	CkSshProgress *get_EventCallbackObject(void) const;
	void put_EventCallbackObject(CkSshProgress *progress);

	// CONNECT_BEGIN
	bool Connect(const char *hostname, int port);
	// CONNECT_END
	// UNLOCKCOMPONENT_BEGIN
	bool UnlockComponent(const char *unlockCode);
	// UNLOCKCOMPONENT_END
	// AUTHENTICATEPW_BEGIN
	bool AuthenticatePw(const char *login, const char *password);
	// AUTHENTICATEPW_END
	// VERSION_BEGIN
	void get_Version(CkString &str);
	const char *version(void);
	// VERSION_END
	// KEEPSESSIONLOG_BEGIN
	bool get_KeepSessionLog(void);
	void put_KeepSessionLog(bool newVal);
	// KEEPSESSIONLOG_END
	// SESSIONLOG_BEGIN
	void get_SessionLog(CkString &str);
	const char *sessionLog(void);
	// SESSIONLOG_END
	// IDLETIMEOUTMS_BEGIN
	int get_IdleTimeoutMs(void);
	void put_IdleTimeoutMs(int newVal);
	// IDLETIMEOUTMS_END
	// CONNECTTIMEOUTMS_BEGIN
	int get_ConnectTimeoutMs(void);
	void put_ConnectTimeoutMs(int newVal);
	// CONNECTTIMEOUTMS_END
	// CHANNELOPENFAILCODE_BEGIN
	int get_ChannelOpenFailCode(void);
	// CHANNELOPENFAILCODE_END
	// DISCONNECTCODE_BEGIN
	int get_DisconnectCode(void);
	// DISCONNECTCODE_END
	// DISCONNECTREASON_BEGIN
	void get_DisconnectReason(CkString &str);
	const char *disconnectReason(void);
	// DISCONNECTREASON_END
	// CHANNELOPENFAILREASON_BEGIN
	void get_ChannelOpenFailReason(CkString &str);
	const char *channelOpenFailReason(void);
	// CHANNELOPENFAILREASON_END
	// MAXPACKETSIZE_BEGIN
	int get_MaxPacketSize(void);
	void put_MaxPacketSize(int newVal);
	// MAXPACKETSIZE_END
	// DISCONNECT_BEGIN
	void Disconnect(void);
	// DISCONNECT_END
	// OPENSESSIONCHANNEL_BEGIN
	int OpenSessionChannel(void);
	// OPENSESSIONCHANNEL_END
	// OPENX11CHANNEL_BEGIN
	//int OpenX11Channel(const char *xAddress, int port);
	// OPENX11CHANNEL_END
	// OPENFORWARDEDTCPIPCHANNEL_BEGIN
	//int OpenForwardedTcpIpChannel(void);
	// OPENFORWARDEDTCPIPCHANNEL_END
	// OPENDIRECTTCPIPCHANNEL_BEGIN
	//int OpenDirectTcpIpChannel(void);
	// OPENDIRECTTCPIPCHANNEL_END
	// OPENCUSTOMCHANNEL_BEGIN
	int OpenCustomChannel(const char *channelType);
	// OPENCUSTOMCHANNEL_END
	// NUMOPENCHANNELS_BEGIN
	int get_NumOpenChannels(void);
	// NUMOPENCHANNELS_END
	// GETCHANNELNUMBER_BEGIN
	int GetChannelNumber(int index);
	// GETCHANNELNUMBER_END
	// GETCHANNELTYPE_BEGIN
	bool GetChannelType(int index, CkString &outStr);
	const char *getChannelType(int index);
	// GETCHANNELTYPE_END
	// SENDREQPTY_BEGIN
	bool SendReqPty(int channelNum, const char *xTermEnvVar, int widthInChars, int heightInRows, int pixWidth, int pixHeight);
	// SENDREQPTY_END
	// SENDREQX11FORWARDING_BEGIN
	bool SendReqX11Forwarding(int channelNum, bool singleConnection, const char *authProt, const char *authCookie, int screenNum);
	// SENDREQX11FORWARDING_END
	// SENDREQSETENV_BEGIN
	bool SendReqSetEnv(int channelNum, const char *name, const char *value);
	// SENDREQSETENV_END
	// SENDREQSHELL_BEGIN
	bool SendReqShell(int channelNum);
	// SENDREQSHELL_END
	// SENDREQEXEC_BEGIN
	bool SendReqExec(int channelNum, const char *command);
	// SENDREQEXEC_END
	// SENDREQSUBSYSTEM_BEGIN
	bool SendReqSubsystem(int channelNum, const char *subsystemName);
	// SENDREQSUBSYSTEM_END
	// SENDREQWINDOWCHANGE_BEGIN
	bool SendReqWindowChange(int channelNum, int widthInChars, int heightInRows, int pixWidth, int pixHeight);
	// SENDREQWINDOWCHANGE_END
	// SENDREQXONXOFF_BEGIN
	bool SendReqXonXoff(int channelNum, bool clientCanDo);
	// SENDREQXONXOFF_END
	// SENDREQSIGNAL_BEGIN
	bool SendReqSignal(int channelNum, const char *signalName);
	// SENDREQSIGNAL_END
	// CHANNELSENDDATA_BEGIN
	bool ChannelSendData(int channelNum, CkByteData &data);
	// CHANNELSENDDATA_END
	// CHANNELSENDSTRING_BEGIN
	bool ChannelSendString(int channelNum, const char *strData, const char *charset);
	// CHANNELSENDSTRING_END
	// CHANNELPOLL_BEGIN
	int ChannelPoll(int channelNum, int pollTimeoutMs);
	// CHANNELPOLL_END
	// CHANNELREADANDPOLL_BEGIN
	int ChannelReadAndPoll(int channelNum, int pollTimeoutMs);
	// CHANNELREADANDPOLL_END
	// CHANNELREAD_BEGIN
	int ChannelRead(int channelNum);
	// CHANNELREAD_END
	// GETRECEIVEDDATA_BEGIN
	void GetReceivedData(int channelNum, CkByteData &outBytes);
	// GETRECEIVEDDATA_END
	// GETRECEIVEDSTDERR_BEGIN
	void GetReceivedStderr(int channelNum, CkByteData &outBytes);
	// GETRECEIVEDSTDERR_END
	// CHANNELRECEIVEDEOF_BEGIN
	bool ChannelReceivedEof(int channelNum);
	// CHANNELRECEIVEDEOF_END
	// CHANNELRECEIVEDCLOSE_BEGIN
	bool ChannelReceivedClose(int channelNum);
	// CHANNELRECEIVEDCLOSE_END
	// CHANNELSENDCLOSE_BEGIN
	bool ChannelSendClose(int channelNum);
	// CHANNELSENDCLOSE_END
	// CHANNELSENDEOF_BEGIN
	bool ChannelSendEof(int channelNum);
	// CHANNELSENDEOF_END
	// CHANNELISOPEN_BEGIN
	bool ChannelIsOpen(int channelNum);
	// CHANNELISOPEN_END
	// CHANNELRECEIVETOCLOSE_BEGIN
	bool ChannelReceiveToClose(int channelNum);
	// CHANNELRECEIVETOCLOSE_END
	// CLEARTTYMODES_BEGIN
	void ClearTtyModes(void);
	// CLEARTTYMODES_END
	// SETTTYMODE_BEGIN
	bool SetTtyMode(const char *name, int value);
	// SETTTYMODE_END
	// ISCONNECTED_BEGIN
	bool get_IsConnected(void);
	// ISCONNECTED_END
	// REKEY_BEGIN
	bool ReKey(void);
	// REKEY_END
	// AUTHENTICATEPK_BEGIN
	bool AuthenticatePk(const char *username, CkSshKey &privateKey);
	// AUTHENTICATEPK_END
	// GETRECEIVEDTEXT_BEGIN
	bool GetReceivedText(int channelNum, const char *charset, CkString &outStr);
	const char *getReceivedText(int channelNum, const char *charset);
	// GETRECEIVEDTEXT_END
	// GETRECEIVEDNUMBYTES_BEGIN
	int GetReceivedNumBytes(int channelNum);
	// GETRECEIVEDNUMBYTES_END

	// SSH_INSERT_POINT

	// END PUBLIC INTERFACE


};
#pragma pack (pop)


#endif


