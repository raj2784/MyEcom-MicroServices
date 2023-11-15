using MVCWebApp.Models;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MVCWebApp.Services
{
    public class CatalogService : ICatalogService
    {
        string _remoteServiceBaseUrl;

        public CatalogService(IConfiguration config)
        {
            _remoteServiceBaseUrl = config["CatalogUrl"];
        }
        public async Task<IEnumerable<CatalogItem>> GetAllCatalogItems()
        {
            var client = new HttpClient();
            var result = await client.GetAsync(_remoteServiceBaseUrl + "/CatalogItems/");
            result.EnsureSuccessStatusCode();
            var dataString = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<CatalogItem>>(dataString);

        }
        public async Task<CatalogItem> GetItemDetails(int id)
        {
            var client = new HttpClient();
            var result = await client.GetStringAsync(_remoteServiceBaseUrl + "/CatalogItems/" + id);
            CatalogItem item = JsonConvert.DeserializeObject<CatalogItem>(result);
            return item;
        }

    }
}
