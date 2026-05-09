using CarBookProject.Dto.StatisticDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookProject.WebUI.ViewComponents.DashboardComponents
{

	public class _AdminDashboardStatisticsComponentPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _AdminDashboardStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			Random random = new Random();
			var client = _httpClientFactory.CreateClient();


			#region CarCount

			var responseMessage = await client.GetAsync("https://localhost:7095/api/Statistics/GetCarCount");
			if (responseMessage.IsSuccessStatusCode)
			{
				int v1 = random.Next(0, 101);
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
				ViewBag.vCarCount = values.carCount;
				ViewBag.v1 = v1;
			}

			#endregion

			#region BrandCount

			var responseMessage2 = await client.GetAsync("https://localhost:7095/api/Statistics/GetBrandCount");
			if (responseMessage2.IsSuccessStatusCode)
			{
				int v2 = random.Next(0, 101);
				var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
				var values2 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData2);
				ViewBag.vBrandCount = values2.brandCount;
				ViewBag.v2 = v2;
			}

			#endregion

			#region AvgRentPriceForDaily

			var responseMessage6 = await client.GetAsync("https://localhost:7095/api/Statistics/GetAvgRentPriceForDaily");
			if (responseMessage6.IsSuccessStatusCode)
			{
				int v6 = random.Next(0, 101);
				var jsonData6 = await responseMessage6.Content.ReadAsStringAsync();
				var values6 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData6);
				ViewBag.vAvgRentPriceForDaily = values6.avgRentPriceForDaily.ToString("N0");
				ViewBag.v6 = v6;
			}

			#endregion

			#region BrandNameByMaxCar

			var responseMessage15 = await client.GetAsync("https://localhost:7095/api/Statistics/GetBrandNameByMaxCar");
			if (responseMessage15.IsSuccessStatusCode)
			{
				int v15 = random.Next(0, 101);
				var jsonData15 = await responseMessage15.Content.ReadAsStringAsync();
				var values15 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData15);
				ViewBag.vBrandNameByMaxCar = values15.brandNameByMaxCar;
				ViewBag.v15 = v15;
			}

			#endregion

			return View();
		}
	}
}
