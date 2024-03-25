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
public class NetSchemaValidationWsInitializerJob : IJob
{
    /// <summary>
    /// Method
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public Task Execute(IJobExecutionContext context)
    {
        string queuePath = @".\private$\nsw.net-schemavalidation-in.tx";

        var thisQueue = queuePath;

        using var mq = new MessageQueue(thisQueue);

        mq.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });
        try
        {
            var messages = mq.GetAllMessages();

            if(messages.Length <= 0)
                return Task.CompletedTask;

            foreach (var message in messages)
            {
                using Stream stream = message.BodyStream;
                StreamReader reader = new StreamReader(stream);
                string body = reader.ReadToEnd();

                WsServer.GetWsServer.RaiseSchemaValidationDetection(body);
            }
        }
        catch (Exception e)
        {
            return Task.CompletedTask;
        }

        return Task.CompletedTask;
    }
}