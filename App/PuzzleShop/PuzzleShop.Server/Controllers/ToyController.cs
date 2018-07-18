using Microsoft.AspNetCore.Mvc;
using PuzzleShop.Shared.Models.Toy;
using System.Collections.Generic;

namespace PuzzleShop.Server.Controllers {
    public class ToyController : Controller {

        private ToyDAO _toyDao = new ToyDAO();

        [HttpPost]
        [Route("api/Toy/Search")]
        public List<Toy> Search([FromBody] string searchValue) {
            var result = _toyDao.FindToys(searchValue);
            return result;
        }
    }
}
