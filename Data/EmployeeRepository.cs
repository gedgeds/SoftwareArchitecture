using Microsoft.EntityFrameworkCore;
using SoftwareArchitecture.Models;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<Employee> Get(int? id)
        {
            return await _context.Employee.FindAsync(id);
        }

        public async Task <List<Employee>> GetAll()
        {
            return await _context.Employee.ToListAsync();
        }

        public bool IsExisting(int id)
        {
            return _context.Employee.Any(e => e.Id == id);
        }

        public async Task Remove(Employee employee)
        {
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Employee employee)
        {
            _context.Update(employee);
            await _context.SaveChangesAsync();
        }
    }
}