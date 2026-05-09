using CarBookProject.Application.Interfaces.StatisticsInterfaces;
using CarBookProject.Domain.Entities;
using CarBookProject.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CarBookProject.Persistence.Repositories.StatisticsRepositories
{
	public class StatisticsRepository : IStatisticsRepository
	{
		private readonly CarBookContext _context;

		public StatisticsRepository(CarBookContext context)
		{
			_context = context;
		}

		public string BlogTitleByMaxBlogComment()
		{
			var values = _context.Comments
								.GroupBy(x => x.BlogId)
								.Select(y => new
								{
									BlogId = y.Key,
									Count = y.Count()
								})
								.OrderByDescending(z => z.Count)
								.Take(1)
								.FirstOrDefault();

			string blogTitle = _context.Blogs
								.Where(x => x.BlogID == values.BlogId)
								.Select(y => y.BlogTitle)
								.FirstOrDefault();

			return blogTitle;
		}

		public string BrandNameByMaxCar()
		{
			var values = _context.Cars
								.GroupBy(x => x.BrandId)
								.Select(y => new
								{
									BrandId = y.Key,
									Count = y.Key
								})
								.OrderByDescending(z => z.Count)
								.Take(1)
								.FirstOrDefault();

			string brandName = _context.Brands
								.Where(x => x.BrandId == values.BrandId)
								.Select(y => y.BrandName)
								.FirstOrDefault();

			return brandName;
		}

		public int GetAuthorCount()
		{
			var value = _context.Authors.Count();
			return value;
		}

		public decimal GetAvgRentPriceForDaily()
		{
			//Select Avg(Amount) FROM CarPricings WHERE PricingId = (Select PricingId FROM Pricings Where Name = 'Günlük')
			int id = _context.Pricings.Where(y => y.Name == "Günlük").Select(z => z.PricingId).FirstOrDefault();
			var values = _context.CarPricings.Where(x => x.PricingId == id).Average(w => w.Amount);
			return values;
		}

		public decimal GetAvgRentPriceForMonthly()
		{
			int id = _context.Pricings.Where(y=>y.Name == "Aylık").Select(z=>z.PricingId).FirstOrDefault();
			var values = _context.CarPricings.Where(x => x.PricingId == id).Average(w => w.Amount);
			return values;
		}

		public decimal GetAvgRentPriceForWeekly()
		{
			int id = _context.Pricings.Where(z=>z.Name == "Haftalık").Select(y=>y.PricingId).FirstOrDefault();
			var values = _context.CarPricings.Where(x => x.PricingId == id).Average(w => w.Amount);
			return values;
		}

		public int GetBlogCount()
		{
			var value = _context.Blogs.Count();
			return value;
		}

		public int GetBrandCount()
		{
			var value = _context.Brands.Count();
			return value;
		}

		public int GetCarCount()
		{
			var value = _context.Cars.Count();
			return value;
		}

		public int GetCarCountByFuelElectric()
		{
			var value = _context.Cars.Where(x => x.Fuel == "Elektrik").Count();
			return value;
		}

		public int GetCarCountByFuelGasolineOrDiesel()
		{
			var values = _context.Cars.Where(x => x.Fuel == "Benzin" || x.Fuel == "Dizel").Count();
			return values;
		}

		public int GetCarCountByMilleageSmallerThen1000()
		{
			var values = _context.Cars.Where(x => x.Mileage <= 1000).Count();
			return values;
		}

		public int GetCarCountByTransmissionIsAuto()
		{
			var value = _context.Cars.Where(x => x.Transmission == "Otomatik").Count();
			return value;
		}

		public string GetCarNameByMinPrice()
		{
			int pricingId = _context.Pricings
									.Where(x => x.Name == "Günlük")
									.Select(y => y.PricingId)
									.FirstOrDefault();

			decimal amount = _context.CarPricings
									.Where(w => w.PricingId == pricingId)
									.Min(z => z.Amount);

			int carId = _context.CarPricings
									.Where(x => x.Amount == amount)
									.Select(y => y.CarId)
									.FirstOrDefault();

			string brandModel = _context.Cars
									.Where(x => x.CarId == carId)
									.Include(y => y.Brand)
									.Select(z => z.Brand.BrandName + " " + z.Model)
									.FirstOrDefault();

			return brandModel;
		}

		public string GetCarNameByMostPrice()
		{
			int pricingId = _context.Pricings
									.Where(x => x.Name == "Günlük")
									.Select(y => y.PricingId)
									.FirstOrDefault();

			decimal amount = _context.CarPricings
									.Where(w => w.PricingId == pricingId)
									.Max(z => z.Amount);

			int carId = _context.CarPricings
									.Where(x => x.Amount == amount)
									.Select(y => y.CarId)
									.FirstOrDefault();

			string brandModel = _context.Cars
									.Where(x => x.CarId == carId)
									.Include(y => y.Brand)
									.Select(z => z.Brand.BrandName + " " + z.Model)
									.FirstOrDefault();

			return brandModel;
		}

		public int GetLocationCount()
		{
			var value = _context.Locations.Count();
			return value;
		}
	}
}