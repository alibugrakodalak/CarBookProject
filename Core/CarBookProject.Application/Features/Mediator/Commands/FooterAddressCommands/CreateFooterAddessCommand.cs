using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Commands.FooterAddressCommands
{
	public class CreateFooterAddessCommand : IRequest
	{
		public string FooterDescription { get; set; }
		public string FooterLocation { get; set; }
		public string FooterPhoneNumber { get; set; }
		public string FooterMail { get; set; }
	}
}
