using ProductCatalog.Domain;
using ProductCatalog.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.BusinessObject
{
    public interface ICatalogItemBO
    {
        Task<IEnumerable<CatalogItem>> GetCatalogItems();
        Task<CatalogItem> GetCatalogItem(int id);
        Task<CatalogItem> Add(CatalogItem item);
        Task Update(CatalogItem item);
        Task Delete(int id);

    }

    public class CatalogItemBO : ICatalogItemBO
    {
        private readonly ICatalogItemRepository _rep;

        public CatalogItemBO(ICatalogItemRepository rep)
        {
            _rep = rep;
         }
        public async Task<CatalogItem> Add(CatalogItem item)
        {
            await _rep.Add(item);
            // extra business logic
            return item;
        }

        public async Task Delete(int id)
        {
            await _rep.Delete(id);
        }

        public async Task<CatalogItem> GetCatalogItem(int id)
        {
           return await _rep.GetById(id);
        }

        public async Task<IEnumerable<CatalogItem>> GetCatalogItems()
        {
            return await _rep.GetAll();
        }

        public async Task Update(CatalogItem item)
        {
            await _rep.Update(item);
        }
    }
}
