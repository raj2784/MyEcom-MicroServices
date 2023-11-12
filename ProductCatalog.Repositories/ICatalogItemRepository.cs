using ProductCatalog.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Repositories
{
    public interface ICatalogItemRepository : IGenericRepository<CatalogItem>
    {
        //Task<IEnumerable<CatalogItem>> GetItems();
        //Task<CatalogItem> GetItem(int id);
        //Task<CatalogItem> Add(CatalogItem item);
        //Task Update(CatalogItem item);
        //Task Delete(int id);

    }
}
