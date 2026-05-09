using CarBookProject.Application.Features.Mediator.Commands.FooterAddressCommands;
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
	public class CreateFooterAddressCommandHandler : IRequestHandler<CreateFooterAddessCommand>
	{
		private readonly IRepository<FooterAddress> _repository;

		public CreateFooterAddressCommandHandler(IRepository<FooterAddress> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateFooterAddessCommand request, CancellationToken cancellationToken)
		{
			await _repository.CreateAsync(new FooterAddress
			{
				FooterDescription	= request.FooterDescription,
				FooterLocation		= request.FooterLocation,
				FooterMail			= request.FooterMail,
				FooterPhoneNumber	= request.FooterPhoneNumber,
			});
		}
	}
}
