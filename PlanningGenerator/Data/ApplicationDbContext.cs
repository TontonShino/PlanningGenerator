using System;
using System.Collections.Generic;
using System.Text;
using PlanningGenerator.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PlanningGenerator.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser,AppIdentityRole,string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
