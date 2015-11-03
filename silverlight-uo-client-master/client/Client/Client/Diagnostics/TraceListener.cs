
namespace Client.Diagnostics
{
    public abstract class TraceListener : ITraceListener
    {
        public virtual TraceLevels? TraceLevel { get; set; }
        public bool Enabled { get; set; }

        protected TraceListener()
        {
            Enabled = true;
            Tracer.TraceReceived += OnTraceReceived;
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private void OnTraceReceived(TraceMessageEventArgs e)
        {
            if (!Enabled)
                return;

            TraceMessage message = e.TraceMessage;

            if (!TraceLevel.HasValue && message.Type < Tracer.TraceLevel)
                return;

            if (TraceLevel.HasValue && message.Type < TraceLevel)
                return;

            OnTraceReceived(message);
        }

        protected abstract void OnTraceReceived(TraceMessage message);

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Tracer.TraceReceived -= OnTraceReceived;
            }
        }
    }
}
