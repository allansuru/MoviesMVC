using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Vidly.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Custumer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
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