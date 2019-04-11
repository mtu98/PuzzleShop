using System.Configuration;
using MongoDB.Driver;

namespace Utils
{
    public static class DBConnect
    {
        public static IMongoDatabase getDB()
        {
            var strConnection = ConfigurationManager.ConnectionStrings["MongoDB"].ConnectionString;
            var client = new MongoClient(strConnection);
            var db = client.GetDatabase(ConfigurationManager.AppSettings["DB"]);
            return db;
        }
    }
}