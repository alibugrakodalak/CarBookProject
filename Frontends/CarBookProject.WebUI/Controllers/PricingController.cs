using CarBookProject.Dto.BlogDtos;
using CarBookProject.Dto.CarPricingDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookProject.WebUI.Controllers
{
	public class PricingController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public PricingController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}			

		public async Task<IActionResult> Index(int page = 1)
		{
			ViewBag.v1 = "Fiyatlandırma";
			ViewBag.v2 = "Bütçenize En Uygun Seçenekler";

			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7095/api/CarPricings/GetCarPricingWithTimePeriodList");

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultCarPricingListWithModelDto>>(jsonData);

				int pageSize = 10;
				int totalItems = values.Count;
				int totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

				if (page < 1) page = 1;
				if(page > totalPages) page = totalPages;

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
	}
}
