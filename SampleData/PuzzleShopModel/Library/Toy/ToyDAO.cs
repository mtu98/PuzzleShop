using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using Library.UserCollection;


namespace Library.ToyCollection
{
    public class ToyDAO
    {
        /// <summary>
        /// Find toy by ToyName
        /// </summary>
        /// <param name="ToyName"></param>
        /// <returns></returns>
        public List<Toy> FindToys(string ToyName)
        {
            //Get connection and PuzzleShopDB
            var db = utils.DBConnect.getDB();
            var Toys = db.GetCollection<Toy>("Toy");
            var builder = Builders<Toy>.Filter;
            // i means case-insensitive
            var filter = builder.Regex(toy => toy.ToyName, $"/{ToyName}/i");

            try
            {
                List<Toy> list = Toys.Find(filter).ToList();
                return list;
            }
            catch (Exception)
            {

                throw;
            }
            
        }


        public List<Toy> GetAllToyOfType(string ToyType)
        {
            //Get connection and PuzzleShopDB
            var db = utils.DBConnect.getDB();
            var Toys = db.GetCollection<Toy>("Toy");

            var builder = Builders<Toy>.Filter;
            var filter = builder.Where(t => t.ToyType.Equals(ToyType));

            try
            {
                List<Toy> list = Toys.Find(filter).ToList();
                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        /// Take list found toy and filter by type
        /// </summary>
        /// <param name="list"></param>
        /// <param name="ToyType"></param>
        /// <returns></returns>
        public List<Toy> FilterToyType(List<Toy> list, string ToyType)
        {
            foreach(Toy t in list)
            {
                //remove which not match the ToyType filter
                if (!t.ToyType.Equals(ToyType))
                {
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
        public List<Toy> FilterToyPrice(List<Toy> list, double MinPrice, double MaxPrice)
        {
            foreach(Toy t in list)
            {
                //Remove toy that out of price range
                if(t.Price < MinPrice || t.Price > MaxPrice)
                {
                    list.Remove(t);
                }
            }
            return list;
        }

        /// <summary>
        /// Review a toy without login
        /// </summary>
        /// <param name="User"></param>
        /// <param name="Toy"></param>
        /// <param name="Content"></param>
        public void ReviewAToy(Toy Toy, string Name, string Email, string Title, string Content, int Star)
        {

            var db = utils.DBConnect.getDB();
            var Toys = db.GetCollection<Toy>("Toy");
            var builder = Builders<Toy>.Filter;
            //Build filter to query the toy need to cmt
            var filter = builder.Where(toy => toy._id.Equals(Toy._id));

            //Create Review
            Review rv = new Review
            {
                Name = Name,
                Email = Email,
                Title = Title,
                Content = Content,
                Star = Star,
                Date = DateTime.Now.ToString()
            };

            var updateBuilder = Builders<Toy>.Update;
            //Build update, import Comment
            var update = updateBuilder.AddToSet(toy => toy.Review, rv);

            try
            {
                Toys.UpdateOne(filter, update);
            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        /// Query 3 first Toy
        /// </summary>
        /// <returns></returns>
        public List<Toy> Random3Toy()
        {
            //Get connection and PuzzleShopDB
            var db = utils.DBConnect.getDB();
            var Toys = db.GetCollection<Toy>("Toy");

            Random rng = new Random();

            List<Toy> list = Toys.Find(new BsonDocument()).Limit(3).Skip(rng.Next(10)).ToList();

            return list;
        }

        public List<Toy> Random5Toy()
        {
            //Get connection and PuzzleShopDB
            var db = utils.DBConnect.getDB();
            var Toys = db.GetCollection<Toy>("Toy");

            Random rng = new Random();

            List<Toy> list = Toys.Find(new BsonDocument()).Limit(5).Skip(rng.Next(10)).ToList();

            return list;
        }

        /// <summary>
        /// Get All Toys
        /// </summary>
        /// <returns></returns>
        public List<Toy> AllToys()
        {
            //Get connection and PuzzleShopDB
            var db = utils.DBConnect.getDB();
            var Toys = db.GetCollection<Toy>("Toy");

            List<Toy> list = Toys.Find(new BsonDocument()).ToList();

            return list;
        }

        /// <summary>
        /// Get a List of All Toy Type in database
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllToyType()
        {
            //Get connection and PuzzleShopDB
            var db = utils.DBConnect.getDB();
            var Toys = db.GetCollection<Toy>("Toy");

            List<string> AllType = new List<string>();

            try
            {
                AllType = Toys.Distinct<string>("ToyType", new BsonDocument()).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            return AllType;
        }


        /// <summary>
        /// Get amount Toy of a Type
        /// </summary>
        /// <param name="ToyType"></param>
        /// <returns></returns>
        public long GetQuantityOfAType(string ToyType)
        {
            //Get connection and PuzzleShopDB
            var db = utils.DBConnect.getDB();
            var Toys = db.GetCollection<Toy>("Toy");

            var builder = Builders<Toy>.Filter;
            var filter = builder.Where(t => t.ToyType.Equals(ToyType));

            try
            {
                long quantity = Toys.CountDocuments(filter);
                return quantity;
            }
            catch (Exception)
            {

                throw;
            }
            
        }


        public int GetQuantity(string Toy_id)
        {
            //Get connection and PuzzleShopDB
            var db = utils.DBConnect.getDB();
            var Toys = db.GetCollection<Toy>("Toy");

            var builder = Builders<Toy>.Filter;
            var filter = builder.Where(t => t._id.Equals(Toy_id));

            List<Toy> list = Toys.Find(filter).ToList();

            return list[0].Quantity;
        }
    }
}
