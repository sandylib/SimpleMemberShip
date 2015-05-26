
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SimpleMemberShip.Models
{
    public class SimpleMemberDB : DbContext
    {
        public SimpleMemberDB() : base("name=DefaultConnection")
        {

        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        //public DbSet<Dealer> Restaurants { get; set; }
        //public DbSet<Commission> Reviews { get; set; }
    }
}