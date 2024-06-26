using ApdAPI.Models;
using ApdAPI.Repository;
using Microsoft.EntityFrameworkCore;

namespace ApdAPI.Services
{
    public class GenericService<TEntity, TContext> : IGenericService<TEntity, TContext>
    where TEntity : class
    where TContext : DbContext
    {
        private readonly IGenericRepository<TEntity, TContext> _repository;

        public GenericService(IGenericRepository<TEntity, TContext> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
        public async Task<TEntity> GetLatestByUserIdAsync(int userId)
        {
            return await _repository.GetLatestByUserIdAsync(userId);
        }


        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            return await _repository.CreateAsync(entity);
        }

    }
}
