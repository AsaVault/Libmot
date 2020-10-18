using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Domain.Entities
{
    public class Stock
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50, MinimumLength = 5)]
        public string Name { get; set; }
        [StringLength(150, MinimumLength = 5)]
        public string Description { get; set; }
        [StringLength(50, MinimumLength = 5)]
        public string Manufacturer { get; set; }
        public double Price { get; set; }
        public String EmployeeId { get; set; }
        
        public Employee CreatedBy { get; set; }
        public int WarehouseId { get; set; }
        public Warehouse Store { get; set; }
    }
}
