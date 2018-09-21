using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginRegEF.Models
{
    public class Vote
    {
        [Key]
        public int vote_id {get;set;}
        public bool is_upvote {get;set;}
        public int user_id {get;set;}
        public int blog_id {get;set;}
        public DateTime created_at {get;set;} = DateTime.Now;
        public DateTime updated_at {get;set;} = DateTime.Now;

        // Reference to related Model (for Entity Framework)
        public MyUser Voter {get;set;}
        public Blog VotedBlog {get;set;}
        
    }
}