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
	public class GetCarNameByMinPriceQueryHandler : IRequestHandler<GetCarNameByMinPriceQuery, GetCarNameByMinPriceQueryResult>
	{
		private readonly IStatisticsRepository _repository;

		public GetCarNameByMinPriceQueryHandler(IStatisticsRepository repository)
		{
			_repository = repository;
		}

		public async Task<GetCarNameByMinPriceQueryResult> Handle(GetCarNameByMinPriceQuery request, CancellationToken cancellationToken)
		{
			var values = _repository.GetCarNameByMinPrice();
			return new GetCarNameByMinPriceQueryResult
			{
				CarNameByMinPrice = values
			};
		}
	}
}
