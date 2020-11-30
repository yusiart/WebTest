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

        public string StreetAddress { get; set; }
        public Country Country { get; set; }
        public string Zip { get; set; }
        public int CountryId { get; set; }
        public Customer Customer { get; set; }


        //public Address(int customerId, string streetAddress, Country country, string zip, int countryId)
        //{
        //    CustomerId = customerId;
        //    StreetAddress = streetAddress;
        //    Country = country;
        //    Zip = zip;
        //    CountryId = countryId;
        //}
    }
}