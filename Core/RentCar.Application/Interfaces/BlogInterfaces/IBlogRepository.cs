using RentCar.Domain.Entities;

namespace RentCar.Application.Interfaces.BlogInterfaces
{
    public interface IBlogRepository
    {
        Task<List<Blog>> GetLastThreeBlogsWithAuthors();
        Task<List<Blog>> GetAllBlogsWithAuthors();
        Task<List<Blog>> GetBlogByAuthorIdAsync(int id);

    }
}
