using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Dto.CarFeatureDtos
{
	public class ResultCarFeatureByCarIdDto
	{
		public int CarFeatureId { get; set; }
		public string FeatureName { get; set; }
		public int FeatureId { get; set; }
		public bool Available { get; set; }
	}
}
