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
	public class GetCarCountByFuelElectricQueryHandler : IRequestHandler<GetCarCountByFuelElectricQuery, GetCarCountByFuelElectricQueryResult>
	{
		private readonly IStatisticsRepository _repository;

		public GetCarCountByFuelElectricQueryHandler(IStatisticsRepository repository)
		{
			_repository = repository;
		}

		public async Task<GetCarCountByFuelElectricQueryResult> Handle(GetCarCountByFuelElectricQuery request, CancellationToken cancellationToken)
		{
			var values = _repository.GetCarCountByFuelElectric();
			return new GetCarCountByFuelElectricQueryResult
			{
				CarCountByFuelElectric = values
			};
		}
	}
}
