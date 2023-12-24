using System.Linq.Expressions;

namespace RentCar.Application.Interfaces.RepositoryPattern.CommentRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task CreateAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null);
        Task<T> GetByIdAsync(int id);
        void RemoveAsync(T entity);
        Task<int> SaveAsync();
        void UpdateAsync(T entity);
    }
}
