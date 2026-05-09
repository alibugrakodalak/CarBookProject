using CarBookProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Results.CarDescriptionResults
{
	public class GetCarDescriptionQueryResult
	{
		public int CarDescriptionId { get; set; }
		public int CarId { get; set; }
		public string CarDescriptionDetails { get; set; }
	}
}
