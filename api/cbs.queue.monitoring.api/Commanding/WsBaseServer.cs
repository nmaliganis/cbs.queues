using System;
using cbs.queue.monitoring.api.Commanding.Events;
using cbs.queue.monitoring.api.Commanding.Inbound;

namespace cbs.queue.monitoring.api.Commanding;

/// <summary>
/// Class
/// </summary>
public abstract class WsBaseServer
{
    /// <summary>
    /// Event
    /// </summary>
    public event EventHandler<NetLoggingDetectionEventArgs> NetLoggingDetector;

    /// <summary>
    /// Event
    /// </summary>
    public event EventHandler<NetNotificationDetectionEventArgs> NetNotificationDetector;
    /// <summary>
    /// Event
    /// </summary>
    public event EventHandler<NetIntegrationDetectionEventArgs> NetIntegrationDetector;
    /// <summary>
    /// Event
    /// </summary>
    public event EventHandler<NetAttachmentDetectionEventArgs> NetAttachmentDetector;
    /// <summary>
    /// Event
    /// </summary>
    public event EventHandler<NetReceptionDetectionEventArgs> NetReceptionDetector;
    /// <summary>
    /// Event
    /// </summary>
    public event EventHandler<NetResolutionDetectionEventArgs> NetResolutionDetector;
    /// <summary>
    /// Event
    /// </summary>
    public event EventHandler<NetContentProcessingDetectionEventArgs> NetContentProcessingDetector;
    /// <summary>
    /// Event
    /// </summary>
    public event EventHandler<NetSchemaValidationDetectionEventArgs> NetSchemaValidationDetector;


    #region Logging detection Event Manipulation

    private void OnLoggingDetection(NetLoggingDetectionEventArgs e)
    {
        NetLoggingDetector?.Invoke(this, e);
    }

    /// <summary>
    /// Method
    /// </summary>
    public void RaiseLoggingDetection(string payload)
    {
        OnLoggingDetection(new NetLoggingDetectionEventArgs(payload));
    }

    /// <summary>
    /// Method
    /// </summary>
    /// <param name="listener"></param>
    public void Attach(INetLoggingDetectionActionListener listener)
    {
        NetLoggingDetector += listener.Update;
    }

    /// <summary>
    /// Method
    /// </summary>
    /// <param name="listener"></param>
    public void Detach(INetLoggingDetectionActionListener listener)
    {
        NetLoggingDetector -= listener.Update;
    }

    #endregion


    #region Notification detection Event Manipulation

    private void OnNotificationDetection(NetNotificationDetectionEventArgs e)
    {
        NetNotificationDetector?.Invoke(this, e);
    }

    /// <summary>
    /// Method
    /// </summary>
    public void RaiseNotificationDetection(string payload)
    {
        OnNotificationDetection(new NetNotificationDetectionEventArgs(payload));
    }

    /// <summary>
    /// Method
    /// </summary>
    /// <param name="listener"></param>
    public void Attach(INetNotificationDetectionActionListener listener)
    {
        NetNotificationDetector += listener.Update;
    }

    /// <summary>
    /// Method
    /// </summary>
    /// <param name="listener"></param>
    public void Detach(INetNotificationDetectionActionListener listener)
    {
        NetNotificationDetector -= listener.Update;
    }

    #endregion


    #region ContentProcessing detection Event Manipulation

    private void OnContentProcessingDetection(NetContentProcessingDetectionEventArgs e)
    {
        NetContentProcessingDetector?.Invoke(this, e);
    }

    /// <summary>
    /// Method
    /// </summary>
    public void RaiseContentProcessingDetection(string payload)
    {
        OnContentProcessingDetection(new NetContentProcessingDetectionEventArgs(payload));
    }

    /// <summary>
    /// Method
    /// </summary>
    /// <param name="listener"></param>
    public void Attach(INetContentProcessingDetectionActionListener listener)
    {
        NetContentProcessingDetector += listener.Update;
    }

    /// <summary>
    /// Method
    /// </summary>
    /// <param name="listener"></param>
    public void Detach(INetContentProcessingDetectionActionListener listener)
    {
        NetContentProcessingDetector -= listener.Update;
    }

    #endregion



    #region SchemaValidation detection Event Manipulation

    private void OnSchemaValidationDetection(NetSchemaValidationDetectionEventArgs e)
    {
        NetSchemaValidationDetector?.Invoke(this, e);
    }

    /// <summary>
    /// Method
    /// </summary>
    public void RaiseSchemaValidationDetection(string payload)
    {
        OnSchemaValidationDetection(new NetSchemaValidationDetectionEventArgs(payload));
    }

    /// <summary>
    /// Method
    /// </summary>
    /// <param name="listener"></param>
    public void Attach(INetSchemaValidationDetectionActionListener listener)
    {
        NetSchemaValidationDetector += listener.Update;
    }

    /// <summary>
    /// Method
    /// </summary>
    /// <param name="listener"></param>
    public void Detach(INetSchemaValidationDetectionActionListener listener)
    {
        NetSchemaValidationDetector -= listener.Update;
    }

    #endregion


    #region Resolution detection Event Manipulation

    private void OnResolutionDetection(NetResolutionDetectionEventArgs e)
    {
        NetResolutionDetector?.Invoke(this, e);
    }

    /// <summary>
    /// Method
    /// </summary>
    public void RaiseResolutionDetection(string payload)
    {
        OnResolutionDetection(new NetResolutionDetectionEventArgs(payload));
    }

    /// <summary>
    /// Method
    /// </summary>
    /// <param name="listener"></param>
    public void Attach(INetResolutionDetectionActionListener listener)
    {
        NetResolutionDetector += listener.Update;
    }

    /// <summary>
    /// Method
    /// </summary>
    /// <param name="listener"></param>
    public void Detach(INetResolutionDetectionActionListener listener)
    {
        NetResolutionDetector -= listener.Update;
    }

    #endregion


    #region Integration detection Event Manipulation

    private void OnIntegrationDetection(NetIntegrationDetectionEventArgs e)
    {
        NetIntegrationDetector?.Invoke(this, e);
    }

    /// <summary>
    /// Method
    /// </summary>
    public void RaiseIntegrationDetection(string payload)
    {
        OnIntegrationDetection(new NetIntegrationDetectionEventArgs(payload));
    }

    /// <summary>
    /// Method
    /// </summary>
    /// <param name="listener"></param>
    public void Attach(INetIntegrationDetectionActionListener listener)
    {
        NetIntegrationDetector += listener.Update;
    }

    /// <summary>
    /// Method
    /// </summary>
    /// <param name="listener"></param>
    public void Detach(INetIntegrationDetectionActionListener listener)
    {
        NetIntegrationDetector -= listener.Update;
    }

    #endregion


    #region Reception detection Event Manipulation

    private void OnReceptionDetection(NetReceptionDetectionEventArgs e)
    {
        NetReceptionDetector?.Invoke(this, e);
    }

    /// <summary>
    /// Method
    /// </summary>
    public void RaiseReceptionDetection(string payload)
    {
        OnReceptionDetection(new NetReceptionDetectionEventArgs(payload));
    }

    /// <summary>
    /// Method
    /// </summary>
    /// <param name="listener"></param>
    public void Attach(INetReceptionDetectionActionListener listener)
    {
        NetReceptionDetector += listener.Update;
    }

    /// <summary>
    /// Method
    /// </summary>
    /// <param name="listener"></param>
    public void Detach(INetReceptionDetectionActionListener listener)
    {
        NetReceptionDetector -= listener.Update;
    }

    #endregion


    #region Attachment detection Event Manipulation

    private void OnAttachmentDetection(NetAttachmentDetectionEventArgs e)
    {
        NetAttachmentDetector?.Invoke(this, e);
    }

    /// <summary>
    /// Method
    /// </summary>
    public void RaiseAttachmentDetection(string payload)
    {
        OnAttachmentDetection(new NetAttachmentDetectionEventArgs(payload));
    }

    /// <summary>
    /// Method
    /// </summary>
    /// <param name="listener"></param>
    public void Attach(INetAttachmentDetectionActionListener listener)
    {
        NetAttachmentDetector += listener.Update;
    }

    /// <summary>
    /// Method
    /// </summary>
    /// <param name="listener"></param>
    public void Detach(INetAttachmentDetectionActionListener listener)
    {
        NetAttachmentDetector -= listener.Update;
    }

    #endregion
}