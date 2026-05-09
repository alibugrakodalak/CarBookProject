using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.CQRS.Queries.BannerQueries
{
	public class GetBannerByIdQuery
	{
		public GetBannerByIdQuery(int id)
		{
			this.id = id;
		}

		public int id {  get; set; }
	}
}
