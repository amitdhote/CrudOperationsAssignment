using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
namespace CrudOperationsAssignment.Entities
{
    public class product
    {
        [BsonId] 
        public ObjectId Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("price")]
        public double Price { get; set; }

        [BsonElement("quantity")]
        public string Quantity { get; set; }

        [BsonElement("status")]
        public bool Status { get; set; }

        [BsonElement("date")]
        public DateTime Date{ get; set; }

        [BsonElement("categoryId")]
        public string CategoryId { get; set; }
    }
}
