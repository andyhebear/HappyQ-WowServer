// CkSocket.h: interface for the CkSocket class.
//
//////////////////////////////////////////////////////////////////////

#ifndef _CKSOCKET_H
#define _CKSOCKET_H

#pragma once


class CkByteData;
#include "CkString.h"
#include "CkObject.h"

class CkCert;
class CkSocketProgress;

#pragma warning( disable : 4068 )
#pragma unmanaged

/*
    IMPORTANT: Objects returned by methods as non-const pointers must be deleted
    by the calling application. 

  */

#pragma pack (push, 8) 

// CLASS: CkSocket
class CkSocket  : public CkObject
{
    public:
	CkSocket();
	virtual ~CkSocket();

	bool SendBytes(const char *byteData, unsigned long numBytes);

	// BEGIN PUBLIC INTERFACE
	bool get_Utf8(void) const;
	void put_Utf8(bool b);

	CkSocketProgress *get_EventCallbackObject(void) const { return m_callback; }
	void put_EventCallbackObject(CkSocketProgress *progress) { m_callback = progress; }

	CkCert *GetSslServerCert(void);
	CkCert *GetMyCert(void);

	bool UnlockComponent(const char *code);
	bool IsUnlocked(void) const;

	// Error log retrieval and saving (these methods are common to all Chilkat VC++ classes.)
	bool SaveLastError(const char *filename);
        void LastErrorXml(CkString &str);
        void LastErrorHtml(CkString &str);
        void LastErrorText(CkString &str);

	void get_Version(CkString &str);
	long get_ObjectId(void);

	bool AsyncDnsStart(const char *hostname, int maxWaitMs);
	bool get_AsyncDnsFinished(void);	// True if finished, false if in progress.
	void get_AsyncDnsResult(CkString &str);
	void AsyncDnsAbort(void);	// Abort the async DNS operation.
	void get_AsyncDnsLog(CkString &str);
	bool get_AsyncDnsSuccess(void);	// True if successful, false if aborted or failed.

	bool AsyncConnectStart(const char *hostname, int port, bool ssl, int maxWaitMs);
	bool get_AsyncConnectFinished(void);	// True if finished, false if in progress.
	void AsyncConnectAbort(void);	// Abort the async connect operation.
	void get_AsyncConnectLog(CkString &str);
	bool get_AsyncConnectSuccess(void);	// True if successful, false if aborted or failed.

	void SleepMs(int millisec) const;

	void get_MyIpAddress(CkString &str);

	bool BindAndListen(int port, int backlog);

	// Synchronous connect and accept.
	bool Connect(const char *hostname, int port, bool ssl, int maxWaitMs);
	CkSocket *AcceptNextConnection(int maxWaitMs);
	
	void Close(int maxWaitMs);
	
	bool get_Ssl(void);
	void put_Ssl(bool newVal);

	bool InitSslServer(CkCert &cert);
	
	// 0 = success
	// 1-299 = underlying reasons
	// Normal sockets:
	//  1 = empty hostname
	//  2 = DNS lookup failed
	//  3 = DNS timeout
	//  4 = Aborted by application.
	//  5 = Internal failure.
	//  6 = Connect Timed Out
	//  7 = Connect Rejected (or failed for some other reason)
	// SSL:
	//  100 = Internal schannel error
	//  101 = Failed to create credentials
	//  102 = Failed to send initial message to proxy.
	//  103 = Handshake failed.
	//  104 = Failed to obtain remote certificate.
	long get_ConnectFailReason(void);

	long get_HeartbeatMs(void);
	void put_HeartbeatMs(long millisec);

	long get_MaxSendIdleMs(void);
	void put_MaxSendIdleMs(long millisec);

	long get_MaxReadIdleMs(void);
	void put_MaxReadIdleMs(long millisec);

	void get_StringCharset(CkString &str);
	void put_StringCharset(const char *str);

	long get_DebugDnsDelayMs(void);
	void put_DebugDnsDelayMs(long millisec);

	long get_DebugConnectDelayMs(void);
	void put_DebugConnectDelayMs(long millisec);

	bool get_IsConnected(void);

	long get_RemotePort(void);
	void get_RemoteIpAddress(CkString &str);

	bool AsyncAcceptStart(int maxWaitMs);
	bool get_AsyncAcceptFinished(void);
	void AsyncAcceptAbort(void);
	void get_AsyncAcceptLog(CkString &str);
	bool get_AsyncAcceptSuccess(void);
	CkSocket *AsyncAcceptSocket(void);


	bool AsyncSendBytes(const unsigned char *byteData, unsigned long numBytes);
	bool AsyncSendString(const char *str);

	bool get_AsyncSendFinished(void);	// True if finished, false if in progress.
	void AsyncSendAbort(void);		// Abort the async send operation.
	void get_AsyncSendLog(CkString &str);
	bool get_AsyncSendSuccess(void);		// True if successful, false if aborted or failed.

	bool AsyncReceiveBytes(void);
	bool AsyncReceiveBytesN(unsigned long numBytes);
	bool AsyncReceiveString(void);
	bool AsyncReceiveToCRLF(void);
	bool AsyncReceiveUntilMatch(const char *matchStr);

	bool get_AsyncReceiveFinished(void);	// True if finished, false if in progress.
	void AsyncReceiveAbort(void);		// Abort the async receive operation.
	void get_AsyncReceiveLog(CkString &str);
	bool get_AsyncReceiveSuccess(void);		// True if successful, false if aborted or failed.

	void get_AsyncReceivedString(CkString &str);
	void get_AsyncReceivedBytes(CkByteData &byteData);

	const char *asyncReceivedString(void);
	const char *asyncReceiveLog(void);
	const char *asyncSendLog(void);


	void BuildHttpGetRequest(const char *url, CkString &str);

	long get_SendPacketSize(void);
	void put_SendPacketSize(long sizeInBytes);

	long get_ReceivePacketSize(void);
	void put_ReceivePacketSize(long sizeInBytes);

	bool SendString(const char *str);
	bool SendBytes(const unsigned char *byteData, unsigned long numBytes);
	bool ReceiveString(CkString &strOut);
	bool ReceiveUntilMatch(const char *matchStr, CkString &strOut);
	bool ReceiveBytes(CkByteData &byteData);
	bool ReceiveBytesN(unsigned long numBytes, CkByteData &byteData);


	const char *stringCharset(void);
	const char *remoteIpAddress(void);
	const char *asyncAcceptLog(void);
	const char *buildHttpGetRequest(const char *url);
	const char *receiveString(void);
	const char *receiveUntilMatch(const char *matchStr);

        const char *lastErrorText(void);
        const char *lastErrorXml(void);
        const char *lastErrorHtml(void);

	const char *asyncDnsResult(void);
	const char *asyncDnsLog(void);
	const char *asyncConnectLog(void);

	const char *myIpAddress(void);
	const char *version(void);
	// DNSLOOKUP_BEGIN
	bool DnsLookup(const char *hostname, int maxWaitMs, CkString &outStr);
	const char *dnsLookup(const char *hostname, int maxWaitMs);
	// DNSLOOKUP_END
	// RECEIVETOCRLF_BEGIN
	bool ReceiveToCRLF(CkString &outStr);
	const char *receiveToCRLF(void);
	// RECEIVETOCRLF_END
	// SESSIONLOG_BEGIN
	void get_SessionLog(CkString &str);
	const char *sessionLog(void);
	// SESSIONLOG_END
	// KEEPSESSIONLOG_BEGIN
	bool get_KeepSessionLog(void);
	void put_KeepSessionLog(bool newVal);
	// KEEPSESSIONLOG_END
	// SESSIONLOGENCODING_BEGIN
	void get_SessionLogEncoding(CkString &str);
	const char *sessionLogEncoding(void);
	void put_SessionLogEncoding(const char *newVal);
	// SESSIONLOGENCODING_END
	// RECEIVEUNTILBYTE_BEGIN
	bool ReceiveUntilByte(int byteValue, CkByteData &outBytes);
	// RECEIVEUNTILBYTE_END
	// CLEARSESSIONLOG_BEGIN
	void ClearSessionLog(void);
	// CLEARSESSIONLOG_END
	// RECEIVESTRINGUNTILBYTE_BEGIN
	bool ReceiveStringUntilByte(int byteValue, CkString &outStr);
	const char *receiveStringUntilByte(int byteValue);
	// RECEIVESTRINGUNTILBYTE_END
	// RECEIVESTRINGMAXN_BEGIN
	bool ReceiveStringMaxN(int maxBytes, CkString &outStr);
	const char *receiveStringMaxN(int maxBytes);
	// RECEIVESTRINGMAXN_END
	// SSLPROTOCOL_BEGIN
	void get_SslProtocol(CkString &str);
	const char *sslProtocol(void);
	void put_SslProtocol(const char *newVal);
	// SSLPROTOCOL_END
	// SETSSLCLIENTCERT_BEGIN
	void SetSslClientCert(CkCert &cert);
	// SETSSLCLIENTCERT_END
	// CLIENTIPADDRESS_BEGIN
	void get_ClientIpAddress(CkString &str);
	const char *clientIpAddress(void);
	void put_ClientIpAddress(const char *newVal);
	// CLIENTIPADDRESS_END
	// SENDCOUNT_BEGIN
	bool SendCount(int byteCount);
	// SENDCOUNT_END
	// RECEIVECOUNT_BEGIN
	int ReceiveCount(void);
	// RECEIVECOUNT_END
	// LASTMETHODFAILED_BEGIN
	bool get_LastMethodFailed(void);
	// LASTMETHODFAILED_END
	// CONVERTTOSSL_BEGIN
	bool ConvertToSsl(void);
	// CONVERTTOSSL_END
	// CONVERTFROMSSL_BEGIN
	bool ConvertFromSsl(void);
	// CONVERTFROMSSL_END
	// SOSNDBUF_BEGIN
	int get_SoSndBuf(void);
	void put_SoSndBuf(int newVal);
	// SOSNDBUF_END
	// SORCVBUF_BEGIN
	int get_SoRcvBuf(void);
	void put_SoRcvBuf(int newVal);
	// SORCVBUF_END
	// CLIENTPORT_BEGIN
	int get_ClientPort(void);
	void put_ClientPort(int newVal);
	// CLIENTPORT_END

	// SOCKET_INSERT_POINT

	// END PUBLIC INTERFACE


    // For internal use only.
    private:
	CkSocketProgress *m_callback;

	void *m_implCb;
	void *m_impl;
	bool m_utf8;	// If true, all input "const char *" parameters are utf-8, otherwise they are ANSI strings.

	// Don't allow assignment or copying these objects.
	CkSocket(const CkSocket &) { } 
	CkSocket &operator=(const CkSocket &) { return *this; }
	CkSocket(void *impl);

	unsigned long nextIdx(void);
	unsigned long m_resultIdx;
	CkString m_resultString[10];

    public:
	void *getImpl(void) const { return m_impl; } 

};

#pragma pack (pop)

#endif


