using CarBookProject.Application.Features.CQRS.Commands.BannerCommands;
using CarBookProject.Application.Interfaces;
using CarBookProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.CQRS.Handlers.BannerHandlers
{
	public class CreateBannerCommandHandler
	{
		private readonly IRepository<Banner> _repository;

		public CreateBannerCommandHandler(IRepository<Banner> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateBannerCommands commands)
		{
			await _repository.CreateAsync(new Banner
			{
				BannerDescription	   = commands.BannerDescription,
				BannerTitle            = commands.BannerTitle,
				BannerVideoDescription = commands.BannerVideoDescription,
				BannerVideoUrl		   = commands.BannerVideoUrl,
			});
		}
	}
}
