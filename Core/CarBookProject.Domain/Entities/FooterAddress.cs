using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Domain.Entities
{
	public class FooterAddress
	{
		public int FooterAddressId { get; set; }
		public string FooterDescription { get; set; }
		public string FooterLocation { get; set; }
		public string FooterPhoneNumber { get; set; }
		public string FooterMail { get; set; }
	}
}
