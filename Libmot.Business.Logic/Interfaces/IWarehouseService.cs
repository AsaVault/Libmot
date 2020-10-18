using Data.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logic.Interfaces
{
    public interface IWarehouseService
    {
        Task<Warehouse> SaveAsync(Warehouse data);
        Task DeleteAsync(int ID);
        Task UpdateAsync(Warehouse data);
        Task<Warehouse> GetAsync(int WID, int SID, int EID);
        Task<List<Warehouse>> GetAllAsync();
    }
}
