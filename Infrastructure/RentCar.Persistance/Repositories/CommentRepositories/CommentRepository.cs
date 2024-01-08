using Microsoft.EntityFrameworkCore;
using RentCar.Application.Interfaces.RepositoryPattern.CommentRepositories;
using RentCar.Domain.Entities;
using RentCar.Persistance.Context;

namespace RentCar.Persistance.Repositories.CommentRepositories
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        private readonly RentCarContext _context;

        public CommentRepository(RentCarContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Comment>> GetCommentsByBlogAsync(int id)
        {
            var values = await _context.Set<Comment>()
                .Where(x => x.BlogId == id)
                .ToListAsync();
            return values;
        }
    }
}
