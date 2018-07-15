using MongoDB.Driver;
using System.Collections.Generic;
using Utils;

namespace PuzzleShop.Shared.Models {
    public class UserDAO {

        public bool CheckLogin(string emailOrUsername, string password) {
            //Get connection and PuzzleShopDB
            var db = DBConnect.getDB();
            var accounts = db.GetCollection<User>("User");
            var builder = Builders<User>.Filter;

            var filter = builder.Where(user => user.Username.Equals(emailOrUsername));
            List<User> usernameList = accounts.Find(filter).ToList();

            filter = builder.Where(user => user.Email.Equals(emailOrUsername));
            List<User> emailList = accounts.Find(filter).ToList();

            List<User> list = new List<User>();
            list.AddRange(usernameList);
            list.AddRange(emailList);

            foreach (var user in list) {
                string passwordHash = user.PasswordHash;
                if (MD5Hash.VerifyMD5Hash(password, passwordHash))
                    return true;
            }
            return false;
        }

        public void register(string username, string password, string firstName, string lastName, string email) {
            var db = DBConnect.getDB();
            var accounts = db.GetCollection<User>("Account");
            string passwordHash = MD5Hash.GetMD5Hash(password);
            //accounts.InsertOneAsync(new User {
            //    username = username,
            //    passwordHash = passwordHash,
            //    firstName = firstName,
            //    lastName = lastName,
            //    email = email,
            //    role = 1
            //});
        }
    }
}
