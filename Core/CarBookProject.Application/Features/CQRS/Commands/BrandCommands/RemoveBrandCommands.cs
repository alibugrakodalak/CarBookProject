using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.CQRS.Commands.BrandCommands
{
	public class RemoveBrandCommands
	{
		public int id { get; set; }

		public RemoveBrandCommands(int id)
		{
			this.id = id;
		}
	}
}
