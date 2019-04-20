using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarryPotterWebAPI.Interface
{
    interface IGenericRepository<T>
    {
        List<T> Get();
        T GetById(int id);
        bool Insert(T entity);
        bool Delete(int id);
        bool Update(T entity);
    }
}
