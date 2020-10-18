using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Domain.Entities
{
    public class Warehouse
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50, MinimumLength = 5)]
        public string Name { get; set; }
        [StringLength(150, MinimumLength = 5)]
        public string Description { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public List<Stock> Stocks { get; set; }
    }
}
