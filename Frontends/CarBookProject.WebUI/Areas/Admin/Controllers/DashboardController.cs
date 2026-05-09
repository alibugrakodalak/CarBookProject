using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/Dashboard")]
	public class DashboardController : Controller
	{
		[Route("Index")]
		public IActionResult Index()
		{
			return View();
		}
	}
}
