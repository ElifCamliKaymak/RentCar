using Microsoft.EntityFrameworkCore;
using RentCar.Application.Interfaces.BlogInterfaces;
using RentCar.Domain.Entities;
using RentCar.Persistance.Context;

namespace RentCar.Persistance.Repositories.BlogRepositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly RentCarContext _context;

        public BlogRepository(RentCarContext context)
        {
            _context = context;
        }

        public async Task<List<Blog>> GetLastThreeBlogsWithAuthors()
        {
            var values = await _context.Blogs
                .Include(x=>x.Author)
                .OrderByDescending(x=>x.BlogId)
                .Take(3)
                .ToListAsync();
            return values;
        }
    }
}
