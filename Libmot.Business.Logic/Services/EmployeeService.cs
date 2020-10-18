using Business.Logic.Interfaces;
using Data.Domain.Entities;
using Data.Domain.IRepository;
using Libmot.Data.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logic.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepo _eRepo;
        public EmployeeService(IEmployeeRepo eRepo)
        {
            _eRepo = eRepo;
        }
        public async Task DeleteAsync(string id)
        {
            await _eRepo.deleteAsync(id);
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            var data = await _eRepo.getAllAsync();
            return data;
        }

        public async Task<Employee> GetAsync(string EID)
        {
            var emp = await _eRepo.getAsync(EID);
            return emp;
        }

        public async Task<Employee> SaveAsync(Employee data)
        {
            var employee = await _eRepo.insertAsync(data);
            return employee;
        }

        public async Task UpdateAsync(Employee data)
        {
            await _eRepo.updateAsync(data);
        }
    }
}
