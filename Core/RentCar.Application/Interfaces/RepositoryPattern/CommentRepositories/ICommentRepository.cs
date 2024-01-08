using RentCar.Domain.Entities;

namespace RentCar.Application.Interfaces.RepositoryPattern.CommentRepositories
{
    public interface ICommentRepository : IGenericRepository<Comment>
    {
        Task<List<Comment>> GetCommentsByBlogAsync(int id);
    }
}
