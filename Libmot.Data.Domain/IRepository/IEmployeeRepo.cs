using Data.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libmot.Data.Domain.IRepository
{
    public interface IEmployeeRepo
    {
        Task<Employee> insertAsync(Employee data);
        Task deleteAsync(string ID);
        Task updateAsync(Employee data);
        Task<Employee> getAsync(string ID);
        Task<List<Employee>> getAllAsync();
    }
}
