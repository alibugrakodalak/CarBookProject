using CarBookProject.Application.Interfaces.CarPricingInterfaces;
using CarBookProject.Application.ViewModels;
using CarBookProject.Domain.Entities;
using CarBookProject.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Persistence.Repositories.CarPricingRepositories
{
	public class CarPricingRepository : ICarPricingRepository
	{
		private readonly CarBookContext _context;

		public CarPricingRepository(CarBookContext context)
		{
			_context = context;
		}

		public List<CarPricing> GetCarPricingWithCarPeriod()
		{			
			throw new NotImplementedException();
		}

		public List<CarPricingViewModel> GetCarPricingWithCarPeriod1()
		{
			List<CarPricingViewModel> values = new List<CarPricingViewModel>();
			using (var command = _context.Database.GetDbConnection().CreateCommand())
			{
				command.CommandText = "Select * From (Select Model, BrandName, CoverImageUrl, PricingId, Amount From CarPricings Inner Join Cars On Cars.CarId = CarPricings.CarId Inner Join Brands On Brands.BrandId = Cars.BrandId) As SourceTable Pivot (Sum(Amount) For PricingId In ([2], [3], [4])) as PivotTable;";
				command.CommandType = System.Data.CommandType.Text;
				_context.Database.OpenConnection();
				using (var reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						CarPricingViewModel carPricingViewModel = new CarPricingViewModel()
						{
							BrandName = reader["BrandName"].ToString(),
							Model = reader["Model"].ToString(),
							CoverImageUrl = reader["CoverImageUrl"].ToString(),
							Amounts = new List<decimal>
							{
								Convert.ToDecimal(reader["2"]),
								Convert.ToDecimal(reader["3"]),
								Convert.ToDecimal(reader["4"])
							}
						};
						values.Add(carPricingViewModel);
					}
				}
			}
			_context.Database.CloseConnection();
			return values;
		}

		public List<CarPricing> GetCarPricingWithCars()
		{
			var values = _context.CarPricings
				.Include(x => x.Car)
				.ThenInclude(y => y.Brand)
				.Include(x => x.Pricing)
				.Where(z => z.PricingId == 2)
				.ToList();

			return values;
		}
	}
}
