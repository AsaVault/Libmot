using System.Threading.Tasks;
using Business.Logic.Interfaces;
using Data.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibmotInventory.Controllers
{
    [Authorize]
    public class WarehouseController : Controller
    {
        private readonly IWarehouseService _service;

        public WarehouseController(IWarehouseService service)
        {
            _service = service;
        }
        // GET: Warehouse
        public async Task<ActionResult >Index()
        {
            ViewBag.Create = TempData["Create"];
            ViewBag.Update = TempData["Update"];
            ViewBag.Delete = TempData["Delete"];
            var data = await _service.GetAllAsync();
            return View(data);
        }

        // GET: Warehouse/Details/5
        public async Task<ActionResult >Details(int id)
        {
            var data = await _service.GetAsync(id, 0, 0);
            return View(data);
        }

        // GET: Warehouse/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Warehouse/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult >Create(Warehouse data)
        {
            try
            {
                // TODO: Add insert logic here
                await _service.SaveAsync(data);
                TempData["Create"] = true;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(data);
            }
        }

        // GET: Warehouse/Edit/5
        public async Task<ActionResult >Edit(int id)
        {
            var data = await _service.GetAsync(id, 0, 0);
            return View(data);
        }

        // POST: Warehouse/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Warehouse data)
        {
            try
            {
                // TODO: Add update logic here
                await _service.UpdateAsync(data);
                TempData["Update"] = true;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(data);
            }
        }

        // GET: Warehouse/Delete/5
        public async Task<ActionResult >Delete(int id)
        {
            var data = await _service.GetAsync(id, 0, 0);
            return View(data);
        }

        // POST: Warehouse/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Warehouse data)
        {
            try
            {
                // TODO: Add delete logic here
                await _service.DeleteAsync(data.Id);
                TempData["Delete"] = true;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(data);
            }
        }
    }
}