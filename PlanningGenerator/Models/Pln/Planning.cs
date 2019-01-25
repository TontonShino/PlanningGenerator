using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanningGenerator.Models.Pln
{
    public class Planning
    {

        public int Id { get; set; }
        public string Nom { get; set; }

        public GroupPostCat GroupPost { get; set; }
        public int GroupPostCatId { get; set; }


        public GroupEmpCat GroupEmpCat { get; set; }
        public int GroupEmpCatId { get; set; }


        public int StartingDayId { get; set; }
        public int EndingDayId { get; set; }

        public string StartingHourId { get; set; }
        public string EndingHourId { get; set; }

        [DisplayName("Journée entière")]
        public bool FullJourney { get; set; }

        [DisplayName("Semaine entière")]
        public bool FullWeek { get; set; }

        [DisplayName("Date de création")]
        public DateTime CreatedAt { get; set; }


        public virtual ICollection<Dhe> Dhe { get; set; } = new List<Dhe>();

        

    }
}
