using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DojoLeague.Models
{
    public class Dojo
    {
        [Key]
        public int dojo_id {get;set;}
        [Display(Name="Dojo Name")]
        [Required]
        [MinLength(2, ErrorMessage="Name must be 2 or more characters")]
        public string name {get;set;}
        [Display(Name="Dojo Location")]
        public string location {get;set;}
        [Display(Name="Additional Dojo Information")]
        [MinLength(10, ErrorMessage="Description must be 10 or more characters long")]
        public string description {get;set;}
        public List<Ninja> Members {get;set;} = new List<Ninja>();
    }
}