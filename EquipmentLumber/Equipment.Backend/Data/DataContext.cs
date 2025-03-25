using Microsoft.EntityFrameworkCore;
using Equipment.Shared.Entities;

namespace Equipment.Backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<BranchOffice> BranchOffices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BranchOffice>().HasIndex(x => x.Name).IsUnique();
        }
    }
}
