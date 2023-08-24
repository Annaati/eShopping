using Catalog.Core.Entities;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace Catalog.Infrastructure.Data
{
    public static class ProductContextSeed
    {

        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool checkProducts = productCollection.Find(p => true).Any();

            string path = Path.Combine("Data", "SeedData", "products.json");

            if (!checkProducts)
            {
                string productsData = File.ReadAllText(path);

                var productsList = JsonConvert.DeserializeObject<List<Product>>(productsData);

                if(productsList != null)
                {
                    foreach (var product in productsList)
                    {
                        productCollection.InsertOneAsync(product);
                    }
                }
            }


            
        }
    
    }
}
