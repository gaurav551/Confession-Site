using ClientNotifications;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NepConfess.Data;
using static ClientNotifications.Helpers.NotificationHelper;

namespace NepConfess.Controllers
{
    public class NotificationController : Controller
    {
        private readonly IClientNotification _clientNotification;
             public NotificationController(
        
        IClientNotification clientNotification)
        {
           
            _clientNotification = clientNotification;
        
        }
         public void Notify(string message, NotificationType type, string k)
        {
            _clientNotification.AddToastNotification(message,type, null);
        }
        public IActionResult Index()
        {
            return View();
        }

    }
}