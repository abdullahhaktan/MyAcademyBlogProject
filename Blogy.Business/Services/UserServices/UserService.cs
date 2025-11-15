using Blogy.DataAccess.Repositories.UserRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Business.Services.UserServices
{
    public class UserService(IUserRepository _userRepository) : IUserService
    {
        public async Task<List<int>> GetMonthlyUserCounts()
        {
            return await _userRepository.GetMonthlyUserCounts();
        }

        public async Task<int> GetTotalUserCount()
        {
            return await _userRepository.GetTotalUserCount();
        }
    }
}
