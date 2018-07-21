using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PuzzleShop.Shared.Models.Cart;
using PuzzleShop.Shared.Models.Toy;
using System.Collections.Generic;
using System.Linq;

namespace PuzzleShop.Server.Controllers {
    public class CartController : Controller {
        [HttpPost]
        [Route("api/Cart/AddToCart")]
        public bool AddToCart([FromBody] Toy toy) {
            // get cart in session
            Cart cart = null;
            List<KeyValuePair<Toy, int>> toyList = null;
            int quantity = 0;
            var cartJson = HttpContext.Session.GetString("CART");
            if (string.IsNullOrEmpty(cartJson)) {
                cart = new Cart();
            } else {
                toyList = JsonConvert.DeserializeObject<List<KeyValuePair<Toy, int>>>(cartJson);
                cart = new Cart(toyList.ToDictionary(item => item.Key, item => item.Value));
                if (cart.ContainsKey(toy)) {
                    quantity = cart[toy];
                }
            }

            // add toy to cart
            quantity += toy.Quantity;
            cart[toy] = quantity;

            // add cart to session
            toyList = cart.ToList();
            cartJson = JsonConvert.SerializeObject(toyList);
            HttpContext.Session.SetString("CART", cartJson);

            //Debug.WriteLine("===> Added toy: " + toy._id + ", " + cart[toy] + "; json: " + cartJson);
            return true;
        }

        [HttpGet]
        [Route("api/Cart/GetCart")]
        public string GetCartListAsJson() {
            var cartJson = HttpContext.Session.GetString("CART");
            return cartJson;
        }
    }
}
