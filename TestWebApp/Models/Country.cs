using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestWebApp.Models
{
    public class Country
    { 
        [Key] public int CountryId { get; set; }
        [Required] public string Name { get; set; }
        public ICollection<Address> Addresses { get; set; }
    }
}