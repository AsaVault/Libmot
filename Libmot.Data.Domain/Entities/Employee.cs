using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Domain.Entities
{
    public class Employee:IdentityUser
    {
        //[Key]
        //public int Id { get; set; }
        [StringLength(150, MinimumLength = 5)]
        public string Name { get; set; }
        //public string UserName { get; set; }
        //public string Password { get; set; }
        //public string PhoneNumber { get; set; }
        public string Address { get; set; }
        //public string Email { get; set; }
        public List<Stock> Stocks { get; set; }

    }
}
