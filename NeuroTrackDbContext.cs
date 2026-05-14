using Microsoft.EntityFrameworkCore;
using NeuroTrack.Models;

namespace NeuroTrack.Data
{
    public class NeuroTrackDbContext : DbContext
    {
        public NeuroTrackDbContext(DbContextOptions<NeuroTrackDbContext> options)
            : base(options) { }

        public DbSet<TestResult> TestResults { get; set; }
    }
}
