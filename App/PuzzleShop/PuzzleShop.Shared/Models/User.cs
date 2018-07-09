
using System.ComponentModel.DataAnnotations;

namespace PuzzleShop.Shared.Models {
    public class User {
        [Required(ErrorMessage = "Email is required!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required!")]
        public string Password { get; set; }
    }
}
