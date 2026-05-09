using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebUI.Controllers
{
	public class SignalrCarController1 : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
