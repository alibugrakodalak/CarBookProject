using CarBookProject.Application.Features.Mediator.Commands.SocialMediaCommands;
using CarBookProject.Application.Features.Mediator.Queries.SocialMediaQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SocialMediasController : ControllerBase
	{
		private readonly IMediator _mediator;

		public SocialMediasController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> SocialMediaList()
		{
			var values = await _mediator.Send(new GetSocialMediaQuery());
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetSocialMedia(int id)
		{
			var values = await _mediator.Send(new GetSocialMediaByIdQuery(id));
			return Ok(values);
		}

		[HttpPost]
		public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaCommand command)
		{
			await _mediator.Send(command);
			return Ok("Sosyal Medya Platformları Eklendi!");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaCommand command)
		{
			await _mediator.Send(command);
			return Ok("Sosyal Medya İçerikleri Güncellendi!");
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> RemoveSocialMedia(int id)
		{
			await _mediator.Send(new RemoveSocialMediaCommand(id));
			return Ok("Sosyal Medya İçerikleri Silindi!");
		}
	}
}
