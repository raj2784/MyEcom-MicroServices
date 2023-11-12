using Microsoft.EntityFrameworkCore;
using ProductCatalog.Domain;
using ProductCatalog.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.EFRepositories
{
    public class CatalogTypeRepository : GenericRepositoy<CatalogType>, ICatalogTypeRepository
    {
        private readonly ProductCatalogContext db;

        public CatalogTypeRepository(ProductCatalogContext context) : base(context)
        {
            db = context;
        }
        public async override Task<CatalogType> Add(CatalogType catalogType)
        {
            db.CatalogTypes.Add(catalogType);
            await db.SaveChangesAsync();
            return catalogType;
        }

        public async override Task Delete(int id)
        {
            var catalogType = await db.CatalogTypes.FindAsync(id);
            if (catalogType == null)
            {
                throw new ApplicationException("CatalogType Not found");
            }
            db.CatalogTypes.Remove(catalogType);
            await db.SaveChangesAsync();
        }

        public async override Task<CatalogType> GetById(int id)
        {
            var catalogType = await db.CatalogTypes.FindAsync(id);

            if (catalogType == null)
            {
                throw new ApplicationException("CatalogBrand Not found");
            }
            return catalogType;
        }

        public async override Task<IEnumerable<CatalogType>> GetAll()
        {
            return await db.CatalogTypes.ToListAsync();
        }

        public async override Task Update(CatalogType type)
        {
            db.Entry(type).State = EntityState.Modified;

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
