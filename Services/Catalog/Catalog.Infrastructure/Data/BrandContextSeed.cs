using Catalog.Core.Entities;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace Catalog.Infrastructure.Data
{
    public static class BrandContextSeed
    {

        public static void SeedData(IMongoCollection<ProductBrand> brandCollection)
        {
            bool checkBrands = brandCollection.Find(p => true).Any();

            string path = Path.Combine("Data", "SeedData", "brands.json");

            if (!checkBrands)
            {
                string brandsData = File.ReadAllText(path);
                //string brandsData = File.ReadAllText("../Catalog.Infrastructure/Data/SeedData/brands.json");

                var brandsList = JsonConvert.DeserializeObject<List<ProductBrand>>(brandsData);

                if(brandsList != null)
                {
                    foreach (var brand in brandsList)
                    {
                        brandCollection.InsertOneAsync(brand);
                    }
                }
            }


            
        }
    
    }
}
