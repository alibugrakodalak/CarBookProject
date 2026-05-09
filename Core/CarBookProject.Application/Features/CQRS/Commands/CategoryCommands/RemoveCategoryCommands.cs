using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.CQRS.Commands.CategoryCommands
{
	public class RemoveCategoryCommands
	{
		public int id { get; set; }

		public RemoveCategoryCommands(int id)
		{
			this.id = id;
		}
	}
}
