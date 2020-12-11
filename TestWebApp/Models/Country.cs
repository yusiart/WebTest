using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestWebApp.Models
{
    public class Country
    {
        [Key] public int CountryId { get; set; }
        public string Name { get; set; }
        // public int AddressId { get; set; }
    }
}