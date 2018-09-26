using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace LoginRegEF.Models
{
    public class Blog
    {
        [Key]
        public int blog_id {get;set;}
        public int user_id {get;set;}
        [Display(Name="Title")]
        [Required]
        public string title {get;set;}
        [Required]
        [MinLength(10, ErrorMessage="Blog must be 10 characters or more!")]
        public string content {get;set;}
        public DateTime created_at {get;set;} = DateTime.Now;
        public DateTime updated_at {get;set;} = DateTime.Now;

        // Reference to related Model (for Entity Framework)
        public MyUser Author {get;set;}
        public IEnumerable<Vote> Votes {get;set;}
       
    }
}