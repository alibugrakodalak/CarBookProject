using CarBookProject.Application.Features.Mediator.Queries.TagCloudQuries;
using CarBookProject.Application.Features.Mediator.Results.TagCloudResults;
using CarBookProject.Application.Interfaces.TagCloudInterfaces;
using CarBookProject.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Handlers.TagCloudHandlers
{
	public class GetTagCloudByBlogIdQueryHandler : IRequestHandler<GetTagCloudByBlogIdQuery, List<GetTagCloudByBlogIdQueryResult>>
	{
		private readonly ITagCloudRepository _repository;

		public GetTagCloudByBlogIdQueryHandler(ITagCloudRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<GetTagCloudByBlogIdQueryResult>> Handle(GetTagCloudByBlogIdQuery request, CancellationToken cancellationToken)
		{
			var values = _repository.GetTagCloudsByBlogId(request.Id);
			return values.Select(x => new GetTagCloudByBlogIdQueryResult
			{
				Title = x.Title,
				BlogID = x.BlogID,
				TagCloudID = x.TagCloudID,
			}).ToList();
		}
	}
}
