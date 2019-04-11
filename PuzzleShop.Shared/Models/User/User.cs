using System;
using MongoDB.Bson;
using Newtonsoft.Json;

namespace PuzzleShop.Shared.Models.User
{
    public class User
    {
        [JsonIgnore] public BsonObjectId _id { get; set; }

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

        public bool HasErrors { get; set; }

        public bool DuplicateUsername { get; set; } = false;

        public string GetErrors(string propertyName)
        {
            if (propertyName == null || propertyName == nameof(Username))
            {
                if (DuplicateUsername) return Username + " has been used!";
                if (string.IsNullOrEmpty(Username))
                {
                    HasErrors = true;
                    return $"{nameof(Username)} is mandatory";
                }
            }

            if (propertyName == null || propertyName == nameof(Password))
                if (string.IsNullOrEmpty(Password))
                {
                    HasErrors = true;
                    return $"{nameof(Password)} is mandatory";
                }

            if (propertyName == null || propertyName == nameof(ConfirmedPassword))
            {
                if (string.IsNullOrEmpty(ConfirmedPassword))
                {
                    HasErrors = true;
                    return $"{nameof(ConfirmedPassword)} is mandatory";
                }

                if (!ConfirmedPassword.Equals(Password))
                {
                    HasErrors = true;
                    return $"{nameof(ConfirmedPassword)} must match with {nameof(Password)}";
                }
            }

            if (propertyName == null || propertyName == nameof(FirstName))
                if (string.IsNullOrEmpty(FirstName))
                {
                    HasErrors = true;
                    return $"{nameof(FirstName)} is mandatory";
                }

            if (propertyName == null || propertyName == nameof(LastName))
                if (string.IsNullOrEmpty(LastName))
                {
                    HasErrors = true;
                    return $"{nameof(LastName)} is mandatory";
                }

            if (propertyName == null || propertyName == nameof(Email))
                if (string.IsNullOrEmpty(Email))
                {
                    HasErrors = true;
                    return $"{nameof(Email)} is mandatory";
                }

            return null;
        }

        public void Validate()
        {
            HasErrors = false;
            GetErrors(nameof(Username));
            GetErrors(nameof(PasswordHash));
            GetErrors(nameof(Password));
            GetErrors(nameof(ConfirmedPassword));
            GetErrors(nameof(FirstName));
            GetErrors(nameof(LastName));
            GetErrors(nameof(Email));
        }
    }
}