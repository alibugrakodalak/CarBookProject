using CarBookProject.Application.Features.Mediator.Commands.ReviewCommands;
using CarBookProject.Application.Interfaces;
using CarBookProject.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Handlers.ReviewHandlers
{
	public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand>
	{
		private readonly IRepository<Review> _repository;

		public CreateReviewCommandHandler(IRepository<Review> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateReviewCommand request, CancellationToken cancellationToken)
		{
			await _repository.CreateAsync(new Review
			{
				CustomerImage	= request.CustomerImage,
				CustomerName	= request.CustomerName,
				Comment			= request.Comment,
				RaitingValue	= request.RaitingValue,
				CarId			= request.CarId,
				ReviewDate		= DateTime.Parse(DateTime.Now.ToShortDateString())
			});
		}
	}
}
