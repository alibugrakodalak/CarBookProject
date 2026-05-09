using CarBookProject.Application.Features.Mediator.Queries.SocialMediaQueries;
using CarBookProject.Application.Features.Mediator.Results.SocialMediaResults;
using CarBookProject.Application.Interfaces;
using CarBookProject.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Handlers.SocialMediaHandlers
{
	public class GetSocialMediaByIdQueryHandler : IRequestHandler<GetSocialMediaByIdQuery, GetSocialMediaByIdQueryResult>
	{
		private readonly IRepository<SocailMedia> _repository;

		public GetSocialMediaByIdQueryHandler(IRepository<SocailMedia> repository)
		{
			_repository = repository;
		}

		public async Task<GetSocialMediaByIdQueryResult> Handle(GetSocialMediaByIdQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.Id);
			return new GetSocialMediaByIdQueryResult
			{
				Icon			= values.Icon,
				Name			= values.Name,
				SocailMediaId	= values.SocailMediaId,
				Url				= values.Url,
			};
		}
	}
}
