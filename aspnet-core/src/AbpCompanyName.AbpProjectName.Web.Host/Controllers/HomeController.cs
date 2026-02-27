using Abp;
using Abp.Notifications;
using Abp.Timing;
using AbpCompanyName.AbpProjectName.Controllers;
using Deploy.LaunchPad.Core.Runtime.Users;
using Deploy.LaunchPad.Util.Extensions;
using Deploy.LaunchPad.Util.Guids;
using Deploy.LaunchPad.Util.Timing;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AbpCompanyName.AbpProjectName.Web.Host.Controllers
{
    public class HomeController : AbpProjectNameControllerBase
    {
        private readonly INotificationPublisher _notificationPublisher;

        public HomeController(INotificationPublisher notificationPublisher)
        {
            _notificationPublisher = notificationPublisher;
        }

        public IActionResult Index()
        {
            return Redirect("/swagger");
        }

        /// <summary>
        /// This is a demo code to demonstrate sending notification to default tenant admin and host admin uers.
        /// Don't use this code in production !!!
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task<ActionResult> TestNotification(string message = "")
        {
            if (message.IsNullOrEmpty())
            {
                message = "This is a test notification, created at " + Clock.Now;
            }
            Guid id1 = GuidConstants.Default;
            Guid id2 = Guid.NewGuid();
            var defaultTenantAdmin = new UserIdentifier(GuidConstants.Default, id2);
            var hostAdmin = new UserIdentifier(null, id1);

            await _notificationPublisher.PublishAsync(
                "App.SimpleMessage",
                new MessageNotificationData(message),
                severity: NotificationSeverity.Info,
                userIds: new[] { defaultTenantAdmin, hostAdmin }
            );

            return Content("Sent notification: " + message);
        }
    }
}
