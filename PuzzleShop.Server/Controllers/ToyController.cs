using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PuzzleShop.Shared.Models.Toy;

namespace PuzzleShop.Server.Controllers
{
    public class ToyController : Controller
    {
        private readonly ToyDAO _toyDao = new ToyDAO();

        [HttpPost]
        [Route("api/Toy/Search")]
        public List<Toy> Search([FromBody] string searchValue)
        {
            var result = _toyDao.FindByName(searchValue);
            return result;
        }

        [HttpPost]
        [Route("api/Toy/WriteReview")]
        public bool WriteReview([FromBody] SimpleToyReview toyReview)
        {
            _toyDao.ReviewAToy(toyReview.ToyId, toyReview.Username, toyReview.Email, toyReview.Title,
                toyReview.Content, toyReview.Star);
            return true;
        }

        [HttpGet]
        [Route("api/toy/{toyId}")]
        public Toy GetToyById([FromRoute] string toyId)
        {
            return _toyDao.FindById(toyId);
        }

        [HttpGet]
        [Route("api/Toy/GetFeatureToys")]
        public List<Toy> GetFeatureToys()
        {
            return _toyDao.GetRandomToy(3);
        }

        [HttpGet]
        [Route("api/Toy/GetNewToys")]
        public List<Toy> GetNewToys()
        {
            return _toyDao.GetRandomToy(5);
        }

        [HttpGet]
        [Route("api/toys")]
        public List<Toy> GetAllToys()
        {
            return _toyDao.AllToys();
        }

        [HttpGet]
        [Route("api/toys/category")]
        public string GetAllCategories()
        {
            return JsonConvert.SerializeObject(_toyDao.GetCategoriesAndQuantities());
        }

        [HttpGet]
        [Route("api/toys/category/{category}")]
        public List<Toy> GetToysOfType([FromRoute] string category)
        {
            return _toyDao.GetAllToyOfCategory(category);
        }
    }
}