using CarBookProject.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Commands.ReservationCommands
{
	public class CreateReservationCommand : IRequest
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public int? PickUpLocationID { get; set; }
		public int? DropOffLocationID { get; set; }
		public int CarId { get; set; }
		public int Age { get; set; }
		public int DriverLicenceYear { get; set; }
		public string Description { get; set; }
	}
}
