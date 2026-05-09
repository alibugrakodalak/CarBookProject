using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Dto.CarPricingDtos
{
	public class ResultCarPricingListWithModelDto
	{
		public string model { get; set; }
		public decimal dailyAmount { get; set; }
		public decimal monthlyAmount { get; set; }
		public decimal yearlyAmount { get; set; }
		public string CoverImageUrl { get; set; }
		public string BrandName { get; set; }
	}
}
