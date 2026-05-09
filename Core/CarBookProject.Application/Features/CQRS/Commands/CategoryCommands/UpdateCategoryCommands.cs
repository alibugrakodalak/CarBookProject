using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.CQRS.Commands.CategoryCommands
{
	public class UpdateCategoryCommands
	{
		public int CategoryId { get; set; }
		public string CategoryName { get; set; }
	}
}
