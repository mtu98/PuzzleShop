using MongoDB.Driver;
using System.Configuration;

namespace Utils {
    public static class DBConnect {
        public static IMongoDatabase getDB() {
            string strConnection = ConfigurationManager.ConnectionStrings["MongoDB"].ConnectionString;
            MongoClient client = new MongoClient(strConnection);
            var db = client.GetDatabase(ConfigurationManager.AppSettings["DB"]);
            return db;
        }
    }
}
