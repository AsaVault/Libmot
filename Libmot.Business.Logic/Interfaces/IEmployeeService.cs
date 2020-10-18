using Data.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logic.Interfaces
{
    public interface IEmployeeService
    {
        Task<Employee> SaveAsync(Employee data);
        Task DeleteAsync(string ID);
        Task UpdateAsync(Employee data);
        Task<Employee> GetAsync(string EID);
        Task<List<Employee>> GetAllAsync();
    }
}
