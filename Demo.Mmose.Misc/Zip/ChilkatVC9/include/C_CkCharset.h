#ifndef _CkCharset_H
#define _CkCharset_H
#include "Chilkat_C.h"

HCkCharset CkCharset_Create(void);
void CkCharset_Dispose(HCkCharset handle);
/*
	Name: AltToCharset
	Type: CkString &
	Arg #1: str - CkString &
	Arg #2: charsetName - const char *
*/
void CkCharset_getAltToCharset(HCkCharset handle, HCkString retval);
/*
	Name: AltToCharset
	Type: CkString &
	Arg #1: str - CkString &
	Arg #2: charsetName - const char *
*/
void CkCharset_putAltToCharset(HCkCharset handle, const char *newVal);
/*
	Name: ErrorAction
	Type: int
	Arg #1: val - int
*/
int CkCharset_getErrorAction(HCkCharset handle);
/*
	Name: ErrorAction
	Type: int
	Arg #1: val - int
*/
void CkCharset_putErrorAction(HCkCharset handle, int newVal);
/*
	Name: FromCharset
	Type: CkString &
	Arg #1: str - CkString &
	Arg #2: charset - const char *
*/
void CkCharset_getFromCharset(HCkCharset handle, HCkString retval);
/*
	Name: FromCharset
	Type: CkString &
	Arg #1: str - CkString &
	Arg #2: charset - const char *
*/
void CkCharset_putFromCharset(HCkCharset handle, const char *newVal);
/*
	Name: LastErrorHtml
	Type: CkString &
	Arg #1: str - CkString &
*/
void CkCharset_getLastErrorHtml(HCkCharset handle, HCkString retval);
/*
	Name: LastErrorText
	Type: CkString &
	Arg #1: str - CkString &
*/
void CkCharset_getLastErrorText(HCkCharset handle, HCkString retval);
/*
	Name: LastErrorXml
	Type: CkString &
	Arg #1: str - CkString &
*/
void CkCharset_getLastErrorXml(HCkCharset handle, HCkString retval);
/*
	Name: LastInputAsHex
	Type: CkString &
	Arg #1: str - CkString &
*/
void CkCharset_getLastInputAsHex(HCkCharset handle, HCkString retval);
/*
	Name: LastInputAsQP
	Type: CkString &
	Arg #1: str - CkString &
*/
void CkCharset_getLastInputAsQP(HCkCharset handle, HCkString retval);
/*
	Name: LastOutputAsHex
	Type: CkString &
	Arg #1: str - CkString &
*/
void CkCharset_getLastOutputAsHex(HCkCharset handle, HCkString retval);
/*
	Name: LastOutputAsQP
	Type: CkString &
	Arg #1: str - CkString &
*/
void CkCharset_getLastOutputAsQP(HCkCharset handle, HCkString retval);
/*
	Name: SaveLast
	Type: bool
	Arg #1: value - bool
*/
BOOL CkCharset_getSaveLast(HCkCharset handle);
/*
	Name: SaveLast
	Type: bool
	Arg #1: value - bool
*/
void CkCharset_putSaveLast(HCkCharset handle, BOOL newVal);
/*
	Name: ToCharset
	Type: CkString &
	Arg #1: str - CkString &
	Arg #2: charset - const char *
*/
void CkCharset_getToCharset(HCkCharset handle, HCkString retval);
/*
	Name: ToCharset
	Type: CkString &
	Arg #1: str - CkString &
	Arg #2: charset - const char *
*/
void CkCharset_putToCharset(HCkCharset handle, const char *newVal);
/*
	Name: Utf8
	Type: bool
	Arg #1: b - bool
*/
BOOL CkCharset_getUtf8(HCkCharset handle);
/*
	Name: Utf8
	Type: bool
	Arg #1: b - bool
*/
void CkCharset_putUtf8(HCkCharset handle, BOOL newVal);
/*
	Name: Version
	Type: CkString &
	Arg #1: str - CkString &
*/
void CkCharset_getVersion(HCkCharset handle, HCkString retval);
/*
	Name: CharsetToCodePage
	Type: int
	Arg #1: charsetName - const char *
*/
int CkCharset_CharsetToCodePage(HCkCharset handle, const char *charsetName);
/*
	Name: CodePageToCharset
	Type: bool
	Arg #1: codePage - int
	Arg #2: sCharset - CkString &
*/
BOOL CkCharset_CodePageToCharset(HCkCharset handle, int codePage, HCkString sCharset);
/*
	Name: ConvertData
	Type: bool
	Arg #1: inData - const CkByteData &
	Arg #2: outData - CkByteData &
*/
BOOL CkCharset_ConvertData(HCkCharset handle, HCkByteData inData, HCkByteData outData);
/*
	Name: ConvertData
	Type: bool
	Arg #1: inData - const unsigned char *
	Arg #2: inDataLen - unsigned long
	Arg #3: outData - CkByteData &
*/
BOOL CkCharset_ConvertData2(HCkCharset handle, const unsigned char *inData, unsigned long inDataLen, HCkByteData outData);
/*
	Name: ConvertData
	Type: bool
	Arg #1: inData - const unsigned char *
	Arg #2: inDataLen - unsigned long
	Arg #3: outData - unsigned char *
	Arg #4: outDataLen - unsigned long *
*/
BOOL CkCharset_ConvertData3(HCkCharset handle, const unsigned char *inData, unsigned long inDataLen, unsigned char *outData, unsigned long *outDataLen);
/*
	Name: ConvertFile
	Type: bool
	Arg #1: inFilename - const char *
	Arg #2: outFilename - const char *
*/
BOOL CkCharset_ConvertFile(HCkCharset handle, const char *inFilename, const char *outFilename);
/*
	Name: ConvertFromUnicode
	Type: bool
	Arg #1: uniData - const CkByteData &
	Arg #2: mbData - CkByteData &
*/
BOOL CkCharset_ConvertFromUnicode(HCkCharset handle, HCkByteData uniData, HCkByteData mbData);
/*
	Name: ConvertFromUnicode
	Type: bool
	Arg #1: data - const unsigned char *
	Arg #2: dataLen - unsigned long
	Arg #3: mbData - CkByteData &
*/
BOOL CkCharset_ConvertFromUnicode2(HCkCharset handle, const unsigned char *data, unsigned long dataLen, HCkByteData mbData);
/*
	Name: ConvertHtml
	Type: bool
	Arg #1: htmlIn - const CkByteData &
	Arg #2: htmlOut - CkByteData &
*/
BOOL CkCharset_ConvertHtml(HCkCharset handle, HCkByteData htmlIn, HCkByteData htmlOut);
/*
	Name: ConvertHtml
	Type: bool
	Arg #1: htmlIn - const unsigned char *
	Arg #2: htmlInLen - unsigned long
	Arg #3: htmlOut - CkByteData &
*/
BOOL CkCharset_ConvertHtml2(HCkCharset handle, const unsigned char *htmlIn, unsigned long htmlInLen, HCkByteData htmlOut);
/*
	Name: ConvertHtmlFile
	Type: bool
	Arg #1: inFilename - const char *
	Arg #2: outFilename - const char *
*/
BOOL CkCharset_ConvertHtmlFile(HCkCharset handle, const char *inFilename, const char *outFilename);
/*
	Name: ConvertToUnicode
	Type: bool
	Arg #1: mbData - const CkByteData &
	Arg #2: uniData - CkByteData &
*/
BOOL CkCharset_ConvertToUnicode(HCkCharset handle, HCkByteData mbData, HCkByteData uniData);
/*
	Name: ConvertToUnicode
	Type: bool
	Arg #1: data - const unsigned char *
	Arg #2: dataLen - unsigned long
	Arg #3: uniData - CkByteData &
*/
BOOL CkCharset_ConvertToUnicode2(HCkCharset handle, const unsigned char *data, unsigned long dataLen, HCkByteData uniData);
/*
	Name: EntityEncodeDec
	Type: void
	Arg #1: inStr - const char *
	Arg #2: outStr - CkString &
*/
void CkCharset_EntityEncodeDec(HCkCharset handle, const char *inStr, HCkString outStr);
/*
	Name: EntityEncodeHex
	Type: void
	Arg #1: inStr - const char *
	Arg #2: outStr - CkString &
*/
void CkCharset_EntityEncodeHex(HCkCharset handle, const char *inStr, HCkString outStr);
/*
	Name: GetHtmlCharset
	Type: bool
	Arg #1: htmlData - const CkByteData &
	Arg #2: strCharset - CkString &
*/
BOOL CkCharset_GetHtmlCharset(HCkCharset handle, HCkByteData htmlData, HCkString strCharset);
/*
	Name: GetHtmlCharset
	Type: bool
	Arg #1: htmlData - const unsigned char *
	Arg #2: htmlDataLen - unsigned long
	Arg #3: strCharset - CkString &
*/
BOOL CkCharset_GetHtmlCharset2(HCkCharset handle, const unsigned char *htmlData, unsigned long htmlDataLen, HCkString strCharset);
/*
	Name: GetHtmlFileCharset
	Type: bool
	Arg #1: htmlFilename - const char *
	Arg #2: strCharset - CkString &
*/
BOOL CkCharset_GetHtmlFileCharset(HCkCharset handle, const char *htmlFilename, HCkString strCharset);
/*
	Name: HtmlDecodeToStr
	Type: bool
	Arg #1: str - const char *
	Arg #2: strOut - CkString &
*/
BOOL CkCharset_HtmlDecodeToStr(HCkCharset handle, const char *str, HCkString strOut);
/*
	Name: HtmlEntityDecode
	Type: bool
	Arg #1: inData - CkByteData &
	Arg #2: outData - CkByteData &
*/
BOOL CkCharset_HtmlEntityDecode(HCkCharset handle, HCkByteData inData, HCkByteData outData);
/*
	Name: HtmlEntityDecodeFile
	Type: bool
	Arg #1: inFilename - const char *
	Arg #2: outFilename - const char *
*/
BOOL CkCharset_HtmlEntityDecodeFile(HCkCharset handle, const char *inFilename, const char *outFilename);
/*
	Name: IsUnlocked
	Type: bool
*/
BOOL CkCharset_IsUnlocked(HCkCharset handle);
/*
	Name: LowerCase
	Type: void
	Arg #1: inStr - const char *
	Arg #2: outStr - CkString &
*/
void CkCharset_LowerCase(HCkCharset handle, const char *inStr, HCkString outStr);
/*
	Name: ReadFile
	Type: bool
	Arg #1: filename - const char *
	Arg #2: dataBuf - CkByteData &
*/
BOOL CkCharset_ReadFile(HCkCharset handle, const char *filename, HCkByteData dataBuf);
/*
	Name: SaveLastError
	Type: bool
	Arg #1: filename - const char *
*/
BOOL CkCharset_SaveLastError(HCkCharset handle, const char *filename);
/*
	Name: SetErrorBytes
	Type: void
	Arg #1: data - const unsigned char *
	Arg #2: dataLen - unsigned long
*/
void CkCharset_SetErrorBytes(HCkCharset handle, const unsigned char *data, unsigned long dataLen);
/*
	Name: SetErrorString
	Type: void
	Arg #1: str - const char *
*/
void CkCharset_SetErrorString(HCkCharset handle, const char *str);
/*
	Name: UnlockComponent
	Type: bool
	Arg #1: unlockCode - const char *
*/
BOOL CkCharset_UnlockComponent(HCkCharset handle, const char *unlockCode);
/*
	Name: UpperCase
	Type: void
	Arg #1: inStr - const char *
	Arg #2: outStr - CkString &
*/
void CkCharset_UpperCase(HCkCharset handle, const char *inStr, HCkString outStr);
/*
	Name: VerifyData
	Type: bool
	Arg #1: charset - const char *
	Arg #2: charData - const CkByteData &
*/
BOOL CkCharset_VerifyData(HCkCharset handle, const char *charset, HCkByteData charData);
/*
	Name: VerifyFile
	Type: bool
	Arg #1: charset - const char *
	Arg #2: filename - const char *
*/
BOOL CkCharset_VerifyFile(HCkCharset handle, const char *charset, const char *filename);
/*
	Name: WriteFile
	Type: bool
	Arg #1: filename - const char *
	Arg #2: dataBuf - const CkByteData &
*/
BOOL CkCharset_WriteFile2(HCkCharset handle, const char *filename, HCkByteData dataBuf);
/*
	Name: WriteFile
	Type: bool
	Arg #1: filename - const char *
	Arg #2: data - const unsigned char *
	Arg #3: dataLen - unsigned long
*/
BOOL CkCharset_WriteFile(HCkCharset handle, const char *filename, const unsigned char *data, unsigned long dataLen);
/*
	Name: altToCharset
	Type: const char *
*/
const char *CkCharset_altToCharset(HCkCharset handle);
/*
	Name: codePageToCharset
	Type: const char *
	Arg #1: codePage - int
*/
const char *CkCharset_codePageToCharset(HCkCharset handle, int codePage);
/*
	Name: entityEncodeDec
	Type: const char *
	Arg #1: inStr - const char *
*/
const char *CkCharset_entityEncodeDec(HCkCharset handle, const char *inStr);
/*
	Name: entityEncodeHex
	Type: const char *
	Arg #1: inStr - const char *
*/
const char *CkCharset_entityEncodeHex(HCkCharset handle, const char *inStr);
/*
	Name: fromCharset
	Type: const char *
*/
const char *CkCharset_fromCharset(HCkCharset handle);
/*
	Name: getHtmlCharset
	Type: const char *
	Arg #1: htmlData - const CkByteData &
*/
const char *CkCharset_getHtmlCharset(HCkCharset handle, HCkByteData htmlData);
/*
	Name: getHtmlCharset
	Type: const char *
	Arg #1: htmlData - const unsigned char *
	Arg #2: htmlDataLen - unsigned long
*/
const char *CkCharset_getHtmlCharset2(HCkCharset handle, const unsigned char *htmlData, unsigned long htmlDataLen);
/*
	Name: getHtmlFileCharset
	Type: const char *
	Arg #1: htmlFilename - const char *
*/
const char *CkCharset_getHtmlFileCharset(HCkCharset handle, const char *htmlFilename);
/*
	Name: htmlDecodeToStr
	Type: const char *
	Arg #1: str - const char *
*/
const char *CkCharset_htmlDecodeToStr(HCkCharset handle, const char *str);
/*
	Name: lastErrorHtml
	Type: const char *
*/
const char *CkCharset_lastErrorHtml(HCkCharset handle);
/*
	Name: lastErrorText
	Type: const char *
*/
const char *CkCharset_lastErrorText(HCkCharset handle);
/*
	Name: lastErrorXml
	Type: const char *
*/
const char *CkCharset_lastErrorXml(HCkCharset handle);
/*
	Name: lastInputAsHex
	Type: const char *
*/
const char *CkCharset_lastInputAsHex(HCkCharset handle);
/*
	Name: lastInputAsQP
	Type: const char *
*/
const char *CkCharset_lastInputAsQP(HCkCharset handle);
/*
	Name: lastOutputAsHex
	Type: const char *
*/
const char *CkCharset_lastOutputAsHex(HCkCharset handle);
/*
	Name: lastOutputAsQP
	Type: const char *
*/
const char *CkCharset_lastOutputAsQP(HCkCharset handle);
/*
	Name: lowerCase
	Type: const char *
	Arg #1: inStr - const char *
*/
const char *CkCharset_lowerCase(HCkCharset handle, const char *inStr);
/*
	Name: toCharset
	Type: const char *
*/
const char *CkCharset_toCharset(HCkCharset handle);
/*
	Name: upperCase
	Type: const char *
	Arg #1: inStr - const char *
*/
const char *CkCharset_upperCase(HCkCharset handle, const char *inStr);
/*
	Name: version
	Type: const char *
*/
const char *CkCharset_version(HCkCharset handle);
#endif
