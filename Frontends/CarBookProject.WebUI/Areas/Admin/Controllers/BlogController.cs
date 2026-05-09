using CarBookProject.Dto.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBookProject.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/Blog")]
	public class BlogController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public BlogController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		[Route("Index")]
		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responsMessage = await client.GetAsync("https://localhost:7095/api/Blogs/GetAllBlogsWithAuthor");
			if (responsMessage.IsSuccessStatusCode)
			{
				var jsonData = await responsMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultGetAllBlogsWithAuthorDto>>(jsonData);
				return View(values);
			}
			return View();
		}

		[Route("RemoveBlog/{id}")]
		public async Task<IActionResult> RemoveBlog(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync("https://localhost:7095/api/Blogs?id=" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Blog", new { area = "Admin" });
			}
			return View();
		}


	}
}
