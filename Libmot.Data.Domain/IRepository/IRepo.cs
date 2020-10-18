using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Domain.IRepository
{
    public interface IRepo<T>
    {
        Task<T> insertAsync(T data);
        Task deleteAsync(int ID);
        Task updateAsync(T data);
        Task<T> getAsync(int ID);
        Task<List<T>> getAllAsync();
    }
}
