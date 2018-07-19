using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using Library.ToyCollection;

namespace Library.OrdersCollection
{
    public class Orders
    {
        public BsonObjectId _id { get; set; }
        public string OrderDate { get; set; }
        public string Username { get; set; }
        public OrderItem[] OrderItems { get; set; }
        public double Total { get; set; }
        public int Status { get; set; }
    }

    public class OrderItem
    {
        public Toy Toy { get; set; }
        public int Quantity { get; set; }
    }
}
