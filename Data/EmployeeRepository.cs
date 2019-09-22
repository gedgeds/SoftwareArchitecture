using SoftwareArchitecture.Models;
using System;
using System.Threading.Tasks;

namespace SoftwareArchitecture.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly SoftwareArchitectureContext _context;

        public EmployeeRepository(SoftwareArchitectureContext context)
        {
            _context = context;
        }

        public async Task Add(Employee employee)
        {
            _context.Add(employee);
            await _context.SaveChangesAsync();
        }
    }
}