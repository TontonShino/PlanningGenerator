using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace PlanningGenerator.Models.Pln
{
    public class GroupPostCat
    {
        public int Id { get; set; }
        [DisplayName("Nom du groupe")]
        public string Name { get; set; }

        public ICollection<GroupPost> GroupPost { get; set; } = new List<GroupPost>();
        public ICollection<Planning> Planning { get; set; } = new List<Planning>();
    }
}
