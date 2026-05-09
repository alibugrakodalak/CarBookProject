using CarBookProject.Application.Features.CQRS.Commands.AboutCommands;
using CarBookProject.Application.Features.CQRS.Handlers.AboutHandlers;
using CarBookProject.Application.Features.CQRS.Queries.AboutQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AboutsController : ControllerBase
	{
		private readonly CreateAboutCommandHandler _createAboutCommandHandler;
		private readonly GetAboutByIdQueryHandler _getAboutByIdQueryHandler;
		private readonly GetAboutQueryHandler _getAboutQueryHandler;
		private readonly RemoveAboutCommandHandler _removeAboutCommandHandler;
		private readonly UpdateAboutCommandHandler	_updateAboutCommandHandler;

		public AboutsController(CreateAboutCommandHandler createAboutCommandHandler, 
			GetAboutByIdQueryHandler getAboutByIdQueryHandler, GetAboutQueryHandler getAboutQueryHandler, 
			RemoveAboutCommandHandler removeAboutCommandHandler, 
			UpdateAboutCommandHandler updateAboutCommandHandler)
		{
			_createAboutCommandHandler = createAboutCommandHandler;
			_getAboutByIdQueryHandler = getAboutByIdQueryHandler;
			_getAboutQueryHandler = getAboutQueryHandler;
			_removeAboutCommandHandler = removeAboutCommandHandler;
			_updateAboutCommandHandler = updateAboutCommandHandler;
		}

		[HttpGet]
		public async Task<IActionResult> AboutList()
		{
			var values = await _getAboutQueryHandler.Handle();
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetAbout(int id)
		{
			var value = await _getAboutByIdQueryHandler.Handle(new GetAboutByIdQuery(id));
			return Ok(value);	
		}

		[HttpPost]
		public async Task<IActionResult> CreateAbout(CreateAboutCommands commands)
		{
			await _createAboutCommandHandler.Handle(commands);
			return Ok("Hakkımda Bilgisi Başarıyla Eklendi");
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> RemoveAbout(int id)
		{
			await _removeAboutCommandHandler.Handle(new RemoveAboutCommands(id));
			return Ok("Hakkımda Bilgisi Başarıyla Silindi");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateAbout(UpdateAboutCommands commands)
		{
			await _updateAboutCommandHandler.Handle(commands);
			return Ok("Hakkımda Bilgisi Başarıyla Güncellendi");
		}
	}
}
