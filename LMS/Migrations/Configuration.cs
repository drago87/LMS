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
            //MigrationsDirectory = @"Migrations\User";
        }


        protected override void Seed(LMS.Models.ApplicationDbContext context)
        {
            //Update-Database -ConfigurationTypeName LMS.Migrations.User.Configuration
            if (!context.Roles.Any(r => r.Name == "Teacher"))
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                var role = new IdentityRole { Name = "Teacher" };

                roleManager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "Student"))
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                var role = new IdentityRole { Name = "Student" };

                roleManager.Create(role);
            }
            
            var userStore = new UserStore<ApplicationUser>(context);

            var userManager = new UserManager<ApplicationUser>(userStore);

            var user1 = new ApplicationUser { UserName = "testTeacher@test.com", Email = "testTeacher@test.com" };
            var user2 = new ApplicationUser { UserName = "testStudent@test.com", Email = "testStudent@test.com" };

            userManager.Create(user1, "Test123!");
            userManager.Create(user2, "Test123!");

            // ClassUnit Seed
            var klass1 = new ClassUnit { ClassName = "Grund1A" };
            var klass3 = new ClassUnit { ClassName = "Grund3A" };
            var klass2 = new ClassUnit { ClassName = "Grund5B" };
            context.MyClassUnit.AddOrUpdate(c => c.ClassUnitID, klass1);
            context.MyClassUnit.AddOrUpdate(c => c.ClassUnitID, klass2);
            context.MyClassUnit.AddOrUpdate(c => c.ClassUnitID, klass3);


            ApplicationUser user1a = context.Users.FirstOrDefault(u => u.Email == "testLärare@test.com");

            if (user1a != null)
            {
                userManager.AddToRole(user1.Id, "Teacher");
            }
            ApplicationUser user2a = context.Users.FirstOrDefault(u => u.Email == "testElev@test.com");
            if (user2a != null)
            {
                userManager.AddToRole(user2.Id, "Student");
            }
            context.SaveChanges();
        }
    }
}
