using CarBookProject.Application.Features.CQRS.Results.ContactResults;
using CarBookProject.Application.Interfaces;
using CarBookProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.CQRS.Handlers.ContactHandlers
{
	public class GetContactQueryHandler
	{
		private readonly IRepository<Contact> _repository;

		public GetContactQueryHandler(IRepository<Contact> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetContactQueryResult>> Handle()
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetContactQueryResult
			{
				ContactId = x.ContactId,
				Subject = x.Subject,
				SendDate = x.SendDate,
				Name = x.Name,
				Message = x.Message,
				Email = x.Email
			}).ToList();
		}
	}
}
