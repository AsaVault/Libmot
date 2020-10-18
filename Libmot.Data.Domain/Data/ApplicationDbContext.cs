using System;
using System.Collections.Generic;
using System.Text;
using Data.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Libmot.WebApplication.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Stock> Stocks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>().HasData(
                new Employee()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Olanrewaju Samuel",
                    UserName = "Admin",
                    PasswordHash = "Admin123@",
                    Email = "asamoja9100@gmail.com",
                    EmailConfirmed = true,
                    PhoneNumber = "07067147323",
                    PhoneNumberConfirmed = true,
                    Address = "38 Fortune Spring Drive Lagos"
                }
                );
        }

    }
}
