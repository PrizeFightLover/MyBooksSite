namespace MyBooksSite.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using MyBooksSite.Models;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyBooksSite.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MyBooksSite.Models.ApplicationDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole { Name = "Admin" };
                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "Overlord"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "Overlord" };

                manager.Create(user, "Password123!");
                manager.AddToRole(user.Id, "Admin");
            }

            if (!context.Roles.Any(r => r.Name == "Editor"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole { Name = "Editor" };

                manager.Create(role);
            }
        }
    }
}
