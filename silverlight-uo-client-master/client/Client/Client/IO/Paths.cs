
using System;
using System.IO;
namespace Client.IO
{
    public static class Paths
    {
        public static string StorageDirectory
        {
            get
            {
                return Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    "Silverlight UO Client");
            }
        }

        public static string LogsDirectory
        {
            get { return Path.Combine(StorageDirectory, "logs"); }
        }

        public static string ConfigFile
        {
            get { return Path.Combine(StorageDirectory, "config.xml"); }
        }
    }
}
