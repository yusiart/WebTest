using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestWebApp.Models
{
    public class Address
    {
        [Key] public int AddressId { get; set; }
        public int CustomerId { get; set; }
        [Required] [StringLength(50)] public string StreetAddress { get; set; }
        [Required] [StringLength(20)] public string Zip { get; set; }
        public int CountryId { get; set; }
        
        public Country Country { get; set; }
        public Customer Customer { get; set; }
    }
}