using Microsoft.EntityFrameworkCore;
namespace Employee.Data.Context
{
    using Employee.Data.Configurations;
    using Employee.Domain.Entities;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        }
        public DbSet<EmployeeEntity> Employees { get; set; }
    }
}
