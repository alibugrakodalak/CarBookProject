using CarBookProject.Dto.FooterAddressDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBookProject.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/FooterAdress")]
	public class FooterAdressController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public FooterAdressController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		[Route("Index")]
		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7095/api/FooterAddress");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultFooterAddressDto>>(jsonData);
				return View(values);
			}
			return View();
		}

		[HttpGet]
		[Route("CreateFooterAdress")]
		public async Task<IActionResult> CreateFooterAdress()
		{
			return View();
		}

		[HttpPost]
		[Route("CreateFooterAdress")]
		public async Task<IActionResult> CreateFooterAdress(CreateFooterAddressDto createFooterAddressDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createFooterAddressDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7095/api/FooterAddress", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "FooterAdress", new { area = "Admin" });
			}
			return View();
		}

		[Route("RemoveFooterAdress/{id}")]
		public async Task<IActionResult> RemoveFooterAdress(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7095/api/FooterAddress/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "FooterAdress", new { area = "Admin" });
			}
			return View();
		}

		[HttpGet]
		[Route("UpdateFooterAdress/{id}")]
		public async Task<IActionResult> UpdateFooterAdress(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7095/api/FooterAddress/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateFooterAddressDto>(jsonData);
				return View(values);
			}
			return View();
		}

		[HttpPost]
		[Route("UpdateFooterAdress/{id}")]
		public async Task<IActionResult> UpdateFooterAdress(UpdateFooterAddressDto updateFooterAddressDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateFooterAddressDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7095/api/FooterAddress", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "FooterAdress", new { area = "Admin" });
			}
			return View();
		}
	}
}
