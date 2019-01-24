using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanningGenerator.Models.Pln
{
    public class GroupEmp
    {
        public int Id { get; set; }

        public Employe Employe { get; set; }
        public int EmployeId { get; set; } 

        public GroupEmpCat GroupEmpCat { get; set; }

        public int GroupEmpCatId { get; set; }

    }
}
