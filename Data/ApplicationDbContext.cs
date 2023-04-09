using AppCollection.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AppCollection.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet <CollectLeadEntity> CollectLead { get; set; }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
    }
}
