using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibmotInventory.Models
{
    public class StockCreateViewModel
    {
        public int Id { get; set; }
        [StringLength(50, MinimumLength = 5)]
        public string Name { get; set; }
        [StringLength(150, MinimumLength = 5)]
        public string Description { get; set; }
        [StringLength(50, MinimumLength = 5)]
        public string Manufacturer { get; set; }
        public double Price { get; set; }
        public string EmployeeId { get; set; }
        public int WarehouseId { get; set; }
        public SelectList employeeList { get; set; }
        public SelectList warehouseList { get; set; }
    }
}
