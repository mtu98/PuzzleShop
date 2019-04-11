using System;
using MongoDB.Driver;
using Utils;

namespace PuzzleShop.Shared.Models.User
{
    public class UserDAO
    {
        public Models.User.User CheckLogin(string emailOrUsername, string password)
        {
            //Get connection and PuzzleShopDB
            var db = DBConnect.getDB();
            var accounts = db.GetCollection<Models.User.User>("User");
            var builder = Builders<Models.User.User>.Filter;

            var filter = builder.Where(user =>
                user.Username.Equals(emailOrUsername) | user.Email.Equals(emailOrUsername));
            var list = accounts.Find(filter).ToList();

            foreach (var user in list)
            {
                var passwordHash = user.PasswordHash;
                if (MD5Hash.VerifyMD5Hash(password, passwordHash))
                    return user;
            }

            return null;
        }

        public bool Register(Models.User.User user)
        {
            var db = DBConnect.getDB();
            var accounts = db.GetCollection<Models.User.User>("User");
            user.PasswordHash = MD5Hash.GetMD5Hash(user.Password);
            accounts.InsertOneAsync(new Models.User.User
            {
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

        public Models.User.User GetUserByUsername(string emailOrUsername)
        {
            //Get connection and PuzzleShopDB
            var db = DBConnect.getDB();
            var accounts = db.GetCollection<Models.User.User>("User");
            var builder = Builders<Models.User.User>.Filter;

            var filter = builder.Where(user =>
                user.Username.Equals(emailOrUsername) | user.Email.Equals(emailOrUsername));
            var list = accounts.Find(filter).ToList();

            foreach (var user in list) return user;
            return null;
        }

        /// <summary>
        ///     Update a user password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public void ChangePassword(string username, string password)
        {
            var db = DBConnect.getDB();
            var Users = db.GetCollection<Models.User.User>("User");

            var passwordHash = MD5Hash.GetMD5Hash(password);

            var builder = Builders<Models.User.User>.Filter;
            var filter = builder.Where(u => u.Username.Equals(username));

            var updateBuilder = Builders<Models.User.User>.Update;
            var update = updateBuilder.Set(u => u.PasswordHash, passwordHash);

            Users.UpdateOne(filter, update);
        }

        /// <summary>
        ///     Edit user information: firstname, lastname, email
        /// </summary>
        /// <param name="username"></param>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <param name="email"></param>
        public void EditInformation(string username, string firstname, string lastname, string email)
        {
            var db = DBConnect.getDB();
            var Users = db.GetCollection<Models.User.User>("User");

            //Build filter to find user need to edit
            var builder = Builders<Models.User.User>.Filter;
            var filter = builder.Where(u => u.Username.Equals(username));

            //build update
            var updateBuilder = Builders<Models.User.User>.Update;
            var update = updateBuilder.Set(u => u.FirstName, firstname).Set(u => u.LastName, lastname)
                .Set(u => u.Email, email);

            Users.UpdateOne(filter, update);
        }
    }
}