using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TestWebApp.Models
{
    public enum Gender
    {
        male,
        female
    }

    public partial class Customer
    {
        public Customer()
        {
            this.Addresses = new HashSet<Address>();
        }


        [Key]
        public int CustomerId { get; set; }

        public string FullName { get; set; }
        [Required]
        [StringLength(30)]
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public Gender Gender { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
