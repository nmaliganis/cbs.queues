using System;

namespace cbs.queue.monitoring.api.Commanding.Events;

/// <summary>
/// Class
/// </summary>
public class NetLoggingDetectionEventArgs : EventArgs
{
    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="payload"></param>
    public NetLoggingDetectionEventArgs(string payload)
    {
        Payload = payload;
    }

    /// <summary>
    /// Property
    /// </summary>
    public string Payload { get; set; }
}