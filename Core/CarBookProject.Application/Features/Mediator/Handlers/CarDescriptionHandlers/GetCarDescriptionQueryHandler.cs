using CarBookProject.Application.Features.Mediator.Queries.CarDescriptionQueries;
using CarBookProject.Application.Features.Mediator.Results.CarDescriptionResults;
using CarBookProject.Application.Interfaces;
using CarBookProject.Application.Interfaces.CarDescriptonInterfaces;
using CarBookProject.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Handlers.CarDescriptionHandlers
{
	public class GetCarDescriptionQueryHandler : IRequestHandler<GetCarDescriptionQuery, GetCarDescriptionQueryResult>
	{
		private readonly ICarDescriptionRepository _repository;

		public GetCarDescriptionQueryHandler(ICarDescriptionRepository repository)
		{
			_repository = repository;
		}

		public async Task<GetCarDescriptionQueryResult> Handle(GetCarDescriptionQuery request, CancellationToken cancellationToken)
		{
			var values = _repository.GetCarDescription(request.Id);
			return new GetCarDescriptionQueryResult
			{
				CarDescriptionId		= values.CarDescriptionId,
				CarDescriptionDetails	= values.CarDescriptionDetails,
				CarId					= values.CarId,
			};
		}
	}
}
