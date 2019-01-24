using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PlanningGenerator.Models.Pln
{
    public class Day
    {
        public int Id { get; set; }
        public string Fr { get; set; }
        public string En { get; set; }


        public ICollection<Dhe> Dhe { get; set; }

        [ForeignKey("StartingDayId")]
        public ICollection<Planning> StartingDay { get; set; } = new List<Planning>();

        [ForeignKey("EndingDayId")]
        public ICollection<Planning> EndingDay { get; set; } = new List<Planning>();
    }
}
