using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Library.Orders
{
    public class Orders
    {
        public BsonObjectId _id { get; set; }
        public string OrderDate { get; set; }
        public string Username { get; set; }
        public Orderitem[] OrderItems { get; set; }
        public float Total { get; set; }
        public int Status { get; set; }
    }

    public class Orderitem
    {
        public BsonObjectId Toy { get; set; }
        public int Quantity { get; set; }
    }
}
