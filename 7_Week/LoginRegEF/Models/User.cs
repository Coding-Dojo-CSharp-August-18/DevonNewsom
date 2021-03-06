using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LoginRegEF.Models
{
    public class MyUser
    {
        [Key]
        public int user_id {get;set;}
        [Display(Name="First Name")]
        [Required]
        public string first_name {get;set;}
        [Display(Name="Last Name")]
        public string last_name {get;set;}
        [Display(Name="Email")]
        [EmailAddress]
        public string email {get;set;}
        [Display(Name="Password")]
        [DataType(DataType.Password)]
        public string password {get;set;}
        public DateTime created_at {get;set;}
        public DateTime updated_at {get;set;}

        [NotMapped]
        [Display(Name="Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("password")]
        public string confirm {get;set;}
    }
    public class LoginUser
    {
        [Display(Name="Email")]
        [EmailAddress]
        public string email {get;set;}
        [Display(Name="Password")]
        [DataType(DataType.Password)]
        public string password {get;set;}
    }
}