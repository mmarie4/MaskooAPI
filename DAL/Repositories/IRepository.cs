using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        Task<int> SaveAsync();
        Task<ICollection<TEntity>> GetAllAsync(int offset, int limit);
        Task<TEntity> GetByIdAsync(Guid id);
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task<TEntity> Remove(TEntity entity);
    }
}
