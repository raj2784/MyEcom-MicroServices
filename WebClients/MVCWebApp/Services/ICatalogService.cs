using MVCWebApp.Models;

namespace MVCWebApp.Services
{
    public interface ICatalogService
    {
        Task <IEnumerable<CatalogItem>> GetAllCatalogItems();
        Task<CatalogItem>GetItemDetails(int id);

    }
}
