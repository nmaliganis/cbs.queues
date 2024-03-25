using System;
using System.Collections.Generic;
using System.Linq;
using cbs.queue.monitoring.api.Commanding;
using cbs.queue.monitoring.api.Commanding.Events;
using cbs.queue.monitoring.api.Proxies.WSs;
using Coldairarrow.DotNettySocket;
using Serilog;

namespace cbs.queue.monitoring.api.Proxies.Msmq;

/// <summary>
/// Class
/// </summary>
public class MsmqConfiguration : IMsmqConfiguration
{
    /// <summary>
    /// Ctor
    /// </summary>
    public MsmqConfiguration()
    {
    }

    /// <summary>
    /// Method
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    public void EstablishConnection()
    {
    }
}