using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using JoelMovies.Models;

namespace JoelMovies.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet] 
        public IActionResult EnterMovies()
        {
            return View();
        }

        [HttpPost] 
        public IActionResult EnterMovies(ApplicationResponse appResponse)
        {
            if (ModelState.IsValid)
            {
                TempStorage.AddApplication(appResponse);
                return View("Confirmation", appResponse);
            }
            else
            {
                return View();
            }

        }

        public IActionResult MovieList()
        {
            return View(TempStorage.Applications);
        }

        public IActionResult MyPodcasts()
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
    }
}
