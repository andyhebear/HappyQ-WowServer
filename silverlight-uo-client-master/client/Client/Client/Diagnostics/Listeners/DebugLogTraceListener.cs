using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows;
using Client.IO;
using System.IO.IsolatedStorage;

namespace Client.Diagnostics
{
    public sealed class DebugLogTraceListener : TraceListener
    {
        private static readonly Dictionary<string, object> _lockTable = new Dictionary<string, object>();
        private readonly string _filename;

        public DebugLogTraceListener(string filename)
        {
            _filename = filename;

            object syncRoot;

            if (!_lockTable.TryGetValue(filename, out syncRoot))
            {
                syncRoot = new object();
                _lockTable.Add(filename, syncRoot);

                if (File.Exists(_filename))
                    File.Delete(_filename);

                OnTraceReceived(new TraceMessage(TraceLevels.Verbose, DateTime.UtcNow, "Logging Started",
                    string.IsNullOrEmpty(Thread.CurrentThread.Name) ? Thread.CurrentThread.ManagedThreadId.ToString() : Thread.CurrentThread.Name));
            }
        }

        protected override void OnTraceReceived(TraceMessage message)
        {
            try
            {
                object syncRoot = _lockTable[_filename];

                lock (syncRoot)
                {
                    string directory = Path.GetDirectoryName(_filename);

                    FileSystemHelper.EnsureDirectoryExists(directory);

                    using (StreamWriter writer = new StreamWriter(_filename))
                    {
                        writer.WriteLine(message);
                        writer.Flush();
                    }
                }
            }
            catch (Exception e)
            {
                Dispose(true);
                Tracer.Error(e);
            }
        }
    }
}
