using System;

namespace Client.Diagnostics
{
    public sealed class TraceMessageEventArgs : EventArgs
    {
        public TraceMessage TraceMessage { get; private set; }

        public TraceMessageEventArgs(TraceMessage traceMessage)
        {
            Asserter.AssertIsNotNull(traceMessage, "traceMessage");

            TraceMessage = traceMessage;
        }
    }
}
