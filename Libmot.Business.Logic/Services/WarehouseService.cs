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
    public class WarehouseService : IWarehouseService
    {
        private readonly IRepo<Warehouse> _wRepo;

        public WarehouseService(IRepo<Warehouse> wRepo)
        {
            _wRepo = wRepo;
        }
        public async Task DeleteAsync(int id)
        {
            await _wRepo.deleteAsync(id);
        }

        public async Task<List<Warehouse>> GetAllAsync()
        {
            var data = await _wRepo.getAllAsync();
            return data;
        }

        public async Task<Warehouse> GetAsync(int WID, int EID, int SID)
        {
            var ware = await _wRepo.getAsync(WID);

            return ware;
        }

        public async Task<Warehouse> SaveAsync(Warehouse data)
        {
            var warehouse = await _wRepo.insertAsync(data);
            return warehouse;
        }

        public async Task UpdateAsync(Warehouse data)
        {
            await _wRepo.updateAsync(data);
        }
    }
}
