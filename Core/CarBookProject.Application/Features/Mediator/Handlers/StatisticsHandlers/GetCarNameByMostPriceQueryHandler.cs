using CarBookProject.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBookProject.Application.Features.Mediator.Results.StatisticsResults;
using CarBookProject.Application.Interfaces.StatisticsInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Handlers.StatisticsHandlers
{
	public class GetCarNameByMostPriceQueryHandler : IRequestHandler<GetCarNameByMostPriceQuery, GetCarNameByMostPriceQueryResult>
	{
		private readonly IStatisticsRepository _repository;

		public GetCarNameByMostPriceQueryHandler(IStatisticsRepository repository)
		{
			_repository = repository;
		}

		public async Task<GetCarNameByMostPriceQueryResult> Handle(GetCarNameByMostPriceQuery request, CancellationToken cancellationToken)
		{
			var value = _repository.GetCarNameByMostPrice();
			return new GetCarNameByMostPriceQueryResult
			{
				GetCarNameByMostPrice = value
			};
		}
	}
}
