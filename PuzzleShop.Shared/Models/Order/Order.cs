using MongoDB.Bson;
using Newtonsoft.Json;

namespace PuzzleShop.Shared.Models.Order {
    public class Orders {
        [JsonIgnore]
        public BsonObjectId _id { get; set; }
        public string OrderDate { get; set; }
        public string Username { get; set; }
        public OrderItem[] OrderItems { get; set; }
        public double Total { get; set; }
        public int Status { get; set; }
    }

    public class OrderItem {
        public Toy.Toy Toy { get; set; }
        public int Quantity { get; set; }
    }
}
