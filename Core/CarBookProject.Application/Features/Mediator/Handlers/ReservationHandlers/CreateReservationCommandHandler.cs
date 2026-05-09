using CarBookProject.Application.Features.Mediator.Commands.ReservationCommands;
using CarBookProject.Application.Interfaces;
using CarBookProject.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Handlers.ReservationHandlers
{
	public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand>
	{
		private readonly IRepository<Reservation> _repository;

		public CreateReservationCommandHandler(IRepository<Reservation> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateReservationCommand request, CancellationToken cancellationToken)
		{
			await _repository.CreateAsync(new Reservation
			{
				Age					= request.Age,
				Description			= request.Description,
				DriverLicenceYear	= request.DriverLicenceYear,
				CarId				= request.CarId,
				Email				= request.Email,
				Name				= request.Name,
				PhoneNumber			= request.PhoneNumber,
				DropOffLocationID	= request.DropOffLocationID,
				PickUpLocationID	= request.PickUpLocationID,
				Surname				= request.Surname,
				Status				= "Rezervasyon Alındı..!!",
			});
		}
	}
}
