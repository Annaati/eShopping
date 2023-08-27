using Catalog.Core.Entities;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace Catalog.Infrastructure.Data
{
    public static class TypeContextSeed
    {

        public static void SeedData(IMongoCollection<ProductType> typeCollection)
        {
            bool checkTypes = typeCollection.Find(p => true).Any();

            string path = Path.Combine("Data", "SeedData", "types.json");

            if (!checkTypes)
            {
                string brandsData = File.ReadAllText(path);
                //string brandsData = File.ReadAllText("../Catalog.Infrastructure/Data/SeedData/types.json");

                var typesList = JsonConvert.DeserializeObject<List<ProductType>>(brandsData);

                if(typesList != null)
                {
                    foreach (var type in typesList)
                    {
                        typeCollection.InsertOneAsync(type);
                    }
                }
            }


            
        }
    
    }
}
