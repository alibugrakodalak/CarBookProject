using CarBookProject.Dto.CategoryDtos;
using CarBookProject.Dto.StatisticDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookProject.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/StatisticCard")]
	public class StatisticCardController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public StatisticCardController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		[Route("Index")]
		public async Task<IActionResult> Index()
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

			#region AuthorCount

			var responseMessage3 = await client.GetAsync("https://localhost:7095/api/Statistics/GetAuthorCount");
			if (responseMessage3.IsSuccessStatusCode)
			{
				int v3 = random.Next(0, 101);
				var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
				var values3 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData3);
				ViewBag.vAuthorCount = values3.auhtorCount;
				ViewBag.v3 = v3;
			}

			#endregion

			#region BlogCount

			var responseMessage4 = await client.GetAsync("https://localhost:7095/api/Statistics/GetBlogCount");
			if (responseMessage4.IsSuccessStatusCode)
			{
				int v4 = random.Next(0, 101);
				var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
				var values4 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData4);
				ViewBag.vBlogCount = values4.blogCount;
				ViewBag.v4 = v4;
			}

			#endregion

			#region LocationCount

			var responseMessage5 = await client.GetAsync("https://localhost:7095/api/Statistics/GetLocationCount");
			if (responseMessage5.IsSuccessStatusCode)
			{
				int v5 = random.Next(0, 101);
				var jsonData5 = await responseMessage5.Content.ReadAsStringAsync();
				var values5 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData5);
				ViewBag.vLocationCount = values5.locationCount;
				ViewBag.v5 = v5;
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

			#region AvgRentPriceForWeekly

			var responseMessage7 = await client.GetAsync("https://localhost:7095/api/Statistics/GetAvgRentPriceForWeekly");
			if (responseMessage7.IsSuccessStatusCode)
			{
				int v7 = random.Next(0, 101);
				var jsonData7 = await responseMessage7.Content.ReadAsStringAsync();
				var values7 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData7);
				ViewBag.vAvgRentPriceForWeekly = values7.avgRentPriceForWeekly.ToString("N0");
				ViewBag.v7 = v7;
			}

			#endregion

			#region AvgRentPriceForMonthly

			var responseMessage8 = await client.GetAsync("https://localhost:7095/api/Statistics/GetAvgRentPriceForMonthly");
			if (responseMessage8.IsSuccessStatusCode)
			{
				int v8 = random.Next(0, 101);
				var jsonData8 = await responseMessage8.Content.ReadAsStringAsync();
				var values8 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData8);
				ViewBag.vAvgRentPriceForMonthly = values8.avgRentPriceForMonthly.ToString("N0");
				ViewBag.v8 = v8;
			}

			#endregion

			#region CarCountByFuelElectric

			var responseMessage9 = await client.GetAsync("https://localhost:7095/api/Statistics/GetCarCountByFuelElectric");
			if (responseMessage9.IsSuccessStatusCode)
			{
				int v9 = random.Next(0, 101);
				var jsonData9 = await responseMessage9.Content.ReadAsStringAsync();
				var values9 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData9);
				ViewBag.vCarCountByFuelElectric = values9.carCountByFuelElectric;
				ViewBag.v9 = v9;
			}

			#endregion

			#region CarCountByFuelGasolineOrDiesel

			var responseMessage10 = await client.GetAsync("https://localhost:7095/api/Statistics/GetCarCountByFuelGasolineOrDiesel");
			if (responseMessage10.IsSuccessStatusCode)
			{
				int v10 = random.Next(0, 101);
				var jsonData10 = await responseMessage10.Content.ReadAsStringAsync();
				var values10 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData10);
				ViewBag.vCarCountByFuelGasolineOrDiesel = values10.carCountByFuelGasolineOrDiesel;
				ViewBag.v10 = v10;
			}

			#endregion

			#region CarCountByMilleageSmallerThen1000

			var responseMessage11 = await client.GetAsync("https://localhost:7095/api/Statistics/GetCarCountByMilleageSmallerThen1000");
			if (responseMessage11.IsSuccessStatusCode)
			{
				int v11 = random.Next(0, 101);
				var jsonData11 = await responseMessage11.Content.ReadAsStringAsync();
				var values11 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData11);
				ViewBag.vCarCountByMilleageSmallerThen1000 = values11.carCountByMilleageSmallerThen1000;
				ViewBag.v11 = v11;
			}

			#endregion

			#region CarCountByTransmissionIsAuto

			var responseMessage12 = await client.GetAsync("https://localhost:7095/api/Statistics/GetCarCountByTransmissionIsAuto");
			if (responseMessage12.IsSuccessStatusCode)
			{
				int v12 = random.Next(0, 101);
				var jsonData12 = await responseMessage12.Content.ReadAsStringAsync();
				var values12 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData12);
				ViewBag.vCarCountByTransmissionIsAuto = values12.carCountByTransmissionIsAuto;
				ViewBag.v12 = v12;
			}

			#endregion

			#region CarNameByMinPrice

			var responseMessage13 = await client.GetAsync("https://localhost:7095/api/Statistics/GetCarNameByMinPrice");
			if (responseMessage13.IsSuccessStatusCode)
			{
				int v13 = random.Next(0, 101);
				var jsonData13 = await responseMessage13.Content.ReadAsStringAsync();
				var values13 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData13);
				ViewBag.vCarNameByMinPrice = values13.carNameByMinPrice;
				ViewBag.v13 = v13;
			}

			#endregion

			#region CarNameByMostPrice

			var responseMessage14 = await client.GetAsync("https://localhost:7095/api/Statistics/GetCarNameByMostPrice");
			if (responseMessage14.IsSuccessStatusCode)
			{
				int v14 = random.Next(0, 101);
				var jsonData14 = await responseMessage14.Content.ReadAsStringAsync();
				var values14 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData14);
				ViewBag.vCarNameByMostPrice = values14.getCarNameByMostPrice;
				ViewBag.v14 = v14;
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

			#region BlogTitleByMaxBlogComment

			var responseMessage16 = await client.GetAsync("https://localhost:7095/api/Statistics/GetBlogTitleByMaxBlogComment");
			if (responseMessage16.IsSuccessStatusCode)
			{
				int v16 = random.Next(0, 101);
				var jsonData16 = await responseMessage16.Content.ReadAsStringAsync();
				var values16 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData16);
				ViewBag.vBlogTitleByMaxBlogComment = values16.blogTitleByMaxBlogComment;
				ViewBag.v16 = v16;
			}

			#endregion

			return View(); 
		}

	}
}

