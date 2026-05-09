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
	public class UpdateContactCommandHandler
	{
		private readonly IRepository<Contact> _repository;

		public UpdateContactCommandHandler(IRepository<Contact> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateContactCommand commands)
		{
			var values = await _repository.GetByIdAsync(commands.ContactId);
			values.Email = commands.Email;
			values.SendDate = commands.SendDate;
			values.Subject = commands.Subject;
			values.Message = commands.Message;
			values.Name = commands.Name;
			await _repository.UpdateAsync(values);
		}
	}
}
