using CarBookProject.Dto.BrandDtos;
using CarBookProject.Dto.RentACarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBookProject.WebUI.Controllers
{
	public class RentACarController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public RentACarController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index(int id)
		{
			var locationID = TempData["locationID"];

			//filterRentACarDto.locationId = int.Parse(locationID.ToString());
			//filterRentACarDto.available = true;
			id = int.Parse(locationID.ToString());

			ViewBag.locationID = locationID;

			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7095/api/RentACars?locationID={id}&available=true");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<FilterRentACarDto>>(jsonData);
				return View(values);
			}

			return View();
		}
	}
}
