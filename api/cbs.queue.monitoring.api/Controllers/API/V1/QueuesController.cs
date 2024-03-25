using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using cbs.common.infrastructure.Extensions;
using cbs.common.infrastructure.PropertyMappings;
using cbs.common.infrastructure.TypeHelpers;
using cbs.queue.monitoring.api.Repositories;
using cbs.queue.monitoring.api.Validators;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace cbs.queue.monitoring.api.Controllers.API.V1;

/// <summary>
/// Message Controller
/// </summary>
[Produces("application/json")]
[ApiVersion("1.0")]
[ResponseCache(Duration = 0, NoStore = true, VaryByHeader = "*")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class QueuesController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IUrlHelper _urlHelper;
    private readonly ITypeHelperService _typeHelperService;
    private readonly IPropertyMappingService _propertyMappingService;


    /// <summary>
    /// ctor
    /// </summary>
    /// <param name="mediator"></param>
    /// <param name="urlHelper"></param>
    /// <param name="typeHelperService"></param>
    /// <param name="propertyMappingService"></param>
    public QueuesController(
        IMediator mediator,
        IUrlHelper urlHelper,
        ITypeHelperService typeHelperService,
        IPropertyMappingService propertyMappingService)
    {
        this._mediator = mediator;
        this._urlHelper = urlHelper;
        this._typeHelperService = typeHelperService;
        this._propertyMappingService = propertyMappingService;
    }

    /// <summary>
    /// Get - Fetch all Blocked Loggings
    /// </summary>
    /// <remarks>Fetch all Messages </remarks>
    /// <response code="200">Resource retrieved correctly</response>
    /// <response code="404">Resource Not Found</response>
    /// <response code="500">Internal Server Error.</response>
    [HttpGet("logging", Name = "FetchLoggingsRoot")]
    [ValidateModel]
    [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> FetchLoggingsAsync()
    {

        var items = QueueRepository.GetInstance.BlockedLogging;
        return Ok(items);
    }

    /// <summary>
    /// Get - Fetch Count Blocked Loggings
    /// </summary>
    /// <remarks>Fetch all Messages </remarks>
    /// <response code="200">Resource retrieved correctly</response>
    /// <response code="404">Resource Not Found</response>
    /// <response code="500">Internal Server Error.</response>
    [HttpGet("count-logging", Name = "FetchCountLoggingsRoot")]
    [ValidateModel]
    [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> FetchCountLoggingsAsync()
    {

        var itemsLen = QueueRepository.GetInstance.GetCountLoggings();
        return Ok(itemsLen);
    }

    /// <summary>
    /// Delete - Remove Blocked Logging
    /// </summary>
    /// <remarks>Fetch all Messages </remarks>
    /// <response code="200">Resource retrieved correctly</response>
    /// <response code="404">Resource Not Found</response>
    /// <response code="500">Internal Server Error.</response>
    [HttpDelete("logging", Name = "RemoveLoggingRoot")]
    [ValidateModel]
    [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> RemoveLoggingAsync([FromBody] string queue)
    {
        var removed = QueueRepository.GetInstance.RemoveLogging(queue);
        return Ok(removed);
    }

    /// <summary>
    /// Get - Fetch all Blocked Notifications
    /// </summary>
    /// <remarks>Fetch all Messages </remarks>
    /// <response code="200">Resource retrieved correctly</response>
    /// <response code="404">Resource Not Found</response>
    /// <response code="500">Internal Server Error.</response>
    [HttpGet("notification", Name = "FetchNotificationsRoot")]
    [ValidateModel]
    [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> FetchNotificationsAsync()
    {

        var items = QueueRepository.GetInstance.BlockedNotification;
        return Ok(items);
    }

    /// <summary>
    /// Get - Fetch Count Blocked Notifications
    /// </summary>
    /// <remarks>Fetch all Messages </remarks>
    /// <response code="200">Resource retrieved correctly</response>
    /// <response code="404">Resource Not Found</response>
    /// <response code="500">Internal Server Error.</response>
    [HttpGet("count-notification", Name = "FetchCountNotificationsRoot")]
    [ValidateModel]
    [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> FetchCountNotificationsAsync()
    {

        var itemsLen = QueueRepository.GetInstance.GetCountNotifications();
        return Ok(itemsLen);
    }


    /// <summary>
    /// Get - Fetch all Blocked Attachments
    /// </summary>
    /// <remarks>Fetch all Messages </remarks>
    /// <response code="200">Resource retrieved correctly</response>
    /// <response code="404">Resource Not Found</response>
    /// <response code="500">Internal Server Error.</response>
    [HttpGet("attachment", Name = "FetchAttachmentsRoot")]
    [ValidateModel]
    [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> FetchAttachmentsAsync()
    {

        var items = QueueRepository.GetInstance.BlockedAttachmentReception;
        return Ok(items);
    }

    /// <summary>
    /// Get - Fetch Count Blocked Attachments
    /// </summary>
    /// <remarks>Fetch all Messages </remarks>
    /// <response code="200">Resource retrieved correctly</response>
    /// <response code="404">Resource Not Found</response>
    /// <response code="500">Internal Server Error.</response>
    [HttpGet("count-Attachment", Name = "FetchCountAttachmentsRoot")]
    [ValidateModel]
    [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> FetchCountAttachmentsAsync()
    {

        var itemsLen = QueueRepository.GetInstance.GetCountAttachments();
        return Ok(itemsLen);
    }


    /// <summary>
    /// Get - Fetch all Blocked ContentProcessings
    /// </summary>
    /// <remarks>Fetch all Messages </remarks>
    /// <response code="200">Resource retrieved correctly</response>
    /// <response code="404">Resource Not Found</response>
    /// <response code="500">Internal Server Error.</response>
    [HttpGet("content-processing", Name = "FetchContentProcessingsRoot")]
    [ValidateModel]
    [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> FetchContentProcessingsAsync()
    {

        var items = QueueRepository.GetInstance.BlockedContentProcessing;
        return Ok(items);
    }

    /// <summary>
    /// Get - Fetch Count Blocked ContentProcessings
    /// </summary>
    /// <remarks>Fetch all Messages </remarks>
    /// <response code="200">Resource retrieved correctly</response>
    /// <response code="404">Resource Not Found</response>
    /// <response code="500">Internal Server Error.</response>
    [HttpGet("count-content-processing", Name = "FetchCountContentProcessingsRoot")]
    [ValidateModel]
    [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> FetchCountContentProcessingsAsync()
    {

        var itemsLen = QueueRepository.GetInstance.GetCountContentProcessing();
        return Ok(itemsLen);
    }


    /// <summary>
    /// Get - Fetch all Blocked Integrations
    /// </summary>
    /// <remarks>Fetch all Messages </remarks>
    /// <response code="200">Resource retrieved correctly</response>
    /// <response code="404">Resource Not Found</response>
    /// <response code="500">Internal Server Error.</response>
    [HttpGet("integration", Name = "FetchIntegrationsRoot")]
    [ValidateModel]
    [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> FetchIntegrationsAsync()
    {

        var items = QueueRepository.GetInstance.BlockedIntegration;
        return Ok(items);
    }

    /// <summary>
    /// Get - Fetch Count Blocked Integrations
    /// </summary>
    /// <remarks>Fetch all Messages </remarks>
    /// <response code="200">Resource retrieved correctly</response>
    /// <response code="404">Resource Not Found</response>
    /// <response code="500">Internal Server Error.</response>
    [HttpGet("count-integration", Name = "FetchCountIntegrationsRoot")]
    [ValidateModel]
    [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> FetchCountIntegrationsAsync()
    {

        var itemsLen = QueueRepository.GetInstance.GetCountIntegrations();
        return Ok(itemsLen);
    }


    /// <summary>
    /// Get - Fetch all Blocked Receptions
    /// </summary>
    /// <remarks>Fetch all Messages </remarks>
    /// <response code="200">Resource retrieved correctly</response>
    /// <response code="404">Resource Not Found</response>
    /// <response code="500">Internal Server Error.</response>
    [HttpGet("reception", Name = "FetchReceptionsRoot")]
    [ValidateModel]
    [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> FetchReceptionsAsync()
    {

        var items = QueueRepository.GetInstance.BlockedReception;
        return Ok(items);
    }

    /// <summary>
    /// Get - Fetch Count Blocked Receptions
    /// </summary>
    /// <remarks>Fetch all Messages </remarks>
    /// <response code="200">Resource retrieved correctly</response>
    /// <response code="404">Resource Not Found</response>
    /// <response code="500">Internal Server Error.</response>
    [HttpGet("count-reception", Name = "FetchCountReceptionsRoot")]
    [ValidateModel]
    [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> FetchCountReceptionsAsync()
    {

        var itemsLen = QueueRepository.GetInstance.GetCountReceptions();
        return Ok(itemsLen);
    }


    /// <summary>
    /// Get - Fetch all Blocked Resolutions
    /// </summary>
    /// <remarks>Fetch all Messages </remarks>
    /// <response code="200">Resource retrieved correctly</response>
    /// <response code="404">Resource Not Found</response>
    /// <response code="500">Internal Server Error.</response>
    [HttpGet("resolution", Name = "FetchResolutionsRoot")]
    [ValidateModel]
    [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> FetchResolutionsAsync()
    {

        var items = QueueRepository.GetInstance.BlockedResolution;
        return Ok(items);
    }

    /// <summary>
    /// Get - Fetch Count Blocked Resolutions
    /// </summary>
    /// <remarks>Fetch all Messages </remarks>
    /// <response code="200">Resource retrieved correctly</response>
    /// <response code="404">Resource Not Found</response>
    /// <response code="500">Internal Server Error.</response>
    [HttpGet("count-resolution", Name = "FetchCountResolutionsRoot")]
    [ValidateModel]
    [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> FetchCountResolutionsAsync()
    {

        var itemsLen = QueueRepository.GetInstance.GetCountResolutions();
        return Ok(itemsLen);
    }

    /// <summary>
    /// Get - Fetch all Blocked SchemaValidations
    /// </summary>
    /// <remarks>Fetch all Messages </remarks>
    /// <response code="200">Resource retrieved correctly</response>
    /// <response code="404">Resource Not Found</response>
    /// <response code="500">Internal Server Error.</response>
    [HttpGet("schema-validation", Name = "FetchSchemaValidationsRoot")]
    [ValidateModel]
    [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> FetchSchemaValidationsAsync()
    {

        var items = QueueRepository.GetInstance.BlockedSchemaValidation;
        return Ok(items);
    }

    /// <summary>
    /// Get - Fetch Count Blocked SchemaValidations
    /// </summary>
    /// <remarks>Fetch all Messages </remarks>
    /// <response code="200">Resource retrieved correctly</response>
    /// <response code="404">Resource Not Found</response>
    /// <response code="500">Internal Server Error.</response>
    [HttpGet("count-schema-validation", Name = "FetchCountSchemaValidationsRoot")]
    [ValidateModel]
    [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> FetchCountSchemaValidationsAsync()
    {

        var itemsLen = QueueRepository.GetInstance.GetCountSchemaValidations();
        return Ok(itemsLen);
    }

}//Class : QueuesController