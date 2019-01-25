using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PlanningGenerator.Models.Pln
{
    public partial class Hour
    {
        
        public string Id { get; set; }
        public int _hour { get; set; }
        public int _minutes { get; set; }
        public string _hms { get; set; }


        public ICollection<Dhe> Dhe { get; set; } = new List<Dhe>();
        
        [ForeignKey("StartingHourId")]
        public ICollection<Planning> StartingHour { get; set; } = new List<Planning>();
        
        [ForeignKey("EndingHourId")]
        public ICollection<Planning> EndingHour { get; set; } = new List<Planning>();

    }
}
