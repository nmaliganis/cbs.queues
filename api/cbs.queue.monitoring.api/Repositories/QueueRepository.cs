using System.Collections.Generic;

namespace cbs.queue.monitoring.api.Repositories
{
    /// <summary>
    /// Class Singleton
    /// </summary>
    public sealed class QueueRepository
    {
        private static QueueRepository _instance = new QueueRepository();

        /// <summary>
        /// Property
        /// </summary>
        public ISet<string> BlockedNotification { get; set; } = new HashSet<string>();
        /// <summary>
        /// Property
        /// </summary>
        public ISet<string> BlockedLogging { get; set; } = new HashSet<string>();
        /// <summary>
        /// Property
        /// </summary>
        public ISet<string> BlockedAttachmentReception { get; set; } = new HashSet<string>();
        /// <summary>
        /// Property
        /// </summary>
        public ISet<string> BlockedContentProcessing { get; set; } = new HashSet<string>();
        /// <summary>
        /// Property
        /// </summary>
        public ISet<string> BlockedIntegration { get; set; } = new HashSet<string>();
        /// <summary>
        /// Property
        /// </summary>
        public ISet<string> BlockedReception { get; set; } = new HashSet<string>();
        /// <summary>
        /// Resolution
        /// </summary>
        public ISet<string> BlockedResolution { get; set; } = new HashSet<string>();
        /// <summary>
        /// Schema Validation
        /// </summary>
        public ISet<string> BlockedSchemaValidation { get; set; } = new HashSet<string>();

        private QueueRepository()
        {
            
        }

        /// <summary>
        /// Property
        /// </summary>
        public static QueueRepository GetInstance => _instance;

        /// <summary>
        /// Method
        /// </summary>
        /// <param name="notificationToBeAdded"></param>
        public void PushNotification(string notificationToBeAdded)
        {
            this.BlockedNotification.Add(notificationToBeAdded);
        }

        /// <summary>
        /// Method
        /// </summary>
        /// <returns></returns>
        public ISet<string> GetNotifications()
        {
            return this.BlockedNotification;
        }

        /// <summary>
        /// Method
        /// </summary>
        /// <returns></returns>
        public int GetCountNotifications()
        {
            return this.BlockedNotification.Count;
        }

        /// <summary>
        /// Method
        /// </summary>
        /// <param name="payloadToBeAdded"></param>
        public void PushLogging(string payloadToBeAdded)
        {
            this.BlockedLogging.Add(payloadToBeAdded);
        }

        /// <summary>
        /// Method
        /// </summary>
        /// <returns></returns>
        public ISet<string> GetLoggings()
        {
            return this.BlockedLogging;
        }

        /// <summary>
        /// Method
        /// </summary>
        /// <returns></returns>
        public int GetCountLoggings()
        {
            return this.BlockedLogging.Count;
        }

        /// <summary>
        /// Method
        /// </summary>
        /// <returns></returns>
        public bool RemoveLogging(string queue)
        {
            if(!this.BlockedLogging.Contains(queue))
                return false;
            
            return this.BlockedLogging.Remove(queue);
        }

        /// <summary>
        /// Method
        /// </summary>
        /// <param name="payloadToBeAdded"></param>
        public void PushAttachment(string payloadToBeAdded)
        {
            this.BlockedAttachmentReception.Add(payloadToBeAdded);
        }

        /// <summary>
        /// Method
        /// </summary>
        /// <returns></returns>
        public ISet<string> GetAttachments()
        {
            return this.BlockedAttachmentReception;
        }

        /// <summary>
        /// Method
        /// </summary>
        /// <returns></returns>
        public int GetCountAttachments()
        {
            return this.BlockedAttachmentReception.Count;
        }

        /// <summary>
        /// Method
        /// </summary>
        /// <param name="payloadToBeAdded"></param>
        public void PushContentProcessing(string payloadToBeAdded)
        {
            this.BlockedContentProcessing.Add(payloadToBeAdded);
        }

        /// <summary>
        /// Method
        /// </summary>
        /// <returns></returns>
        public ISet<string> GetContentProcessing()
        {
            return this.BlockedContentProcessing;
        }

        /// <summary>
        /// Method
        /// </summary>
        /// <returns></returns>
        public int GetCountContentProcessing()
        {
            return this.BlockedContentProcessing.Count;
        }

        /// <summary>
        /// Method
        /// </summary>
        /// <param name="payloadToBeAdded"></param>
        public void PushIntegration(string payloadToBeAdded)
        {
            this.BlockedIntegration.Add(payloadToBeAdded);
        }

        /// <summary>
        /// Method
        /// </summary>
        /// <returns></returns>
        public ISet<string> GetIntegrations()
        {
            return this.BlockedIntegration;
        }

        /// <summary>
        /// Method
        /// </summary>
        /// <returns></returns>
        public int GetCountIntegrations()
        {
            return this.BlockedIntegration.Count;
        }

        /// <summary>
        /// Method
        /// </summary>
        /// <param name="payloadToBeAdded"></param>
        public void PushReception(string payloadToBeAdded)
        {
            this.BlockedReception.Add(payloadToBeAdded);
        }

        /// <summary>
        /// Method
        /// </summary>
        /// <returns></returns>
        public ISet<string> GetReceptions()
        {
            return this.BlockedReception;
        }

        /// <summary>
        /// Method
        /// </summary>
        /// <returns></returns>
        public int GetCountReceptions()
        {
            return this.BlockedReception.Count;
        }

        /// <summary>
        /// Method
        /// </summary>
        /// <param name="payloadToBeAdded"></param>
        public void PushResolution(string payloadToBeAdded)
        {
            this.BlockedResolution.Add(payloadToBeAdded);
        }

        /// <summary>
        /// Method
        /// </summary>
        /// <returns></returns>
        public ISet<string> GetResolutions()
        {
            return this.BlockedResolution;
        }

        /// <summary>
        /// Method
        /// </summary>
        /// <returns></returns>
        public int GetCountResolutions()
        {
            return this.BlockedResolution.Count;
        }

        /// <summary>
        /// Method
        /// </summary>
        /// <param name="payloadToBeAdded"></param>
        public void PushSchemaValidation(string payloadToBeAdded)
        {
            this.BlockedSchemaValidation.Add(payloadToBeAdded);
        }

        /// <summary>
        /// Method
        /// </summary>
        /// <returns></returns>
        public ISet<string> GetSchemaValidations()
        {
            return this.BlockedSchemaValidation;
        }

        /// <summary>
        /// Method
        /// </summary>
        /// <returns></returns>
        public int GetCountSchemaValidations()
        {
            return this.BlockedSchemaValidation.Count;
        }
    }
}
