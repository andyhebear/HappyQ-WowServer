using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.Mmose.Xyz
{
    public enum CompressionMethod
    {
        None = 0x00,
        Deflate = 0x01,
        Bzip2 = 0x02,
        Lzw = 0x03,
        Ppmd = 0x04,
    }

    public class XyzEntry
    {
        private bool m_IsPasswordProtected = false;
        public bool IsPasswordProtected
        {
            get { return m_IsPasswordProtected; }
            set { m_IsPasswordProtected = value; }
        }

        private string m_Password = string.Empty;
        public string Password
        {
            get { return m_Password; }
            set { m_Password = value; }
        }

        private string m_Comment = string.Empty;
        public string Comment 
		{
			get  { return m_Comment; }
			set { m_Comment = value; }
		}

        private ulong m_CompressedLength = 0;
        public ulong CompressedLength 
		{
            get { return m_CompressedLength; }
		}

        private byte m_CompressionLevel = 0;
        public byte CompressionLevel 
		{
            get { return m_CompressionLevel; }
            set { m_CompressionLevel = value; }
        }

        private CompressionMethod m_CompressionMethod;
        public CompressionMethod CompressionMethod 
		{
            get { return m_CompressionMethod; }
            set { m_CompressionMethod = value; }
        }

        private ulong m_EntryID = 0;
        public ulong EntryID
        {
            get { return m_EntryID; }
        }

        private bool m_IsDirectory = false;
        public bool IsDirectory
        {
            get { return m_IsDirectory; }
        }

        private ulong m_UncompressedLength = 0;
        public ulong UncompressedLength
        {
            get { return m_UncompressedLength; }
        }

        private DateTime m_DateTime;			//Time represented as an Int
        public DateTime DateTime 
		{
			get { return m_DateTime; }
			set { this.m_DateTime = value; }
		}

		private Int16 nameLength;		//Length of the variable sized name
		public Int16 NameLength
		{
			get
			{
				return nameLength;
			}
			set
			{
				//Check if the value is greater than 16 bytes
				if ((UInt16)value > 0xffff)
					throw new ArgumentOutOfRangeException();
				this.nameLength = value;
			}
		}

        private string m_Name;
        /// <summary>
		/// Returns the entry name.  The path components in the entry are
		/// always separated by slashes ('/').
		/// </summary>
		public string Name 
		{
			get 
			{
                return m_Name;
			}
			set
			{
				//Check if the value is greater than 16 bytes or null
				if (value == null || value.Length > 0xffffL)
					throw new ArgumentOutOfRangeException();

				if (value.Length != 0)
				{
                    m_Name = value;
					nameLength = (Int16)value.Length;
				}
			}
		}


        private byte[] m_Crc;             //Array of 16 CRC bytes
        /// <summary>
		/// Gets/Sets the crc of the compressed data.
		/// </summary>
		/// <exception cref="System.ArgumentOutOfRangeException">
		/// if crc is not in 16 byte array
		/// </exception>
		/// <returns>
		/// the crc.
		/// </returns>
		public byte[] Crc
		{
            get { return m_Crc; }
            set { m_Crc = value; }
		}

		public void SetCrc(byte[] value)
		{
				//Check if the Length of value array is greater than 16
            if ( value.Length != m_Crc.Length )
					throw new ArgumentOutOfRangeException();

            m_Crc = value;
		}

        /// <summary>
        /// Creates a zip entry with the given name.
        /// </summary>
        /// <param name="name">
        /// the name. May include directory components separated by '/'.
        /// </param>
        public XyzEntry( string name )
        {
            if ( name == null )
            {
                //Wrong entry
                throw new System.ArgumentNullException();
            }
            this.DateTime = System.DateTime.Now;
            this.Name = name;
            //this.size = 0;
            //this.compressedSize = 0;
            //this.crc = new byte[16];
        }

        public bool AppendData( byte[] name, int office, int count )
        {
            return false;
        }

        public bool AppendFile( string name )
        {
            return false;
        }

        public int Extract( byte[] name, int office, int count )
        {
            return 0;
        }

        public bool Extract( string dirPath, bool isIncludeComment )
        {
            return false;
        }

        public bool ReplaceData( byte[] name, int office, int count )
        {
            return false;
        }

        public XyzEntry NextEntry()
        {
            return null;
        }

    }
}
