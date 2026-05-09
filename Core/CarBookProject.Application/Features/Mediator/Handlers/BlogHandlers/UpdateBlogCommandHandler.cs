using CarBookProject.Application.Features.Mediator.Commands.BlogCommands;
using CarBookProject.Application.Interfaces;
using CarBookProject.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Handlers.BlogHandlers
{
	public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand>
	{
		private readonly IRepository<Blog> _repository;

		public UpdateBlogCommandHandler(IRepository<Blog> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.BlogID);
			values.AuthorId = request.AuthorId;
			values.CreatedDate = request.CreatedDate;
			values.CategoryId = request.CategoryId;
			values.CoverImageUrl = request.CoverImageUrl;
			values.BlogTitle = request.BlogTitle;
			await _repository.UpdateAsync(values);
		}
	}
}
