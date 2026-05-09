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
	public class GetCarCountByMilleageSmallerThen1000QueryHandler : IRequestHandler<GetCarCountByMilleageSmallerThen1000Query, GetCarCountByMilleageSmallerThen1000QueryResult>
	{
		private readonly IStatisticsRepository _repository;

		public GetCarCountByMilleageSmallerThen1000QueryHandler(IStatisticsRepository repository)
		{
			_repository = repository;
		}

		public async Task<GetCarCountByMilleageSmallerThen1000QueryResult> Handle(GetCarCountByMilleageSmallerThen1000Query request, CancellationToken cancellationToken)
		{
			var value = _repository.GetCarCountByMilleageSmallerThen1000();
			return new GetCarCountByMilleageSmallerThen1000QueryResult
			{
				CarCountByMilleageSmallerThen1000 = value
			};
		}
	}
}
