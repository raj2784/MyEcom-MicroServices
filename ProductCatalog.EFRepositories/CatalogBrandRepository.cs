using ProductCatalog.Domain;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.EFRepositories
{
    public class CatalogBrandRepository : GenericRepositoy<CatalogBrand>, ICatalogBrandRepository
    {
        private readonly ProductCatalogContext db;
        public CatalogBrandRepository(ProductCatalogContext context) : base(context) 
        {
            db = context;
        }

        // overriding method as we can have different implementation than generic 
        public async override Task<CatalogBrand> Add(CatalogBrand brand)
        {
            db.CatalogBrands.Add(brand);
            await db.SaveChangesAsync();
            return brand;
        }

        public async override Task Delete(int id)
        {
            var catalogBrand = await db.CatalogBrands.FindAsync(id);
            if (catalogBrand == null)
            {
                throw new ApplicationException("CatalogBrand Not found");
            }
            db.CatalogBrands.Remove(catalogBrand);
            await db.SaveChangesAsync();
        }

        public async override Task<CatalogBrand> GetById(int id)
        {
            var catalogBrand = await db.CatalogBrands.FindAsync(id);

            if (catalogBrand == null)
            {
                throw new ApplicationException("CatalogBrnad Not found");
            }
            return catalogBrand;
        }

        public async override Task<IEnumerable<CatalogBrand>> GetAll()
        {
            return await db.CatalogBrands.ToListAsync();
        }

        public async override Task Update(CatalogBrand brand)
        {
            db.Entry(brand).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new ApplicationException("Not updated because of concurrency please try again");
            }
        }
    }
}
