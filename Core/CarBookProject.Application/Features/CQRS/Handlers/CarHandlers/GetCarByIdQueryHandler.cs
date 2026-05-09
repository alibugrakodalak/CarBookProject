using CarBookProject.Application.Features.CQRS.Queries.CarQueries;
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
	public class GetCarByIdQueryHandler
	{
		private readonly IRepository<Car> _repository;

		public GetCarByIdQueryHandler(IRepository<Car> repository)
		{
			_repository = repository;
		}

		public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery query)
		{
			var values = await _repository.GetByIdAsync(query.Id);
			return new GetCarByIdQueryResult
			{
				CoverImageUrl		= values.CoverImageUrl,
				Fuel				= values.Fuel,
				Luggage				= values.Luggage,
				MainCoverImageUrl	= values.MainCoverImageUrl,
				Mileage				= values.Mileage,
				Model				= values.Model,
				Seat				= values.Seat,
				Transmission		= values.Transmission,
				BrandId				= values.BrandId,
			};
		}
	}
}
