using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Repositories
{
    public interface IGenericRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T>GetById(int id);
        Task<T>Add(T t);
        Task Update(T t);
        Task Delete(int id);
    }
}
