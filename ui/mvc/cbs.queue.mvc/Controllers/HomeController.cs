using cbs.queue.mvc.Models;
using cbs.queue.mvc.Services.Contracts;
using cbs.queue.mvc.Services.Impls;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Timers;

namespace cbs.queue.mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IQueueService _queueService;

        private System.Timers.Timer _timer;

        protected void SetTimer(double interval)
        {
            this._timer = new System.Timers.Timer(interval);
            this._timer.Elapsed += this.NotifyTimerElapsed;
            this._timer.Enabled = true;
        }

        private void NotifyTimerElapsed(object sender, ElapsedEventArgs e)
        {
            this.Fetch();

            this._timer.Enabled = false;
            OnElapsed?.Invoke();
            this._timer.Dispose();

            this.SetTimer(3000);
        }

        public event Action OnElapsed;


        public HomeController(ILogger<HomeController> logger, IQueueService queueService)
        {
            this._logger = logger;
            this._queueService = queueService;
        }

        public async Task<IActionResult> Index()
        {
            await this.Fetch();

            this.SetTimer(3000);

            return this.View();
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        protected async Task Fetch()
        {
            var notificationCount = await this._queueService.GetNotificationCount();
            ViewBag.NotificationCount = notificationCount;

            var loggingCount = await this._queueService.GetLoggingCount();
            ViewBag.LoggingCount = loggingCount;

            var attachmentCount = await this._queueService.GetAttachmentCount();
            ViewBag.AttachmentCount = attachmentCount;

            var integrationCount = await this._queueService.GetIntegrationCount();
            ViewBag.IntegrationCount = integrationCount;

            var resolutionCount = await this._queueService.GetResolutionCount();
            ViewBag.ResolutionCount = resolutionCount;

            var receptionCount = await this._queueService.GetReceptionCount();
            ViewBag.ReceptionCount = receptionCount;

            var contentProcessingCount = await this._queueService.GetContentProcessingCount();
            ViewBag.ContentProcessingCount = contentProcessingCount;

            var schemaValidationCount = await this._queueService.GetSchemaValidationCount();
            ViewBag.SchemaValidationCount = schemaValidationCount;
        }

        [HttpGet]
        public async Task<IActionResult> GetList(string btn)
        {
            List<string> list = new List<string>();

            if (btn == "Notifications")
            {
                list = await this._queueService.GetNotificationList();
            }

            if (btn == "Logging")
            {
                list = await this._queueService.GetLoggingList();
            }

            if (btn == "Attachments")
            {
                list = await this._queueService.GetAttachmentList();
            }

            if (btn == "Integrations")
            {
                list = await this._queueService.GetIntegrationList();
            }

            if (btn == "Resolutions")
            {
                list = await this._queueService.GetResolutionList();
            }

            if (btn == "Receptions")
            {
                list = await this._queueService.GetReceptionList();
            }

            if (btn == "Content Processing")
            {
                list = await this._queueService.GetContentProcessingList();
            }

            if (btn == "Schema Validation")
            {
                list = await this._queueService.GetSchemaValidationList();
            }

            return Json(list);
        }
    }
}
