using Microsoft.EntityFrameworkCore;
using RentCar.Application.Interfaces.RepositoryPattern.CommentRepositories;
using RentCar.Persistance.Context;
using System.Linq.Expressions;

namespace RentCar.Persistance.Repositories.CommentRepositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly RentCarContext _context;

        public GenericRepository(RentCarContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(T entity)
        {
            await _context.AddAsync(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null)
        {
            return expression == null
                ? await _context.Set<T>().ToListAsync()
                : await _context.Set<T>().Where(expression).ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public void RemoveAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
        }

    }
}
