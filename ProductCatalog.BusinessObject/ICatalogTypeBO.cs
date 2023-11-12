using ProductCatalog.Domain;
using ProductCatalog.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.BusinessObject
{
    public interface ICatalogTypeBO
    {
        Task<IEnumerable<CatalogType>> GetCatalogTypes();
        Task<CatalogType> GetCatalogType(int id);
        Task<CatalogType> Add(CatalogType type);
        Task Update(CatalogType type);
        Task Delete(int id);
    }

    public class CatalogTypeBO : ICatalogTypeBO
    {
        private readonly ICatalogTypeRepository _rep;


        public CatalogTypeBO(ICatalogTypeRepository rep)
        {
            _rep = rep;
        }
        public async Task<CatalogType> Add(CatalogType type)
        {
            await _rep.Add(type);
            // extra business logic
            return type;
        }

        public async Task Delete(int id)
        {
            await _rep.Delete(id);
        }

        public async Task<CatalogType> GetCatalogType(int id)
        {
            return await _rep.GetById(id);
        }

        public async Task<IEnumerable<CatalogType>> GetCatalogTypes()
        {
            return await _rep.GetAll();
        }

        public async Task Update(CatalogType type)
        {
            await _rep.Update(type);
        }
    }
}
