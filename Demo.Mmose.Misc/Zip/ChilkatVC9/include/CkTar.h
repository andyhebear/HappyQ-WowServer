// CkTar.h: interface for the CkTar class.
//
//////////////////////////////////////////////////////////////////////

#ifndef _CKTAR_H
#define _CKTAR_H

#pragma once


class CkByteData;
#include "CkString.h"
#include "CkObject.h"

#pragma warning( disable : 4068 )
#pragma unmanaged

/*
    IMPORTANT: Objects returned by methods as non-const pointers must be deleted
    by the calling application. 

  */
#pragma pack (push, 8) 


// CLASS: CkTar
class CkTar  : public CkObject
{
    public:
	CkTar();
	virtual ~CkTar();

	// BEGIN PUBLIC INTERFACE
	bool get_Utf8(void) const;
	void put_Utf8(bool b);

	// Error log retrieval and saving (these methods are common to all Chilkat VC++ classes.)
	bool SaveLastError(const char *filename);
        void LastErrorXml(CkString &str);
        void LastErrorHtml(CkString &str);
        void LastErrorText(CkString &str);

	void get_Version(CkString &str);

	CkString m_resultString;
        const char *lastErrorText(void);
        const char *lastErrorXml(void);
        const char *lastErrorHtml(void);
	const char *version(void); 
	// NOABSOLUTEPATHS_BEGIN
	bool get_NoAbsolutePaths(void);
	void put_NoAbsolutePaths(bool newVal);
	// NOABSOLUTEPATHS_END
	// UNTARCASESENSITIVE_BEGIN
	bool get_UntarCaseSensitive(void);
	void put_UntarCaseSensitive(bool newVal);
	// UNTARCASESENSITIVE_END
	// UNTARDEBUGLOG_BEGIN
	bool get_UntarDebugLog(void);
	void put_UntarDebugLog(bool newVal);
	// UNTARDEBUGLOG_END
	// UNTARDISCARDPATHS_BEGIN
	bool get_UntarDiscardPaths(void);
	void put_UntarDiscardPaths(bool newVal);
	// UNTARDISCARDPATHS_END
	// UNTARFROMDIR_BEGIN
	void get_UntarFromDir(CkString &str);
	const char *untarFromDir(void);
	void put_UntarFromDir(const char *newVal);
	// UNTARFROMDIR_END
	// UNTARMATCHPATTERN_BEGIN
	void get_UntarMatchPattern(CkString &str);
	const char *untarMatchPattern(void);
	void put_UntarMatchPattern(const char *newVal);
	// UNTARMATCHPATTERN_END
	// UNTARMAXCOUNT_BEGIN
	int get_UntarMaxCount(void);
	void put_UntarMaxCount(int newVal);
	// UNTARMAXCOUNT_END
	// UNLOCKCOMPONENT_BEGIN
	bool UnlockComponent(const char *unlockCode);
	// UNLOCKCOMPONENT_END
	// UNTAR_BEGIN
	int Untar(const char *tarFilename);
	// UNTAR_END
	// UNTARFROMMEMORY_BEGIN
	int UntarFromMemory(CkByteData &tarFileBytes);
	// UNTARFROMMEMORY_END
	// UNTARFIRSTMATCHINGTOMEMORY_BEGIN
	bool UntarFirstMatchingToMemory(CkByteData &tarFileBytes, const char *matchPattern, CkByteData &outBytes);
	// UNTARFIRSTMATCHINGTOMEMORY_END

	// TAR_INSERT_POINT

	// END PUBLIC INTERFACE


    // For internal use only.
    private:
	void *m_impl;
	bool m_utf8;	// If true, all input "const char *" parameters are utf-8, otherwise they are ANSI strings.

	// Don't allow assignment or copying these objects.
	CkTar(const CkTar &) { } 
	CkTar &operator=(const CkTar &) { return *this; }
	CkTar(void *impl);

    public:
	void *getImpl(void) const { return m_impl; } 



};

#pragma pack (pop)

#endif


