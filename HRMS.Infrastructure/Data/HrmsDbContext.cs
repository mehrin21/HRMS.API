using Microsoft.EntityFrameworkCore;
using HRMS.Domain.Entities;


namespace HRMS.Infrastructure.Data
{
    public class HrmsDbContext : DbContext
    {
        public HrmsDbContext(
            DbContextOptions<HrmsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Departments => Set<Department>();

        public DbSet<Designation> Designations => Set<Designation>();
    }
}
