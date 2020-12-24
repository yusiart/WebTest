using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TestWebApp.Models
{
    public enum Gender
    {
        Male,
        Female
    }

    public class Customer
    {
        [Key] [Required] public int CustomerId { get; set; }
        [Required] public string FullName { get; set; }
        [Required] [StringLength(30)] public string Email { get; set; }
        [Required] public DateTime Birthdate { get; set; }
        [Required] public Gender Gender { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
