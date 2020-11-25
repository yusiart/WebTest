using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestWebApp.Models
{
    public enum Gender
    {
        male,
        female
    }

    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public Gender Gender { get; set; }
        public List<Address> Addresses { get; set; }

        //public Customers(int id, string fullName, string email, DateTime birthdate)
        //{
        //    Id = id;
        //    FullName = fullName;
        //    Email = email;
        //    Birthdate = birthdate;
        //}
    }
}