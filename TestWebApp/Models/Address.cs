using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestWebApp.Models
{
    public enum Country
    {
       Latvia,
       Russia,
    }

    public class Address
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        [Required]
        [StringLength(50)]
        public string StreetAddress { get; set; }
        public Country Country { get; set; }
        [Required]
        [StringLength(20)]
        public string Zip { get; set; }
        [Required]
        public int CountryId { get; set; }
        public Customer Customer { get; set; }
    }
}