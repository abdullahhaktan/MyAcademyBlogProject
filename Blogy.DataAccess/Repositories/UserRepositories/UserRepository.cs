using Blogy.DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace Blogy.DataAccess.Repositories.UserRepositories
{
    public class UserRepository(AppDbContext _context) : IUserRepository
    {
        public async Task<int> GetTotalUserCount()
        {
            return await _context.Users.CountAsync();
        }

        public async Task<List<int>> GetMonthlyUserCounts()
        {
            var currentYear = DateTime.Now.Year;
            var monthlyCounts = new List<int>();

            for (int month = 1; month <= 12; month++)
            {
                var count = await _context.Users.Where(u => u.CreatedDate.Year == currentYear && u.CreatedDate.Month == month).CountAsync();

                monthlyCounts.Add(count);
            }
            return monthlyCounts;
        }

    }
}
