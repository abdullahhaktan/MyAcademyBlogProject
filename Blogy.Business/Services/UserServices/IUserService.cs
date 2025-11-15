using Blogy.Business.DTOs.Comment;
using Blogy.Business.DTOs.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Business.Services.UserServices
{
    public interface IUserService 
    {
        Task<int> GetTotalUserCount();
        Task<List<int>> GetMonthlyUserCounts();
    }
}
