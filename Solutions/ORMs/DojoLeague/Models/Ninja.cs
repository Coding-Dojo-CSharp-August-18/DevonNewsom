using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DojoLeague.Models
{
    public class Ninja
    {
        public int ninja_id {get;set;}
        [Display(Name="Ninja Name")]
        public string name {get;set;}
        [Display(Name="Ninjaing Level (1-10)")]
        [Range(1, 10, ErrorMessage="Ninja level must be 1-10")]
        public int level {get;set;}
        [Display(Name="Optional Description")]
        [MinLength(10, ErrorMessage="Description must be 10 or more characters long")]
        public string description {get;set;}
        [Display(Name="Assigned Dojo?")]
        public int? dojo_id {get;set;}
        public Dojo Dojo {get;set;}
    }
}