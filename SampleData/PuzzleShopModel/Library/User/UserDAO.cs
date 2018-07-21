using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Library.UserCollection
{
    public class UserDAO
    {
        /// <summary>
        /// Check login by username or email
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public User checkLogin(string Username_Email, string Password)
        {
            //Get connection and PuzzleShopDB
            var db = utils.DBConnect.getDB();
            var Users = db.GetCollection<User>("User");
            var builder = Builders<User>.Filter;
            //Find account by username or password
            var filter = builder.Where(a => a.Username.Equals(Username_Email)) | builder.Where(a =>a.Email.Equals(Username_Email));
            
            List<User> list = Users.Find(filter).ToList();
            if(list.Count > 0)
            {
                string passwordHash = list[0].PasswordHash;
                if (MD5Hash.VerifyMD5Hash(Password, passwordHash))
                    return list[0];
            }
            return null;
        }


        /// <summary>
        /// Register, input must be validated first
        /// If Username or Email existed in system, throw Duplicate Exception
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        public void register(string username, string password, string firstName, string lastName, string email)
        {
            var db = utils.DBConnect.getDB();
            var Users = db.GetCollection<User>("User");
            string passwordHash = MD5Hash.GetMD5Hash(password);
            try
            {
                Users.InsertOne(new User
                {
                    Username = username,
                    PasswordHash = passwordHash,
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    Role = 1
                });
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Update a user password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public void ChangePassword(string username, string password)
        {
            var db = utils.DBConnect.getDB();
            var Users = db.GetCollection<User>("User");

            string passwordHash = MD5Hash.GetMD5Hash(password);

            var builder = Builders<User>.Filter;
            var filter = builder.Where(u => u.Username.Equals(username));

            var updateBuilder = Builders<User>.Update;
            var update = updateBuilder.Set(u => u.PasswordHash, passwordHash);

            try
            {
                Users.UpdateOne(filter, update);
            }
            catch (Exception)
            {

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
        public void EditInformation(string username, string firstname, string lastname, string email)
        {
            var db = utils.DBConnect.getDB();
            var Users = db.GetCollection<User>("User");

            //Build filter to find user need to edit
            var builder = Builders<User>.Filter;
            var filter = builder.Where(u => u.Username.Equals(username));

            //build update
            var updateBuilder = Builders<User>.Update;
            var update = updateBuilder.Set(u => u.FirstName, firstname).Set(u => u.LastName, lastname).Set(u => u.Email, email);

            try
            {
                Users.UpdateOne(filter, update);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
