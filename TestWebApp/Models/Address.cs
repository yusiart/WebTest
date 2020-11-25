using System;
using System.ComponentModel.DataAnnotations;

namespace TestWebApp.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public Address(string name)
        {
            Name = name;
        }
    }
}
