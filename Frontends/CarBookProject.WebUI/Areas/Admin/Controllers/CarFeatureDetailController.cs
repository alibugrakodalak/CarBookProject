using CarBookProject.Dto.CarFeatureDtos;
using CarBookProject.Dto.FeatureDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBookProject.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/CarFeatureDetail")]
	public class CarFeatureDetailController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public CarFeatureDetailController (IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		[Route("Index/{id}")]
		[HttpGet]
		public async Task<IActionResult> Index(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7095/api/CarFeatures?id=" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultCarFeatureByCarIdDto>>(jsonData);
				return View(values);
			}
			return View();
		}

		[HttpPost]
		[Route("Index")]
		public async Task<IActionResult> Index(List<ResultCarFeatureByCarIdDto> resultCarFeatureByCarIdDto)
		{
			foreach(var item in resultCarFeatureByCarIdDto)
			{
				if (item.Available)
				{
					var client = _httpClientFactory.CreateClient();
					await client.GetAsync("https://localhost:7095/api/CarFeatures/CarFeatureAvailableChangeToTrue?id=" + item.CarFeatureId);
				}
				else
				{
					var client = _httpClientFactory.CreateClient();
					await client.GetAsync("https://localhost:7095/api/CarFeatures/CarFeatureAvailableChangeToFalse?id=" + item.CarFeatureId);
				}
			}
			return RedirectToAction("Index", "AdminCar");
		}

		[Route("CreateFeatureByCarId")]
		[HttpGet]
		public async Task<IActionResult> CreateFeatureByCarId()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7095/api/Features");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}
