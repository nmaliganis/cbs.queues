﻿using cbs.queue.monitoring.api.Commanding.Events;

namespace cbs.queue.monitoring.api.Commanding.Inbound;

/// <summary>
/// Interface
/// </summary>
public interface INetResolutionDetectionActionListener
{
    /// <summary>
    /// Method
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void Update(object sender, NetResolutionDetectionEventArgs e);
}