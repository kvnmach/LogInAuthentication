using LogInAuthentication.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LogInAuthentication.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LogInAuthentication.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LogInAuthentication.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var userRole = new UserStore<ApplicationUser>(context);
            var managerRole = new UserManager<ApplicationUser>(userRole);
            var userJob = new RoleStore<IdentityRole>(context);
            var managerJob = new RoleManager<IdentityRole>(userJob);

            if (!context.Roles.Any())
            {
                managerJob.Create(new IdentityRole("Admin"));
                managerJob.Create(new IdentityRole("Developer"));
                managerJob.Create(new IdentityRole("Secretary"));
            }

            if (!context.Users.Any(x => x.UserName == "kvnmach@gmail.com"))
            {
                var user = new ApplicationUser
                {
                    FirstName = "Kevin",
                    LastName = "Mach",
                    DateOfBirth = DateTime.Parse("10/10/1990"),
                    Hello = "Hello",
                    Email = "kvnmach@gmail.com",
                    UserName = "kvnmach@gmail.com"
                };
                managerRole.Create(user, "Passcode!1");
                managerRole.AddToRole(user.Id, "Admin");

                var user2 = new ApplicationUser
                {
                    FirstName = "Kevin",
                    LastName = "Mach",
                    DateOfBirth = DateTime.Parse("10/10/1990"),
                    Hello = "Hello",
                    Email = "kvnmach@gmail.com",
                    UserName = "kvnmach@gmail.com"
                };
                managerRole.Create(user, "Passcode!1");
                managerRole.AddToRole(user.Id, "Dev");

                var user3 = new ApplicationUser
                {
                    FirstName = "Kevin",
                    LastName = "Mach",
                    DateOfBirth = DateTime.Parse("10/10/1990"),
                    Hello = "Hello",
                    Email = "kvnmach@gmail.com",
                    UserName = "kvnmach@gmail.com"
                };
                managerRole.Create(user, "Passcode!1");
                managerRole.AddToRole(user.Id, "Dev");

                var user4 = new ApplicationUser
                {
                    FirstName = "Kevin",
                    LastName = "Mach",
                    DateOfBirth = DateTime.Parse("10/10/1990"),
                    Hello = "Hello",
                    Email = "kvnmach@gmail.com",
                    UserName = "kvnmach@gmail.com"
                };
                managerRole.Create(user, "Passcode!1");
                managerRole.AddToRole(user.Id, "Dev");
            }
        }
    }
}
