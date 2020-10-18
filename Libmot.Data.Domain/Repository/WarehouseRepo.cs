using Data.Domain.Entities;
using Data.Domain.IRepository;
using Libmot.WebApplication.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Domain.Repository
{
    public class WarehouseRepo:IRepo<Warehouse>
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<WarehouseRepo> _logger;
        public WarehouseRepo(ApplicationDbContext context, ILogger<WarehouseRepo> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task deleteAsync(int ID)
        {
            try
            {
                var data = await _context.Warehouses.FindAsync(ID);
                _context.Warehouses.Remove(data);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        public async Task<List<Warehouse>> getAllAsync()
        {
            return await _context.Warehouses.ToListAsync();
        }

        public async Task<Warehouse> getAsync(int ID)
        {
            try
            {
                var data = await _context.Warehouses.FindAsync(ID);
                return data;
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
                throw ex;
            }

        }

        public async Task<Warehouse> insertAsync(Warehouse data)
        {
            try
            {
                var warehouse = new Warehouse()
                {
                    Id = data.Id,
                    Description = data.Description,
                    Address = data.Address,
                    Name = data.Name,
                    PhoneNumber = data.PhoneNumber
                };
                await _context.Warehouses.AddAsync(warehouse);
                await _context.SaveChangesAsync();
                return warehouse;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }

        }

        public async Task updateAsync(Warehouse data)
        {
            try
            {
                var warehouse = await _context.Warehouses.FirstOrDefaultAsync(x => x.Id == data.Id);
                if (warehouse != null)
                {
                    warehouse.Name = data.Name;
                    warehouse.Description = data.Description;
                    warehouse.Address = data.Address;
                    warehouse.PhoneNumber = data.PhoneNumber;
                }
                _context.Warehouses.Update(warehouse);
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
