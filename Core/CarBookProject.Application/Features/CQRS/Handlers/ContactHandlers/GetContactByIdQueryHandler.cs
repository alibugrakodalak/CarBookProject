using CarBookProject.Application.Features.CQRS.Queries.ContactQueries;
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
	public class GetContactByIdQueryHandler
	{
		private readonly IRepository<Contact> _repository;

		public GetContactByIdQueryHandler(IRepository<Contact> repository)
		{
			_repository = repository;
		}

		public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery query)
		{
			var values = await _repository.GetByIdAsync(query.Id);
			return new GetContactByIdQueryResult
			{
				ContactId = values.ContactId,
				Email = values.Email,
				Message = values.Message,
				Name = values.Name,
				SendDate = values.SendDate,
				Subject = values.Subject
			};
		}
	}
}
