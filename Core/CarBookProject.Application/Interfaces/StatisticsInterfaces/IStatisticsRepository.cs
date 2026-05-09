using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Interfaces.StatisticsInterfaces
{
	public interface IStatisticsRepository
	{
		int GetCarCount();
		int GetLocationCount();
		int GetAuthorCount();
		int GetBlogCount();
		int GetBrandCount();
		decimal GetAvgRentPriceForDaily();
		decimal GetAvgRentPriceForWeekly();
		decimal GetAvgRentPriceForMonthly();
		int GetCarCountByTransmissionIsAuto();
		string BrandNameByMaxCar();
		string BlogTitleByMaxBlogComment();
		int GetCarCountByMilleageSmallerThen1000();
		int GetCarCountByFuelGasolineOrDiesel();
		int GetCarCountByFuelElectric();
		string GetCarNameByMostPrice();
		string GetCarNameByMinPrice();
	}
}
