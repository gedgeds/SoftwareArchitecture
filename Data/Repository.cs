using Microsoft.EntityFrameworkCore;
using SoftwareArchitecture.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareArchitecture.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly SoftwareArchitectureContext _context;
        private DbSet<T> table = null;

        public Repository(SoftwareArchitectureContext context)
        {
            _context = context;
            table = _context.Set<T>();
        }

        public async Task <IEnumerable<T>> GetAll()
        {
            return await table.ToListAsync();
        }
        public async Task<T> Get(int? id)
        {
            return await table.FindAsync(id);
        }
        public async Task Add(T obj)
        {
            await table.AddAsync(obj);
        }
        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
        public void Remove(T entity)
        {
            table.Remove(entity);
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}