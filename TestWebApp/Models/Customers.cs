using System;
using System.ComponentModel.DataAnnotations;

namespace TestWebApp.Models
{
    public enum Gender
    {
        male,
        female
    }

    public class Customers
    {
        [Key]
        public int CustomerId { get; set; }

        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public Gender Gender { get; set; }
        public Address Addresses { get; set; }

        //public Customers(int id, string fullName, string email, DateTime birthdate)
        //{
        //    Id = id;
        //    FullName = fullName;
        //    Email = email;
        //    Birthdate = birthdate;
        //}
    }
}