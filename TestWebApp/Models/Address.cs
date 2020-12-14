using System.ComponentModel.DataAnnotations;

namespace TestWebApp.Models
{
    public class Address
    {
        [Key] public int AddressId { get; set; }
        [Required] public int CustomerId { get; set; }
        [Required] [StringLength(50)] public string StreetAddress { get; set; }
        [Required] [StringLength(20)] public string Zip { get; set; }
        [Range(1, 3)]public int CountryId { get; set; }
        
        public Country Country { get; set; }
        public Customer Customer { get; set; }
    }
}