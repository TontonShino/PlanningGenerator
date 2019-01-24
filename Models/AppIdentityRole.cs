using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace PlanningGenerator.Models
{
    public class AppIdentityRole : IdentityRole
    {
        public AppIdentityRole() : base() { }

        public AppIdentityRole(string rolename) : base(rolename) { }

        public AppIdentityRole(string roleName, string description,
            DateTime createdDate)
            : base(roleName)
        {
            base.Name = roleName;

            this.Description = description;
            this.CreatedDate = createdDate;
        }

        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
