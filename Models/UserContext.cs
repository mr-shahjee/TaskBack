
using Microsoft.EntityFrameworkCore;

namespace PracticeCrud.Models
{
    public class UserContext : DbContext
    {
        
        public UserContext(DbContextOptions<UserContext> options): base(options)
        {
         
        }
 
        public DbSet<Job> Job {get; set;}
        public DbSet<JobDescription> JobDescriptions {get; set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Job>()
                .HasMany(j => j.JobDescription)
            .WithOne(s => s.Job)
            .HasForeignKey(s => s.JobId)
            .OnDelete(DeleteBehavior.Cascade);

        }
    }
}