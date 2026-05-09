using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.CQRS.Commands.BannerCommands
{
	public class RemoveBannerCommands
	{
		public int id { get; set; }

		public RemoveBannerCommands(int id)
		{
			this.id = id;
		}
	}
}
