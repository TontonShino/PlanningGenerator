using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PlanningGenerator.Models.Pln;

namespace PlanningGenerator.Models.Pln
{
    public partial class PlnContext : DbContext
    {
        public PlnContext() { }
        public PlnContext(DbContextOptions<PlnContext> options) : base(options) { }

        public virtual DbSet<Employe> Employe { get; set; }
        public virtual DbSet<Hour> Hour { get; set; }
        public virtual DbSet<Day> Day { get; set; }
        public virtual DbSet<Planning> Planning { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<TypeEmp> TypeEmp { get; set; }
        public virtual DbSet<GroupPostCat> GroupPostCat { get; set; }
        public virtual DbSet<GroupEmp> GroupEmp { get; set; }
        public virtual DbSet<GroupEmpCat> GroupEmpCat { get; set; }
        public virtual DbSet<GroupPost> GroupPost { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Ignore<IdentityUserLogin<string>>();
            modelBuilder.Ignore<IdentityUserRole<string>>();
            modelBuilder.Ignore<IdentityUserClaim<string>>();
            modelBuilder.Ignore<IdentityUserToken<string>>();
            modelBuilder.Ignore<IdentityUser<string>>();

            
        }

        public DbSet<PlanningGenerator.Models.Pln.Dhe> Dhe { get; set; }




        

    }
}
