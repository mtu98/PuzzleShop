using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Library.Toy
{
    public class ToyDTO
    {
        public ObjectId _id { get; set; }
        public string ToyName { get; set; }
        public string ToyType { get; set; }
        public string Producer { get; set; }
        public int SizeX { get; set; }
        public int SizeY { get; set; }
        public int SizeZ { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public int YearOfManufacture { get; set; }
        public string Description { get; set; }
        public string PhotoURL { get; set; }
        public Comment[] Comment { get; set; }

    }

    public class Comment
    {
        public string username { get; set; }
        public string Content { get; set; }
        public string Date { get; set; }
    }

}
