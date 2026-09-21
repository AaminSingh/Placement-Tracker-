using Microsoft.EntityFrameworkCore;
using PlacementTracker.Models;

namespace PlacementTracker.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<JobApplication> JobApplications { get; set; }
    }
}