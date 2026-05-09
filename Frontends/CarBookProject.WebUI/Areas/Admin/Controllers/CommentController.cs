using CarBookProject.Dto.CommentDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookProject.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/Comment")]
	public class CommentController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public CommentController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		[Route("Index/{id}")]
		public async Task<IActionResult> Index(int id)
		{
			ViewBag.v = id;
			var client = _httpClientFactory.CreateClient();
			var responsMessage = await client.GetAsync("https://localhost:7095/api/Comments/CommentsListByBlogId?id=" + id);
			if (responsMessage.IsSuccessStatusCode)
			{
				var jsonData = await responsMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}
