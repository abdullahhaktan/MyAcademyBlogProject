using Blogy.DataAccess.Repositories.UserRepositories;

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
