using System;

namespace cbs.queue.monitoring.api.Commanding.Events;

/// <summary>
/// Class
/// </summary>
public class NetSchemaValidationDetectionEventArgs : EventArgs
{
    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="payload"></param>
    public NetSchemaValidationDetectionEventArgs(string payload)
    {
        this.Payload = payload;
    }

    /// <summary>
    /// Property
    /// </summary>
    public string Payload { get; set; }
}