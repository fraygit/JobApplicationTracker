using JobApplicationTracker.core.Entity;
using Microsoft.EntityFrameworkCore;

namespace JobApplicationTracker.core
{
    public class JobApplicationDbContext : DbContext
    {
        public JobApplicationDbContext(DbContextOptions<JobApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<JobApplication> JobApplications { get; set; }
    }
}
