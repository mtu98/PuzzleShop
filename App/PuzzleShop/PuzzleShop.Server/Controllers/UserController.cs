using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PuzzleShop.Shared.Models;

namespace PuzzleShop.Server.Controllers {
    public class UserController : Controller {

        private UserDAO _userDao = new UserDAO();

        [HttpPost]
        [Route("api/User/Login")]
        public User Login([FromBody] User user) {
            var result = _userDao.CheckLogin(user.Username, user.Password);
            if (result != null) {
                HttpContext.Session.SetString("USERNAME", result.Username);
            }
            return result;
        }

        [HttpPost]
        [Route("api/User/Register")]
        public bool Register([FromBody] User user) {
            return _userDao.Register(user);
        }

        [HttpGet]
        [Route("api/User/GetLoginUser")]
        public string GetLoginUser() {
            return HttpContext.Session.GetString("USERNAME");
        }

        [HttpDelete]
        [Route("api/User/Logout")]
        public void Logout() {
            HttpContext.Session.Remove("USERNAME");
        }
    }
}
