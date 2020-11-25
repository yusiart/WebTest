using System;
using System.ComponentModel.DataAnnotations;

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

        public int CustomerId { get; set; }
        public string StreetAddress { get; set; }
        public Country Country { get; set; }
        public string Zip { get; set; }
        public int CountryId { get; set; }
  

        public Address(int customerId, string streetAdress, Country country, string zip, int countryId)
        {
            CustomerId = customerId;
            StreetAddress = streetAdress;
            Country = country;
            Zip = zip;
            CountryId = countryId;
        }
    }
  
}