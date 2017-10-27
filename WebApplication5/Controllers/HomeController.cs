using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.Models;
using Microsoft.Extensions.Configuration;

namespace WebApplication5.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // Place to store the Config object and use in this controller
        private readonly IConfiguration Config;

        // Constructor that that takes IConfiguration is called on instantiation thanks to Dependency injection
        public ValuesController(IConfiguration config)
        {
            Config = config;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            // Use the Config object set in the constructor
            var x = Config["mykey"];
            return new string[] { "value1", "value2" };
        }
    }

}

