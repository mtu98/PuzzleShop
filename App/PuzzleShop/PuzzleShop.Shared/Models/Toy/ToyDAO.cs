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
        /// User Add a comment in a toy
        /// </summary>
        /// <param name="User"></param>
        /// <param name="Toy"></param>
        /// <param name="Content"></param>
        public void CommentInToy(User User, Toy Toy, string Content) {

            var db = DBConnect.getDB();
            var toys = db.GetCollection<Toy>("Toy");
            var builder = Builders<Toy>.Filter;
            //Build filter to query the toy need to cmt
            var filter = builder.Where(toy => toy._id.Equals(Toy._id));

            //Create Comment
            Comment cmt = new Comment {
                Username = User.Username,
                Content = Content,
                Date = DateTime.Now.ToString()
            };

            var updateBuilder = Builders<Toy>.Update;
            //Build update, import Comment
            var update = updateBuilder.AddToSet(toy => toy.Comment, cmt);

            try {
                toys.UpdateOne(filter, update);
            } catch (Exception) {

                throw;
            }
        }


        /// <summary>
        /// Query 3 first Toy
        /// </summary>
        /// <returns></returns>
        public List<Toy> RandomToy() {
            //Get connection and PuzzleShopDB
            var db = DBConnect.getDB();
            var toys = db.GetCollection<Toy>("Toy");

            Random rng = new Random();

            List<Toy> list = toys.Find(new BsonDocument()).Limit(3).Skip(rng.Next(10)).ToList();

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
    }
}
