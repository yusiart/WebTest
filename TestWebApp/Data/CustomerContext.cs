using System;
using Microsoft.EntityFrameworkCore;
using TestWebApp.Models;

namespace TestWebApp.Data
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options)
             : base(options)
        {
        }

        public DbSet<Customers> Customers { get; set; }
    }
}
