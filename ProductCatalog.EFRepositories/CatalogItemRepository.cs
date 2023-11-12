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
    public class CatalogItemRepository : GenericRepositoy<CatalogItem>, ICatalogItemRepository
    {
        private readonly ProductCatalogContext db;

        public CatalogItemRepository(ProductCatalogContext context) : base(context) 
        {
            db = context;
        }

        public async override Task<CatalogItem> Add(CatalogItem item)
        {
            db.CatalogItems.Add(item);
            await db.SaveChangesAsync();
            return item;

        }

        public override async Task Delete(int id)
        {
            var catalogItem = await db.CatalogItems.FindAsync(id);
            if (catalogItem == null)
            {
                throw new ApplicationException("CatalogItem Not found");
            }

            db.CatalogItems.Remove(catalogItem);
            await db.SaveChangesAsync();

        }

        public async override Task<CatalogItem> GetById(int id)
        {

            var catalogItem = await db.CatalogItems.Include("CatalogType").Include("CatalogBrand")
                .Where(item => item.Id == id).FirstOrDefaultAsync();

            if (catalogItem == null)
            {
                throw new ApplicationException("CatalogItem Not found");
            }

            return catalogItem;

        }

        public async override Task<IEnumerable<CatalogItem>> GetAll()
        {
            return await db.CatalogItems.Include("CatalogType").Include("CatalogBrand").ToListAsync();
        }


        public async override Task Update(CatalogItem item)
        {
            db.Entry(item).State = EntityState.Modified;

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
