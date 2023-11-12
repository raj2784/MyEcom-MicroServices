using ProductCatalog.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Repositories
{
    public interface ICatalogTypeRepository : IGenericRepository<CatalogType>
    {
        //Task<IEnumerable<CatalogType>> GetTypes();
        //Task<CatalogType> GetType(int id);
        //Task<CatalogType> Add(CatalogType catalogType);
        //Task Update(CatalogType type);
        //Task Delete(int id);
    }
}
