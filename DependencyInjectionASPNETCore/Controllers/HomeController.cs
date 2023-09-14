using DependencyInjectionASPNETCore.Models;
using DependencyInjectionASPNETCore.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DependencyInjectionASPNETCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmailSenderService _emailSenderService;
        public HomeController(IEmailSenderService emailSenderService)
        {
            _emailSenderService = emailSenderService;
        }

        public IActionResult Index()
        {
            var data = _emailSenderService.SendEmail("Helloworld");
            return View(data);
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