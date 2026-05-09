using CarBookProject.Application.Interfaces.BlogInterfaces;
using CarBookProject.Domain.Entities;
using CarBookProject.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Persistence.Repositories.BlogRepositories
{
	public class BlogRepository : IBlogRepository
	{
		private readonly CarBookContext _context;

		public BlogRepository(CarBookContext context)
		{
			_context = context;
		}

		public List<Blog> GetAllBlogWithAuthors()
		{
			var values = _context.Blogs.Include(x => x.Author).ToList();
			return values;
		}

		public List<Blog> GetBlogByAuthorId(int id)
		{
			var values = _context.Blogs.Include(x => x.Author).Where(y => y.BlogID == id).ToList();
			return values;
		}

		public List<Blog> GetLast3BlogWithAuthors()
		{
			var values = _context.Blogs
				.Include(x => x.Author)
				.OrderByDescending(x=>x.BlogID)
				.Take(3)
				.ToList();

			return values;
		}
	}
}
