using MongoDB.Bson;
using System;

namespace PuzzleShop.Shared.Models {
    public class User {

        public BsonObjectId _id { get; set; }

        public string Username { get; set; }

        public string PasswordHash { get; set; }

        //[Required(ErrorMessage = "Password is required!")]
        public string Password { get; set; }

        public string ConfirmedPassword { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        //[Required(ErrorMessage = "Email is required!")]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime Birthdate { get; set; }

        public double RoleId { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
