using CarBookProject.Application.Features.Mediator.Commands.CarFeatureCommands;
using CarBookProject.Application.Features.Mediator.Queries.CarFeatureQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarFeaturesController : ControllerBase
	{
		private readonly IMediator _mediator;

		public CarFeaturesController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> CarFeatureListByCarId(int id)
		{
			var values = await _mediator.Send(new GetCarFeatureByCarIdQuery(id));
			return Ok(values);
		}

		[HttpGet("CarFeatureAvailableChangeToFalse")]
		public async Task<IActionResult> CarFeatureAvailableChangeToFalse (int id)
		{
			await _mediator.Send(new UpdateCarFeatureAvailableChangeToFalseCommand(id));
			return Ok("Güncelleme Başarılı");
		}

		[HttpGet("CarFeatureAvailableChangeToTrue")]
		public async Task<IActionResult> CarFeatureAvailableChangeToTrue(int id)
		{
			await _mediator.Send(new UpdateCarFeatureAvailableChangeToTrueCommand(id));
			return Ok("Güncelleme Başarılı");
		}

		[HttpPost]
		public async Task<IActionResult> CreateCarFeatureByCarId(CreateCarFeatureByCarCommand createCarFeatureByCarCommand)
		{
			_mediator.Send(createCarFeatureByCarCommand);
			return Ok("Ekleme İşlemi Başarılı");
		}
	}
}
