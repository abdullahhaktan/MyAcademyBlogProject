namespace Blogy.DataAccess.Repositories.UserRepositories
{
    public interface IUserRepository
    {
        Task<int> GetTotalUserCount();
        Task<List<int>> GetMonthlyUserCounts();
    }
}
