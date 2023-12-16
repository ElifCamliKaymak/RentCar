using RentCar.Domain.Entities;

namespace RentCar.Application.Interfaces.BlogInterfaces
{
    public interface IBlogRepository
    {
        Task<List<Blog>> GetLastThreeBlogsWithAuthors();
    }
}
