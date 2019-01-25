using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel; 

namespace PlanningGenerator.Models.Pln
{
    public class Employe
    {
        [DisplayName("N° Identifiant")]
        public int Id { get; set; }
        public string Nom { get; set; }
        [DisplayName("Prénom")]
        public string Prenom { get; set; }
        public int TypeEmpId { get; set; }
        public TypeEmp TypeEmp { get; set; }

        public Employe() { Dhe = new HashSet<Dhe>(); }

        public ICollection<GroupEmpCat> GroupEmp { get; set; } = new List<GroupEmpCat>();

        public ICollection<Dhe> Dhe { get; set; }


        public int GetConesNb(Employe emp)
        {

            if (emp.TypeEmp.Half == true)
            {
                return (emp.TypeEmp.NbHeure * 2) + 1;
            }
            else
            {
                return emp.TypeEmp.NbHeure * 2;
            }
        }

        internal int GetConesNb()
        {
            throw new NotImplementedException();
        }
    }
}
