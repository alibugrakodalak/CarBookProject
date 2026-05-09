using CarBookProject.Application.Features.Mediator.Commands.SocialMediaCommands;
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
	public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateSocialMediaCommand>
	{
		private readonly IRepository<SocailMedia> _repository;

		public UpdateSocialMediaCommandHandler(IRepository<SocailMedia> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.SocailMediaId);
			values.Url  = request.Url;
			values.Name = request.Name;
			values.Icon = request.Icon;
			await _repository.UpdateAsync(values);
		}
	}
}
