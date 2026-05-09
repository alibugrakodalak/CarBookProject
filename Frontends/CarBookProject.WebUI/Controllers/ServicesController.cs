using CarBookProject.Dto.ServicesDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookProject.WebUI.Controllers
{
	public class ServicesController : Controller
	{
		public IActionResult Index()
		{
			ViewBag.v1 = "Hizmetler";
			ViewBag.v2 = "Sizler İçin Sunduğumuz Hizmetlerimiz";
			return View();
		}
	}
}
