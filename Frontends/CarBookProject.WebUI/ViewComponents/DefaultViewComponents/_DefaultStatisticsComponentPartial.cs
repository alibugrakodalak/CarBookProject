using CarBookProject.Dto.StatisticDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookProject.WebUI.ViewComponents.DefaultViewComponents
{
	public class _DefaultStatisticsComponentPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _DefaultStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();

			#region CarCount

			var responseMessage = await client.GetAsync("https://localhost:7095/api/Statistics/GetCarCount");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
				ViewBag.vCarCount = values.carCount;
			}

			#endregion

			#region BrandCount

			var responseMessage2 = await client.GetAsync("https://localhost:7095/api/Statistics/GetBrandCount");
			if (responseMessage2.IsSuccessStatusCode)
			{
				var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
				var values2 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData2);
				ViewBag.vBrandCount = values2.brandCount;
			}

			#endregion

			#region CarCountByMilleageSmallerThen1000

			var responseMessage11 = await client.GetAsync("https://localhost:7095/api/Statistics/GetCarCountByMilleageSmallerThen1000");
			if (responseMessage11.IsSuccessStatusCode)
			{
				var jsonData11 = await responseMessage11.Content.ReadAsStringAsync();
				var values11 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData11);
				ViewBag.vCarCountByMilleageSmallerThen1000 = values11.carCountByMilleageSmallerThen1000;
			}

			#endregion

			#region CarCountByTransmissionIsAuto

			var responseMessage12 = await client.GetAsync("https://localhost:7095/api/Statistics/GetCarCountByTransmissionIsAuto");
			if (responseMessage12.IsSuccessStatusCode)
			{
				var jsonData12 = await responseMessage12.Content.ReadAsStringAsync();
				var values12 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData12);
				ViewBag.vCarCountByTransmissionIsAuto = values12.carCountByTransmissionIsAuto;
			}

			#endregion

			return View();
		}
	}
}
