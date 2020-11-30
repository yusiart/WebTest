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

                //context.Database.EnsureCreated();

                if (context.Customers.Any())
                {
                    return;
                }

                context.Customers.AddRange(
                        new Customer
                        {
                            FullName = "Alez",
                            Email = "example@gmail.com",
                            Birthdate = DateTime.Parse("1995-8-11"),
                            Gender = Gender.male

                        },

                        new Customer
                        {
                            FullName = "Rick",
                            Email = "alex@gmail.com",
                            Birthdate = DateTime.Parse("1995-3-12"),
                            Gender = Gender.female

                        },

                        new Customer
                        {
                            FullName = "Alex",
                            Email = "mikhail@inbox.com",
                            Birthdate = DateTime.Parse("1992-8-22"),
                            Gender = Gender.male

                        });

                context.SaveChanges();



                // Addresses
                if (context.Addresses.Any())
                {
                    return;
                }


                context.Addresses.AddRange(
                       new Address
                       {
                           CustomerId = 1,
                           StreetAddress = "Baker",
                           Country = Country.Latvia,
                           Zip = "Lv42",
                           CountryId = 2
                       },

                    new Address
                    {
                        CustomerId = 1,
                        StreetAddress = "Rigas",
                        Country = Country.Latvia,
                        Zip = "Lv41",
                        CountryId = 2
                    },

                    new Address
                    {
                        CustomerId = 1,
                        StreetAddress = "Sauiles",
                        Country = Country.Russia,
                        Zip = "Rus42",
                        CountryId = 4
                    });


                context.SaveChanges();
            }
        }
    }
}