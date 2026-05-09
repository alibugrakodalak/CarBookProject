using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebUI.ViewComponents.UILayoutViewComponents
{
	public class _UILayoutPagesComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
