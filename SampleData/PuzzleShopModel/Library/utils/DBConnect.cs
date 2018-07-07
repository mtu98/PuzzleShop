using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using System.Configuration;

namespace Library.utils
{
    public static class DBConnect
    {
        public static IMongoDatabase getDB()
        {
            string strConnection = ConfigurationManager.ConnectionStrings["MongoDB"].ConnectionString;
            MongoClient client = new MongoClient(strConnection);
            var db = client.GetDatabase(ConfigurationManager.AppSettings["DB"]);
            return db;
        }
    }
}
