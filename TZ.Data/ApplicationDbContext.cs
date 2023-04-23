using Microsoft.EntityFrameworkCore;
using TZ.Domain.DbModels;

namespace TZ.Data
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Experiment> Experiments { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);
        }
    }
}