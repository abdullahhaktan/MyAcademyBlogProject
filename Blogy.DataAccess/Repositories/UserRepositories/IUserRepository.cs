using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DataAccess.Repositories.UserRepositories
{
    public interface IUserRepository
    {
        Task<int> GetTotalUserCount();
        Task<List<int>> GetMonthlyUserCounts();
    }
}
