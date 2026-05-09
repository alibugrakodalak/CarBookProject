using CarBookProject.Dto.CommentDtos;
using CarBookProject.Dto.LocationDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBookProject.WebUI.Controllers
{
	public class BlogController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public BlogController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public IActionResult Index()
		{
			ViewBag.v1 = "Bloglar";
			ViewBag.v2 = "Güncel Yazılarımıza Göz Atın";
			return View();
		}

		public async Task<IActionResult> BlogDetails(int id)
		{
			ViewBag.v1 = "Bloglar";
			ViewBag.v2 = "Blog Detayları ve Yorumları";
			ViewBag.blogId = id;

			var client = _httpClientFactory.CreateClient();
			var responseMessage2 = await client.GetAsync($"https://localhost:7095/api/Comments/CountCommentByBlog?id=" + id);
			var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
			ViewBag.commentCount = jsonData2;

			return View();
		}

		[HttpGet]
		public PartialViewResult AddComment(int id)
		{
			ViewBag.BlogId = id;
			return PartialView();
		}

		[HttpPost]
		public async Task<IActionResult> AddComment(CreateCommentDto createCommentDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createCommentDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7095/api/Comments/CreateCommentWithMediator", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Default");
			}
			return View();
		}
	}
}
