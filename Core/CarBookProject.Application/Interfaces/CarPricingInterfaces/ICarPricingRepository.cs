using CarBookProject.Application.ViewModels;
using CarBookProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Interfaces.CarPricingInterfaces
{
	public interface ICarPricingRepository
	{
		List<CarPricing> GetCarPricingWithCars();
		List<CarPricing> GetCarPricingWithCarPeriod();
		List<CarPricingViewModel> GetCarPricingWithCarPeriod1();
	}
}
