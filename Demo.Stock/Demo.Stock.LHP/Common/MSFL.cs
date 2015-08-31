using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Demo.Stock.LHP.Common
{
    /// <summary>
    /// 
    /// </summary>
    public static class MSFL
    {
        /*----------------------------  Version Info  --------------------------------*/
        public const int MSFL_DLL_INTERFACE_VERSION = 9100;         // DLL interface version

        /*----------------------------  Open directory flags  ------------------------*/
        public const int MSFL_DIR_NO_FLAGS = 0x00;                  // Standard open
        public const int MSFL_DIR_FORCE_USER_IN = 0x04;             // Force user in directory
        public const int MSFL_DIR_MERGE_DUP_SECS = 0x08;            // Merge duplicate securities
        public const int MSFL_DIR_REMOVE_EMPTY_FILES = 0x10;        // On close, remove empty files
        public const int MSFL_DIR_CREATE_DOP_FILES = 0x20;          // Create & maintain DOP files
        public const int MSFL_DIR_ALLOW_MULTI_OPEN = 0x40;          // Allow opening a dir # times

        /*----------------------------  Name & Symbol  -------------------------------*/
        public const int MSFL_MAX_NAME_LENGTH = 45;                 // Max length of security name
        public const int MSFL_MAX_SYMBOL_LENGTH = 14;               // Max length of ticker symbol
        public const int MSFL_MAX_USER_NAME_LENGTH = 30;            // Max len of user name no null
        public const int MSFL_MAX_APP_NAME_LENGTH = 30;             // Max len of app name no null
        public const int MSFL_MAX_USER_ID_LENGTH = ( MSFL_MAX_APP_NAME_LENGTH + MSFL_MAX_USER_NAME_LENGTH + 1 );

        /*----------------------------  Lock Types  ----------------------------------*/
        public const int MSFL_LOCK_PREV_WRITE_LOCK = 0x10;          // Prevent write lock
        public const int MSFL_LOCK_WRITE_LOCK = 0x20;               // Write lock
        public const int MSFL_LOCK_FULL_LOCK = 0x80;                // Full lock

        /*----------------------------  Limitations  ---------------------------------*/
        public const int MSFL_MAX_OPEN_DIRECTORIES = 125;           // Max num of open directories
        public const int MSFL_MAX_NUM_OF_SECURITIES = 2000;         // Max num of securities in dir
        public const int MSFL_MAX_DATA_RECORDS = 65500;             // Max num of data records
        public const int MSFL_OLD_MAX_DATA_RECORDS = 32766;         // Max num of data recs <= v6.5
        public const int MSFL_MAX_LOCKED_SECURITIES = 24;           // Max num of locked securities
        public const int MSFL_MAX_ERR_MSG_LENGTH = 100;             // Max length of error message
        public const int MSFL_MAX_PATH = 261;                       // Max path length + NULL
        public const int MSFL_MAX_READ_WRITE_RECORDS = 65500;       // Max records to read/write
        public const int MSFL_MIN_DATE = 18000101;                  // Min date  1/01/1800
        public const int MSFL_MAX_DATE = 22001231;                  // Max date 12/31/2200

        /*----------------------------  Data Fields (DO NOT REORDER)  ----------------*/
        public const int MSFL_DATA_DATE = 0x0001;                   // Date field used
        public const int MSFL_DATA_CLOSE = 0x0002;                  // Close field used
        public const int MSFL_DATA_VOLUME = 0x0004;                 // Volume field used
        public const int MSFL_DATA_HIGH = 0x0008;                   // High field used
        public const int MSFL_DATA_LOW = 0x0010;                    // Low field used
        public const int MSFL_DATA_OPEN = 0x0020;                   // Open field used
        public const int MSFL_DATA_OPENINT = 0x0040;                // Open interest field used
        public const int MSFL_DATA_TIME = 0x0080;                   // Time field used

        /*----------------------------  Find Modes  ----------------------------------*/
        public enum MSFL_FIND
        {
            MSFL_FIND_CLOSEST_PREV,                                 // If not exact match, use prev
            MSFL_FIND_CLOSEST_NEXT,                                 // If not exact match, use next
            MSFL_FIND_EXACT_MATCH,                                  // Must match exactly

            MSFL_FIND_USE_CURRENT_POS                               // Use current pos (read/write)
        }

        /*----------------------------  MSFL Messages  -------------------------------*/
        public enum MSFL_Messages
        {
            MSFL_NO_MSG = 0,                                        //   0| No message
            MSFL_MSG_NOT_A_METASTOCK_DIR,                           //   1| Not a MetaStock data directory
            MSFL_MSG_CREATED_DIR,                                   //   2| Created directory
            MSFL_MSG_BUILT_METASTOCK_DIR,                           //   3| Built MetaStock directory
            MSFL_MSG_CREATED_N_BUILT_DIR,                           //   4| Created and built MS directory

            MSFL_MSG_FIRST_SECURITY_IN_DIR,                         //   5| First security in directory
            MSFL_MSG_LAST_SECURITY_IN_DIR,                          //   6| Last security in directory

            MSFL_MSG_NOT_AN_EXACT_MATCH = 25,                       //  25| Find was not an exact match

            MSFL_MSG_OVERWROTE_RECORDS = 50,                        //  50| Write overwrote current records
            MSFL_MSG_LESS_RECORDS_DEL,                              //  51| Less rec were del than asked
            MSFL_MSG_LESS_RECORDS_READ,                             //  52| Less rec were read than asked
            MSFL_MSG_MORE_RECORDS_IN_RANGE                          //  53| More recs to read in date range
        }

        /*----------------------------  MSFL Errors  ---------------------------------*/
        public enum MSFL_ERR
        {
            MSFL_ERR_NOT_INITIALIZED = -400,                //-400| MSFL hasn't been initialized
            MSFL_ERR_ALREADY_INITIALIZED,                   //-399| MSFL has been initialized
            MSFL_ERR_MSFL_CORRUPT,                          //-398| MSFL is corrupt - shutdown!
            MSFL_ERR_OS_VER_NOT_SUPPORTED,                  //-397| Windows version below NT 3.1
            MSFL_ERR_SHARE_NOT_LOADED,                      //-396| Share not loaded, load SHARE
            MSFL_ERR_INSUFFICIENT_FILES,                    //-395| Insufficient file handles
            MSFL_ERR_INSUFFICIENT_MEM,                      //-394| Insufficient memory
            MSFL_ERR_INVALID_USER_ID,                       //-393| Invalid user id
            MSFL_ERR_INVALID_TEMP_DIR,                      //-392| Invalid TEMP directory
            MSFL_ERR_DLL_INCOMPATIBLE,                      //-391| DLL interface is incompatible

            MSFL_ERR_INVALID_DRIVE = -375,                  //-375| Drive is an invalid drive
            MSFL_ERR_INVALID_DIR,                           //-374| Directory is invalid
            MSFL_ERR_DIR_DOES_NOT_EXIST,                    //-373| Directory does not exist
            MSFL_ERR_UNABLE_TO_CREATE_DIR,                  //-372| Unable to create the directory
            MSFL_ERR_DIR_ALREADY_OPEN,                      //-371| Directory was already opened
            MSFL_ERR_DIR_NOT_OPEN,                          //-370| Directory has not been opened
            MSFL_ERR_TOO_MANY_DIRS_OPEN,                    //-369| Too many directories opened
            MSFL_ERR_ALREADY_A_MS_DIR,                      //-368| Already a MetaStock directory
            MSFL_ERR_NOT_A_MS_DIR,                          //-367| Not a MetaStock data directory
            MSFL_ERR_DIR_IS_BUSY,                           //-366| Directory is busy
            MSFL_ERR_USER_ID_ALREADY_IN_DIR,                //-365| Duplicate user id in directory
            MSFL_ERR_TOO_MANY_USERS_IN_DIR,                 //-364| Too many users can't open
            MSFL_ERR_INVALID_USER,                          //-363| No longer a valid user in dir
            MSFL_ERR_NON_MSFL_USER_IN_DIR,                  //-362| Non-MSFL user accessing dir
            MSFL_ERR_DIR_IS_READ_ONLY,                      //-361| Directory is read-only
            MSFL_ERR_MAX_FILES_IN_TEMP_DIR,                 //-360| Too many MSFL files in temp dir

            MSFL_ERR_INVALID_XMASTER_FILE = -355,           //-355| XMaster file has an invalid id
            MSFL_ERR_INVALID_INDEX_FILE,                    //-354| Index file has an invalid id
            MSFL_ERR_INVALID_LOCK_FILE,                     //-353| Lock file had an invalid id
            MSFL_ERR_INVALID_SECURITY_FILE,                 //-352| Security file has an invalid id
            MSFL_ERR_INVALID_USERS_FILE,                    //-351| User file has an invalid id

            MSFL_ERR_CRC_ERROR = -350,                      //-350| CRC Error while reading
            MSFL_ERR_DRIVE_NOT_READY,                       //-349| Drive is not ready
            MSFL_ERR_GENERAL_FAILURE,                       //-348| General failure on disk
            MSFL_ERR_MISC_DISK_ERROR,                       //-347| General disk error
            MSFL_ERR_SECTOR_NOT_FOUND,                      //-346| Sector not found
            MSFL_ERR_SEEK_ERROR,                            //-345| Error seeking in file
            MSFL_ERR_UNKNOWN_MEDIA,                         //-344| Unknown media type
            MSFL_ERR_WRITE_PROTECTED,                       //-343| Disk is write protected
            MSFL_ERR_DISK_IS_FULL,                          //-342| Disk is full unable to write
            MSFL_ERR_NOT_SAME_DEVICE,                       //-341| The device is not the same
            MSFL_ERR_NETWORK_ERROR,                         //-340| There was a network error

            MSFL_ERR_LOCK_VIOLATION = -325,                 //-325| File locking violation
            MSFL_ERR_INVALID_LOCK_TYPE,                     //-324| Lock type is invalid
            MSFL_ERR_FILE_LOCKED,                           //-323| File locked by another user
            MSFL_ERR_TOO_MANY_SEC_LOCKED,                   //-322| Too many securities locked
            MSFL_ERR_SECURITY_LOCKED,                       //-321| Security locked by another user
            MSFL_ERR_SECURITY_NOT_LOCKED,                   //-320| Security not locked
            MSFL_ERR_IMPROPER_LOCK_TYPE,                    //-319| Improper lock for operation

            MSFL_ERR_END_OF_FILE = -300,                    //-300| End of the file
            MSFL_ERR_ERROR_OPENING_FILE,                    //-299| Unable to open file
            MSFL_ERR_ERROR_READING_FILE,                    //-298| Error reading the file
            MSFL_ERR_ERROR_WRITING_FILE,                    //-297| Error writing the file
            MSFL_ERR_FILE_DOESNT_EXIST,                     //-296| File doesn't exist
            MSFL_ERR_INVALID_FILE_HANDLE,                   //-295| The file handle is invalid
            MSFL_ERR_PERMISSION_DENIED,                     //-294| Access to file denied
            MSFL_ERR_SEEK_PAST_EOF,                         //-293| Seek went past the end of file
            MSFL_ERR_MISC_FILE_ERROR,                       //-292| Misc file error

            MSFL_ERR_UNABLE_TO_READ_ALL = -275,             //-275| Unable to read all records
            MSFL_ERR_UNABLE_TO_WRITE_ALL,                   //-274| Unable to write all records

            MSFL_ERR_ALL_SYMB_NOT_LOADED = -250,            //-250| Not all symbols were loaded
            MSFL_ERR_UNABLE_TO_RESYNCH,                     //-249| Unable to resynch masters
            MSFL_ERR_FILES_IN_DIR_CHANGED,                  //-248| Files in dir changed
            MSFL_ERR_UNRECOGNIZED_VERSION,                  //-247| Files are not recognized ver.

            MSFL_ERR_INVALID_COMP_SYMBOL = -225,            //-225| Composite symbol is invalid
            MSFL_ERR_INVALID_SYMBOL,                        //-224| Symbol is invalid

            MSFL_ERR_DIFFERENT_DATA_FORMATS = -200,         //-200| Securities with different data
            MSFL_ERR_DUPLICATE_SECURITIES,                  //-199| Duplicate securities in dir
            MSFL_ERR_DUPLICATE_SECURITY,                    //-198| Add/change would duplicate
            MSFL_ERR_PRIMARY_SEC_NOT_FOUND,                 //-197| Primary security not found
            MSFL_ERR_SECONDARY_SEC_NOT_FOUND,               //-196| Secondary security not found
            MSFL_ERR_SECURITY_HAS_COMPOSITES,               //-195| Can't del, security has comp.
            MSFL_ERR_SECURITY_HAS_NO_DATA,                  //-194| The security data file is empty
            MSFL_ERR_SECURITY_IS_A_COMPOSITE,               //-193| Security is a composite
            MSFL_ERR_SECURITY_NOT_COMPOSITE,                //-192| Security is not a composite
            MSFL_ERR_SECURITY_NOT_FOUND,                    //-191| Security not found
            MSFL_ERR_TOO_MANY_SECURITIES,                   //-190| Attempted to add too many
            MSFL_ERR_TOO_MANY_COMPOSITES,                   //-189| Too many composites in directory
            MSFL_ERR_SECURITIES_ARE_THE_SAME,               //-188| Securities are same security

            MSFL_ERR_INVALID_DATE = -175,                   //-175| Invalid date
            MSFL_ERR_INVALID_TIME,                          //-174| Invalid time
            MSFL_ERR_INVALID_INTERVAL,                      //-173| Invalid interval
            MSFL_ERR_INVALID_PERIODICITY,                   //-172| Invalid periodicity
            MSFL_ERR_INVALID_OPERATOR,                      //-171| Invalid composite operator
            MSFL_ERR_INVALID_FIELD_ORDER,                   //-170| Invalid combination of fields
            MSFL_ERR_INVALID_RECORDS,                       //-169| Invalid records for operation
            MSFL_ERR_INVALID_DISPLAY_UNITS,                 //-168| Invalid display units
            MSFL_ERR_INVALID_SECURITY_HANDLE,               //-167| Invalid security handle

            MSFL_ERR_ADDING_WOULD_OVERFLOW = -150,          //-150| Adding recs would overflow file
            MSFL_ERR_DATA_FILE_IS_FULL,                     //-149| The data file is full can't add
            MSFL_ERR_DATA_RECORD_NOT_FOUND,                 //-148| Date was not found for data rec
            MSFL_ERR_DATA_NOT_SORTED,                       //-147| Data is not in date/time order
            MSFL_ERR_DATE_AFTER_LAST_REC,                   //-146| Date requested is after last
            MSFL_ERR_DATE_BEFORE_FIRST_REC,                 //-145| Date requested is before first
            MSFL_ERR_RECORD_IS_A_DUPLICATE,                 //-144| Record is a duplicate
            MSFL_ERR_RECORD_OUT_OF_RANGE,                   //-143| Record number is out of range
            MSFL_ERR_RECORD_NOT_FOUND,                      //-142| Record not found

            MSFL_ERR_BUFFER_NOT_ATTACHED = -125,            //-125| Buffer !attached to security
            MSFL_ERR_INVALID_FUNC_PARMS,                    //-124| Invalid function parms
            MSFL_ERR_UNKNOWN_FIELDS_REQ,                    //-123| Unknown fields requested

            MSFL_ERR_LAST_ERROR,                            // -99| Last MSFL error    

            MSFL_NO_ERR = 0                                 //   0| Operation completed normally
        }

        [StructLayout( LayoutKind.Sequential, CharSet = CharSet.Ansi )]
        public struct MSFLDirectoryStatus
        {
            public uint dwTotalSize;                            // Structure size
            public bool bExists;                                // Directory exists
            public bool bInUse;                                 // In use by one or more users
            public bool bMetaStockDir;                          // Contains MetaStock files
            public ushort wDriveType;                           // Drive type

            public bool bOpen;                                  // Directory is open
            public bool bReadOnly;                              // Directory is read-only
            public bool bUserInvalid;                           // User is invalid in dir
            public byte cDirNumber;                             // Directory number
            public uint dwNumOfSecurities;                      // Number of securities
        }

        [StructLayout( LayoutKind.Sequential, CharSet = CharSet.Ansi )]
        public struct MSFLSecurityInfo
        {
            public uint dwTotalSize;                            // Structure size
            public IntPtr hSecurity;                            // Security handle
            [MarshalAs( UnmanagedType.ByValTStr, SizeConst = MSFL_MAX_NAME_LENGTH + 1 )]
            public String szName;                               // Security name
            [MarshalAs( UnmanagedType.ByValTStr, SizeConst = MSFL_MAX_SYMBOL_LENGTH + 1 )]
            public String szSymbol;                             // Ticker symbol
            public Char cPeriodicity;                           // Periodicity (D, W, M, I)
            public ushort wInterval;                            // Intraday time interval
            public bool bComposite;                             // 0 = FALSE, otherwise TRUE
            public bool bFlagged;                               // 0 = FALSE, otherwise TRUE
            public byte ucDisplayUnits;                         // Units decimal/fraction
            [MarshalAs( UnmanagedType.ByValTStr, SizeConst = MSFL_MAX_SYMBOL_LENGTH + 1 )]
            public String szCompSymbol;                         // 2nd symbol in comp.
            public byte cCompOperator;                          // Composite Op (+, -, *, or /)
            public float fCompFactor1;                          // Multiply factor for 1st sec.
            public float fCompFactor2;                          // Multiply factor for 2nd sec.
            public int lFirstDate;                              // Date in first data record
            public int lLastDate;                               // Date in last data record
            public int lFirstTime;                              // Time in the first record
            public int lLastTime;                               // Time in the last record
            public int lStartTime;                              // Intraday start trade time
            public int lEndTime;                                // Intraday end trade time
            public int lCollectionDate;                         // Date to collect data for
            public int lMostRecentAdjDate;                      // Most recent adjustment date
            public float fMostRecentAdjRatio;                   // Ratio of the most recent adj
            public ushort wDataAvailable;                       // Data fields available
        }

        [StructLayout( LayoutKind.Sequential, CharSet = CharSet.Ansi )]
        public struct MSFLPriceRecord
        {
            public int lDate;                                   // Date of price record
            public int lTime;                                   // Time of price record
            public float fOpen;                                 // Open price
            public float fHigh;                                 // High price
            public float fLow;                                  // Low price
            public float fClose;                                // Close price
            public float fVolume;                               // Volume value
            public float fOpenInt;                              // Open interest value
            public ushort wDataAvailable;                       // Data fields available
        }

        [StructLayout( LayoutKind.Sequential, CharSet = CharSet.Ansi )]
        public struct DateTime
        {
            public int lDate;
            public int lTime;
        }

        //[DllImport( "MSFL91.dll", CallingConvention = CallingConvention.StdCall )]
        //private static extern int MSFL1_AddSecurity();

        //[DllImport( "MSFL91.dll", CallingConvention = CallingConvention.StdCall )]
        //private static extern int MSFL1_BuildMetaStockDirectory();

        [DllImport( "MSFL91.dll", CallingConvention = CallingConvention.StdCall )]
        public static extern int MSFL1_CloseDirectory( byte cDirNumber );

        //[DllImport( "MSFL91.dll", CallingConvention = CallingConvention.StdCall )]
        //private static extern int MSFL1_DeleteDataRec();

        //[DllImport( "MSFL91.dll", CallingConvention = CallingConvention.StdCall )]
        //private static extern int MSFL1_DeleteSecurity();

        //[DllImport( "MSFL91.dll", CallingConvention = CallingConvention.StdCall )]
        //private static extern int MSFL1_FindDataDate();

        //[DllImport( "MSFL91.dll", CallingConvention = CallingConvention.StdCall )]
        //private static extern int MSFL1_FindDataRec();

        [DllImport( "MSFL91.dll", CallingConvention = CallingConvention.StdCall )]
        public static extern int MSFL1_FormatDate( StringBuilder pszDateString, ushort wStringSize, int lDate );

        [DllImport( "MSFL91.dll", CallingConvention = CallingConvention.StdCall )]
        public static extern int MSFL1_FormatTime( StringBuilder pszTimeString, ushort wStringSize, int lTime, bool bIncludeTicks );

        //[DllImport( "MSFL91.dll", CallingConvention = CallingConvention.StdCall )]
        //private static extern int MSFL1_GetCurrentDataPos();

        //[DllImport( "MSFL91.dll", CallingConvention = CallingConvention.StdCall )]
        //private static extern int MSFL1_GetDataPath();

        [DllImport( "MSFL91.dll", CallingConvention = CallingConvention.StdCall )]
        public static extern int MSFL1_GetDataRecordCount( IntPtr hSecurity, ref ushort pwNumOfDataRecs );

        //[DllImport( "MSFL91.dll", CallingConvention = CallingConvention.StdCall )]
        //private static extern int MSFL1_GetDayMonthYear();

        //[DllImport( "MSFL91.dll", CallingConvention = CallingConvention.StdCall )]
        //private static extern int MSFL1_GetDirectoryNumber();

        [DllImport( "MSFL91.dll", CallingConvention = CallingConvention.StdCall )]
        public static extern int MSFL1_GetDirectoryStatus( byte cDirNumber, string pszDirectory, ref MSFLDirectoryStatus psDirStatus );

        //[DllImport( "MSFL91.dll", CallingConvention = CallingConvention.StdCall )]
        //private static extern int MSFL1_GetDirNumberFromHandle();

        [DllImport( "MSFL91.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi )]
        public static extern IntPtr MSFL1_GetErrorMessage( int iErr, StringBuilder pszErrorMessage, ushort wMaxMsgLength );

        [DllImport( "MSFL91.dll", CallingConvention = CallingConvention.StdCall )]
        public static extern int MSFL1_GetFirstSecurityInfo( byte cDirNumber, ref MSFLSecurityInfo psSecurityInfo );

        //[DllImport( "MSFL91.dll", CallingConvention = CallingConvention.StdCall )]
        //private static extern int MSFL1_GetHourMinTicks();

        //[DllImport( "MSFL91.dll", CallingConvention = CallingConvention.StdCall )]
        //private static extern int MSFL1_GetLastFailedLockInfo();

        //[DllImport( "MSFL91.dll", CallingConvention = CallingConvention.StdCall )]
        //private static extern int MSFL1_GetLastFailedOpenDirInfo();

        //[DllImport( "MSFL91.dll", CallingConvention = CallingConvention.StdCall )]
        //private static extern int MSFL1_GetLastSecurityInfo();

        //[DllImport( "MSFL91.dll", CallingConvention = CallingConvention.StdCall )]
        //private static extern int MSFL1_GetMSFLState();

        [DllImport( "MSFL91.dll", CallingConvention = CallingConvention.StdCall )]
        public static extern int MSFL1_GetNextSecurityInfo( IntPtr hSecurity, ref MSFLSecurityInfo psSecurityInfo );

        //[DllImport( "MSFL91.dll", CallingConvention = CallingConvention.StdCall )]
        //private static extern int MSFL1_GetPrevSecurityInfo();

        //[DllImport( "MSFL91.dll", CallingConvention = CallingConvention.StdCall )]
        //private static extern int MSFL1_GetRecordCountForDateRange();

        //[DllImport( "MSFL91.dll", CallingConvention = CallingConvention.StdCall )]
        //private static extern int MSFL1_GetSecurityCount();

        //[DllImport( "MSFL91.dll", CallingConvention = CallingConvention.StdCall )]
        //private static extern int MSFL1_GetSecurityHandle();

        //[DllImport( "MSFL91.dll", CallingConvention = CallingConvention.StdCall )]
        //private static extern int MSFL1_GetSecurityID();

        //[DllImport( "MSFL91.dll", CallingConvention = CallingConvention.StdCall )]
        //private static extern int MSFL1_GetSecurityInfo();

        //[DllImport( "MSFL91.dll", CallingConvention = CallingConvention.StdCall )]
        //private static extern int MSFL1_GetSecurityLockedStatus();

        [DllImport( "MSFL91.dll", CallingConvention = CallingConvention.StdCall )]
        public static extern int MSFL1_Initialize( string pszAppName, string pszUserName, int iInterfaceVersion );

        //[DllImport( "MSFL91.dll", CallingConvention = CallingConvention.StdCall )]
        //private static extern int MSFL1_InsertDataRec();

        [DllImport( "MSFL91.dll", CallingConvention = CallingConvention.StdCall )]
        public static extern int MSFL1_LockSecurity( IntPtr hSecurity, int uiLockType );

        //[DllImport( "MSFL91.dll", CallingConvention = CallingConvention.StdCall )]
        //private static extern int MSFL1_MakeMSFLDate();

        //[DllImport( "MSFL91.dll", CallingConvention = CallingConvention.StdCall )]
        //private static extern int MSFL1_MakeMSFLTime();

        [DllImport( "MSFL91.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi )]
        public static extern int MSFL1_OpenDirectory( string pszDirectory, ref byte pcDirNumber, int iDirOpenFlags );

        //[DllImport( "MSFL91.dll", CallingConvention = CallingConvention.StdCall )]
        //private static extern int MSFL1_ParseDateString();

        //[DllImport( "MSFL91.dll", CallingConvention = CallingConvention.StdCall )]
        //private static extern int MSFL1_ParseTimeString();

        //[DllImport( "MSFL91.dll", CallingConvention = CallingConvention.StdCall )]
        //private static extern int MSFL1_ReadDataRec();

        [DllImport( "MSFL91.dll", CallingConvention = CallingConvention.StdCall )]
        public static extern int MSFL1_SeekBeginData( IntPtr hSecurity );

        //[DllImport( "MSFL91.dll", CallingConvention = CallingConvention.StdCall )]
        //private static extern int MSFL1_SeekEndData();

        [DllImport( "MSFL91.dll", CallingConvention = CallingConvention.StdCall )]
        public static extern int MSFL1_Shutdown();

        [DllImport( "MSFL91.dll", CallingConvention = CallingConvention.StdCall )]
        public static extern int MSFL1_UnlockSecurity( IntPtr hSecurity );

        //[DllImport( "MSFL91.dll", CallingConvention = CallingConvention.StdCall )]
        //private static extern int MSFL1_UpdateSecurity();

        //[DllImport( "MSFL91.dll", CallingConvention = CallingConvention.StdCall )]
        //private static extern int MSFL1_WriteDataRec();

        //[DllImport( "MSFL91.dll", CallingConvention = CallingConvention.StdCall )]
        //private static extern int MSFL2_AdjustData();

        //[DllImport( "MSFL91.dll", CallingConvention = CallingConvention.StdCall )]
        //private static extern int MSFL2_ChangeFieldsInData();

        //[DllImport( "MSFL91.dll", CallingConvention = CallingConvention.StdCall )]
        //private static extern int MSFL2_CopySecurity();

        // [DllImport( "MSFL91.dll", CallingConvention = CallingConvention.StdCall )]
        //private static extern int MSFL2_DeleteMultipleRecs();

        //[DllImport( "MSFL91.dll", CallingConvention = CallingConvention.StdCall )]
        //private static extern int MSFL2_DeleteMultipleRecsByDates();

        //[DllImport( "MSFL91.dll", CallingConvention = CallingConvention.StdCall )]
        //private static extern int MSFL2_GetSecurityHandles();

        //[DllImport( "MSFL91.dll", CallingConvention = CallingConvention.StdCall )]
        //private static extern int MSFL2_InsertMultipleRecs();

        //[DllImport( "MSFL91.dll", CallingConvention = CallingConvention.StdCall )]
        //private static extern int MSFL2_MergeData();

        //[DllImport( "MSFL91.dll", CallingConvention = CallingConvention.StdCall )]
        //private static extern int MSFL2_ReadBackMultipleRecs();

        //[DllImport( "MSFL91.dll", CallingConvention = CallingConvention.StdCall )]
        //private static extern int MSFL2_ReadDataRec();

        [DllImport( "MSFL91.dll", CallingConvention = CallingConvention.StdCall )]
        public static extern int MSFL2_ReadMultipleRecs( IntPtr hSecurity, [In, Out] MSFLPriceRecord[] pasPriceRec, ref DateTime psFirstRecDate, ref ushort pwReadCount, int iFindMode );

        //[DllImport( "MSFL91.dll", CallingConvention = CallingConvention.StdCall )]
        //private static extern int MSFL2_ReadMultipleRecsByDates();

        //[DllImport( "MSFL91.dll", CallingConvention = CallingConvention.StdCall )]
        //private static extern int MSFL2_RemoveDuplicateDataRecs();

        //[DllImport( "MSFL91.dll", CallingConvention = CallingConvention.StdCall )]
        //private static extern int MSFL2_SortData();

        //[DllImport( "MSFL91.dll", CallingConvention = CallingConvention.StdCall )]
        //private static extern int MSFL2_SortSecurities();

        //[DllImport( "MSFL91.dll", CallingConvention = CallingConvention.StdCall )]
        //private static extern int MSFL2_WriteDataRec();

        //[DllImport( "MSFL91.dll", CallingConvention = CallingConvention.StdCall )]
        //private static extern int MSFL2_WriteMultipleRecs();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iErr"></param>
        public static void DisplayMSFLError( int iErr )
        {
            // If there is an error or message
            if ( iErr != (int)MSFL_ERR.MSFL_NO_ERR )
            {
                StringBuilder szErrMsg = new StringBuilder( MSFL.MSFL_MAX_ERR_MSG_LENGTH );

                // Get the error/message text from MSFL
                IntPtr ptrStrInfo = MSFL.MSFL1_GetErrorMessage( iErr, szErrMsg, (ushort)szErrMsg.Capacity );
                //String strInfo = Marshal.PtrToStringAuto( ptrStrInfo );

                // If this is a information message, display the text in a message box
                if ( iErr > (int)MSFL_ERR.MSFL_NO_ERR )
                    MessageBox.Show( szErrMsg.ToString(), "MSFL Message", MessageBoxButtons.OK, MessageBoxIcon.Information );
                // If there is an error, display the text in a message box
                else
                    MessageBox.Show( szErrMsg.ToString(), "MSFL Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }

        public static System.DateTime FormatDate( int lDate )
        {
            StringBuilder szBuf = new StringBuilder( MSFL.MSFL_MAX_NAME_LENGTH + 1 );
            MSFL.MSFL1_FormatDate( szBuf, (ushort)szBuf.Capacity, lDate );

            return System.DateTime.Parse( szBuf.ToString() );
        }

        public static System.DateTime FormatTime( int lTime )
        {
            StringBuilder szBuf = new StringBuilder( MSFL.MSFL_MAX_NAME_LENGTH + 1 );
            MSFL.MSFL1_FormatTime( szBuf, (ushort)szBuf.Capacity, lTime, true );

            return System.DateTime.Parse( szBuf.ToString() );
        }

        public static float FormatPrice( float priceValue )
        {
            return float.Parse( priceValue.ToString( "0.00" ) );
        }

        public static float FormatVolume( float volumeValue )
        {
            return float.Parse( volumeValue.ToString( "0." ) );
        }
    }
}
