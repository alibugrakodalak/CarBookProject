using CarBookProject.Application.Features.CQRS.Commands.CarCommands;
using CarBookProject.Application.Interfaces;
using CarBookProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.CQRS.Handlers.CarHandlers
{
	public class UpdateCarCommandHandler
	{
		private readonly IRepository<Car> _repository;

		public UpdateCarCommandHandler(IRepository<Car> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateCarCommand command) 
		{ 
			var values = await _repository.GetByIdAsync(command.CarId);
			values.BrandId = command.BrandId;
			values.Fuel = command.Fuel;
			values.CoverImageUrl = command.CoverImageUrl;
			values.Luggage = command.Luggage;
			values.MainCoverImageUrl = command.MainCoverImageUrl;
			values.Mileage = command.Mileage;
			values.Model = command.Model;
			values.Seat = command.Seat;
			values.Transmission = command.Transmission;
			await _repository.UpdateAsync(values);	
		}
	}
}
