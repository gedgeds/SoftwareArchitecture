using Microsoft.EntityFrameworkCore;

namespace SoftwareArchitecture.Models
{
    public class SoftwareArchitectureContext : DbContext
    {
        public SoftwareArchitectureContext (DbContextOptions<SoftwareArchitectureContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employee { get; set; }
    }
}
