namespace SimpleMemberShip.Migrations
{
   
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;
    using WebMatrix.WebData;

    internal sealed class Configuration : DbMigrationsConfiguration<SimpleMemberShip.Models.SimpleMemberDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SimpleMemberShip.Models.SimpleMemberDB context)
        {
            
          

            SeedMembership();

        }

        private void SeedMembership()
        {
            WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);

            var roles = (SimpleRoleProvider)Roles.Provider;
            var membership = (SimpleMembershipProvider)Membership.Provider;

            if (!roles.RoleExists("Admin"))
            {
                roles.CreateRole("Admin");
            }

            if (membership.GetUser("sandy", false) == null)
            {   

                membership.CreateUserAndAccount("sandy", "sandy123");
            }

            if (!roles.GetRolesForUser("sandy").Contains("Admin"))
            {
                roles.AddUsersToRoles(new[] { "sandy" }, new[] { "Admin" });
            }


            if (!roles.RoleExists("Dealer"))
            {
                roles.CreateRole("Dealer");
            }

            if (membership.GetUser("mike", false) == null)
            {
                membership.CreateUserAndAccount("mike", "mike123");
            }

            if (!roles.GetRolesForUser("mike").Contains("Dealer"))
            {
                roles.AddUsersToRoles(new[] { "mike" }, new[] { "Dealer" });
            }

        }
    }
}
