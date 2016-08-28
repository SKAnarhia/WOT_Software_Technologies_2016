namespace DemoBlogWasteOfTimeTeam.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<DemoBlogWasteOfTimeTeam.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DemoBlogWasteOfTimeTeam.Models.ApplicationDbContext context)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!roleManager.Roles.Any())
            {
                roleManager.Create(new IdentityRole { Name = "Regular"});
                roleManager.Create(new IdentityRole { Name = "Administrator"});
            }

            context.SaveChanges();

            var adminUser = userManager.Users.FirstOrDefault(x => x.Email == "admin@gmail.com");

            if (adminUser == null)
            {
                var admin = new ApplicationUser
                {
                    Email = "admin@gmail.com",
                    UserName = "admin@gmail.com",
                    EmailConfirmed = true,
                };

                userManager.Create(admin, "123456q");
                userManager.AddToRole(admin.Id, "Administrator");
            }

            context.SaveChanges();

            var regularUser = userManager.Users.FirstOrDefault(x => x.Email == "regular@gmail.com");

            if (regularUser == null)
            {
                var regular = new ApplicationUser
                {
                    Email = "regular@gmail.com",
                    UserName = "regular@gmail.com",
                    EmailConfirmed = true,
                };

                userManager.Create(regular, "123456q");
                userManager.AddToRole(regular.Id, "Regular");
                regularUser = regular;
            }

            context.SaveChanges();
        }
    }
}
