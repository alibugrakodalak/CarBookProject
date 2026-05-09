using CarBookProject.Application.Features.CQRS.Results.AboutResults;
using CarBookProject.Application.Interfaces;
using CarBookProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.CQRS.Handlers.AboutHandlers
{
	public class GetAboutQueryHandler
	{
		private readonly IRepository<About> _repository;

		public GetAboutQueryHandler(IRepository<About> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetAboutQueryResult>> Handle()
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetAboutQueryResult
			{
				AboutId				= x.AboutId,
				AboutDescription	= x.AboutDescription,
				AboutImageUrl		= x.AboutImageUrl,
				AboutTitle			= x.AboutTitle
			}).ToList();
		}
	}
}
