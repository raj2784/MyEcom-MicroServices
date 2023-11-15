using Microsoft.AspNetCore.Mvc;
using MVCWebApp.Models;
using MVCWebApp.Services;

namespace MVCWebApp.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ICatalogService _service;
        public CatalogController(ICatalogService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var items = await _service.GetAllCatalogItems();
            return View(items);
        }

        public async Task<ActionResult> Details(int id)
        {
            CatalogItem item = await _service.GetItemDetails(id);
            return View(item);
        }
    }
}
