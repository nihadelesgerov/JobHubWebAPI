using JobHubWebAPI.DataLayer.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JobHubWebAPI.DataLayer.DataBaseConnection
{
    public class JobHubDataBaseContext : IdentityDbContext<AppUser>
    {

        public JobHubDataBaseContext(DbContextOptions options) : base(options) { }

        public DbSet<Company> CompanyTable { get; set; }
        public DbSet<Job> JobTable { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //relation between user and company
            builder.Entity<AppUser>().HasOne(a => a.CompanyProfile).WithOne(u => u.User).HasForeignKey<Company>(c => c.UserId).OnDelete(DeleteBehavior.Cascade);

            //relationship between copany and job (1 to many)
            builder.Entity<Company>().HasMany(a => a.JobsList).WithOne(c => c.Company).HasForeignKey(f => f.CompanyProfileId).OnDelete(DeleteBehavior.Cascade);

            // I declared Ondelete Behaviour => Cascade because if User Deletes his own account relative entity should be deleted
        }
    }
}
