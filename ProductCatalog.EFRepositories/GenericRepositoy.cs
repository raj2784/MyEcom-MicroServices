using Microsoft.EntityFrameworkCore;
using ProductCatalog.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.EFRepositories
{
    public class GenericRepositoy<T> : IGenericRepository<T> where T : class
    {
        private readonly DbContext _dbContext;
        DbSet<T> dbSet;

        public GenericRepositoy(DbContext dbContext)
        {
            _dbContext = dbContext;
            dbSet = _dbContext.Set<T>();

        }

        // virtual method so that we can have diffrent implemetation on child class
        public async virtual Task<T> Add(T t)
        {
            dbSet.Add(t);
            await _dbContext.SaveChangesAsync();
            return t;
        }

        public async virtual Task Delete(int id)
        {
            T entity = await dbSet.FindAsync(id);
            dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();

        }

        public async virtual Task<IEnumerable<T>> GetAll()
        {
            return await dbSet.ToListAsync<T>();
        }

        public async virtual Task<T> GetById(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async virtual Task Update(T t)
        {
            _dbContext.Entry(t).State = EntityState.Modified;
            
            await _dbContext.SaveChangesAsync();
        }
    }
}
