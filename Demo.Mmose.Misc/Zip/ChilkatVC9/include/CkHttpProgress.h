// CkHttpProgress.h: interface for the CkHttpProgress class.
//
//////////////////////////////////////////////////////////////////////

#ifndef _CKHTTPPROGRESS_H
#define _CKHTTPPROGRESS_H

#pragma once

#pragma pack (push, 8) 

class CkHttpProgress  
{
    public:
	CkHttpProgress() { }
	virtual ~CkHttpProgress() { }

	// Called periodically to check to see if the method call should be aborted.
	virtual void AbortCheck(bool *abort) { }
	virtual void PercentDone(int pctDone, bool *abort) { }


	virtual void HttpRedirect(const char *originalUrl, const char *redirectUrl, bool *abort) { }

	// Called just before a chunked response is about to be received.
	// With chunked responses, it is not possible to get PercentDone callbacks because
	// the entire size of the HTTP response is not known as it is being received.
	virtual void HttpChunked() { }

	virtual void HttpBeginReceive(void) { }
	virtual void HttpEndReceive(bool success) { }
	virtual void HttpBeginSend(void) { }
	virtual void HttpEndSend(bool success) { }

	virtual void ReceiveRate(unsigned long byteCount, unsigned long bytesPerSec) { }

};
#pragma pack (pop)

#endif
