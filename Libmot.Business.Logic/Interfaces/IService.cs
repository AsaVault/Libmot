using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logic.Interfaces
{
    public interface IService<T>
    {
        Task<T> SaveAsync(T data);
        Task DeleteAsync(int id);
        Task UpdateAsync(T data);
        Task<T> GetAsync(int id);
        Task<List<T>> GetAllAsync();
    }
}
