using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using Library.User;


namespace Library.Toy
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
            var toys = db.GetCollection<Toy>("Toy");
            var builder = Builders<Toy>.Filter;
            // i means case-insensitive
            var filter = builder.Regex(toy => toy.ToyName, $"/{ToyName}/i");

            try
            {
                List<Toy> list = toys.Find(filter).ToList();
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


        public void CommentInToy(User.User User, Toy Toy, string Content)
        {

            var db = utils.DBConnect.getDB();
            var toys = db.GetCollection<Toy>("Toy");
            var builder = Builders<Toy>.Filter;
            var filter = builder.Where(toy => toy._id.Equals(Toy._id));
            var updateBuilder = Builders<Toy>.Update;

            Comment cmt = new Comment
            {
                Username = User.Username,
                Content = Content,
                Date = DateTime.Now.ToString()
            };

            var update = updateBuilder.AddToSet(toy => toy.Comment, cmt);

            try
            {
                toys.UpdateOne(filter, update);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
