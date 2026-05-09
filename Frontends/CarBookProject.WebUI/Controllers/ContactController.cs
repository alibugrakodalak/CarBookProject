using CarBookProject.Dto.ContactDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBookProject.WebUI.Controllers
{
	public class ContactController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public ContactController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		[HttpGet]
		public IActionResult Index()
		{
			ViewBag.v1 = "İletişim";
			ViewBag.v2 = "En Uygun Teklifler İçin İletişime Geçin";
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(CreateContactDto createContact)
		{
			var client = _httpClientFactory.CreateClient();
			createContact.SendDate = DateTime.Now;
			var jsonData = JsonConvert.SerializeObject(createContact);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7095/api/Contacts", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Default");
			}
			return View();
		}
	}

}
