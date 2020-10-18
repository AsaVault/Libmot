using Data.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logic.Interfaces
{
    public interface IStockService
    {
        Task<Stock> SaveAsync(Stock data);
        Task DeleteAsync(int ID);
        Task UpdateAsync(Stock data);
        Task<Stock> GetAsync(int ID);
        Task<List<Stock>> GetAllAsync();
        Task<object> GetWarehouseDropdownList();
        Task<object> GetEmployeeDropdownList();
    }
}
