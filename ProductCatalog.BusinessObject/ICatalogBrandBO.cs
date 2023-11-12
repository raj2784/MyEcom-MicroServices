using ProductCatalog.Domain;
using ProductCatalog.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.BusinessObject
{
    public interface ICatalogBrandBO
    {
        Task<IEnumerable<CatalogBrand>> GetCatalogBrands();
        Task<CatalogBrand> GetCatalogBrand(int id);
        Task<CatalogBrand> Add(CatalogBrand brand);
        Task Update(CatalogBrand brand);
        Task Delete(int id);
    }

    public class CatalogBrandBO : ICatalogBrandBO
    {
        private readonly ICatalogBrandRepository _rep;

        public CatalogBrandBO(ICatalogBrandRepository rep)
        {
            _rep = rep;
        }
        public async Task<CatalogBrand> Add(CatalogBrand brand)
        {
            await _rep.Add(brand);
            // extra business logic
            return brand;
        }

        public async Task Delete(int id)
        {
            await _rep.Delete(id);
        }

        public async Task<CatalogBrand> GetCatalogBrand(int id)
        {
           return await _rep.GetById(id);
        }

        public async Task<IEnumerable<CatalogBrand>> GetCatalogBrands()
        {
            return await _rep.GetAll();
        }

        public async Task Update(CatalogBrand brand)
        {
            await _rep.Update(brand);
        }
    }
}
