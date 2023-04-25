using Microsoft.EntityFrameworkCore;
using TZ.Data.Configuration;
using TZ.Domain.DbModels;

namespace TZ.Data
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<ExperimentResult> ExperimentResults { get; set; }
        public DbSet<Experiment> Experiments { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            Database.Migrate();
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, string test) : base(options) { Database.EnsureCreated(); }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);
            modelbuilder.ApplyConfiguration(new ExperimentConfiguration());
        }
    }
}