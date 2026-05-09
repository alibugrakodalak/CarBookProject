using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebUI.ViewComponents.UILayoutViewComponents
{
	public class _UILayoutNavbarComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
