using HtmlAgilityPack;
using System.Net.Http;
using System.Threading.Tasks;


namespace SuperOferta.Data

{
    public class WebScrapingService
    {
        private readonly HttpClient _httpClient;
        public WebScrapingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<string> GetProductDataAsync(string url)
        {
            try
            {
                // Obtener la página HTML de la URL proporcionada
                var response = await _httpClient.GetStringAsync(url);
                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(response);
                var productNodes = htmlDocument.DocumentNode.SelectNodes("//<img src=https://static.cotodigital3.com.ar/sitios/fotos/large/>]");

                if (productNodes == null)
                    return "No se encontraron productos.";

                var result = "";
                foreach (var productNode in productNodes)
                {
                    var productName = productNode.SelectSingleNode(".//h5[contains(@class, 'nombre-producto')]")?.InnerText?.Trim();
                    var productNombre = productNode.SelectSingleNode("<img src=\"https://static.cotodigital3.com.ar/sitios/fotos/large/00267700/00267716.jpg\">")?.InnerText?.Trim();
                    var productPrice = productNode.SelectSingleNode(".//span[contains(@class, 'price')]")?.InnerText?.Trim();
                    result += $"Producto: {productName}\nPrecio: {productPrice}\n\n";
                }
            return result;
        }
        catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
    }
}
