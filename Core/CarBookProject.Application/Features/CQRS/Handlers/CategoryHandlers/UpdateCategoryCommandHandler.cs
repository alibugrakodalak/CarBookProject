using CarBookProject.Application.Features.CQRS.Commands.CategoryCommands;
using CarBookProject.Application.Interfaces;
using CarBookProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.CQRS.Handlers.CategoryHandlers
{
	public class UpdateCategoryCommandHandler
	{
		private readonly IRepository<Category> _repository;

		public UpdateCategoryCommandHandler(IRepository<Category> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateCategoryCommands commands)
		{
			var values = await _repository.GetByIdAsync(commands.CategoryId);
			values.CategoryName = commands.CategoryName;
			await _repository.UpdateAsync(values);
		}
	}
}
