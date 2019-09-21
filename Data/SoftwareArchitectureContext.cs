using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SoftwareArchitecture.Models
{
    public class SoftwareArchitectureContext : DbContext
    {
        public SoftwareArchitectureContext (DbContextOptions<SoftwareArchitectureContext> options)
            : base(options)
        {
        }

        public DbSet<SoftwareArchitecture.Models.Employee> Employee { get; set; }
    }
}
