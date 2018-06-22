namespace Badminton_Sport.Models
{
    using Badminton_Sport.Models;
    using Badminton_Sport.Models.Data;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Badminton_Sport.Models.Data.WebContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Badminton_Sport.Models.Data.WebContext context)
        {

            var user = new USER()
            {
                USER_ID = "U_001",
                USERNAME = "admin",
                PASSWORD = "admin",
                FULLNAME = "Nguyen Duy Anh",
                EMAIL = "nguyen.duy.anh.9199@gmail.com",
                ISADMIN = 1

            };
            context.SaveChanges();


            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
