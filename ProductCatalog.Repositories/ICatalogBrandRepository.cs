using ProductCatalog.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Repositories
{
    public interface ICatalogBrandRepository : IGenericRepository<CatalogBrand>
    {

        //Task<IEnumerable<CatalogBrand>> GetBrands();
        //Task<CatalogBrand>GetBrand (int id);
        //Task<CatalogBrand> Add(CatalogBrand brand);
        //Task Update(CatalogBrand brand);
        //Task Delete(int id);
      
    }
}
