using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using cbs.queue.monitoring.api.Commanding;
using MSMQ.Messaging;
using Quartz;

namespace cbs.queue.monitoring.api.Schedulers;

/// <summary>
/// Class
/// </summary>
public class NetLoggingWsInitializerJob : IJob
{
    /// <summary>
    /// Method
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public Task Execute(IJobExecutionContext context)
    {
        string queuePath = @".\private$\nsw.net-logging";

        var thisQueue = queuePath;

        using var mq = new MessageQueue(thisQueue);

        try
        {
            mq.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });
            var messages = mq.GetAllMessages();

            if (messages.Length <= 0)
                return Task.CompletedTask;

            foreach (var message in messages)
            {
                using Stream stream = message.BodyStream;
                StreamReader reader = new StreamReader(stream);

                string body = reader.ReadToEnd();

                if(!String.IsNullOrEmpty(body))
                    WsServer.GetWsServer.RaiseLoggingDetection(body);
            }
        }
        catch (Exception e)
        {
            return Task.CompletedTask;
        }

        return Task.CompletedTask;
    }
}