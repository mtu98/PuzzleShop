using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json.Linq;
using Utils;

namespace PuzzleShop.Shared.Models.Toy
{
    public class ToyDAO
    {
        private const string CollectionName = "Toy";

        public Toy FindById(string toyId)
        {
            var toyCollection = DBConnect.getDB().GetCollection<Toy>(CollectionName);
            return toyCollection.Find(t => t._id.Equals(toyId)).Single();
        }

        /// <summary>
        ///     Find toy by ToyName
        /// </summary>
        /// <param name="toyName"></param>
        /// <returns></returns>
        public List<Toy> FindByName(string toyName)
        {
            if (string.IsNullOrEmpty(toyName)) return null;

            var toyCollection = DBConnect.getDB().GetCollection<Toy>(CollectionName);
            var builder = Builders<Toy>.Filter;
            // i means case-insensitive
            var filter = builder.Regex(toy => toy.Name, $"/{toyName}/i");
            return toyCollection.Find(filter).ToList();
        }

        public List<Toy> GetAllToyOfCategory(string category)
        {
            var toyCollection = DBConnect.getDB().GetCollection<Toy>(CollectionName);

            var builder = Builders<Toy>.Filter;
            var filter = builder.Where(t => t.Category.Equals(category));

            return toyCollection.Find(filter).ToList();
        }

        /// <summary>
        ///     Review a toy without login
        /// </summary>
        /// <param name="toyId"></param>
        /// <param name="title"></param>
        /// <param name="content"></param>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="star"></param>
        public bool ReviewAToy(string toyId, string name, string email, string title, string content, int star)
        {
            var toyCollection = DBConnect.getDB().GetCollection<Toy>(CollectionName);
            var builder = Builders<Toy>.Filter;
            //Build filter to query the toy need to cmt
            var filter = builder.Where(toy => toy._id.Equals(toyId));

            //Create Review
            var rv = new Review
            {
                Name = name,
                Email = email,
                Title = title,
                Content = content,
                Star = star,
                Date = DateTime.Now.ToString("F")
            };

            var updateBuilder = Builders<Toy>.Update;
            //Build update, import Comment
            var update = updateBuilder.AddToSet(toy => toy.Review, rv);

            return toyCollection.UpdateOne(filter, update).IsAcknowledged;
        }

        /// <summary>
        ///     Query some random toys
        /// </summary>
        /// <returns></returns>
        public List<Toy> GetRandomToy(int quantity)
        {
            var toyCollection = DBConnect.getDB().GetCollection<Toy>(CollectionName);
            var rng = new Random();
            return toyCollection.Find(new BsonDocument()).Limit(quantity).Skip(rng.Next(10)).ToList();
        }

        /// <summary>
        ///     Get All Toys
        /// </summary>
        /// <returns></returns>
        public List<Toy> AllToys()
        {
            var toyCollection = DBConnect.getDB().GetCollection<Toy>(CollectionName);
            return toyCollection.Find(new BsonDocument()).ToList();
        }

        /// <summary>
        ///     Get all toy type and each type distinct type count
        /// </summary>
        /// <returns></returns>
        public List<JObject> GetCategoriesAndQuantities()
        {
            var toyCollection = DBConnect.getDB().GetCollection<Toy>(CollectionName);

            var group = new BsonDocument().Add("$group",
                new BsonDocument().Add("_id", "$Category").Add("count", new BsonDocument().Add("$sum", 1)));
            var pipeline = new[] {group};

            // aggregate result and apply toJson method into each result element, return json list with format {"Category": Count}
            var result = toyCollection.Aggregate<BsonDocument>(pipeline).ToList()
                .Select(doc => JObject.Parse(doc.ToJson())).ToList()
                .Select(json =>
                    new JObject(new JProperty(json.GetValue("_id").ToString(), json.GetValue("count").ToString())))
                .ToList();
            Debug.WriteLine("All toy types: ");
            foreach (var entry in result) Debug.WriteLine(entry);

            return result;
        }

        public int GetQuantity(string toyId)
        {
            var toyCollection = DBConnect.getDB().GetCollection<Toy>(CollectionName);

            var builder = Builders<Toy>.Filter;
            var filter = builder.Where(t => t._id.Equals(toyId));

            return toyCollection.Find(filter).ToList().Single().Quantity;
        }


        /// <summary>
        ///     Take list found toy and filter by type
        ///     TODO Move this method because this is not a DAO logic
        /// </summary>
        /// <param name="list"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        private List<Toy> FilterCategory(List<Toy> list, string category)
        {
            foreach (var toy in list)
                //remove which not match the Category filter
                if (!toy.Category.Equals(category))
                    list.Remove(toy);

            return list;
        }

        /// <summary>
        ///     Take list of found toy and filter by price range
        ///     TODO Move this method because this is not a DAO logic
        /// </summary>
        /// <param name="list"></param>
        /// <param name="minPrice"></param>
        /// <param name="maxPrice"></param>
        /// <returns></returns>
        private List<Toy> FilterPrice(List<Toy> list, double minPrice, double maxPrice)
        {
            foreach (var toy in list)
                //Remove toy that out of price range
                if (toy.Price < minPrice || toy.Price > maxPrice)
                    list.Remove(toy);

            return list;
        }
    }
}