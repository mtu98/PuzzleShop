using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.User {
    public class UserDAO {
        /// <summary>
        /// Check login by username or email
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public User checkLogin(string Username_Email, string Password) {
            //Get connection and PuzzleShopDB
            var db = utils.DBConnect.getDB();
            var Users = db.GetCollection<User>("User");
            var builder = Builders<User>.Filter;
            //Find account by username or password
            var filter = builder.Where(a => a.Username.Equals(Username_Email)) | builder.Where(a => a.Email.Equals(Username_Email));

            List<User> list = Users.Find(filter).ToList();
            if (list.Count > 0) {
                string passwordHash = list[0].PasswordHash;
                if (MD5Hash.VerifyMD5Hash(Password, passwordHash))
                    return list[0];
            }
            return null;
        }

        public void register(string username, string password, string firstName, string lastName, string email) {
            var db = utils.DBConnect.getDB();
            var accounts = db.GetCollection<User>("Account");
            string passwordHash = MD5Hash.GetMD5Hash(password);
            try {
                accounts.InsertOne(new User {
                    Username = username,
                    PasswordHash = passwordHash,
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    RoleId = 1
                });
            } catch (Exception e) {
                throw e;
            }
        }

    }
}
