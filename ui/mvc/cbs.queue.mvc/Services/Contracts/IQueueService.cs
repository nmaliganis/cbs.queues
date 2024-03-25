namespace cbs.queue.mvc.Services.Contracts;

public interface IQueueService
{
    Task<List<string>> GetLoggingList();
    Task<int> GetLoggingCount();
    Task<List<string>> GetNotificationList();
    Task<int> GetNotificationCount();
    Task<List<string>> GetAttachmentList();
    Task<int> GetAttachmentCount();
    Task<List<string>> GetContentProcessingList();
    Task<int> GetContentProcessingCount();
    Task<List<string>> GetIntegrationList();
    Task<int> GetIntegrationCount();
    Task<List<string>> GetReceptionList();
    Task<int> GetReceptionCount();
    Task<List<string>> GetResolutionList();
    Task<int> GetResolutionCount();
    Task<List<string>> GetSchemaValidationList();
    Task<int> GetSchemaValidationCount();
}