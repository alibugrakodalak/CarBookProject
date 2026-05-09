using CarBookProject.Dto.LocationDtos;
using CarBookProject.Dto.ReservationDtos;
using CarBookProject.Dto.TestimonialDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace CarBookProject.WebUI.Controllers
{
	public class ReservationController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public ReservationController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		[HttpGet]
		public async Task<IActionResult> Index(int id)
		{
			ViewBag.v1 = "Rezervasyon";
			ViewBag.v2 = "Aracınızı Hemen Rezerve Edin";
			ViewBag.v3 = id;

			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7095/api/Locations");
			var jsonData = await responseMessage.Content.ReadAsStringAsync();
			var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);
			List<SelectListItem> values2 = (from x in values
											select new SelectListItem
											{
												Text = x.LocationName,
												Value = x.LocationId.ToString()
											}).ToList();		

			ViewBag.v = values2;

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(CreateReservationDto createReservationDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createReservationDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7095/api/Reservation", stringContent);

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Default");
			}

			var responseMessage2 = await client.GetAsync("https://localhost:7095/api/Locations");
			var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
			var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData2);

			ViewBag.v = values.Select(x => new SelectListItem
			{
				Text = x.LocationName,
				Value = x.LocationId.ToString()
			}).ToList();

			return View(); 
		}
	}
}
