using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WeddingPlanner.Models
{
    public class MyUser
    {
        [Key]
        public int UserId {get;set;}
        [Display(Name="First Name")]
        [Required]
        public string FirstName {get;set;}
        [Display(Name="Last Name")]
        public string LastName {get;set;}
        [Display(Name="Email")]
        [EmailAddress]
        public string Email {get;set;}
        [Display(Name="Password")]
        [DataType(DataType.Password)]
        public string Password {get;set;}

        [NotMapped]
        [Display(Name="Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string Confirm {get;set;}

        // Reference to related Model (for Entity Framework)
        
    }
    public class LoginUser
    {
        [Display(Name="Email")]
        [EmailAddress]
        public string Email {get;set;}
        [Display(Name="Password")]
        [DataType(DataType.Password)]
        public string Password {get;set;}
    }
}