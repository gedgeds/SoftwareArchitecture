using SoftwareArchitecture.Models;
using System;
using System.Threading.Tasks;

namespace SoftwareArchitecture.Data
{
    public interface IEmployeeRepository
    {
        Task Add(Employee employee);
    }
}