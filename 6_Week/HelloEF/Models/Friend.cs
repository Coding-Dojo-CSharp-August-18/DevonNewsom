using System;
using System.ComponentModel.DataAnnotations;

namespace HelloEF.Models
{
    public class Friend
    {
        [Key]
        public int FriendId {get;set;}
        [Required]
        public string Name {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
    
}