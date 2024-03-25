using System;

namespace cbs.queue.monitoring.api.Commanding.Events;

/// <summary>
/// Class
/// </summary>
public class NetReceptionDetectionEventArgs : EventArgs
{
    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="payload"></param>
    public NetReceptionDetectionEventArgs(string payload)
    {
        this.Payload = payload;
    }

    /// <summary>
    /// Property
    /// </summary>
    public string Payload { get; set; }
}