namespace CallCentre.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using CallCentre.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<CallCentre.Models.CallCentreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CallCentre.Models.CallCentreContext context)
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

            context.Contacts.AddOrUpdate(
                c => c.Name,
                new Contact { Name = "Nelson", Email = "nelson@example.com" },
                new Contact { Name = "Jack", Phone = "0456123123" }
                );

            context.SaveChanges();
        }
    }
}
