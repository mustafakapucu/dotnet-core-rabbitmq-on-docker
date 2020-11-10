using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RabbitMQ.Producer.Models;
using RabbitMQ.Producer.Services;

namespace RabbitMQ.Producer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMqService _mqService;

        public HomeController(ILogger<HomeController> logger, IMqService mqService)
        {
            _logger = logger;
            _mqService = mqService;
        }

        public async Task<IActionResult> Index()
        {

            await _mqService.publishMessage("Merhaba RabbitMq");

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
