using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BankAccountsDB
{
    public interface IGenericRepository<TEntity> where TEntity : class, IEntityBase
    {
        IQueryable<TEntity> GetAll();
        Task<TEntity> GetById(int id);
        Task Create(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(int id);
        Task Save();
    }

    public interface IEntityBase
    {
        int Id { get; set; }
    }

    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IEntityBase {
        private readonly IApplicationDbContext _dbContext;
        public GenericRepository(IApplicationDbContext dbContext) {
            _dbContext = dbContext;
        }
        public IQueryable<TEntity> GetAll() {
            return _dbContext.Set<TEntity>().AsNoTracking();
        }
        public async Task<TEntity> GetById(int id) {
            return await _dbContext.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }
        public async Task Create(TEntity entity) {
            _dbContext.Set<TEntity>().Add(entity);
        }
        public async Task Update(TEntity entity) {
            _dbContext.Set<TEntity>().Update(entity);
        }
        public async Task Delete(int id) {
            var entity = await GetById(id);
            _dbContext.Set<TEntity>().Remove(entity);
        }
        public async Task Save() {
            await _dbContext.SaveChangesAsync();
        }
    }
}
