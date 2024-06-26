using ApdAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ApdAPI.Repository
{
    public class GenericRepository<TEntity, TContext> : IGenericRepository<TEntity, TContext>
    where TEntity : class
    where TContext : DbContext
    {
        private readonly TContext _context;

        public GenericRepository(TContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }
        public async Task<TEntity> GetLatestByUserIdAsync(int userId)
        {
            var propertyInfo = typeof(TEntity).GetProperty("UserId");
            if (propertyInfo == null)
            {
                throw new InvalidOperationException("La entidad no tiene la propiedad 'UserId'.");
            }

            var allEntities = await _context.Set<TEntity>().ToListAsync();
            var entity = allEntities.LastOrDefault(e => (int)propertyInfo.GetValue(e) == userId);

            return entity;
        }


        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
