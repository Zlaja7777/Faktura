using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Enterwell.Models;
using Enterwell.Data;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Enterwell.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
       
        private readonly UserManager<IdentityUser> userManager;
        public HomeController(ILogger<HomeController> logger, UserManager<IdentityUser> _userManager)
        {
            _logger = logger;
            userManager = _userManager;
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
    }
}
