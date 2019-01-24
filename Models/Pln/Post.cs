using System;
using System.Collections.Generic;
using PlanningGenerator.Models.Pln;

namespace PlanningGenerator.Models
{
    public class Post
    {
        
        public int Id { get; set; }
        
        public string Nom { get; set; }
        public string Description { get; set; }

        public ICollection<GroupPost> GroupPost { get; set; } = new List<GroupPost>();
        public ICollection<Dhe> Dhe { get; set; } = new List<Dhe>(); 
        
    }
}