using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebUI.ViewComponents.CarDetailComponents
{
	public class _CarDetailTabPaneComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
