using System;
using System.Threading;

namespace Client.Diagnostics
{
    public delegate void TraceReveivedHandler(TraceMessageEventArgs e);

    public static class Tracer
    {
        private static readonly object _syncRoot = new object();
        private static TraceLevels _traceLevel;

        public static TraceLevels TraceLevel
        {
            get { return _traceLevel; }
            set { _traceLevel = value; }
        }

        public static TraceReveivedHandler TraceReceived;

        public static void Verbose(object obj)
        {
            Trace(TraceLevels.Verbose, obj.ToString());
        }

        public static void Verbose(string message, params object[] args)
        {
            Trace(TraceLevels.Verbose, message, args);
        }

        public static void Info(object obj)
        {
            Trace(TraceLevels.Info, obj.ToString());
        }

        public static void Info(string message, params object[] args)
        {
            Trace(TraceLevels.Info, message, args);
        }

        public static void Warn(object obj)
        {
            Trace(TraceLevels.Warning, obj.ToString());
        }

        public static void Warn(string message, params object[] args)
        {
            Trace(TraceLevels.Warning, message, args);
        }

        public static void Error(object obj)
        {
            Trace(TraceLevels.Error, obj.ToString());
        }

        public static void Error(string message, params object[] args)
        {
            Trace(TraceLevels.Error, message, args);
        }

        public static void Fatal(object obj)
        {
            Trace(TraceLevels.Fatal, obj.ToString());
        }

        public static void Fatal(string message, params object[] args)
        {
            Trace(TraceLevels.Fatal, message, args);
        }

        public static void Trace(TraceLevels type, string message, params object[] args)
        {
            lock (_syncRoot)
            {
                if (TraceReceived != null)
                {
                    if (args.Length > 0)
                    {
                        message = string.Format(message, args);
                    }

                    TraceMessage traceMessage =
                        new TraceMessage(type, DateTime.UtcNow, message,
                            string.IsNullOrEmpty(Thread.CurrentThread.Name) ? Thread.CurrentThread.ManagedThreadId.ToString() : Thread.CurrentThread.Name);

                    TraceReceived(new TraceMessageEventArgs(traceMessage));
                }
            }
        }
    }
}
