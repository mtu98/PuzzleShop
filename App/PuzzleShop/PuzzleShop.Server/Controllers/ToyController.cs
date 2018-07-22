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

        [HttpPost]
        [Route("api/Toy/WriteReview")]
        public bool WriteReview([FromBody] SimpleToyReview toyReview) {
            _toyDao.ReviewAToy(toyReview.Toyid, toyReview.Username, toyReview.Email, toyReview.Title,
                toyReview.Content, toyReview.Star);
            return true;
        }

        [HttpPost]
        [Route("api/Toy/GetToyById")]
        public Toy GetToyById([FromBody] string toyId) {
            return _toyDao.FindToyById(toyId);
        }

        [HttpGet]
        [Route("api/Toy/GetFeatureToys")]
        public List<Toy> GetFeatureToys() {
            return _toyDao.Random3Toy();
        }

        [HttpGet]
        [Route("api/Toy/GetNewToys")]
        public List<Toy> GetNewToys() {
            return _toyDao.Random5Toy();
        }
    }
}
