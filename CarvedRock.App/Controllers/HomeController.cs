using CarvedRock.App.Models;
using CarvedRock.App.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace CarvedRock.App.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
        private readonly ICarvedRockApiClient apiClient;

        public HomeController(ILogger<HomeController> logger, ICarvedRockApiClient apiClient)
		{
			_logger = logger;
            this.apiClient = apiClient;
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

		public async Task<IActionResult> CallAPI()
		{
			var products = new List<Product>() { new Product() { Id = 1, Name = "Test 1" } };
			var client = new HttpClient();
			products = await apiClient.GetProducts();
			return View("Index", products);
		}
	}
}
