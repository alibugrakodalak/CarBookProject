using CarBookProject.Application.Features.CQRS.Commands.CategoryCommands;
using CarBookProject.Application.Features.CQRS.Handlers.CategoryHandlers;
using CarBookProject.Application.Features.CQRS.Queries.CategoryQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		private readonly CreateCategoryCommandHandler _createCategoryCommandHandler;
		private readonly GetCategoryByIdQueryHandler _getCategoryByIdQueryHandler;
		private readonly GetCategoryQueryHandler _getCategoryQueryHandler;
		private readonly RemoveCategoryCommandHandler _removeCategoryCommandHandler;
		private readonly UpdateCategoryCommandHandler _updateCategoryCommandHandler;

		public CategoriesController(CreateCategoryCommandHandler createCategoryCommandHandler,
			GetCategoryByIdQueryHandler getCategoryByIdQueryHandler,
			GetCategoryQueryHandler getCategoryQueryHandler,
			RemoveCategoryCommandHandler removeCategoryCommandHandler,
			UpdateCategoryCommandHandler updateCategoryCommandHandler)
		{
			_createCategoryCommandHandler = createCategoryCommandHandler;
			_getCategoryByIdQueryHandler = getCategoryByIdQueryHandler;
			_getCategoryQueryHandler = getCategoryQueryHandler;
			_removeCategoryCommandHandler = removeCategoryCommandHandler;
			_updateCategoryCommandHandler = updateCategoryCommandHandler;
		}

		[HttpGet]
		public async Task<IActionResult> CategoryList()
		{
			var values = await _getCategoryQueryHandler.Handle();
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetCategory(int id)
		{
			var value = await _getCategoryByIdQueryHandler.Handle(new GetCategoryByIdQuery(id));
			return Ok(value);
		}

		[HttpPost]
		public async Task<IActionResult> CreateCategory(CreateCategoryCommands commands)
		{
			await _createCategoryCommandHandler.Handle(commands);
			return Ok("Kategori Başarıyla Oluşturuldu");
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteCategory(int id)
		{
			await _removeCategoryCommandHandler.Handle(new RemoveCategoryCommands(id));
			return Ok("Kategori Başarıyla Silindi");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateCategory(UpdateCategoryCommands commands)
		{
			await _updateCategoryCommandHandler.Handle(commands);
			return Ok("Kategori Başarıyla Güncellendi");
		}
	}
}
