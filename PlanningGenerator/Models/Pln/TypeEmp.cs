using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace PlanningGenerator.Models.Pln
{
    public class TypeEmp
    {
        public int Id { get; set; }
        [DisplayName("Type employé")]
        public string Nom { get; set; }
        [DisplayName("Nombre d'heure")]
        public int NbHeure { get; set; }
        [DisplayName("Demi-heure")]
        public bool Half { get; set; }

        public ICollection<Employe> Employe { get; set; } = new List<Employe>();

         
    }
}
