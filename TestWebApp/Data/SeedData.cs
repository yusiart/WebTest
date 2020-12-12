using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TestWebApp.Models;

namespace TestWebApp.Data
{
    public static class SeedData
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CustomerContext(
                serviceProvider.GetRequiredService<DbContextOptions<CustomerContext>>()))
            {
                CreateCountry(context);
                CreateCustomers(context);
                CreateAddress(context);
            }
        }

        private static void CreateAddress(CustomerContext context)
        {
            if (context.Addresses.Any())
            {
                return;
            }
            
            context.Addresses.AddRange(
                new Address
                {
                    CustomerId = 1,
                    StreetAddress = "Baker",
                    Zip = "Lv42",
                    CountryId = 2
                },
                new Address
                {
                    CustomerId = 1,
                    StreetAddress = "Rigas",
                    Zip = "Lv41",
                    CountryId = 2
                },
                new Address
                {
                    CustomerId = 1,
                    StreetAddress = "Sauiles",
                    Zip = "Rus42",
                    CountryId = 1
                });


            context.SaveChanges();
        }

        private static void CreateCustomers(CustomerContext context)
        {
            if (context.Customers.Any())
            {
                return ;
            }

            context.Customers.AddRange(
                new Customer
                {
                    FullName = "Alez",
                    Email = "example@gmail.com",
                    Birthdate = DateTime.Parse("1995-8-11"),
                    Gender = Gender.Male
                },
                new Customer
                {
                    FullName = "Rick",
                    Email = "alex@gmail.com",
                    Birthdate = DateTime.Parse("1995-3-12"),
                    Gender = Gender.Female
                },
                new Customer
                {
                    FullName = "Alex",
                    Email = "mikhail@inbox.com",
                    Birthdate = DateTime.Parse("1992-8-22"),
                    Gender = Gender.Male
                });

            context.SaveChanges();
        }

        private static void CreateCountry(CustomerContext context)
        {
            if (context.Countries.Any())
            {
                return;
            }

            context.Countries.AddRange(
                new Country
                {
                    CountryId = 2,
                    Name = "Latvia"
                },
                new Country
                {
                    CountryId = 1,
                    Name = "Russia"
                });

            context.SaveChanges();
        }
    }
}