using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CustomerReading.Entities
{
    [Table("CUSTOMER_DETAILS")]
    public class Customer
    {
        [Display(Name = "Id")]
        [Required(ErrorMessage = "The Id is required")]
        [Column("ID")]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "The First Name is required")]
        [Column("FIRST_NAME")]
        public string FirstName { get; set; }

        [Display(Name = "LastName")]
        [Required(ErrorMessage = "The Last Name is required")]
        [Column("LAST_NAME")]
        public string LastName { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Column("EMAIL_ADDRESS")]
        public string Email { get; set; }

        [Required]
        [Column("ADDRESS")]
        public string Address { get; set; }

        [Required]
        [RegularExpression("^\\d{10}$", ErrorMessage = "Invalid contact format.")]
        [Column("CONTACT")]
        public string ContactNo { get; set; }
    }
}
