using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlanningGenerator.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlanningGenerator.Models;
using PlanningGenerator.Models.Pln;
using Microsoft.AspNetCore.Identity.UI.Services;
using PlanningGenerator.Areas.Identity.Services;

namespace PlanningGenerator
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //On ajoute la db Context de base données identity
            services
                .AddDbContext<ApplicationDbContext>(options => options
                .UseMySql(
                    Configuration
                    .GetConnectionString("LocalConnection")));

            //On ajoute la dbContext Planning
            services
                .AddDbContext<PlnContext>(options => options
                .UseMySql(
                    Configuration
                    .GetConnectionString("LocalConnection")));

            //On ajoute les services d'identité et de role
            services
               .AddIdentity<AppUser, AppIdentityRole>(c =>
               {
                   c.SignIn.RequireConfirmedEmail = true; //Confirmation d'email requis
                   c.Password.RequireNonAlphanumeric = false; // Les mots de passes ne requière pas de caractères spéciaux
               })
               .AddDefaultTokenProviders()
               .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1).AddRazorPagesOptions(options =>
            {
                options.AllowAreas = true;
                options.Conventions.AuthorizeAreaFolder("Identity", "/Account/Manage");
                options.Conventions.AuthorizeAreaPage("Identity", "/Account/Logout");

            });

            //Ajout des services de cookie
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/Identity/Account/Login";
                options.LogoutPath = $"/Identity/Account/Logout";
                options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
            });

            //Ajout du service Mail avec ses paramètres
            services.AddTransient<IEmailSender, EmailSender>(i => new EmailSender(
                Configuration["EmailSender:Host"],
                Configuration.GetValue<int>("EmailSender:Port"),
                Configuration.GetValue<bool>("EmailSender:EnableSSL"),
                Configuration["EmailSender:UserName"],
                Configuration["EmailSender:Password"])
                );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env,
            ApplicationDbContext context,
            RoleManager<AppIdentityRole> roleManager,
            UserManager<AppUser> userManager,
            PlnContext plnContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            
            InitRolesData.Initialize(context, userManager, roleManager).Wait();//On initialise les rôles par défaut
            InitHoursDays.Initialize(plnContext).Wait();//On initialise les heures et les jours
        }
    }
}
