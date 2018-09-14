using System.Collections.Generic;

namespace DojoLeague.Models
{
    public class NinjaIndex
    {
        public List<Ninja> Ninjas {get;set;}
        public List<Dojo> Dojos {get;set;}
        public Ninja NewNinja {get;set;}
        
    }
    public class DojoIndex
    {
        public List<Dojo> Dojos {get;set;}
        public Dojo NewDojo {get;set;}
    }
    public class ShowDojo
    {
        public Dojo Dojo {get;set;}
        public List<Ninja> RogueNinjas {get;set;}
    }
}