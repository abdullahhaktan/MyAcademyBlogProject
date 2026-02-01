using Blogy.DataAccess.Context;
using Blogy.DataAccess.Repositories.GenericRepositories;
using Blogy.Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blogy.DataAccess.Repositories.BlogRepositories
{
    public class BlogRepository : GenericRepository<Blog>, IBlogRepository
    {
        public BlogRepository(AppDbContext context) : base(context)
        {
        }


        public async Task<List<Blog>> GetBlogsByWriterAsync(int id)
        {
            return await _table.Where(b => b.WriterId == id && b.IsDeleted == false).ToListAsync();
        }

        public async Task<List<Blog>> GetBlogsWithCategories()
        {
            return await _table.Include(x => x.Category).ToListAsync();
        }

        public override async Task DeleteAsync(int id)
        {
            var entity = await _table.FindAsync(id);
            entity.IsDeleted = true;
            _table.Update(entity);
            _context.SaveChanges();
        }

        public override async Task<List<Blog>> GetAllAsync()
        {
            return await _table.AsNoTracking().Where(b => b.IsDeleted == false).ToListAsync();
        }

        public async Task<List<Blog>> GetLast3BlogsAsync()
        {
            return await _table
                .OrderByDescending(x => x.Id)
                .Take(3)
                .ToListAsync();
        }


        public async Task<List<Blog>> GetLast5BlogsAsync()
        {
            return await _table
                .OrderByDescending(x => x.Id)
                .Take(5)
                .ToListAsync();
        }

        public async Task<int> GetBlogCountByCategory(int id)
        {
            var count = await _table.Where(b => b.CategoryId == id).CountAsync();
            return count;
        }

        public async Task<int> GetTotalBlogCountAsync()
        {
            return await _table.CountAsync();
        }

        public async Task<List<int>> GetMonthlyBlogCountsAsync()
        {
            var currentYear = DateTime.Now.Year;
            var monthlyCounts = new List<int>();

            for (int month = 1; month <= 12; month++)
            {
                var count = await _table.CountAsync(b => b.CreatedDate.Year == currentYear && b.CreatedDate.Month == month);
                monthlyCounts.Add(count);
            }

            return monthlyCounts;
        }
    }
}