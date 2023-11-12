using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.BusinessObject;
using ProductCatalog.Domain;
using ProductCatalog.EFRepositories;

namespace ProductCatalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogBrandsController : ControllerBase
    {
        //private readonly ProductCatalogContext db;
        private readonly ICatalogBrandBO _bo;

        public CatalogBrandsController(ICatalogBrandBO bo)
        {
            _bo = bo;
        }

        // GET: api/CatalogBrands
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CatalogBrand>>> GetCatalogBrands()
        {
            var brands = await _bo.GetCatalogBrands();
            return Ok(brands);
        }

        // GET: api/CatalogBrands/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CatalogBrand>> GetCatalogBrand(int id)
        {
            var catalogBrand = await _bo.GetCatalogBrand(id);

            if(catalogBrand == null)
            {
                return NotFound();
            }
            return catalogBrand;
                        
        }

        // PUT: api/CatalogBrands/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCatalogBrand(int id, CatalogBrand catalogBrand)
        {
            if (id != catalogBrand.Id)
            {
                return BadRequest();
            }
            try
            {
                await _bo.Update(catalogBrand);
            }
            catch (DbUpdateConcurrencyException)
            {

                throw;
            }
            return NoContent();
                       
        }

        // POST: api/CatalogBrands
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CatalogBrand>> PostCatalogBrand(CatalogBrand catalogBrand)
        {
            await _bo.Add(catalogBrand);
            
            return CreatedAtAction("GetCatalogBrand", new { id = catalogBrand.Id }, catalogBrand);
        }

        // DELETE: api/CatalogBrands/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCatalogBrand(int id)
        {
           await _bo.Delete(id);

            return NoContent();
        }

        //private bool CatalogBrandExists(int id)
        //{
        //    return (db.CatalogBrands?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
