using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Dto.AuthorDtos
{
	public class UpdateAuthorDto
	{
		public int AuthorId { get; set; }
		public string AuthorName { get; set; }
		public string AuthorImageUrl { get; set; }
		public string AuthorDescription { get; set; }
	}
}
