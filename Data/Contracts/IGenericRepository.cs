using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        int Add(T entity);
        T Get(int id);
        bool Update(T entity);
        bool Delete(int id);
    }
}