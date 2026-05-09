using CarBookProject.Application.Features.CQRS.Results.CarResults;
using CarBookProject.Application.Interfaces;
using CarBookProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.CQRS.Handlers.CarHandlers
{
	public class GetCarQueryHandler
	{
		private readonly IRepository<Car> _repository;

		public GetCarQueryHandler(IRepository<Car> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetCarQueryResult>> Handle()
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x=> new GetCarQueryResult
			{
				CarId				= x.CarId,
				CoverImageUrl		= x.CoverImageUrl,
				Fuel				= x.Fuel,
				Luggage				= x.Luggage,
				MainCoverImageUrl	= x.MainCoverImageUrl,
				Mileage				= x.Mileage,
				Model				= x.Model,
				Seat				= x.Seat,
				Transmission		= x.Transmission,
				BrandId				= x.BrandId,
			}).ToList();
		}
	}
}
