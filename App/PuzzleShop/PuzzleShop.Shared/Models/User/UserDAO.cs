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

        public User GetUserByUsername(string emailOrUsername) {
            //Get connection and PuzzleShopDB
            var db = DBConnect.getDB();
            var accounts = db.GetCollection<User>("User");
            var builder = Builders<User>.Filter;

            var filter = builder.Where(user => user.Username.Equals(emailOrUsername) | user.Email.Equals(emailOrUsername));
            List<User> list = accounts.Find(filter).ToList();

            foreach (var user in list) {
                return user;
            }
            return null;
        }

        /// <summary>
        /// Update a user password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public void ChangePassword(string username, string password) {
            var db = DBConnect.getDB();
            var Users = db.GetCollection<User>("User");

            string passwordHash = MD5Hash.GetMD5Hash(password);

            var builder = Builders<User>.Filter;
            var filter = builder.Where(u => u.Username.Equals(username));

            var updateBuilder = Builders<User>.Update;
            var update = updateBuilder.Set(u => u.PasswordHash, passwordHash);

            try {
                Users.UpdateOne(filter, update);
            } catch (Exception) {

                throw;
            }
        }

        /// <summary>
        /// Edit user information: firstname, lastname, email
        /// </summary>
        /// <param name="username"></param>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <param name="email"></param>
        public void EditInformation(string username, string firstname, string lastname, string email) {
            var db = DBConnect.getDB();
            var Users = db.GetCollection<User>("User");

            //Build filter to find user need to edit
            var builder = Builders<User>.Filter;
            var filter = builder.Where(u => u.Username.Equals(username));

            //build update
            var updateBuilder = Builders<User>.Update;
            var update = updateBuilder.Set(u => u.FirstName, firstname).Set(u => u.LastName, lastname).Set(u => u.Email, email);

            try {
                Users.UpdateOne(filter, update);
            } catch (Exception) {

                throw;
            }
        }
    }
}
