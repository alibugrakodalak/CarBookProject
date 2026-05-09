using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Results.ServiceResults
{
	public class GetServiceQueryResult
	{
		public int ServiceId { get; set; }
		public string ServiceTitle { get; set; }
		public string ServiceDescription { get; set; }
		public string ServiceIconUrl { get; set; }
	}
}
