using CarBookProject.Application.Features.Mediator.Commands.ServiceCommands;
using CarBookProject.Application.Interfaces;
using CarBookProject.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Handlers.ServiceHandlers
{
	public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand>
	{
		private readonly IRepository<Service> _repository;

		public UpdateServiceCommandHandler(IRepository<Service> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.ServiceId);
			values.ServiceDescription = request.ServiceDescription;
			values.ServiceTitle = request.ServiceTitle;
			values.ServiceIconUrl = request.ServiceIconUrl;
			await _repository.UpdateAsync(values);
		}
	}
}
