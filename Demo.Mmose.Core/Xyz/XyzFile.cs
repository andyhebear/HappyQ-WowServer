using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Demo.Mmose.Xyz
{
    public class XyzFile
    {
        private string m_Comment = string.Empty;
        public string Comment
        {
            get { return m_Comment; }
            set { m_Comment = value; }
        }

        private XyzHeadReader m_HeadReader = null;
        internal XyzHeadReader HeadReader
        {
            get { return m_HeadReader; }
        }

        private bool m_IsEncryptFileName = false;
        public bool IsEncryptFileName
        {
            get { return m_IsEncryptFileName; }
            set { m_IsEncryptFileName = value; }
        }

        private bool m_IsPasswordProtected = false;
        public bool IsPasswordProtected
        {
            get { return m_IsPasswordProtected; }
        }

        private string m_Password = string.Empty;
        public string Password
        {
            get { return m_Password; }
            set { m_Password = value; }
        }

        private string m_FileName = string.Empty;
        public string FileName
        {
            get { return m_FileName; }
            set { m_FileName = value; }
        }

        private int m_FileCount = 0;
        public int FileCount
        {
            get { return m_FileCount; }
        }

        FileStream m_XyzFileStream = null;
        XyzHeadReader m_XyzHeadReader = null;
        public bool OpenXyz( string zipFileName )
        {
            if ( File.Exists( zipFileName ) == false )
                return false;

            try
            {
                m_XyzFileStream = File.Open( zipFileName, FileMode.Open, FileAccess.ReadWrite, FileShare.Read );
            }
            catch
            {
                if ( m_XyzFileStream != null )
                {
                    m_XyzFileStream.Close();
                    m_XyzFileStream = null;
                }
            }

            if ( m_XyzFileStream == null )
                return false;

            m_XyzHeadReader = XyzHeadReader.ReadXyzHead( m_XyzFileStream );
            if ( m_XyzHeadReader == null )
            {
                m_XyzFileStream.Close();
                m_XyzFileStream = null;
                return false;
            }

            return true;
        }

        public bool OpenXyzReadonly( string zipFileName )
        {

            return true;
        }

        public bool NewXyz( string zipFileName )
        {
            if ( File.Exists( zipFileName ) == true )
                return false;

            try
            {
                m_XyzFileStream = File.Open( zipFileName, FileMode.CreateNew, FileAccess.ReadWrite, FileShare.Read );
            }
            catch
            {
                if ( m_XyzFileStream != null )
                {
                    m_XyzFileStream.Close();
                    m_XyzFileStream = null;
                }
            }

            XyzHeadWriter.WriteXyzHead( m_XyzFileStream, XyzHeadWriter.DEFUALT );
            return false;
        }

        public bool WriteXyz()
        {
            return false;
        }

        public bool WriteXyzAndClose()
        {
            return false;
        }

        public void Close()
        {
            if ( m_XyzFileStream == null )
                return;

            m_XyzFileStream.Flush();
            m_XyzFileStream.Close();
            m_XyzFileStream = null;
            m_XyzHeadReader = null;
        }

        public XyzEntry GetEntryByID( ulong entryID )
        {
            return null;
        }

        public XyzEntry GetEntryByName( string entryName )
        {
            return null;
        }

        public XyzEntry FirstEntry()
        {
            return null;
        }

        public XyzEntry CreateNewEntry( string Name )
        {
            return null;
        }

        public XyzEntry CreateNewDirectoryEntry( string dirName )
        {
            return null;
        }

        public int AppendFileFormDirectory( string dirPath )
        {
            
            return 0;
        }

        public bool AppendXyz( string xyzFileName )
        {
            return false;
        }

        public bool DeleteEntry( XyzEntry entry )
        {
            return false;
        }

        public bool DeleteEntry( ulong entryID )
        {
            return false;
        }

        public bool ExtractAllEntry( string dirPath, bool isIncludeComment )
        {
            return false;
        }

        public bool ExtractMatchingEntry( string pattern, string dirPath, bool isIncludeComment )
        {
            return false;
        }

        public XyzEntry FirstMatchingEntry(string pattern)
        {
            return null;
        }



        List<XyzEntry> zipEntries = new List<XyzEntry>();		// The collection of entries
        //private XyzEntryReader thisReader;
        private XyzEntryWriter thisWriter;

        private System.IO.Stream baseStream;		// Stream to which the writer writes 
										// both header and data, the reader
										// reads this
		private string zipName;

		/// <summary>
		/// Created a new Zip file with the given name.
		/// </summary>
		/// <param name="method"> Gzip or deflate</param>
		/// <param name="name"> Zip name</param>
		public XyzFile()
		{
			try
			{
                //zipName = name;
				
                //baseStream = new FileStream(zipName, mode);
                //thisWriter = new XyzEntryWriter(baseStream);
                //thisWriter.Method = method;

				//New File
                //thisWriter.WriteSuperHeader(0, method);

                //int index1 = zipName.IndexOf(XyzConstants.Dot);
                //int index2 = zipName.LastIndexOf(XyzConstants.BackSlash);
                //thisReader = new XyzEntryReader(baseStream, zipName.Substring(index2,
                //        index1 - index2));

                //zipEntries = thisReader.GetAllEntries();
                //CompressionForm.statusMessage =
                //    String.Format(
                //    System.Threading.Thread.CurrentThread.CurrentUICulture,
                //    XyzConstants.NewMessage, name);
			}
			catch (System.IO.IOException)
			{
				XyzConstants.ShowError(XyzConstants.IOError);
			}
		}

		/// <summary>
		/// Opens a Zip file with the given name.
		/// </summary>
		/// <param name="name"> Zip name</param>
        public XyzFile( string name )
		{
			try
			{
				zipName = name;
				baseStream = new FileStream(zipName, FileMode.Open);
				thisWriter = new XyzEntryWriter(baseStream);

				int index1 = zipName.IndexOf(XyzConstants.Dot);
				int index2 = zipName.LastIndexOf(XyzConstants.BackSlash);
                //thisReader = new XyzEntryReader(baseStream, zipName.Substring(index2,
                //        index1 - index2));

                //zipEntries = thisReader.GetAllEntries();
                //thisWriter.Method = thisReader.Method;
                //if (CompressionForm.statusMessage != String.Empty)
                //    CompressionForm.statusMessage =
                //    String.Format(
                //    System.Threading.Thread.CurrentThread.CurrentUICulture, 
                //    XyzConstants.OpenMessage, name);
			}		
			catch (IOException)
			{
				XyzConstants.ShowError("Error opening the file");
			}
			catch (ArgumentOutOfRangeException)
			{
				XyzConstants.ShowError(XyzConstants.CorruptedError);
			}
		}


		/// <summary>
		/// Gets offset to which the jump should be made by summing up 
		/// all the individual lengths.
		/// </summary>
		/// <returns>
		/// the offset from SeekOrigin.Begin
		/// </returns>
		private long GetOffset(int index)
		{
			if (index > zipEntries.Count)
				return -1;
			int jump = XyzConstants.SuperHeaderSize;
			int i;
			for (i = 0; i < index - 1; ++i)
			{
                //XyzEntry entry = zipEntries[i];
                //jump += XyzConstants.FixedHeaderSize + entry.NameLength 
                //    + entry.CompressedSize;
			}
			return jump;
		}

		public void Add(string fileName) {
			System.Globalization.CultureInfo ci = 
				System.Threading.Thread.CurrentThread.CurrentUICulture;
			if (fileName.ToLower(ci).Equals(zipName.ToLower(ci)))
			{
				XyzConstants.ShowError("Cannot add the current xip file");
                //CompressionForm.statusMessage = String.Empty;
				return;
			}
			XyzEntry entry = new XyzEntry(fileName);
			thisWriter.Add(entry);

            //if (CompressionForm.statusMessage.Length != 0)
            //{
            //    zipEntries.Add(entry);
            //    thisWriter.CloseHeaders((Int16)zipEntries.Count);
            //}
		}

		public void Extract(int index, string path) {
			
			if(index < 0 || index >= zipEntries.Count)	
			{
				XyzConstants.ShowError("Argument out of range" +
					"exception");
				return;
			}
            //thisReader.Extract(zipEntries[index], GetOffset(index + 1), 
            //        path);
		}

		public void ExtractAll(string path) {
            //thisReader.ExtractAll(zipEntries, path);
		}

        ///// <summary>
        ///// Closes the ZipFile.  This also closes all input streams given by
        ///// this class.  After this is called, no further method should be
        ///// called.
        ///// </summary>
        //public void Close()
        //{
        //    if(baseStream != null)
        //        baseStream.Close();
        //}

		/// <summary>
		/// Gets the entries of compressed files.
		/// </summary>
		/// <returns>
		/// Collection of ZipEntries
		/// </returns>
		public List<XyzEntry> Entries
		{
			get
			{
				return zipEntries;
			}
		}

		public byte CompressionMethod()
		{
			return thisWriter.Method;
		}

		public int CheckFileExists(string fileName)
		{
			System.Globalization.CultureInfo ci =
						System.Threading.Thread.CurrentThread.CurrentUICulture;
			int i = -1;
			foreach (XyzEntry eachEntry in zipEntries)
			{
				++i;
				if (eachEntry.Name.ToLower(ci).Equals(fileName.ToLower(ci)))
				{
					return i;
				}
			}
			return -1;
		}

		/// <summary>
		/// Remove an entry from the archive
		/// </summary>
		/// <param name="index">
		/// The index of the entry that is to be removed
		/// </param>
		private void DeleteEntryFromFile(int index)
		{
			long jump = XyzConstants.SuperHeaderSize;
			for(int i = 0; i < index; ++i)
			{
				jump += XyzConstants.FixedHeaderSize +
					zipEntries[i].NameLength
                    //+zipEntries[i].CompressedSize
                    ;
			}
			XyzEntry entry = zipEntries[index];
			long fileJump = XyzConstants.FixedHeaderSize +
					entry.NameLength
                    //+entry.CompressedSize
                    ;
			baseStream.Seek(jump + fileJump, SeekOrigin.Begin);
			long length = baseStream.Length - fileJump - jump;
			byte[] b = new byte[length];
			baseStream.Read(b, 0, (int)length);
			baseStream.Seek(jump, SeekOrigin.Begin);
			baseStream.Write(b, 0, (int)length);
			baseStream.SetLength(baseStream.Length - fileJump);
            //CompressionForm.statusMessage = "Removed successfully";
		}

		/// <summary>
		/// Remove an entry from the archive
		/// </summary>
		/// <param name="index">
		/// The index of the entry that is to be removed
		/// </param>
		public void Remove(int index)
		{
			long jump = XyzConstants.SuperHeaderSize;
			for (int i = 0; i < index; ++i)
			{
				jump += XyzConstants.FixedHeaderSize +
					zipEntries[i].NameLength
                    //+zipEntries[i].CompressedSize
                    ;
			}
			thisWriter.Remove(jump, zipEntries[index]);
			zipEntries.RemoveAt(index);
            //if (CompressionForm.statusMessage.Length != 0)
            //{
            //    thisWriter.CloseHeaders((Int16)zipEntries.Count);
            //}
		}
    }
}
