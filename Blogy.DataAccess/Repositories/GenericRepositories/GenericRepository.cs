using Blogy.DataAccess.Context;
using Blogy.Entity.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Blogy.DataAccess.Repositories.GenericRepositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        public readonly AppDbContext _context;
        public readonly DbSet<TEntity> _table;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _table = _context.Set<TEntity>();
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _table.FindAsync(id);
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            return await _table.AsNoTracking().ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _table.AsNoTracking().Where(filter).ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _table.FindAsync(id);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _context.Update(entity);
            _context.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
            await _context.SaveChangesAsync();
        }
    }
}
