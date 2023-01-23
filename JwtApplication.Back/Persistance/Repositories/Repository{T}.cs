using JwtApplication.Back.Core.Application.Interfaces;
using JwtApplication.Back.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JwtApplication.Back.Persistance.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly JwtContext JwtContext;

        public Repository(JwtContext jwtContext)
        {
            JwtContext = jwtContext;
        }

        public async Task CreateAsync(T entity)
        {
            await this.JwtContext.Set<T>().AsNoTracking().ToListAsync();
            await this.JwtContext.SaveChangesAsync();
            
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await this.JwtContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
            return await this.JwtContext.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter);
        }

        public async Task<T?> GetByIdAsync(object id)
        {
            return await this.JwtContext.Set<T>().FindAsync(id);
        }

        public async Task RemoveAsync(T entity)
        {
            this.JwtContext.Set<T>().Remove(entity);
            await this.JwtContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            this.JwtContext.Set<T>().Update(entity);
            await this.JwtContext.SaveChangesAsync();
        }
    }
}
