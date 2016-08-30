namespace DemoBlogWasteOfTimeTeam.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Collections.Generic;
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

            var postsFromDb = context.Posts.FirstOrDefault();
            if (postsFromDb == null)
            {
                var user = userManager.Users.FirstOrDefault(x => x.Email == "regular@gmail.com");
               
                    var post1 = new Post() { };
                    post1.Category = Category.Rock;
                    post1.Date = DateTime.Now;
                post1.Comment = "This Song is awsome ";
                post1.Song = "Deep Purple-Soldier of Fortune ";
                    post1.Video = @"<iframe width=""420"" height=""315"" src=""https://www.youtube.com/embed/RKrNdxiBW3Y"" frameborder=""0"" allowfullscreen></iframe>";
                    post1.Author = user;

                    context.Posts.Add(post1);
                var post2 = new Post() { };
                post2.Category = Category.Ska;
                post2.Date = DateTime.Now;
                post2.Comment = "I love this song! ";
                post2.Song = "Reel Big Fish - Beer";
                post2.Video = @"<iframe width=""420"" height=""315"" src=""https://www.youtube.com/embed/SCgX4ixCRcQ"" frameborder=""0"" allowfullscreen></iframe>";
                post2.Author = user;

                context.Posts.Add(post2);
                var post3 = new Post() { };
                post3.Category = Category.Alternative;
                post3.Date = DateTime.Now;
                post3.Comment = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo.Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum fugiat quo voluptas nulla pariatur ? ";

               post3.Song = "Linkin Park - In The End";
                post3.Video = @"<iframe width=""420"" height=""315"" src=""https://www.youtube.com/embed/eVTXPUF4Oz4"" frameborder=""0"" allowfullscreen></iframe>";
                post3.Author = user;

                context.Posts.Add(post3);
                var post4 = new Post() { };
                post4.Category = Category.Hardcore;
                post4.Date = DateTime.Now;
                post4.Comment = "What happened with the passion?";
                post4.Song = "H2O - What Happened";
                post4.Video = @"<iframe width=""420"" height=""315"" src=""https://www.youtube.com/embed/c1kgZLgWpb"" frameborder=""0"" allowfullscreen></iframe>";
                post4.Author = user;

                context.Posts.Add(post4);
                var post5 = new Post() { };
                post5.Category = Category.Punk;
                post5.Date = DateTime.Now;
                post5.Comment = "Super";
                post5.Song = "Letcite - Dokoga";
                post5.Video = @"<iframe width=""420"" height=""315"" src=""https://www.youtube.com/embed/Kbi0uIKeaEw"" frameborder=""0"" allowfullscreen></iframe>";
                post5.Author = user;

                context.Posts.Add(post5);

                context.SaveChanges();
            }
        }
    }
}
