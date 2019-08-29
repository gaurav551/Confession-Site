using Microsoft.AspNetCore.Mvc;

namespace NepConfess.Controllers
{
    public class DiscussionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}