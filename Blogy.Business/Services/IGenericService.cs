using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Business.Services
{
    public interface IGenericService<TResult,TUpdate,TCreate>
    {
        Task<List<TResult>> GetAllAsync();
        Task<TUpdate> GetByIdAsync(int id);
        Task CreateAsync(TCreate dto);
        Task UpdateAsync(TUpdate dto);
        Task DeleteAsync(int id);
    }
}
