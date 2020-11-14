using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBookProject.Models
{
    public class AddressRecord
    {
        public int id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Full Name")]
        [NotMapped]
        public string FullName { get { return $"{FirstName} {LastName}"; } }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Avatar")]
        public string ImagePath { get; set; }
        [Display(Name = "Avatar")]
        public byte[] ImageData { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Address")]
        public string Address1 { get; set; }

        [StringLength(20)]
        public string Address2 { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [Required]
        [StringLength(50)]
        public string State { get; set; }

        [Required]
        [DataType(DataType.PostalCode)]
        [Display(Name = "Zip Code")]
        [RegularExpression("^[0-9]{5,5}$", ErrorMessage = "Please Enter A 5 Digit Zip Code")]
        public string ZipCode { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(14, ErrorMessage = "Please Enter A Valid 10 Digit Phone Number", MinimumLength = 10)]
        [RegularExpression(@"^(\+\s?)?((?<!\+.*)\(\+?\d+([\s\-\.]?\d+)?\)|\d+)([\s\-\.]?(\(\d+([\s\-\.]?\d+)?\)|\d+))*(\s?(x|ext\.?)\s?\d+)?$", ErrorMessage = "Please Enter A Valid 10 Digit Phone Number")]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Date)]
        [Display(Name ="Date Added")]
        public DateTimeOffset Created { get; set; }

        [DataType(DataType.Date)]
        public DateTimeOffset? Updated { get; set; }

        [StringLength(100)]
        public string Note { get; set; }
    }
}
