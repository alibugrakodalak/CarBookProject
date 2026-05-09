using CarBookProject.Dto.AuthorDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBookProject.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/Author")]
	public class AuthorController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public AuthorController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		[Route("Index")]
		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7095/api/Authors");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultAuthorDto>>(jsonData);
				return View(values);
			}
			return View();
		}

		[Route("CreateAuthor")]
		[HttpGet]
		public async Task<IActionResult> CreateAuthor()
		{
			return View();
		}

		[Route("CreateAuthor")]
		[HttpPost]
		public async Task<IActionResult> CreateAuthor(CreateAuthorDto createAuthorDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createAuthorDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7095/api/Authors", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Author", new { area = "Admin" });
			}
			return View();
		}

		[Route("RemoveAuthor/{id}")]
		public async Task<IActionResult> RemoveAuthor(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7095/api/Authors/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Author", new { area = "Admin" });
			}
			return View();
		}

		[Route("UpdateAuthor/{id}")]
		[HttpGet]
		public async Task<IActionResult> UpdateAuthor(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7095/api/Authors/{id}");
			if (responseMessage.IsSuccessStatusCode) 
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateAuthorDto>(jsonData);
				return View(values);
			}
			return View();
		}

		[Route("UpdateAuthor/{id}")]
		[HttpPost]
		public async Task<IActionResult> UpdateAuthor(UpdateAuthorDto updateAuthorDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateAuthorDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7095/api/Authors", stringContent);
			if (responseMessage.IsSuccessStatusCode) 
			{ 
				return RedirectToAction("Index", "Author", new { area = "Admin" });
			}
			return View();
		}

	}
}
