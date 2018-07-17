using MongoDB.Driver;
using System;
using System.Collections.Generic;
using Utils;

namespace PuzzleShop.Shared.Models {
    public class UserDAO {

        public User CheckLogin(string emailOrUsername, string password) {
            //Get connection and PuzzleShopDB
            var db = DBConnect.getDB();
            var accounts = db.GetCollection<User>("User");
            var builder = Builders<User>.Filter;

            var filter = builder.Where(user => user.Username.Equals(emailOrUsername) | user.Email.Equals(emailOrUsername));
            List<User> list = accounts.Find(filter).ToList();

            foreach (var user in list) {
                string passwordHash = user.PasswordHash;
                if (MD5Hash.VerifyMD5Hash(password, passwordHash))
                    return user;
            }
            return null;
        }

        public bool Register(User user) {
            var db = DBConnect.getDB();
            var accounts = db.GetCollection<User>("User");
            user.PasswordHash = MD5Hash.GetMD5Hash(user.Password);
            accounts.InsertOneAsync(new User {
                Username = user.Username,
                PasswordHash = user.PasswordHash,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Birthdate = user.Birthdate,
                RoleId = user.RoleId,
                CreatedDate = DateTime.Now
            });
            return true;
        }
    }
}
