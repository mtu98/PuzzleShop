using Microsoft.AspNetCore.Mvc;
using PuzzleShop.Shared.Models;

namespace PuzzleShop.Server.Controllers {
    public class UserController : Controller {

        [HttpPost]
        [Route("api/User/Login")]
        public bool Login([FromBody] User user) {
            var dao = new UserDAO();
            var result = dao.CheckLogin(user.Username, user.Password);
            return result;
        }
    }
}
