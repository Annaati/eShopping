﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Catalog.Core.Entities;

namespace Catalog.Core.Application.Responses
{
    public class ProductResponse
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Summery { get; set; }
        public string ImageFile { get; set; }
        public ProductBrand Brands { get; set; }
        public ProductType Types { get; set; }
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Price { get; set; }
    }
}
