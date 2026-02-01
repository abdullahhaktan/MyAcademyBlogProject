using Blogy.DataAccess.Context;
using Blogy.DataAccess.Repositories.GenericRepositories;
using Blogy.Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blogy.DataAccess.Repositories.CommentRepositories
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<int> GetTotalCommentAsync()
        {
            return await _table.CountAsync();
        }
    }
}
