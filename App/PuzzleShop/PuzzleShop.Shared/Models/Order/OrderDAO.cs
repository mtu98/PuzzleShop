using System;
using System.Collections.Generic;
using Utils;

namespace PuzzleShop.Shared.Models.Order {
    public class OrdersDAO {

        /// <summary>
        /// Not done yet
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="OrderItems"></param>
        /// <returns></returns>
        public bool CreateOrder(string Username, Dictionary<Toy.Toy, int> OrderItems) {
            //Get connection and PuzzleShopDB
            var db = DBConnect.getDB();
            var Orders = db.GetCollection<Orders>("Orders");

            string OrderDate = DateTime.Now.ToString();
            double Total = 0;
            int Status = -1;

            try {
                Orders.InsertOne(new Orders {
                    OrderDate = OrderDate,
                    Username = Username,
                    Total = Total,
                    Status = Status
                });
                return true;
            } catch (Exception) {

                throw;
            }
            return false;
        }
    }
}
