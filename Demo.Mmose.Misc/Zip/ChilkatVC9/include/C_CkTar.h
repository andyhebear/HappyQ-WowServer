#ifndef _CkTar_H
#define _CkTar_H
#include "Chilkat_C.h"

HCkTar CkTar_Create(void);
void CkTar_Dispose(HCkTar handle);
void CkTar_getLastErrorHtml(HCkTar handle, HCkString retval);
void CkTar_getLastErrorText(HCkTar handle, HCkString retval);
void CkTar_getLastErrorXml(HCkTar handle, HCkString retval);
BOOL CkTar_getNoAbsolutePaths(HCkTar handle);
void CkTar_putNoAbsolutePaths(HCkTar handle, BOOL newVal);
BOOL CkTar_getUntarCaseSensitive(HCkTar handle);
void CkTar_putUntarCaseSensitive(HCkTar handle, BOOL newVal);
BOOL CkTar_getUntarDebugLog(HCkTar handle);
void CkTar_putUntarDebugLog(HCkTar handle, BOOL newVal);
BOOL CkTar_getUntarDiscardPaths(HCkTar handle);
void CkTar_putUntarDiscardPaths(HCkTar handle, BOOL newVal);
void CkTar_getUntarFromDir(HCkTar handle, HCkString retval);
void CkTar_putUntarFromDir(HCkTar handle, const char *newVal);
void CkTar_getUntarMatchPattern(HCkTar handle, HCkString retval);
void CkTar_putUntarMatchPattern(HCkTar handle, const char *newVal);
int CkTar_getUntarMaxCount(HCkTar handle);
void CkTar_putUntarMaxCount(HCkTar handle, int newVal);
BOOL CkTar_getUtf8(HCkTar handle);
void CkTar_putUtf8(HCkTar handle, BOOL newVal);
void CkTar_getVersion(HCkTar handle, HCkString retval);
BOOL CkTar_SaveLastError(HCkTar handle, const char *filename);
BOOL CkTar_UnlockComponent(HCkTar handle, const char *unlockCode);
int CkTar_Untar(HCkTar handle, const char *tarFilename);
const char *CkTar_lastErrorHtml(HCkTar handle);
const char *CkTar_lastErrorText(HCkTar handle);
const char *CkTar_lastErrorXml(HCkTar handle);
const char *CkTar_untarFromDir(HCkTar handle);
const char *CkTar_untarMatchPattern(HCkTar handle);
const char *CkTar_version(HCkTar handle);
#endif
