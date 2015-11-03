
namespace Client.Diagnostics
{
    public sealed class DebugTraceListener : TraceListener
    {
        protected override void OnTraceReceived(TraceMessage message)
        {
            System.Diagnostics.Debug.WriteLine(message);
        }
    }
}
