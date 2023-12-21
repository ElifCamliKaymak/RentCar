using Microsoft.EntityFrameworkCore;
using RentCar.Application.Interfaces.TagCloudInterfaces;
using RentCar.Domain.Entities;
using RentCar.Persistance.Context;

namespace RentCar.Persistance.Repositories.TagCloudRepositories
{
    public class TagCloudRepository : ITagCloudRepository
    {
        private readonly RentCarContext _context;

        public TagCloudRepository(RentCarContext context)
        {
            _context = context;
        }

        public async Task<List<TagCloud>> GetTagCloudsByBlogIdAsync(int blogId)
        {
            var values = await _context.TagClouds
                .Where(x => x.BlogId == blogId)
                .ToListAsync();
            return values;
        }
    }
}
