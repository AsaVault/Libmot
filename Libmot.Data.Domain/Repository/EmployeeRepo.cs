using Data.Domain.Entities;
using Data.Domain.IRepository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Libmot.WebApplication.Data;
using Libmot.Data.Domain.IRepository;

namespace Data.Domain.Repository
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<EmployeeRepo> _logger;
        public EmployeeRepo(ApplicationDbContext context, ILogger<EmployeeRepo> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task deleteAsync(string ID)
        {
            try
            {
                var em = await _context.Employees.FindAsync(ID);
                 _context.Employees.Remove(em);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        public async Task<List<Employee>> getAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> getAsync(string ID)
        {
            try
            {
                var em = await _context.Employees.FindAsync(ID);
                return em;
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
                throw ex;
            }
            
        }

        public async Task<Employee> insertAsync(Employee data)
        {
            try
            {
                var employee = new Employee()
                {
                    Id = data.Id,
                    Email = data.Email,
                    Address = data.Address,
                    Name = data.Name,
                    PhoneNumber = data.PhoneNumber,
                    PasswordHash = data.PasswordHash
                };
                await _context.Employees.AddAsync(employee);
                await _context.SaveChangesAsync();
                return employee;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
            
        }

        public async Task updateAsync(Employee data)
        {
            try
            {
                var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == data.Id);
                if(employee != null)
                {
                    employee.Name = data.Name;
                    employee.Email = data.Email;
                    employee.Address = data.Address;
                    employee.PhoneNumber = data.PhoneNumber;
                }
                 _context.Employees.Update(employee);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            };
        }
    }
}
