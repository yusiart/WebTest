using System;
using Microsoft.EntityFrameworkCore;
using TestWebApp.Models;

namespace TestWebApp.Data
{
    public class CustomerContext : DbContext
    {
        public CustomerContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public CustomerContext(DbContextOptions<CustomerContext> options)
             : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
