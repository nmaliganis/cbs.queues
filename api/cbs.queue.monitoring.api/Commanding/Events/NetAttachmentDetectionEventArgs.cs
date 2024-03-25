using System;

namespace cbs.queue.monitoring.api.Commanding.Events;

/// <summary>
/// Class
/// </summary>
public class NetAttachmentDetectionEventArgs : EventArgs
{
    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="payload"></param>
    public NetAttachmentDetectionEventArgs(string payload)
    {
        this.Payload = payload;
    }

    /// <summary>
    /// Property
    /// </summary>
    public string Payload { get; set; }
}