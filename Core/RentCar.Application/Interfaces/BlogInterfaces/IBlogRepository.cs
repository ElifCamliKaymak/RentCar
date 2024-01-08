using RentCar.Domain.Entities;

namespace RentCar.Application.Interfaces.BlogInterfaces
{
    public interface IBlogRepository
    {
        Task<List<Blog>> GetLastThreeBlogsWithAuthors();
        Task<List<Blog>> GetAllBlogsWithAuthors();
        Task<List<Blog>> GetBlogByAuthorIdAsync(int id);
        Task<List<Blog>> GetBlogsOfAuthors(int authorId);
        Task<List<Blog>> GetBlogsOfCategorys(int categoryId);

    }
}
