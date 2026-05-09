using CarBookProject.Application.Features.Mediator.Commands.CommentCommands;
using CarBookProject.Application.Features.RepositoryPattern;
using CarBookProject.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CommentsController : ControllerBase
	{
		private readonly IGenericRepository<Comment> _repository;
		private readonly IMediator _mediator;

		public CommentsController(IGenericRepository<Comment> repository, IMediator mediator)
		{
			_repository = repository;
			_mediator = mediator;
		}

		[HttpGet]
		public IActionResult CommentList()
		{
			var values = _repository.GetAll();
			return Ok(values);
		}

		[HttpGet("{id}")]
		public IActionResult GetComment(int id)
		{
			var values = _repository.GetById(id);
			return Ok(values);
		}

		[HttpPost]
		public IActionResult CreateComment(Comment comment)
		{
			_repository.Create(comment);
			return Ok("Yorum Başarıyla Oluşturuldu");
		}

		[HttpPut]
		public IActionResult UpdateComment(Comment comment)
		{
			_repository.Update(comment);
			return Ok("Yorum Güncelleme Başarılı");
		}

		[HttpDelete]
		public IActionResult RemoveComment(int id)
		{
			var value = _repository.GetById(id);
			_repository.Remove(value);
			return Ok("Yorum Silindi!");
		}

		[HttpGet("CommentsListByBlogId")]
		public IActionResult CommentsListByBlogId(int id)
		{
			var values = _repository.GetCommentsByBlogId(id);
			return Ok(values);
		}

		[HttpGet("CountCommentByBlog")]
		public IActionResult CountCommentByBlog(int id)
		{
			var value = _repository.CountCommentByBlog(id);
			return Ok(value);
		}

		[HttpPost("CreateCommentWithMediator")]
		public async Task<IActionResult> CreateCommentWithMediator(CreateCommentCommand command)
		{
			await _mediator.Send(command);
			return Ok("Yorum Ekleme Başarılı");
		}
	}
}
