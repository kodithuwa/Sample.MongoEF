using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Sample.MongoEF.Console
{
    public class Product
    {
        public ObjectId Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public int Quantity { get; set; }

        public bool IsStocked {  get; set; }    

    }
}
