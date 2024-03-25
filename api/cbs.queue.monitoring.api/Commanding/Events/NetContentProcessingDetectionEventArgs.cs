using System;

namespace cbs.queue.monitoring.api.Commanding.Events;

/// <summary>
/// Class
/// </summary>
public class NetContentProcessingDetectionEventArgs : EventArgs
{
    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="payload"></param>
    public NetContentProcessingDetectionEventArgs(string payload)
    {
        this.Payload = payload;
    }

    /// <summary>
    /// Property
    /// </summary>
    public string Payload { get; set; }
}