using System.Net;
using cbs.queue.mvc.Models;
using cbs.queue.mvc.Services.Base;
using cbs.queue.mvc.Services.Contracts;
using Newtonsoft.Json;
using RestSharp;

namespace cbs.queue.mvc.Services.Impls;

public class QueueService : IQueueService
{
    public IConfiguration Configuration { get; set; }
    public string BaseAddr { get; private set; }
    public string Version { get; private set; }

    public QueueService(IConfiguration configuration)
    {
        this.Configuration = configuration;
        this.OnCreated();
    }
    private void OnCreated()
    {
        this.BaseAddr = this.Configuration["url"];
        this.Version = this.Configuration["version"];
    }

    public async Task<List<string>> GetLoggingList()
    {
        var result = new List<string>();

        var client = new RestClient($"{this.BaseAddr}/api/{this.Version}/queues/logging");
        var request = new RestRequest();

        request.AddHeader("Content-Type", "application/json");

        try
        {
            var response = await client.GetAsync(request);
            if (response.IsSuccessful)
            {
                result = JsonConvert.DeserializeObject<List<string>>(response!.Content!);
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.Conflict)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                if (!string.IsNullOrEmpty(response!.Content!))
                {
                    QueueErrorModel resultError =
                        JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                    throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
                }

                throw new Exception("ERROR_CONNECTION_SERVER");
            }
        }
        catch (Exception e)
        {
            throw new ServiceHttpRequestException<string>(HttpStatusCode.Conflict, e.Message);
        }
        return result;
    }

    public async Task<int> GetLoggingCount()
    {
        int result = 0;

        var client = new RestClient($"{this.BaseAddr}/api/{this.Version}/queues/count-logging");
        var request = new RestRequest();

        request.AddHeader("Content-Type", "application/json");

        try
        {
            var response = await client.GetAsync(request);
            if (response.IsSuccessful)
            {
                result = JsonConvert.DeserializeObject<int>(response!.Content!);
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.Conflict)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                if (!string.IsNullOrEmpty(response!.Content!))
                {
                    QueueErrorModel resultError =
                        JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                    throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
                }

                throw new Exception("ERROR_CONNECTION_SERVER");
            }
        }
        catch (Exception e)
        {
            throw new ServiceHttpRequestException<string>(HttpStatusCode.Conflict, e.Message);
        }
        return result;
    }

    public async Task<List<string>> GetNotificationList()
    {
        var result = new List<string>();

        var client = new RestClient($"{this.BaseAddr}/api/{this.Version}/queues/notification");
        var request = new RestRequest();

        request.AddHeader("Content-Type", "application/json");

        try
        {
            var response = await client.GetAsync(request);
            if (response.IsSuccessful)
            {
                result = JsonConvert.DeserializeObject<List<string>>(response!.Content!);
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.Conflict)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                if (!string.IsNullOrEmpty(response!.Content!))
                {
                    QueueErrorModel resultError =
                        JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                    throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
                }

                throw new Exception("ERROR_CONNECTION_SERVER");
            }
        }
        catch (Exception e)
        {
            throw new ServiceHttpRequestException<string>(HttpStatusCode.Conflict, e.Message);
        }
        return result;
    }

    public async Task<int> GetNotificationCount()
    {
        int result = 0;

        var client = new RestClient($"{this.BaseAddr}/api/{this.Version}/queues/count-notification");
        var request = new RestRequest();

        request.AddHeader("Content-Type", "application/json");

        try
        {
            var response = await client.GetAsync(request);
            if (response.IsSuccessful)
            {
                result = JsonConvert.DeserializeObject<int>(response!.Content!);
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.Conflict)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                if (!string.IsNullOrEmpty(response!.Content!))
                {
                    QueueErrorModel resultError =
                        JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                    throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
                }

                throw new Exception("ERROR_CONNECTION_SERVER");
            }
        }
        catch (Exception e)
        {
            throw new ServiceHttpRequestException<string>(HttpStatusCode.Conflict, e.Message);
        }
        return result;
    }

    public async Task<List<string>> GetAttachmentList()
    {
        var result = new List<string>();

        var client = new RestClient($"{this.BaseAddr}/api/{this.Version}/queues/attachment");
        var request = new RestRequest();

        request.AddHeader("Content-Type", "application/json");

        try
        {
            var response = await client.GetAsync(request);
            if (response.IsSuccessful)
            {
                result = JsonConvert.DeserializeObject<List<string>>(response!.Content!);
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.Conflict)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                if (!string.IsNullOrEmpty(response!.Content!))
                {
                    QueueErrorModel resultError =
                        JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                    throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
                }

                throw new Exception("ERROR_CONNECTION_SERVER");
            }
        }
        catch (Exception e)
        {
            throw new ServiceHttpRequestException<string>(HttpStatusCode.Conflict, e.Message);
        }
        return result;
    }

    public async Task<int> GetAttachmentCount()
    {
        int result = 0;

        var client = new RestClient($"{this.BaseAddr}/api/{this.Version}/queues/count-attachment");
        var request = new RestRequest();

        request.AddHeader("Content-Type", "application/json");

        try
        {
            var response = await client.GetAsync(request);
            if (response.IsSuccessful)
            {
                result = JsonConvert.DeserializeObject<int>(response!.Content!);
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.Conflict)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                if (!string.IsNullOrEmpty(response!.Content!))
                {
                    QueueErrorModel resultError =
                        JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                    throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
                }

                throw new Exception("ERROR_CONNECTION_SERVER");
            }
        }
        catch (Exception e)
        {
            throw new ServiceHttpRequestException<string>(HttpStatusCode.Conflict, e.Message);
        }
        return result;
    }

    public async Task<List<string>> GetContentProcessingList()
    {
        var result = new List<string>();

        var client = new RestClient($"{this.BaseAddr}/api/{this.Version}/queues/content-processing");
        var request = new RestRequest();

        request.AddHeader("Content-Type", "application/json");

        try
        {
            var response = await client.GetAsync(request);
            if (response.IsSuccessful)
            {
                result = JsonConvert.DeserializeObject<List<string>>(response!.Content!);
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.Conflict)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                if (!string.IsNullOrEmpty(response!.Content!))
                {
                    QueueErrorModel resultError =
                        JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                    throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
                }

                throw new Exception("ERROR_CONNECTION_SERVER");
            }
        }
        catch (Exception e)
        {
            throw new ServiceHttpRequestException<string>(HttpStatusCode.Conflict, e.Message);
        }
        return result;
    }

    public async Task<int> GetContentProcessingCount()
    {
        int result = 0;

        var client = new RestClient($"{this.BaseAddr}/api/{this.Version}/queues/count-content-processing");
        var request = new RestRequest();

        request.AddHeader("Content-Type", "application/json");

        try
        {
            var response = await client.GetAsync(request);
            if (response.IsSuccessful)
            {
                result = JsonConvert.DeserializeObject<int>(response!.Content!);
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.Conflict)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                if (!string.IsNullOrEmpty(response!.Content!))
                {
                    QueueErrorModel resultError =
                        JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                    throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
                }

                throw new Exception("ERROR_CONNECTION_SERVER");
            }
        }
        catch (Exception e)
        {
            throw new ServiceHttpRequestException<string>(HttpStatusCode.Conflict, e.Message);
        }
        return result;
    }

    public async Task<List<string>> GetIntegrationList()
    {
        var result = new List<string>();

        var client = new RestClient($"{this.BaseAddr}/api/{this.Version}/queues/integration");
        var request = new RestRequest();

        request.AddHeader("Content-Type", "application/json");

        try
        {
            var response = await client.GetAsync(request);
            if (response.IsSuccessful)
            {
                result = JsonConvert.DeserializeObject<List<string>>(response!.Content!);
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.Conflict)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                if (!string.IsNullOrEmpty(response!.Content!))
                {
                    QueueErrorModel resultError =
                        JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                    throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
                }

                throw new Exception("ERROR_CONNECTION_SERVER");
            }
        }
        catch (Exception e)
        {
            throw new ServiceHttpRequestException<string>(HttpStatusCode.Conflict, e.Message);
        }
        return result;
    }

    public async Task<int> GetIntegrationCount()
    {
        int result = 0;

        var client = new RestClient($"{this.BaseAddr}/api/{this.Version}/queues/count-integration");
        var request = new RestRequest();

        request.AddHeader("Content-Type", "application/json");

        try
        {
            var response = await client.GetAsync(request);
            if (response.IsSuccessful)
            {
                result = JsonConvert.DeserializeObject<int>(response!.Content!);
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.Conflict)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                if (!string.IsNullOrEmpty(response!.Content!))
                {
                    QueueErrorModel resultError =
                        JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                    throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
                }

                throw new Exception("ERROR_CONNECTION_SERVER");
            }
        }
        catch (Exception e)
        {
            throw new ServiceHttpRequestException<string>(HttpStatusCode.Conflict, e.Message);
        }
        return result;
    }

    public async Task<List<string>> GetReceptionList()
    {
        var result = new List<string>();

        var client = new RestClient($"{this.BaseAddr}/api/{this.Version}/queues/reception");
        var request = new RestRequest();

        request.AddHeader("Content-Type", "application/json");

        try
        {
            var response = await client.GetAsync(request);
            if (response.IsSuccessful)
            {
                result = JsonConvert.DeserializeObject<List<string>>(response!.Content!);
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.Conflict)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                if (!string.IsNullOrEmpty(response!.Content!))
                {
                    QueueErrorModel resultError =
                        JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                    throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
                }

                throw new Exception("ERROR_CONNECTION_SERVER");
            }
        }
        catch (Exception e)
        {
            throw new ServiceHttpRequestException<string>(HttpStatusCode.Conflict, e.Message);
        }
        return result;
    }

    public async Task<int> GetReceptionCount()
    {
        int result = 0;

        var client = new RestClient($"{this.BaseAddr}/api/{this.Version}/queues/count-reception");
        var request = new RestRequest();

        request.AddHeader("Content-Type", "application/json");

        try
        {
            var response = await client.GetAsync(request);
            if (response.IsSuccessful)
            {
                result = JsonConvert.DeserializeObject<int>(response!.Content!);
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.Conflict)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                if (!string.IsNullOrEmpty(response!.Content!))
                {
                    QueueErrorModel resultError =
                        JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                    throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
                }

                throw new Exception("ERROR_CONNECTION_SERVER");
            }
        }
        catch (Exception e)
        {
            throw new ServiceHttpRequestException<string>(HttpStatusCode.Conflict, e.Message);
        }
        return result;
    }

    public async Task<List<string>> GetResolutionList()
    {
        var result = new List<string>();

        var client = new RestClient($"{this.BaseAddr}/api/{this.Version}/queues/resolution");
        var request = new RestRequest();

        request.AddHeader("Content-Type", "application/json");

        try
        {
            var response = await client.GetAsync(request);
            if (response.IsSuccessful)
            {
                result = JsonConvert.DeserializeObject<List<string>>(response!.Content!);
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.Conflict)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                if (!string.IsNullOrEmpty(response!.Content!))
                {
                    QueueErrorModel resultError =
                        JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                    throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
                }

                throw new Exception("ERROR_CONNECTION_SERVER");
            }
        }
        catch (Exception e)
        {
            throw new ServiceHttpRequestException<string>(HttpStatusCode.Conflict, e.Message);
        }
        return result;
    }

    public async Task<int> GetResolutionCount()
    {
        int result = 0;

        var client = new RestClient($"{this.BaseAddr}/api/{this.Version}/queues/count-resolution");
        var request = new RestRequest();

        request.AddHeader("Content-Type", "application/json");

        try
        {
            var response = await client.GetAsync(request);
            if (response.IsSuccessful)
            {
                result = JsonConvert.DeserializeObject<int>(response!.Content!);
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.Conflict)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                if (!string.IsNullOrEmpty(response!.Content!))
                {
                    QueueErrorModel resultError =
                        JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                    throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
                }

                throw new Exception("ERROR_CONNECTION_SERVER");
            }
        }
        catch (Exception e)
        {
            throw new ServiceHttpRequestException<string>(HttpStatusCode.Conflict, e.Message);
        }
        return result;
    }

    public async Task<List<string>> GetSchemaValidationList()
    {
        var result = new List<string>();

        var client = new RestClient($"{this.BaseAddr}/api/{this.Version}/queues/schema-validation");
        var request = new RestRequest();

        request.AddHeader("Content-Type", "application/json");

        try
        {
            var response = await client.GetAsync(request);
            if (response.IsSuccessful)
            {
                result = JsonConvert.DeserializeObject<List<string>>(response!.Content!);
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.Conflict)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                if (!string.IsNullOrEmpty(response!.Content!))
                {
                    QueueErrorModel resultError =
                        JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                    throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
                }

                throw new Exception("ERROR_CONNECTION_SERVER");
            }
        }
        catch (Exception e)
        {
            throw new ServiceHttpRequestException<string>(HttpStatusCode.Conflict, e.Message);
        }
        return result;
    }

    public async Task<int> GetSchemaValidationCount()
    {
        int result = 0;

        var client = new RestClient($"{this.BaseAddr}/api/{this.Version}/queues/count-schema-validation");
        var request = new RestRequest();

        request.AddHeader("Content-Type", "application/json");

        try
        {
            var response = await client.GetAsync(request);
            if (response.IsSuccessful)
            {
                result = JsonConvert.DeserializeObject<int>(response!.Content!);
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.Conflict)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                QueueErrorModel resultError =
                    JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                if (!string.IsNullOrEmpty(response!.Content!))
                {
                    QueueErrorModel resultError =
                        JsonConvert.DeserializeObject<QueueErrorModel>(response!.Content!);
                    throw new ServiceHttpRequestException<string>(response.StatusCode, resultError!.ErrorMessage);
                }

                throw new Exception("ERROR_CONNECTION_SERVER");
            }
        }
        catch (Exception e)
        {
            throw new ServiceHttpRequestException<string>(HttpStatusCode.Conflict, e.Message);
        }
        return result;
    }
}//Class : InmateService