using System.Threading.Tasks;
using Business.Logic.Interfaces;
using Data.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LibmotInventory.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _service;
        private readonly UserManager<Employee> _userManager;

        public EmployeeController(IEmployeeService service, UserManager<Employee> userManager)
        {
            _service = service;
            _userManager = userManager;
        }
        // GET: Employee
        public async Task<ActionResult> Index()
        {
            ViewBag.Create = TempData["Create"];
            ViewBag.Update = TempData["Update"];
            ViewBag.Delete = TempData["Delete"];
            var data = await _service.GetAllAsync();
            return View(data);
        }

        // GET: Employee/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var data = await _service.GetAsync(id);
            return View(data);
        }

        // GET: Employee/Create
        public  ActionResult Create()
        {

            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Employee data)
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

        // GET: Employee/Edit/5
        public  async Task<ActionResult> Edit(string id)
        {
            var data = await _service.GetAsync(id);
            return View(data);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Employee data)
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

        // GET: Employee/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            var data = await _service.GetAsync(id);
            return View(data);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Employee data)
        {
            try
            {
                // TODO: Add delete logic here
                await _service.DeleteAsync(data.Id);
                TempData["Delete"] =true;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(data);
            }
        }
    }
}