// Demo.Mmose.Zip.h

#pragma once


class Global
{
public:

	static const int BUFFER_SIZE;
};

class GlobalString
{
public:

	static const char* ZIP_LICENCE;

	static const char* COMPRESS_LICENCE;

	static const char* COMPRESS_ALGORITHM_DEFLATE;

	static const char* COMPRESS_ALGORITHM_PPMD;

	static const char* COMPRESS_ALGORITHM_BZIP2;

	static const char* COMPRESS_ALGORITHM_LZW;

	static const char* COMPRESS_CHAR_SET;

	static const char* COMPRESS_ENCODING_BASE64;

	static const char* COMPRESS_ENCODING_HEX;

	static const char* COMPRESS_ENCODING_URL;

	static const char* COMPRESS_ENCODING_QUOTED_PRINTABLE;

};

namespace Demo
{
	namespace Mmose
	{
		namespace Zip
		{

			public enum class EncodingMode
			{
				Byte = 0x00,
				Base64 = 0x01,
				Hex = 0x02,
				Url = 0x03,
				QuotedPrintable = 0x04
			};

		}
	}
}