using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TZ.UI.Models;
using System.Net.NetworkInformation;
using System.Net.Http;
using TZ.Domain.DtoModels;
using System.Security.Cryptography;
using TZ.Services;
using System.Net;
using TZ.Domain.DbModels;
using TZ.Domain.ViewModels;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

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

        public async Task<IActionResult> ExperimentOne()
        {
            Guid id = Guid.Parse("A3DC9081-6DC1-4CF1-9E44-CEFE22F97E85");

            //Get global IP address of user
            var request = _httpClientFactory.CreateClient();
            var requestToIpify = await request.GetAsync("https://api.ipify.org");
            var ipAddress = await requestToIpify.Content.ReadAsStringAsync();

            MD5Hash.ConvertToMD5(ref ipAddress);
            
            var apiClient = _httpClientFactory.CreateClient();
            string url = "https://localhost:7068/api/RequestExperiment/?Id="+Guid.NewGuid()+"&DeviceToken="+ipAddress+"&ExperimentId="+id;
            var response = await apiClient.GetAsync(url);
            ViewBag.Value = await response.Content.ReadAsStringAsync();

            return View();
        }

        public async Task<IActionResult> ExperimentTwo()
        {
            Guid id = Guid.Parse("EB63B870-0675-4DBE-89D7-3E64BDB21F31");

            //Get global IP address of user
            var request = _httpClientFactory.CreateClient();
            var requestToIpify = await request.GetAsync("https://api.ipify.org");
            var ipAddress = await requestToIpify.Content.ReadAsStringAsync();

            MD5Hash.ConvertToMD5(ref ipAddress);

            var apiClient = _httpClientFactory.CreateClient();
            string url = "https://localhost:7068/api/RequestExperiment/?Id=" + Guid.NewGuid() + "&DeviceToken=" + ipAddress + "&ExperimentId=" + id;
            var response = await apiClient.GetAsync(url);
            ViewBag.Price = await response.Content.ReadAsStringAsync();

            return View();
        }

        public IActionResult Main()
        {
            return View();
        }
        public IActionResult Statistic()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Statistic(string key)
        {
            var apiClient = _httpClientFactory.CreateClient();
            string url = "https://localhost:7068/api/RequestExperiment/"+key;
            var response = await apiClient.GetAsync(url);
            string experiments = await response.Content.ReadAsStringAsync();
           
            
            //Create view model
            ExperimentsViewModel vm = new ExperimentsViewModel();
            vm.Experiments = JsonConvert.DeserializeObject<List<ExperimentResult>>(experiments);
            ViewBag.Count = vm.Experiments.Count();

            return View(vm.Experiments);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}