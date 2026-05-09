using CarBookProject.Application.Features.Mediator.Results.TagCloudResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Queries.TagCloudQuries
{
	public class GetTagCloudByBlogIdQuery : IRequest<List<GetTagCloudByBlogIdQueryResult>>
	{
		public int Id { get; set; }

		public GetTagCloudByBlogIdQuery(int id)
		{
			Id = id;
		}
	}
}
