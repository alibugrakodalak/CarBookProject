using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.CQRS.Results.BannerResults
{
	public class GetBannerQueryResult
	{
		public int BannerId { get; set; }
		public string BannerTitle { get; set; }
		public string BannerDescription { get; set; }
		public string BannerVideoDescription { get; set; }
		public string BannerVideoUrl { get; set; }
	}
}
