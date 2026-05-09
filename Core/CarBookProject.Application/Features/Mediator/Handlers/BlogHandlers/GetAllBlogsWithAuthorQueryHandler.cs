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
	public class GetAllBlogsWithAuthorQueryHandler : IRequestHandler<GetAllBlogsWithAuthorQuery, List<GetAllBlogsWithAuthorQueryResult>>
	{
		private readonly IBlogRepository _repository;

		public GetAllBlogsWithAuthorQueryHandler(IBlogRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<GetAllBlogsWithAuthorQueryResult>> Handle(GetAllBlogsWithAuthorQuery request, CancellationToken cancellationToken)
		{
			var values = _repository.GetAllBlogWithAuthors();
			return values.Select(x => new GetAllBlogsWithAuthorQueryResult
			{
				AuthorId			= x.AuthorId,
				BlogID				= x.BlogID,
				CategoryId			= x.CategoryId,
				CoverImageUrl		= x.CoverImageUrl,
				BlogTitle			= x.BlogTitle,
				CreatedDate			= x.CreatedDate,
				AuthorName			= x.Author.AuthorName,
				Description			= x.Description,
				AuthorDescription	= x.Author.AuthorDescription,
				AuthorImageUrl		= x.Author.AuthorImageUrl,
			}).ToList();
		}
	}
}
