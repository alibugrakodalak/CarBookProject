using CarBookProject.Application.Features.Mediator.Queries.BlogQueries;
using CarBookProject.Application.Features.Mediator.Results.BlogResults;
using CarBookProject.Application.Interfaces.BlogInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Handlers.BlogHandlers
{
	public class GetBlogByAuthorIdQueryHandler : IRequestHandler<GetBlogByAuthorIdQuery, List<GetBlogByAuthorIdQueryResult>>
	{
		private readonly IBlogRepository _repository;

		public GetBlogByAuthorIdQueryHandler(IBlogRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<GetBlogByAuthorIdQueryResult>> Handle(GetBlogByAuthorIdQuery request, CancellationToken cancellationToken)
		{
			var values = _repository.GetBlogByAuthorId(request.Id);
			return values.Select(x => new GetBlogByAuthorIdQueryResult
			{
				AuthorId			= x.AuthorId,
				BlogID				= x.BlogID,
				AuthorName			= x.Author.AuthorName,
				AuthorDescription	= x.Author.AuthorDescription,
				AuthorImageUrl		= x.Author.AuthorImageUrl,
			}).ToList();
		}
	}
}
