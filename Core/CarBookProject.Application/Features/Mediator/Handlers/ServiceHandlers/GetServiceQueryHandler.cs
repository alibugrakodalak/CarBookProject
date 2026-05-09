using CarBookProject.Application.Features.Mediator.Queries.ServiceQueries;
using CarBookProject.Application.Features.Mediator.Results.ServiceResults;
using CarBookProject.Application.Interfaces;
using CarBookProject.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Handlers.ServiceHandlers
{
	public class GetServiceQueryHandler : IRequestHandler<GetServiceQuery, List<GetServiceQueryResult>>
	{
		private readonly IRepository<Service> _repository;

		public GetServiceQueryHandler(IRepository<Service> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetServiceQueryResult>> Handle(GetServiceQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetServiceQueryResult
			{
				ServiceId = x.ServiceId,
				ServiceDescription = x.ServiceDescription,
				ServiceIconUrl = x.ServiceIconUrl,
				ServiceTitle = x.ServiceTitle,
			}).ToList();
		}
	}
}
