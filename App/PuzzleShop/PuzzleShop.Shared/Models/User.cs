using MongoDB.Bson;
using Newtonsoft.Json;
using System;

namespace PuzzleShop.Shared.Models {
    public class User {

        [JsonIgnore]
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

        public string GetErrors(string propertyName) {
            if (propertyName == null || propertyName == nameof(this.Username)) {
                if (DuplicateUsername) {
                    return Username + " has been used!";
                }
                if (string.IsNullOrEmpty(this.Username)) {
                    HasErrors = true;
                    return $"{nameof(Username)} is mandatory";
                }
            }
            if (propertyName == null || propertyName == nameof(this.Password)) {
                if (string.IsNullOrEmpty(this.Password)) {
                    HasErrors = true;
                    return $"{nameof(Password)} is mandatory";
                }
            }
            if (propertyName == null || propertyName == nameof(this.ConfirmedPassword)) {
                if (string.IsNullOrEmpty(this.ConfirmedPassword)) {
                    HasErrors = true;
                    return $"{nameof(ConfirmedPassword)} is mandatory";
                } else if (!this.ConfirmedPassword.Equals(this.Password)) {
                    HasErrors = true;
                    return $"{nameof(ConfirmedPassword)} must match with {nameof(Password)}";
                }
            }
            if (propertyName == null || propertyName == nameof(this.FirstName)) {
                if (string.IsNullOrEmpty(this.FirstName)) {
                    HasErrors = true;
                    return $"{nameof(FirstName)} is mandatory";
                }
            }
            if (propertyName == null || propertyName == nameof(this.LastName)) {
                if (string.IsNullOrEmpty(this.LastName)) {
                    HasErrors = true;
                    return $"{nameof(LastName)} is mandatory";
                }
            }
            if (propertyName == null || propertyName == nameof(this.Email)) {
                if (string.IsNullOrEmpty(this.Email)) {
                    HasErrors = true;
                    return $"{nameof(Email)} is mandatory";
                }
            }

            return null;
        }

        public bool HasErrors { get; set; } = false;

        public bool DuplicateUsername { get; set; } = false;

        public void Validate() {
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
