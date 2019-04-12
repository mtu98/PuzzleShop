using System;
using MongoDB.Driver;
using Utils;

namespace PuzzleShop.Shared.Models.User
{
    public class UserDAO
    {
        private const string CollectionName = "User";

        public User CheckLogin(string emailOrUsername, string password)
        {
            var userCollection = DBConnect.getDB().GetCollection<User>(CollectionName);
            var builder = Builders<User>.Filter;

            var filter = builder.Where(user =>
                user.Username.Equals(emailOrUsername) | user.Email.Equals(emailOrUsername));
            var list = userCollection.Find(filter).ToList();

            foreach (var user in list)
            {
                var passwordHash = user.PasswordHash;
                if (MD5Hash.VerifyMD5Hash(password, passwordHash))
                    return user;
            }

            return null;
        }

        /// <summary>
        ///     TODO Adjust this pretty dirty method
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool Register(User user)
        {
            var userCollection = DBConnect.getDB().GetCollection<User>(CollectionName);
            user.PasswordHash = MD5Hash.GetMD5Hash(user.Password);
            userCollection.InsertOne(new User
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

        public User GetUserByUsername(string emailOrUsername)
        {
            var userCollection = DBConnect.getDB().GetCollection<User>(CollectionName);
            var builder = Builders<User>.Filter;

            var filter = builder.Where(user =>
                user.Username.Equals(emailOrUsername) | user.Email.Equals(emailOrUsername));
            return userCollection.Find(filter).Single();
        }

        /// <summary>
        ///     Update a user password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public bool ChangePassword(string username, string password)
        {
            var userCollection = DBConnect.getDB().GetCollection<User>(CollectionName);

            var passwordHash = MD5Hash.GetMD5Hash(password);

            var builder = Builders<User>.Filter;
            var filter = builder.Where(u => u.Username.Equals(username));

            var updateBuilder = Builders<User>.Update;
            var update = updateBuilder.Set(u => u.PasswordHash, passwordHash);

            return userCollection.UpdateOne(filter, update).IsAcknowledged;
        }

        /// <summary>
        ///     Edit user information: firstname, lastname, email
        /// </summary>
        /// <param name="username"></param>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <param name="email"></param>
        public bool EditInformation(string username, string firstname, string lastname, string email)
        {
            var userCollection = DBConnect.getDB().GetCollection<User>(CollectionName);

            //Build filter to find user need to edit
            var builder = Builders<User>.Filter;
            var filter = builder.Where(u => u.Username.Equals(username));

            //build update
            var updateBuilder = Builders<User>.Update;
            var update = updateBuilder.Set(u => u.FirstName, firstname).Set(u => u.LastName, lastname)
                .Set(u => u.Email, email);

            return userCollection.UpdateOne(filter, update).IsAcknowledged;
        }
    }
}