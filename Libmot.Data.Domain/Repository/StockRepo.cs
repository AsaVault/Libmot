using Data.Domain.Entities;
using Data.Domain.IRepository;
using Libmot.WebApplication.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Domain.Repository
{
    public class StockRepo:IRepo<Stock>
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<StockRepo> _logger;
        public StockRepo(ApplicationDbContext context, ILogger<StockRepo> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task deleteAsync(int ID)
        {
            try
            {
                var data = await _context.Stocks.FindAsync(ID);
                _context.Stocks.Remove(data);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        public async Task<List<Stock>> getAllAsync()
        {
            return await _context.Stocks.Include(x=>x.CreatedBy).Include(x=>x.Store).ToListAsync();
        }

        public async Task<Stock> getAsync(int ID)
        {
            try
            {
                var data = await _context.Stocks.FindAsync(ID);
                return data;
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
                throw ex;
            }

        }

        public async Task<Stock> insertAsync(Stock data)
        {
            try
            {
                var stock = new Stock()
                {
                    Id = data.Id,
                    Description = data.Description,
                    Manufacturer = data.Manufacturer,
                    Name = data.Name,
                    Price = data.Price
                };
                await _context.Stocks.AddAsync(data);
                await _context.SaveChangesAsync();
                return data;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        public async Task updateAsync(Stock data)
        {
            try
            {
                var stock = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == data.Id);
                if (stock != null)
                {
                    stock.Name = data.Name;
                    stock.Description = data.Description;
                    stock.Manufacturer = data.Manufacturer;
                    stock.Price = data.Price;
                }
                _context.Stocks.Update(stock);
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
