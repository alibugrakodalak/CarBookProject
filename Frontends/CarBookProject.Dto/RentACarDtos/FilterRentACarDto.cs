using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Dto.RentACarDtos
{
	public class FilterRentACarDto
	{
		public int CarId { get; set; }

		public string BrandName { get; set; }
		public string Model { get; set; }
		public decimal Amount { get; set; }
		public string CoverImageUrl { get; set; }
	}
}
