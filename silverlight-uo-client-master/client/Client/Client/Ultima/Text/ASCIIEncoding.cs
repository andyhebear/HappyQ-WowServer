using System;
using System.Text;

namespace Client.Text
{
    public class ASCIIEncoding : Encoding
    {
        public static readonly ASCIIEncoding Instance = new ASCIIEncoding();

        /// <summary>
        /// Gets the name registered with the
        /// Internet Assigned Numbers Authority (IANA) for the current encoding.
        /// </summary>
        /// <returns>
        /// The IANA name for the current <see cref="System.Text.Encoding"/>.
        /// </returns>
        public override string WebName
        {
            get
            {
                return "us-ascii";
            }
        }

        public override int GetHashCode()
        {
            return WebName.GetHashCode();
        }

        private char? fallbackCharacter;

        /// <summary>
        /// A character that can be set in order to make the encoding class
        /// more fault tolerant. If this property is set, the encoding class will
        /// use this property instead of throwing an exception if an unsupported
        /// byte value is being passed for decoding.
        /// </summary>
        public char? FallbackCharacter
        {
            get { return fallbackCharacter; }
            set
            {
                fallbackCharacter = value;

                if (value.HasValue && (byte)value > 128)
                {
                    string msg = "Cannot use the character [{0}] (int value {1}) as fallback value "
                    + "- the fallback character itself is not supported by the encoding.";
                    msg = String.Format(msg, value.Value, (int)value.Value);
                    throw new EncoderFallbackException(msg);
                }

                FallbackByte = value.HasValue ? (byte)value.Value : (byte?)null;
            }
        }

        /// <summary>
        /// A byte value that corresponds to the <see cref="FallbackCharacter"/>.
        /// It is used in encoding scenarios in case an unsupported character is
        /// being passed for encoding.
        /// </summary>
        public byte? FallbackByte { get; private set; }


        public ASCIIEncoding()
        {
            FallbackCharacter = '?';
        }

        /// <summary>
        /// Encodes a set of characters from the specified character array into the specified byte array.
        /// </summary>
        /// <returns>
        /// The actual number of bytes written into <paramref name="bytes"/>.
        /// </returns>
        /// <param name="chars">The character array containing the set of characters to encode. 
        /// </param><param name="charIndex">The index of the first character to encode. 
        /// </param><param name="charCount">The number of characters to encode. 
        /// </param><param name="bytes">The byte array to contain the resulting sequence of bytes.
        /// </param><param name="byteIndex">The index at which to start writing the resulting sequence of bytes. 
        /// </param>
        public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex)
        {
            return FallbackByte.HasValue
                     ? GetBytesWithFallBack(chars, charIndex, charCount, bytes, byteIndex)
                     : GetBytesWithoutFallback(chars, charIndex, charCount, bytes, byteIndex);
        }


        private int GetBytesWithFallBack(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex)
        {
            for (int i = 0; i < charCount; i++)
            {
                var character = chars[i + charIndex];
                byte byteValue = (byte)character;

                if (byteValue > 128)
                    bytes[byteIndex + i] = FallbackByte.Value;
                else
                    bytes[byteIndex + i] = byteValue;
            }

            return charCount;
        }

        private int GetBytesWithoutFallback(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex)
        {
            for (int i = 0; i < charCount; i++)
            {
                var character = chars[i + charIndex];
                byte byteValue = (byte)character;
                bool status = byteValue > 128;

                if (!status)
                {
                    //throw exception
                    string msg =
                      "The encoding [{0}] cannot encode the character [{1}] (int value {2}). Set the FallbackCharacter property in order to suppress this exception and encode a default character instead.";
                    msg = String.Format(msg, WebName, character, (int)character);
                    throw new EncoderFallbackException(msg);
                }

                bytes[byteIndex + i] = byteValue;
            }

            return charCount;
        }



        /// <summary>
        /// Decodes a sequence of bytes from the specified byte array into the specified character array.
        /// </summary>
        /// <returns>
        /// The actual number of characters written into <paramref name="chars"/>.
        /// </returns>
        /// <param name="bytes">The byte array containing the sequence of bytes to decode. 
        /// </param><param name="byteIndex">The index of the first byte to decode. 
        /// </param><param name="byteCount">The number of bytes to decode. 
        /// </param><param name="chars">The character array to contain the resulting set of characters. 
        /// </param><param name="charIndex">The index at which to start writing the resulting set of characters. 
        /// </param>
        public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex)
        {
            return FallbackCharacter.HasValue
                     ? GetCharsWithFallback(bytes, byteIndex, byteCount, chars, charIndex)
                     : GetCharsWithoutFallback(bytes, byteIndex, byteCount, chars, charIndex);
        }


        private int GetCharsWithFallback(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex)
        {
            for (int i = 0; i < byteCount; i++)
            {
                byte lookupIndex = bytes[i + byteIndex];

                //if the byte value is not in our lookup array, fall back to default character
                char result = lookupIndex >= 128
                                ? FallbackCharacter.Value
                                : (char)lookupIndex;

                chars[charIndex + i] = result;
            }

            return byteCount;
        }



        private int GetCharsWithoutFallback(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex)
        {
            for (int i = 0; i < byteCount; i++)
            {
                byte lookupIndex = bytes[i + byteIndex];
                if (lookupIndex >= 128)
                {
                    //throw exception
                    string msg = "The encoding [{0}] cannot decode byte value [{1}]. Set the FallbackCharacter property in order to suppress this exception and decode the value as a default character instead.";
                    msg = String.Format(msg, WebName, lookupIndex);
                    throw new EncoderFallbackException(msg);
                }


                chars[charIndex + i] = (char)lookupIndex;
            }

            return byteCount;
        }



        /// <summary>
        /// Calculates the number of bytes produced by encoding a set of characters
        /// from the specified character array.
        /// </summary>
        /// <returns>
        /// The number of bytes produced by encoding the specified characters. This class
        /// alwas returns the value of <paramref name="count"/>.
        /// </returns>
        public override int GetByteCount(char[] chars, int index, int count)
        {
            return count;
        }


        /// <summary>
        /// Calculates the number of characters produced by decoding a sequence
        /// of bytes from the specified byte array.
        /// </summary>
        /// <returns>
        /// The number of characters produced by decoding the specified sequence of bytes. This class
        /// alwas returns the value of <paramref name="count"/>. 
        /// </returns>
        public override int GetCharCount(byte[] bytes, int index, int count)
        {
            return count;
        }


        /// <summary>
        /// Calculates the maximum number of bytes produced by encoding the specified number of characters.
        /// </summary>
        /// <returns>
        /// The maximum number of bytes produced by encoding the specified number of characters. This
        /// class alwas returns the value of <paramref name="charCount"/>.
        /// </returns>
        /// <param name="charCount">The number of characters to encode. 
        /// </param>
        public override int GetMaxByteCount(int charCount)
        {
            return charCount;
        }

        /// <summary>
        /// Calculates the maximum number of characters produced by decoding the specified number of bytes.
        /// </summary>
        /// <returns>
        /// The maximum number of characters produced by decoding the specified number of bytes. This class
        /// alwas returns the value of <paramref name="byteCount"/>.
        /// </returns>
        /// <param name="byteCount">The number of bytes to decode.</param> 
        public override int GetMaxCharCount(int byteCount)
        {
            return byteCount;
        }


        /// <summary>
        /// Gets the number of characters that are supported by this encoding.
        /// This property returns a maximum value of 256, as the encoding class
        /// only supports single byte encodings (1 byte == 256 possible values).
        /// </summary>
        public static int CharacterCount
        {
            get { return 128; }
        }
    }
}
