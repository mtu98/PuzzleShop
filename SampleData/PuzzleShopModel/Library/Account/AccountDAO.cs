using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Library.Account
{
    public class AccountDAO
    {
        /// <summary>
        /// Check login function
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool checkLogin(string username, string password)
        {
            //Get connection and PuzzleShopDB
            var db = utils.DBConnect.getDB();
            var accounts = db.GetCollection<AccountDTO>("Account");
            var builder = Builders<AccountDTO>.Filter;
            var filter = builder.Where(a => a.username.Equals(username));
            List<AccountDTO> list = accounts.Find(filter).ToList();
            if(list.Count > 0)
            {
                string passwordHash = list[0].passwordHash;
                if (MD5Hash.VerifyMD5Hash(password, passwordHash))
                    return true;
            }
            return false;
        }

        public void register(string username, string password, string firstName, string lastName, string email)
        {
            var db = utils.DBConnect.getDB();
            var accounts = db.GetCollection<AccountDTO>("Account");
            string passwordHash = MD5Hash.GetMD5Hash(password);
            accounts.InsertOneAsync(new AccountDTO
            {
                username = username,
                passwordHash = passwordHash,
                firstName = firstName,
                lastName = lastName,
                email = email,
                role = 1
            });
        }

    }
}
