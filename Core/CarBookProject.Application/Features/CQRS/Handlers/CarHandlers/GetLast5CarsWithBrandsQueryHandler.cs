using CarBookProject.Application.Features.CQRS.Results.CarResults;
using CarBookProject.Application.Interfaces;
using CarBookProject.Application.Interfaces.CarInterfaces;
using CarBookProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.CQRS.Handlers.CarHandlers
{
	public class GetLast5CarsWithBrandsQueryHandler
	{
		private readonly ICarRepository _repository;
		public GetLast5CarsWithBrandsQueryHandler(ICarRepository repository)
		{
			_repository = repository;
		}

		public List<GetLast5CarsWithBrandsQueryResult> Handle()
		{
			var values = _repository.GetLast5CarsWithBrands();
			return values.Select(x => new GetLast5CarsWithBrandsQueryResult
			{
				BrandName = x.Brand.BrandName,
				CarId = x.CarId,
				CoverImageUrl = x.CoverImageUrl,
				Fuel = x.Fuel,
				Luggage = x.Luggage,
				MainCoverImageUrl = x.MainCoverImageUrl,
				Mileage = x.Mileage,
				Model = x.Model,
				Seat = x.Seat,
				Transmission = x.Transmission,
				BrandId = x.BrandId,
			}).ToList();
		}
	}
}
