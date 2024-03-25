namespace cbs.queue.monitoring.api.Commanding;

/// <summary>
/// Class
/// </summary>
public sealed class WsServer : WsBaseServer
{
    private WsServer()
    {
    }
    /// <summary>
    /// Prop
    /// </summary>
    public static WsServer GetWsServer { get; } = new WsServer();
}