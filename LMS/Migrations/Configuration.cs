namespace LMS.Migrations
{
    using LMS.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LMS.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LMS.Models.ApplicationDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == "Lärare"))
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                var role = new IdentityRole { Name = "Lärare" };

                roleManager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "Elev"))
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                var role = new IdentityRole { Name = "Elev" };

                roleManager.Create(role);
            }
            
            var userStore = new UserStore<ApplicationUser>(context);

            var userManager = new UserManager<ApplicationUser>(userStore);
            
            var user1 = new ApplicationUser{UserName = "testLärare@test.com", Email = "testLärare@test.com"};
            var user2 = new ApplicationUser { UserName = "testElev@test.com", Email = "testElev@test.com" };

            userManager.Create(user1, "Test123!");
            userManager.Create(user2, "Test123!");

            

            ApplicationUser user1a = context.Users.FirstOrDefault(u => u.Email == "testLärare@test.com");

            if (user1a != null)
            {
                userManager.AddToRole(user1.Id, "Lärare");
            }
            ApplicationUser user2a = context.Users.FirstOrDefault(u => u.Email == "testElev@test.com");
            if (user2a != null)
            {
                userManager.AddToRole(user2.Id, "Elev");
            }
            context.SaveChanges();
        }
    }
}
