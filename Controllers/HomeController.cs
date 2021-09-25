using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using POCWeb.Models;

namespace POCWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;

            _logger = logger;
        }


        // [3insys]
        // these 2 act as a backend which is a caller to our API
        // their HTTP client is pre configured with Polly library to 
        // support retries and can be extended to cache rerouting after n tries


        [HttpGet]
        public async Task<IActionResult> CallError()
        {
            // Get an HttpClient pre-configured StartUp
            // this client includes the Polly config assigned by name "selftest"
            var client = _httpClientFactory.CreateClient("selftest");

            // call the intentional Error function, will ALWAYS generate an error
            // (it's a forced divide by 0)


            string result;


            try
            {
                // this causes failure after 3 tries, based on config in stratup
                result = await client.GetStringAsync("/api/command/doerror");
            }
            catch (Exception)
            {
                // number 3 could be based on retrieving Polly configuration
                _logger.LogCritical(">>> API call failed after 3 tries");
                throw;
            }
                


            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> CallNoError()
        {
            // Get an HttpClient pre-configured StartUp
            // this client includes the Polly config assigned by name "selftest"
            var client = _httpClientFactory.CreateClient("selftest");

            // call the valid function, will never generate an error 
            return Ok(await client.GetStringAsync("/api/command/doValid"));
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
