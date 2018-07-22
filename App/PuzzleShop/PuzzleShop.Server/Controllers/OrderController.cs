using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PuzzleShop.Shared.Models.Cart;
using PuzzleShop.Shared.Models.Order;
using PuzzleShop.Shared.Models.Toy;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PuzzleShop.Server.Controllers {
    public class OrderController : Controller {

        private OrdersDAO _ordersDao = new OrdersDAO();

        [HttpPost]
        [Route("api/Order/SaveOrder")]
        public bool SaveOrder() {
            // get cart in session
            Cart cart = null;
            List<KeyValuePair<Toy, int>> toyList = null;
            var cartJson = HttpContext.Session.GetString("CART");
            if (string.IsNullOrEmpty(cartJson)) {
                return false;
            } else {
                toyList = JsonConvert.DeserializeObject<List<KeyValuePair<Toy, int>>>(cartJson);
                cart = new Cart(toyList.ToDictionary(item => item.Key, item => item.Value));
            }

            // get login user
            var username = HttpContext.Session.GetString("USERNAME");
            try {
                var result = _ordersDao.CreateOrder(username, cart);
                Debug.WriteLine("==> save order result: " + result);
                if (result) {
                    HttpContext.Session.Remove("CART"); // delete cart
                }

                return result;
            } catch (Exception ex) {
                return false;
            }
        }
    }
}
