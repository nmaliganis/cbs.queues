using System;
using System.Collections.Generic;
using System.Linq;
using cbs.queue.monitoring.api.Commanding;
using cbs.queue.monitoring.api.Commanding.Events;
using cbs.queue.monitoring.api.Commanding.Inbound;
using cbs.queue.monitoring.api.Repositories;
using Coldairarrow.DotNettySocket;
using Newtonsoft.Json;
using Serilog;

namespace cbs.queue.monitoring.api.Proxies.WSs;

/// <summary>
/// Class
/// </summary>
public class WsConfiguration : IWsConfiguration,
    INetLoggingDetectionActionListener,
    INetNotificationDetectionActionListener,
    INetAttachmentDetectionActionListener,
    INetContentProcessingDetectionActionListener,
    INetReceptionDetectionActionListener,
    INetResolutionDetectionActionListener,
    INetIntegrationDetectionActionListener,
    INetSchemaValidationDetectionActionListener
{
    private IWebSocketServer _theServer;
    private readonly List<IWebSocketConnection> _theConnections;


    /// <summary>
    /// Ctor
    /// </summary>
    public WsConfiguration()
    {
        this._theConnections = new List<IWebSocketConnection>();

        WsServer.GetWsServer.Attach((INetLoggingDetectionActionListener)this);
        WsServer.GetWsServer.Attach((INetNotificationDetectionActionListener)this);
        WsServer.GetWsServer.Attach((INetReceptionDetectionActionListener)this);
        WsServer.GetWsServer.Attach((INetAttachmentDetectionActionListener)this);
        WsServer.GetWsServer.Attach((INetIntegrationDetectionActionListener)this);
        WsServer.GetWsServer.Attach((INetResolutionDetectionActionListener)this);
        WsServer.GetWsServer.Attach((INetContentProcessingDetectionActionListener)this);
        WsServer.GetWsServer.Attach((INetSchemaValidationDetectionActionListener)this);
    }

    /// <summary>
    /// Method
    /// </summary>
    public async void EstablishConnection()
    {
        _theServer = await SocketBuilderFactory.GetWebSocketServerBuilder(6001)
            .OnConnectionClose((server, connection) =>
            {
                var alreadyConnected = _theConnections.FirstOrDefault(x => x.ConnectionId == connection.ConnectionId);
                if (alreadyConnected != null)
                {
                    Log.Information(
                        $"This connection already exists :{connection.ConnectionName},Current connection number:{server.GetConnectionCount()}");
                    try
                    {
                        _theConnections.Remove(connection);
                    }
                    catch (Exception e)
                    {
                        Log.Fatal(
                            $"OnConnectionClose:{e.Message}"
                        );
                    }

                }
                Log.Fatal(
                    $"Connection cannot close cause not exists," +
                    $"Connection name[{connection.ConnectionName}],Current connection number:{server.GetConnectionCount()}"
                );
            })
            .OnException(ex => { Log.Error($"Server exception:{ex.Message}"); })
            .OnNewConnection((server, connection) =>
            {
                connection.ConnectionName = $"1st Name{connection.ConnectionId}";
                var alreadyConnected = _theConnections.FirstOrDefault(x => x.ConnectionId == connection.ConnectionId);
                if (alreadyConnected != null)
                {
                    Log.Fatal(
                        $"This connection already exists :{connection.ConnectionName},Current connection number:{server.GetConnectionCount()}");
                }
                else
                {
                    Log.Information(
                        $"New connection:{connection.ConnectionName},Current connection number:{server.GetConnectionCount()}");
                    try
                    {
                        _theConnections.Add(connection);
                    }
                    catch (Exception e)
                    {
                        Log.Fatal(
                            $"OnNewConnection:{e.Message}"
                        );
                    }
                }

            })
            .OnRecieve((server, connection, msg) =>
            {
                connection?.Send("ACK");
                Log.Information($"Server:Data{msg}");
            })
            .OnSend((server, connection, msg) =>
            {
                Log.Information($"Connection name[{connection.ConnectionName}]send Data:{msg}");
            })
            .OnServerStarted(server => { Log.Information($"Service Start"); }).BuildAsync();
    }

    /// <summary>
    /// Method:
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void Update(object sender, NetLoggingDetectionEventArgs e)
    {
        QueueRepository.GetInstance.PushLogging(e.Payload);

        foreach (var theConnection in _theConnections)
        {
            theConnection?.Send(e.Payload);
            Log.Information($"Update for NetLoggingDetectionEventArgs was caught");
        }
    }

    /// <summary>
    /// Method
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void Update(object sender, NetNotificationDetectionEventArgs e)
    {
        QueueRepository.GetInstance.PushNotification(e.Payload);

        foreach (var theConnection in _theConnections)
        {
            theConnection?.Send(e.Payload);
            Log.Information($"Update for NetNotificationDetectionEventArgs was caught");
        }
    }

    /// <summary>
    /// Method
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void Update(object sender, NetAttachmentDetectionEventArgs e)
    {
        QueueRepository.GetInstance.PushAttachment(e.Payload);

        foreach (var theConnection in _theConnections)
        {
            theConnection?.Send(e.Payload);
            Log.Information($"Update for NetAttachmentDetectionEventArgs was caught");
        }
    }

    void INetContentProcessingDetectionActionListener.Update(object sender, NetContentProcessingDetectionEventArgs e)
    {
        QueueRepository.GetInstance.PushContentProcessing(e.Payload);

        foreach (var theConnection in _theConnections)
        {
            theConnection?.Send(e.Payload);
            Log.Information($"Update for NetContentProcessingDetectionEventArgs was caught");
        }
    }

    /// <summary>
    /// Method
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void Update(object sender, NetReceptionDetectionEventArgs e)
    {
        QueueRepository.GetInstance.PushReception(e.Payload);

        foreach (var theConnection in _theConnections)
        {
            theConnection?.Send(e.Payload);
            Log.Information($"Update for NetReceptionDetectionEventArgs was caught");
        }
    }

    /// <summary>
    /// Method
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void Update(object sender, NetResolutionDetectionEventArgs e)
    {
        QueueRepository.GetInstance.PushResolution(e.Payload);

        foreach (var theConnection in _theConnections)
        {
            theConnection?.Send(e.Payload);
            Log.Information($"Update for NetResolutionDetectionEventArgs was caught");
        }
    }

    void INetIntegrationDetectionActionListener.Update(object sender, NetIntegrationDetectionEventArgs e)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Method
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void Update(object sender, NetSchemaValidationDetectionEventArgs e)
    {
        QueueRepository.GetInstance.PushSchemaValidation(e.Payload);

        foreach (var theConnection in _theConnections)
        {
            theConnection?.Send(e.Payload);
            Log.Information($"Update for NetSchemaValidationDetectionEventArgs was caught");
        }
    }
}