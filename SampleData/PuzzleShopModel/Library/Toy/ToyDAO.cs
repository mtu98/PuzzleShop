using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Library.Toy
{
    public class ToyDAO
    {
        public void FindToys(string ToyName)
        {
            //Get connection and PuzzleShopDB
            var db = utils.DBConnect.getDB();
            var toys = db.GetCollection<ToyDTO>("Toy");
            var builder = Builders<ToyDTO>.Filter;
            var filter = builder.Regex(t => t.ToyName, $"/{ToyName}/");

            List<ToyDTO> list = toys.Find(filter).ToList();
            foreach(ToyDTO t in list)
            {
                Console.WriteLine(t.ToString());
            }

            
            
        }
    }
}
