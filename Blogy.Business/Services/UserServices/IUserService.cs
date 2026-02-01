namespace Blogy.Business.Services.UserServices
{
    public interface IUserService
    {
        Task<int> GetTotalUserCount();
        Task<List<int>> GetMonthlyUserCounts();
    }
}
