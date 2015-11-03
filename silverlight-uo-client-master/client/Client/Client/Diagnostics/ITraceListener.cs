using System;

namespace Client.Diagnostics
{
    public interface ITraceListener : IDisposable
    {
        TraceLevels? TraceLevel { get; set; }
    }
}
