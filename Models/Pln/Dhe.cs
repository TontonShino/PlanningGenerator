using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanningGenerator.Models.Pln
{
    public partial class Dhe
    {
        
        public Dhe() { }
        public int Id { get; set; }
        public int DayId { get; set; }
        public string HourId { get; set; }
        public int EmployeId { get; set; }
        public int PostId { get; set; }

        public Day Day { get; set; }
        public Hour Hour { get; set; }
        public Employe Employe { get; set; }
        public Post Post { get; set; }

    }
}
