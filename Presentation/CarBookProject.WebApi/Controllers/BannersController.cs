using CarBookProject.Application.Features.CQRS.Commands.BannerCommands;
using CarBookProject.Application.Features.CQRS.Handlers.BannerHandlers;
using CarBookProject.Application.Features.CQRS.Queries.BannerQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BannersController : ControllerBase
	{
		private readonly CreateBannerCommandHandler _createBannerCommandHandler;
		private readonly GetBannerByIdQueryHandler _getBannerByIdQueryHandler;
		private readonly GetBannerQueryHandler _getBannerQueryHandler;
		private readonly RemoveBannerCommandHandler _removeBannerCommandHandler;
		private readonly UpdateBannerCommandHandler _updateBannerCommandHandler;

		public BannersController(CreateBannerCommandHandler createBannerCommandHandler,
			GetBannerByIdQueryHandler getBannerByIdQueryHandler,
			GetBannerQueryHandler getBannerQueryHandler,
			RemoveBannerCommandHandler removeBannerCommandHandler, 
			UpdateBannerCommandHandler updateBannerCommandHandler)
		{
			_createBannerCommandHandler = createBannerCommandHandler;
			_getBannerByIdQueryHandler = getBannerByIdQueryHandler;
			_getBannerQueryHandler = getBannerQueryHandler;
			_removeBannerCommandHandler = removeBannerCommandHandler;
			_updateBannerCommandHandler = updateBannerCommandHandler;
		}

		[HttpGet]
		public async Task<IActionResult> BannerList()
		{
			var values = await _getBannerQueryHandler.Handle();
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetBanner(int id)
		{
			var value = await _getBannerByIdQueryHandler.Handle(new GetBannerByIdQuery(id));
			return Ok(value);
		}

		[HttpPost]
		public async Task<IActionResult> CreateBanner(CreateBannerCommands commands)
		{
			await _createBannerCommandHandler.Handle(commands);
			return Ok("Bilgi Başarıyla Eklendi");
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> RemoveBanner(int id)
		{
			await _removeBannerCommandHandler.Handle(new RemoveBannerCommands(id));
			return Ok("Bilgi Başarıyla Silindi");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateBanner(UpdateBannerCommands commands)
		{
			await _updateBannerCommandHandler.Handle(commands);
			return Ok("Bilgi Başarıyla Güncellendi");
		}

	}
}
