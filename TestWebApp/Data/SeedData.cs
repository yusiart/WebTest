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
                        Addresses = new List<Address> {new Address("Baker street"), new Address("Saules Street") }
                    },

                    new Customer
                    {
                        Email = "alex@gmail.com",
                        Birthdate = DateTime.Parse("1995-3-12"),
                        Gender = Gender.female,
                        Addresses = new List<Address> { new Address("Baker street"), new Address("Saules Street") }
                    },

                    new Customer
                    {
                        Email = "mikhail@inbox.com",
                        Birthdate = DateTime.Parse("1992-8-22"),
                        Gender = Gender.male,
                        Addresses = new List<Address> { new Address("Baker street"), new Address("Saules Street") }
                    },

                    new Customer
                    {
                        Email = "example2@gmail.com",
                        Birthdate = DateTime.Parse("1998-2-23"),
                        Gender = Gender.female,
                        Addresses = new List<Address> { new Address("Baker street"), new Address("Saules Street") }
                    }
                ) ;
                context.SaveChanges();
            }
        }
    }
}
