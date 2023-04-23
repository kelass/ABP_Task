using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TZ.UI.Models;
using System.Net.NetworkInformation;
using System.Net.Http;
using TZ.Domain.DtoModels;

namespace TZ.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            
        }

        public async Task<IActionResult> IndexAsync()
        {
            //Get global IP address of user
            var request = _httpClientFactory.CreateClient();
            var requestToIpify = await request.GetAsync("https://api.ipify.org");
            var ipAddress = await requestToIpify.Content.ReadAsStringAsync();

            //Create ExperimentDto and serialize to JSON

            var apiClient = _httpClientFactory.CreateClient();
            string url = "https://localhost:7068/api/Experiment";
            var response = await apiClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

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