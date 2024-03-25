using cbs.queue.mvc.Models;
using cbs.queue.mvc.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace cbs.queue.mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IQueueService _queueService;

        public HomeController(ILogger<HomeController> logger, IQueueService queueService)
        {
            _logger = logger;
            _queueService = queueService;
        }

        public async Task<IActionResult> Index()
        {
            var notificationCount = await _queueService.GetNotificationCount();
            ViewBag.NotificationCount = notificationCount;

            var loggingCount = await _queueService.GetLoggingCount();
            ViewBag.LoggingCount = loggingCount;

            var attachmentCount = await _queueService.GetAttachmentCount();
            ViewBag.AttachmentCount = attachmentCount;

            var integrationCount = await _queueService.GetIntegrationCount();
            ViewBag.IntegrationCount = integrationCount;

            var resolutionCount = await _queueService.GetResolutionCount();
            ViewBag.ResolutionCount = resolutionCount;

            var receptionCount = await _queueService.GetReceptionCount();
            ViewBag.ReceptionCount = receptionCount;

            var contentProcessingCount = await _queueService.GetContentProcessingCount();
            ViewBag.ContentProcessingCount = contentProcessingCount;

            var schemaValidationCount = await _queueService.GetSchemaValidationCount();
            ViewBag.SchemaValidationCount = schemaValidationCount;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
