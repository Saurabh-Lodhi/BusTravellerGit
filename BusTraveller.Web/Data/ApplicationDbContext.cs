using BusTraveller.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace BusTraveller.Web.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }

       public DbSet<Destination> Destinations { get; set; }
       public DbSet<Registration> FeedBacks { get; set; }
    }
}
