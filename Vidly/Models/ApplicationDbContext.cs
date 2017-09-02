using System;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Vidly.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public DbSet <MembershipType> MembershipTypes { get; set; }
        public ApplicationDbContext()
                 : base("conn", throwIfV1Schema: false)
        {
       
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

   
    }
}