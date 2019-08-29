using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NepConfess.Data;
using NepConfess.Models;
using NepConfess.Services;

namespace NepConfess.Controllers
{
    public class HomeController : Controller
    {
    private readonly IMailService _mailservice;
    public HomeController(IMailService mailservice)
    {
        _mailservice = mailservice;
    }
    
        public IActionResult Index()
        {
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
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost("Message")]
        public IActionResult Message(ContactViewModel model)
        {
            if(ModelState.IsValid)
            {
                _mailservice.SendMessage("gaurav.ga6@gmail.com",model.Subject, model.Message,model.Name);
                ViewBag.m = "Message Sent";
                ModelState.Clear();
            }  
            
            return View();
        }
        public IActionResult Message()
        {
        
            return View();
        }
    }
}
