using CarBookProject.Dto.CarDtos;
using CarBookProject.Dto.CarPricingDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookProject.WebUI.Controllers
{
	public class CarController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public CarController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index(int page = 1)
		{
			ViewBag.v1 = "Araçlar";
			ViewBag.v2 = "Her İhtiyaca Uygun Araç Koleksiyonumuz";

			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7095/api/CarPricings");

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultCarPricingWithCarDto>>(jsonData);

				int pageSize = 9;
				int totalItems = values.Count;
				int totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

				if (page < 1) page = 1;
				if (page > totalPages) page = totalPages;

				var pagedValues = values
					.Skip((page - 1) * pageSize)
					.Take(pageSize)
					.ToList();

				ViewBag.CurrentPage = page;
				ViewBag.TotalPages = totalPages;

				return View(pagedValues);
			}
			return View();
		}

		public async Task<IActionResult> CarDetail(int id)
		{
			ViewBag.v1 = "Araçlar";
			ViewBag.v2 = "Araç Detayları";
			ViewBag.carId = id;
			return View();
		}
	}
}
