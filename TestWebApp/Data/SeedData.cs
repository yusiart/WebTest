using System;
using Microsoft.EntityFrameworkCore;
using TestWebApp.Models;
using TestWebApp.Data;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;


namespace TestWebApp.Data
{
    public static class SeedData
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CustomerContext(
                serviceProvider.GetRequiredService<DbContextOptions<CustomerContext>>()))
            {
               
                if (context.Customers.Any())
                {
                    return;
                }

                context.Customers.AddRange(
                    new Customer
                    {
                        Email = "example@gmail.com",
                        Birthdate = DateTime.Parse("1995-8-11"),
                        Gender = Gender.male,
                        Addresses = new List<Address> {new Address(2, "Baker street", Country.Latvia, "Lv", 009), new Address(1, "Baker street", Country.Latvia, "Ru", 77) }
                    },

                    new Customer
                    {
                        Email = "alex@gmail.com",
                        Birthdate = DateTime.Parse("1995-3-12"),
                        Gender = Gender.female,
                        Addresses = new List<Address> { new Address(77, "Rigas street", Country.Latvia, "Sw", 55), new Address(55, "Cinema street", Country.Russia, "Lv", 11) }
                    },

                    new Customer
                    {
                        Email = "mikhail@inbox.com",
                        Birthdate = DateTime.Parse("1992-8-22"),
                        Gender = Gender.male,
                        Addresses = new List<Address> { new Address(1, "Rezeknes street", Country.Russia, "DDS", 12), new Address(2, "Saules street", Country.Latvia, "Lv", 11) }
                    }
                ) ;
                context.SaveChanges();
            }
        }
    }
}
