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
	public class GetSocialMediaQueryHandler : IRequestHandler<GetSocialMediaQuery, List<GetSocialMediaQueryResult>>
	{
		private readonly IRepository<SocailMedia> _repository;

		public GetSocialMediaQueryHandler(IRepository<SocailMedia> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetSocialMediaQueryResult>> Handle(GetSocialMediaQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetSocialMediaQueryResult
			{
				Icon			= x.Icon,
				Name			= x.Name,
				SocailMediaId	= x.SocailMediaId,
				Url				= x.Url,
			}).ToList();
		}
	}
}
