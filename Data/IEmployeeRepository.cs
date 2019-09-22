using SoftwareArchitecture.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SoftwareArchitecture.Data
{
    public interface IEmployeeRepository
    {
        Task <List<Employee>> GetAll();
        Task <Employee> Get(int? id);
        Task Add(Employee employee);
        Task Update(Employee employee);
        Task Remove(Employee employee);
        bool IsExisting(int id);
    }
}