using CarBookProject.Application.Features.CQRS.Commands.BrandCommands;
using CarBookProject.Application.Features.CQRS.Handlers.BrandHandlers;
using CarBookProject.Application.Features.CQRS.Queries.BrandQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BrandsController : ControllerBase
	{
		private readonly CreateBrandCommandHandler _createBrandCommandHandler;
		private readonly GetBrandByIdQueryHandler _getBrandByIdQueryHandler;
		private readonly GetBrandQueryHandler _getBrandQueryHandler;
		private readonly RemoveBrandCommandHandler _removeBrandCommandHandler;
		private readonly UpdateBrandCommandHandler _updateBrandCommandHandler;

		public BrandsController(CreateBrandCommandHandler createBrandCommandHandler, 
			GetBrandByIdQueryHandler getBrandByIdQueryHandler, 
			GetBrandQueryHandler getBrandQueryHandler, 
			RemoveBrandCommandHandler removeBrandCommandHandler, 
			UpdateBrandCommandHandler updateBrandCommandHandler)
		{
			_createBrandCommandHandler = createBrandCommandHandler;
			_getBrandByIdQueryHandler = getBrandByIdQueryHandler;
			_getBrandQueryHandler = getBrandQueryHandler;
			_removeBrandCommandHandler = removeBrandCommandHandler;
			_updateBrandCommandHandler = updateBrandCommandHandler;
		}

		[HttpGet]
		public async Task<IActionResult> BrandList()
		{
			var values = await _getBrandQueryHandler.Handle();
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetBrand(int id)
		{
			var value = await _getBrandByIdQueryHandler.Handle(new GetBrandByIdQuery(id));
			return Ok(value);
		}

		[HttpPost]
		public async Task<IActionResult> CreateBrand(CreateBrandCommands commands)
		{
			await _createBrandCommandHandler.Handle(commands);
			return Ok("Marka Başarıyla Oluşturuldu");
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteBrand(int id) 
		{
			await _removeBrandCommandHandler.Handle(new RemoveBrandCommands(id));
			return Ok("Marka Başarıyla Silindi");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateBrand(UpdateBrandCommands commands)
		{
			await _updateBrandCommandHandler.Handle(commands);
			return Ok("Marka Başarıyla Güncellendi");
		}
	}
}
