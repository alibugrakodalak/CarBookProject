using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebUI.ViewComponents.UILayoutViewComponents
{
	public class _UILayoutScriptsComponenPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
