﻿using MongoDB.Bson;
using Newtonsoft.Json;

namespace PuzzleShop.Shared.Models.Toy {
    public class Toy {
        [JsonIgnore]
        public BsonObjectId _id { get; set; }

        public string ToyName { get; set; }
        public string ToyType { get; set; }
        public string Producer { get; set; }
        public int SizeX { get; set; }
        public int SizeY { get; set; }
        public int SizeZ { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int YearOfManufacture { get; set; }
        public string Description { get; set; }
        public string PhotoURL { get; set; }
        public Comment[] Comment { get; set; }

        public override string ToString() {
            return ToyName + "\n" +
                Producer + "\n" +
                Price + "\n" +
                Quantity + "\n" +
                YearOfManufacture + "\n" +
                Description + "\n";
        }

    }

    public class Comment {
        public string Username { get; set; }
        public string Content { get; set; }
        public string Date { get; set; }

        public override string ToString() {
            return Username + ": " + Content + "\n" + Date;
        }
    }

}
