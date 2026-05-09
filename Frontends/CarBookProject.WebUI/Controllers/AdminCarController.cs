using CarBookProject.Dto.BrandDtos;
using CarBookProject.Dto.CarDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace CarBookProject.WebUI.Controllers
{
	public class AdminCarController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public AdminCarController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7095/api/Cars/GetCarWithBrand");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultCarWithBrandDto>>(jsonData);
				return View(values);
			}

			return View(new List<ResultCarWithBrandDto>());
		}

		[HttpGet]
		public async Task<IActionResult> CreateCar()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7095/api/Brands");
			var jsonData = await responseMessage.Content.ReadAsStringAsync();
			var values = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);
			List<SelectListItem> brandValues = (from x in values
												select new SelectListItem
												{
													Text  = x.BrandName,
													Value = x.BrandId.ToString()
												}).ToList();
			ViewBag.BrandValues = brandValues;
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateCar(CreateCarDto createCarDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createCarDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7095/api/Cars/", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		public async Task<IActionResult> DeleteCar(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7095/api/Cars/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");

			}
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> UpdateCar(int id)
		{
			var client = _httpClientFactory.CreateClient();

			var responseMessage2 = await client.GetAsync("https://localhost:7095/api/Brands");
			var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
			var values2 = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData2);
			List<SelectListItem> brandValues = (from x in values2
												select new SelectListItem
												{
													Text = x.BrandName,
													Value = x.BrandId.ToString()
												}).ToList();
			ViewBag.BrandValues = brandValues;

			var responseMessage = await client.GetAsync($"https://localhost:7095/api/Cars/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateCarDto>(jsonData);
				return View(values);
			}
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> UpdateCar(UpdateCarDto updateCarDto)
		{
			var client = _httpClientFactory.CreateClient();

			var responseMessage2 = await client.GetAsync("https://localhost:7095/api/Brands");
			var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
			var values2 = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData2);
			List<SelectListItem> brandValues = (from x in values2
												select new SelectListItem
												{
													Text = x.BrandName,
													Value = x.BrandId.ToString()
												}).ToList();
			ViewBag.BrandValues = brandValues;


			var jsonData = JsonConvert.SerializeObject(updateCarDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7095/api/Cars", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}			

			return View();
		}
	}
}
