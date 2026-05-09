using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Commands.AuthorCommands
{
	public class CreateAuthorCommand : IRequest
	{
		public string AuthorName { get; set; }
		public string AuthorImageUrl { get; set; }
		public string AuthorDescription { get; set; }
	}
}
