using CarBookProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Interfaces.CarFeatureInterfaces
{
	public interface ICarFeatureRepository
	{
		List<CarFeature> GetCarFeaturesByCarId (int id);
		void ChangeCarFeatureAvailableToFalse(int id);
		void ChangeCarFeatureAvailableToTrue(int id);
		void CreateCarFeatureByCarId(CarFeature carFeature);
	}
}
