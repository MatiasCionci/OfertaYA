using HtmlAgilityPack;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium.Chrome;
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
            var response = await _httpClient.GetStringAsync(url);

            // Parsear el JSON
            var json = JObject.Parse(response);
            var result = "";

            // Verificar que el nodo "contents" existe y tiene datos
            var mainContents = json["contents"]?[0]?["Main"];
            if (mainContents == null) { return "No se encontraron categorías."; }


               

            // Iterar sobre las categorías principales
            foreach (var mainContent in mainContents)
            {

                {

                    // Obtener nombre de la categoría principal


                    var mainCategoryName = mainContent["category"]?["name"]?.ToString();
                    if (!string.IsNullOrEmpty(mainCategoryName))
                    {
                        result += $"Categoría Principal: {mainCategoryName}\n";
                    }


                }


                // Obtener subcategorías dentro de cada categoría principal
                var subcategories = mainContent["contents"];


                if (subcategories != null) {

                    

                        foreach (var subcategory in subcategories)
                        {
                            // Obtener nombre de la subcategoría
                            var subcategoryName = subcategory["category"]?["name"]?.ToString();
                            if (!string.IsNullOrEmpty(subcategoryName))
                            {
                                result += $"  Subcategoría: {subcategoryName}\n";
                            }


                        


                        // Obtener productos dentro de la subcategoría


                        var products = subcategory["records"];
                        if (products != null)
                        {
                            foreach (var product in products)
                            {

                                {

                                    // Obtener nombre del producto
                                    var productName = product["attributes"]?["product.displayName"]?.ToString();


                                    if (!string.IsNullOrEmpty(productName))
                                    {
                                        result +=$"    - Producto: {productName}\n";
                                            }
                                        }
                                    }
                                }
                            }
                        }


                    }
            return string.IsNullOrEmpty(result) ? "No se encontraron productos." : result;
        }
            }
        }
    


  
