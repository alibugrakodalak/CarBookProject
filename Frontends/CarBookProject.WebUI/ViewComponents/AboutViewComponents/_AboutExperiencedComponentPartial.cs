using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebUI.ViewComponents.AboutViewComponents
{
	public class _AboutExperiencedComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
