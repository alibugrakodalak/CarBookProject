using CarBookProject.Application.Features.CQRS.Commands.CarCommands;
using CarBookProject.Application.Features.CQRS.Handlers.CarHandlers;
using CarBookProject.Application.Features.CQRS.Queries.CarQueries;
using CarBookProject.Application.Features.Mediator.Queries.StatisticsQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarsController : ControllerBase
	{
		private readonly CreateCarCommandHandler _createCarCommandHandler;
		private readonly GetCarByIdQueryHandler _getCarByIdQueryHandler;
		private readonly GetCarQueryHandler _getCarQueryHandler;
		private readonly RemoveCarCommandHandler _removeCarCommandHandler;
		private readonly UpdateCarCommandHandler _updateCarCommandHandler;
		private readonly GetCarWithBrandQueryHandler _getCarWithBrandQueryHandler;
		private readonly GetLast5CarsWithBrandsQueryHandler _getLast5CarsWithBrandsQueryHandler;

		public CarsController(CreateCarCommandHandler createCarCommandHandler, GetCarByIdQueryHandler getCarByIdQueryHandler, GetCarQueryHandler getCarQueryHandler, RemoveCarCommandHandler removeCarCommandHandler, UpdateCarCommandHandler updateCarCommandHandler, GetCarWithBrandQueryHandler getCarWithBrandQueryHandler, GetLast5CarsWithBrandsQueryHandler getLast5CarsWithBrandsQueryHandler)
		{
			_createCarCommandHandler = createCarCommandHandler;
			_getCarByIdQueryHandler = getCarByIdQueryHandler;
			_getCarQueryHandler = getCarQueryHandler;
			_removeCarCommandHandler = removeCarCommandHandler;
			_updateCarCommandHandler = updateCarCommandHandler;
			_getCarWithBrandQueryHandler = getCarWithBrandQueryHandler;
			_getLast5CarsWithBrandsQueryHandler = getLast5CarsWithBrandsQueryHandler;
		}

		[HttpGet]
		public async Task<IActionResult> CarList()
		{
			var values = await _getCarQueryHandler.Handle();
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetCar(int id)
		{
			var value = await _getCarByIdQueryHandler.Handle(new GetCarByIdQuery(id));
			return Ok(value);
		}

		[HttpPost]
		public async Task<IActionResult> CreateCar(CreateCarCommand commands)
		{
			await _createCarCommandHandler.Handle(commands);
			return Ok("Araç Başarıyla Oluşturuldu");
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> RemoveCar(int id)
		{
			await _removeCarCommandHandler.Handle(new RemoveCarCommand(id));
			return Ok("Araç Başarıyla Silindi");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateCar(UpdateCarCommand commands)
		{
			await _updateCarCommandHandler.Handle(commands);
			return Ok("Araç Başarıyla Güncellendi");
		}

		[HttpGet("GetCarWithBrand")]
		public IActionResult GetCarWithBrand()
		{
			var values = _getCarWithBrandQueryHandler.Handle();
			return Ok(values);
		}

		[HttpGet("GetLast5CarsWithBrandsWithBrand")]
		public IActionResult GetLast5CarsWithBrandsWithBrand()
		{
			var values = _getLast5CarsWithBrandsQueryHandler.Handle();
			return Ok(values);
		}		
	}
}
