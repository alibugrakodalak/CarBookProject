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
	public class UpdateBannerCommandHandler
	{
		private readonly IRepository<Banner> _repository;

		public UpdateBannerCommandHandler(IRepository<Banner> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateBannerCommands commands)
		{
			var values = await _repository.GetByIdAsync(commands.BannerId);
			values.BannerVideoDescription = commands.BannerVideoDescription;
			values.BannerVideoUrl = commands.BannerVideoUrl;
			values.BannerDescription = commands.BannerDescription;
			values.BannerTitle = commands.BannerTitle;
			await _repository.UpdateAsync(values);

		}
	}
}
