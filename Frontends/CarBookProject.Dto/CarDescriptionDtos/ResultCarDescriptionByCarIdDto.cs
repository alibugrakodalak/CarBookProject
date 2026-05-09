using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Dto.CarDescriptionDtos
{
	public class ResultCarDescriptionByCarIdDto
	{
		public int carDescriptionId { get; set; }
		public int carId { get; set; }
		public string carDescriptionDetails { get; set; }

	}
}
