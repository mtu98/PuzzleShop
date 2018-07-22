using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using Utils;

namespace PuzzleShop.Shared.Models.Toy {
    public class ToyDAO {

        public Toy FindToyById(string toyId) {
            var db = DBConnect.getDB();
            var toys = db.GetCollection<Toy>("Toy");
            try {
                var toy = toys.Find(t => t._id.Equals(toyId)).Single();
                return toy;
            } catch (Exception ex) {
                throw;
            }
        }

        /// <summary>
        /// Find toy by ToyName
        /// </summary>
        /// <param name="ToyName"></param>
        /// <returns></returns>
        public List<Toy> FindToys(string ToyName) {
            if (string.IsNullOrEmpty(ToyName)) {
                return null;
            }
            //Get connection and PuzzleShopDB
            var db = DBConnect.getDB();
            var toys = db.GetCollection<Toy>("Toy");
            var builder = Builders<Toy>.Filter;
            // i means case-insensitive
            var filter = builder.Regex(toy => toy.ToyName, $"/{ToyName}/i");

            try {
                List<Toy> list = toys.Find(filter).ToList();
                return list;
            } catch (Exception) {

                throw;
            }

        }

        public List<Toy> GetAllToyOfType(string ToyType) {
            //Get connection and PuzzleShopDB
            var db = DBConnect.getDB();
            var Toys = db.GetCollection<Toy>("Toy");

            var builder = Builders<Toy>.Filter;
            var filter = builder.Where(t => t.ToyType.Equals(ToyType));

            try {
                List<Toy> list = Toys.Find(filter).ToList();
                return list;
            } catch (Exception) {

                throw;
            }
        }


        /// <summary>
        /// Take list found toy and filter by type
        /// </summary>
        /// <param name="list"></param>
        /// <param name="ToyType"></param>
        /// <returns></returns>
        public List<Toy> FilterToyType(List<Toy> list, string ToyType) {
            foreach (Toy t in list) {
                //remove which not match the ToyType filter
                if (!t.ToyType.Equals(ToyType)) {
                    list.Remove(t);
                }
            }
            return list;
        }

        /// <summary>
        /// Take list of found toy and filter by price range
        /// </summary>
        /// <param name="list"></param>
        /// <param name="MinPrice"></param>
        /// <param name="MaxPrice"></param>
        /// <returns></returns>
        public List<Toy> FilterToyPrice(List<Toy> list, double MinPrice, double MaxPrice) {
            foreach (Toy t in list) {
                //Remove toy that out of price range
                if (t.Price < MinPrice || t.Price > MaxPrice) {
                    list.Remove(t);
                }
            }
            return list;
        }

        /// <summary>
        /// Review a toy without login
        /// </summary>
        /// <param name="toyId"></param>
        /// <param name="title"></param>
        /// <param name="content"></param>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="star"></param>
        public void ReviewAToy(string toyId, string name, string email, string title, string content, int star) {

            var db = DBConnect.getDB();
            var Toys = db.GetCollection<Toy>("Toy");
            var builder = Builders<Toy>.Filter;
            //Build filter to query the toy need to cmt
            var filter = builder.Where(toy => toy._id.Equals(toyId));

            //Create Review
            Review rv = new Review {
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

            try {
                Toys.UpdateOne(filter, update);
            } catch (Exception) {

                throw;
            }
        }

        /// <summary>
        /// Query 3 first Toy
        /// </summary>
        /// <returns></returns>
        public List<Toy> Random3Toy() {
            //Get connection and PuzzleShopDB
            var db = DBConnect.getDB();
            var Toys = db.GetCollection<Toy>("Toy");

            Random rng = new Random();

            List<Toy> list = Toys.Find(new BsonDocument()).Limit(3).Skip(rng.Next(10)).ToList();

            return list;
        }

        public List<Toy> Random5Toy() {
            //Get connection and PuzzleShopDB
            var db = DBConnect.getDB();
            var Toys = db.GetCollection<Toy>("Toy");

            Random rng = new Random();

            List<Toy> list = Toys.Find(new BsonDocument()).Limit(5).Skip(rng.Next(10)).ToList();

            return list;
        }

        /// <summary>
        /// Get All Toys
        /// </summary>
        /// <returns></returns>
        public List<Toy> AllToys() {
            //Get connection and PuzzleShopDB
            var db = DBConnect.getDB();
            var toys = db.GetCollection<Toy>("Toy");

            List<Toy> list = toys.Find(new BsonDocument()).ToList();

            return list;
        }

        /// <summary>
        /// Get a List of All Toy Type in database
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllToyType() {
            //Get connection and PuzzleShopDB
            var db = DBConnect.getDB();
            var Toys = db.GetCollection<Toy>("Toy");

            List<string> AllType = new List<string>();

            try {
                AllType = Toys.Distinct<string>("ToyType", new BsonDocument()).ToList();
            } catch (Exception) {

                throw;
            }
            return AllType;
        }


        /// <summary>
        /// Get amount Toy of a Type
        /// </summary>
        /// <param name="ToyType"></param>
        /// <returns></returns>
        public long GetQuantityOfAType(string ToyType) {
            //Get connection and PuzzleShopDB
            var db = DBConnect.getDB();
            var Toys = db.GetCollection<Toy>("Toy");

            var builder = Builders<Toy>.Filter;
            var filter = builder.Where(t => t.ToyType.Equals(ToyType));

            try {
                long quantity = Toys.CountDocuments(filter);
                return quantity;
            } catch (Exception) {

                throw;
            }

        }
    }
}
