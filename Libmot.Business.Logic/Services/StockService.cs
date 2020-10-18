using Business.Logic.Interfaces;
using Data.Domain.Entities;
using Data.Domain.IRepository;
using Libmot.Data.Domain.IRepository;
using Libmot.WebApplication.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Logic.Services
{
    public class StockService : IStockService
    {
        private readonly IRepo<Stock> _sRepo;
        private readonly ApplicationDbContext _context;

        public StockService(IRepo<Stock> sRepo, ApplicationDbContext context)
        {
            _sRepo = sRepo;
            _context = context;
        }
        public async Task DeleteAsync(int id)
        {
            await _sRepo.deleteAsync(id);
        }

        public async Task<List<Stock>> GetAllAsync()
        {
            var data = await _sRepo.getAllAsync();
            return data;
        }

        public async Task<Stock> GetAsync(int ID)
        {
            var stock = await _sRepo.getAsync(ID);
            //var ware = await _wRepo.getAsync(stock.WarehouseId);
            //stock.Store = ware;

            return stock;
        }

        public async Task<Stock> SaveAsync(Stock data)
        {
            var stock = await _sRepo.insertAsync(data) ;
            return stock;
        }

        public async Task UpdateAsync(Stock data)
        {
            await _sRepo.updateAsync(data);
        }

        public async Task<object> GetWarehouseDropdownList()
        {
            var warehouseList = await _context.Warehouses.Select(w => new { w.Id, w.Name }).ToListAsync();
            return warehouseList;
        }

        public async Task<object> GetEmployeeDropdownList()
        {
            var employeeList = await _context.Employees.Select(w => new { w.Id, w.Name }).ToListAsync();
            return employeeList;
        }
    }
}
