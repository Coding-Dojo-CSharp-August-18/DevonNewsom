using System.ComponentModel.DataAnnotations;

namespace LoginFun.Models
{
    public class RegistrationUser
    {
        [Required]
        [Display(Name="First Name")]
        [MinLength(2, ErrorMessage="Name fields must be 2 characters or more")]
        [MaxLength(20, ErrorMessage="Name fields must be 20 characters or less")]
        [RegularExpression(@"^[A-Za-z''-'\s]{2,10}$", ErrorMessage="Name fields must only contain letters, apostrophies, and whitespace")]
        public string first_name {get;set;}

        [Required]
        [Display(Name="Last Name")]
        [MinLength(2, ErrorMessage="Name fields must be 2 characters or more")]
        [MaxLength(20, ErrorMessage="Name fields must be 20 characters or less")]
        [RegularExpression(@"^[A-Za-z''-'\s]{2,10}$", ErrorMessage="Name fields must only contain letters, apostrophies, and whitespace")]
        public string last_name {get;set;}

        [Required]
        [EmailAddress]
        [Display(Name="Email Address")]
        public string email {get;set;}

        [Required]
        [DataType(DataType.Password)]
        [Display(Name="Password")]
        public string password {get;set;}

        [DataType(DataType.Password)]
        [Required]
        [Compare("password")]
        [Display(Name="Confirm Password")]
        public string confirm {get;set;}
    }
    public class LoginUser
    {
        [Required]
        [EmailAddress]
        public string email {get;set;}
        [Required]
        [DataType(DataType.Password)]
        public string password {get;set;}
    }
}