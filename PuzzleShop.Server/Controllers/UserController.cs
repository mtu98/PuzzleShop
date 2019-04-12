using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PuzzleShop.Shared.Models.User;

namespace PuzzleShop.Server.Controllers
{
    public class UserController : Controller
    {
        private readonly UserDAO _userDao = new UserDAO();

        [HttpPost]
        [Route("api/User/Login")]
        public User Login([FromBody] User user)
        {
            var result = _userDao.CheckLogin(user.Username, user.Password);
            if (result != null) HttpContext.Session.SetString("USERNAME", result.Username);
            return result;
        }

        [HttpPost]
        [Route("api/User/Register")]
        public bool Register([FromBody] User user)
        {
            return _userDao.Register(user);
        }

        [HttpGet]
        [Route("api/User/GetLoginUser")]
        public string GetLoginUser()
        {
            return HttpContext.Session.GetString("USERNAME");
        }

        [HttpDelete]
        [Route("api/User/Logout")]
        public void Logout()
        {
            HttpContext.Session.Remove("USERNAME");
        }

        [HttpGet]
        [Route("api/User/GetLoginUserObject")]
        public User GetLoginUserObject()
        {
            // get login username
            var username = GetLoginUser();
            if (string.IsNullOrEmpty(username)) return null;

            return _userDao.GetUserByUsername(username);
        }

        [HttpPost]
        [Route("api/User/UpdateProfile")]
        public bool UpdateProfile([FromBody] User user)
        {
            _userDao.EditInformation(user.Username, user.FirstName, user.LastName, user.Email);
            return true;
        }

        [HttpPost]
        [Route("api/User/ChangePassword")]
        public bool UpdatePassword([FromBody] User user)
        {
            _userDao.ChangePassword(user.Username, user.Password);
            return true;
        }
    }
}