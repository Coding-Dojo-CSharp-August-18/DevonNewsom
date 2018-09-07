using System;
using System.ComponentModel.DataAnnotations;

namespace DapperLecture.Models
{
    public class Friend
    {
        public int FriendId {get;set;}
        [Required]
        public string Name {get;set;}
        [Required]
        public string Location {get;set;}
        [DataType(DataType.Date)]
        public DateTime DOB {get;set;}
        public DateTime CreatedAt {get;set;}
    }
}