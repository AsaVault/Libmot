using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Logic.Interfaces;
using Data.Domain.Entities;
using Data.Domain.IRepository;
using LibmotInventory.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibmotInventory.Controllers
{
    [Authorize]
    public class StockController : Controller
    {
        private readonly IStockService _service;
        private readonly UserManager<Employee> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public StockController(IStockService service, UserManager<Employee> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _service = service;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }
        // GET: Stock
        public async Task<IActionResult> Index()
        {
            ViewBag.Create = TempData["Create"];
            ViewBag.Update = TempData["Update"];
            ViewBag.Delete = TempData["Delete"];
            var data = await _service.GetAllAsync();
            return View(data);
        }

        // GET: Stock/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var data = await _service.GetAsync(id);
            return View(data);
        }

        // GET: Stock/Create
        public async Task<IActionResult> Create()
        {
            var data = new StockCreateViewModel()
            {
                //employeeList = new SelectList((IEnumerable<dynamic>) await _service.GetEmployeeDropdownList(),"Id","Name"),
               warehouseList = new SelectList((IEnumerable<dynamic>)await _service.GetWarehouseDropdownList(), "Id", "Name")
            };
            return View(data);
        }

        // POST: Stock/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StockCreateViewModel data)
        {
            try
            {
                // TODO: Add insert logic here
                var userId = _userManager.GetUserId(this.HttpContext.User);
                var model = new Stock()
                {
                    Name = data.Name,
                    Manufacturer = data.Manufacturer,
                    Description = data.Description,
                    Price = data.Price,
                    EmployeeId = userId,
                    WarehouseId = data.WarehouseId,
                    Id = data.Id
                };
                await _service.SaveAsync(model);
                TempData["Create"] = true;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(data);
            }
        }

        // GET: Stock/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var data = await _service.GetAsync(id);
            StockCreateViewModel model = new StockCreateViewModel()
            {
                Id = data.Id,
                EmployeeId = data.EmployeeId,
                WarehouseId = data.WarehouseId,
                Name = data.Name,
                Price = data.Price,
                Manufacturer = data.Manufacturer,
                Description = data.Description,
                employeeList = new SelectList((IEnumerable<dynamic>)await _service.GetEmployeeDropdownList(), "Id", "Name"),
                warehouseList = new SelectList((IEnumerable<dynamic>)await _service.GetWarehouseDropdownList(), "Id", "Name")
            };
            return View(model);
        }

        // POST: Stock/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(StockCreateViewModel model)
        {
            try
            {
                // TODO: Add update logic here
                var data = await _service.GetAsync(model.Id);
                data.Manufacturer = model.Manufacturer;
                data.Name = model.Name;
                data.Description = model.Description;
                data.Price = model.Price;
                data.EmployeeId = model.EmployeeId;
                data.WarehouseId = model.WarehouseId;
                await _service.UpdateAsync(data);
                TempData["Update"] = true;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }

        // GET: Stock/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var data = await _service.GetAsync(id);
            StockCreateViewModel model = new StockCreateViewModel()
            {
                Id = data.Id,
                EmployeeId = data.EmployeeId,
                WarehouseId = data.WarehouseId,
                Name = data.Name,
                Price = data.Price,
                Manufacturer = data.Manufacturer,
                Description = data.Description
            };
            return View(model);
        }

        // POST: Stock/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(StockCreateViewModel model)
        {
            try
            {
                // TODO: Add delete logic here
                var data = await _service.GetAsync(model.Id);
                await _service.DeleteAsync(data.Id);
                TempData["Delete"] = true;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }
    }
}