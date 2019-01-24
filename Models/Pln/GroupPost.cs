using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanningGenerator.Models.Pln
{
    public class GroupPost
    {
        public int Id { get; set; }

        public Post Post { get; set; }
        public int PostId { get; set; }

        public GroupPostCat GroupPostCat { get; set; }
        public int GroupPostCatId { get; set; }

    }
}
