using MongoDB.Bson;

namespace Library.User {

    public class User {
        public BsonObjectId _id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
    }

}
