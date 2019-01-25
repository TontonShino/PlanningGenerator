using PlanningGenerator.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanningGenerator.Models
{
    public class InitRolesData
    {
        public static async Task Initialize(ApplicationDbContext context,
                          UserManager<AppUser> userManager,
                          RoleManager<AppIdentityRole> roleManager)
        {
            context.Database.EnsureCreated();

            string[] roleName = { "Admin", "Member", "Server Admin" };
            string[] roleDesc = { "Super administrator", "Member of site", "Server Administrator" };

            for (int i = 0; i < roleName.Length; i++)
            {
                if (await roleManager.FindByNameAsync(roleName[i]) == null)
                {
                    await roleManager.CreateAsync(new AppIdentityRole(roleName[i], roleDesc[i], DateTime.Now));
                }
            }
            var superAdmin = new AppUser
            {
                EmailConfirmed = true,
                Nom = "TurfuPower",
                Prenom = "Okheu",
                UserName = "XeuXeu",
                Email="xeu@xeu.fr"
                
                
            };
            string password = "Admin123";
            await userManager.CreateAsync(superAdmin, password);
            await userManager.AddToRoleAsync(superAdmin, "Admin");
        }
    }
}
