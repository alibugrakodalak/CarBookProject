using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Dto.ServicesDtos
{
	public class UpdateServicesDto
	{
		public int serviceId { get; set; }
		public string serviceTitle { get; set; }
		public string serviceDescription { get; set; }
		public string serviceIconUrl { get; set; }
	}
}
