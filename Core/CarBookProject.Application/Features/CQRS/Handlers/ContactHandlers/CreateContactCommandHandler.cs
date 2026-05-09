using CarBookProject.Application.Features.CQRS.Commands.ContactCommands;
using CarBookProject.Application.Interfaces;
using CarBookProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.CQRS.Handlers.ContactHandlers
{
	public class CreateContactCommandHandler
	{
		private readonly IRepository<Contact> _repository;

		public CreateContactCommandHandler(IRepository<Contact> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateContactCommand commands)
		{
			await _repository.CreateAsync(new Contact
			{
				Email = commands.Email,
				Message = commands.Message,
				Name = commands.Name,
				SendDate = commands.SendDate,
				Subject = commands.Subject,
			});
		}
	}
}
