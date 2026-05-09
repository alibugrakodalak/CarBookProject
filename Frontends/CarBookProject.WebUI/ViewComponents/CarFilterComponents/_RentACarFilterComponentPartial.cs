using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebUI.ViewComponents.CarFilterComponents
{
	public class _RentACarFilterComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke(string v)
		{
			TempData["value"] = v;
			return View();
		}
	}
}
