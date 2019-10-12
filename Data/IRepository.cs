using SoftwareArchitecture.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SoftwareArchitecture.Data
{
    public interface IRepository<T>
    {
        Task <IEnumerable<T>> GetAll();
        Task <T> Get(int? id);
        Task Add(T employee);
        void Update(T employee);
        void Remove(T employee);
        Task Save();
    }
}