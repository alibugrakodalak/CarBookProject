using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebUI.ViewComponents.UILayoutViewComponents
{
	public class _UILayoutHeadComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
