using CarBookProject.Application.Features.Mediator.Queries.FooterAddressQueries;
using CarBookProject.Application.Features.Mediator.Results.FooterAddressResults;
using CarBookProject.Application.Interfaces;
using CarBookProject.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
	public class GetFooterAddressQueryHandler : IRequestHandler<GetLocationAddressQuery, List<GetFooterAddressQueryResult>>
	{
		private readonly IRepository<FooterAddress> _repository;

		public GetFooterAddressQueryHandler(IRepository<FooterAddress> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetFooterAddressQueryResult>> Handle(GetLocationAddressQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetFooterAddressQueryResult
			{
				FooterAddressId		= x.FooterAddressId,
				FooterDescription	= x.FooterDescription,
				FooterLocation		= x.FooterLocation,
				FooterMail			= x.FooterMail,
				FooterPhoneNumber	= x.FooterPhoneNumber,
			}).ToList();
		}
	}
}
