using MongoDB.Driver;
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
        public bool CreateOrder(string Username, Dictionary<Toy.Toy, int> ListItems) {
            //Get connection and PuzzleShopDB
            var db = DBConnect.getDB();
            var Orders = db.GetCollection<Orders>("Orders");

            string OrderDate = DateTime.Now.ToString();
            double Total = 0;
            OrderItem[] OrderItems = null;
            foreach (KeyValuePair<Toy.Toy, int> entry in ListItems) {
                Total += entry.Key.Price * entry.Value;
                OrderItem i = new OrderItem {
                    Toy = entry.Key,
                    Quantity = entry.Value
                };
                OrderItems[OrderItems.Length - 1] = i;
            }
            //Status = -1 means Pending order
            // 0 means Processing order
            // 1 means Completed order
            int Status = -1;

            try {
                Orders.InsertOne(new Orders {
                    OrderDate = OrderDate,
                    Username = Username,
                    OrderItems = OrderItems,
                    Total = Total,
                    Status = Status
                });
                return true;
            } catch (Exception) {

                throw;
            }
        }

        public List<Dictionary<Toy.Toy, int>> GetAllOrders(string Username) {
            var db = DBConnect.getDB();
            var Orders = db.GetCollection<Orders>("Orders");

            var builder = Builders<Orders>.Filter;
            var filter = builder.Where(od => od.Username.Equals(Username));

            //List All Orders of User return to client
            List<Dictionary<Toy.Toy, int>> allOrders = new List<Dictionary<Toy.Toy, int>>();

            try {
                //Query all orders
                List<Orders> list = Orders.Find(filter).ToList();
                foreach (Orders o in list) {

                    Dictionary<Toy.Toy, int> order = new Dictionary<Toy.Toy, int>();
                    for (int i = 0; i < o.OrderItems.Length; i++) {
                        order.Add(o.OrderItems[i].Toy, o.OrderItems[i].Quantity);
                    }
                    allOrders.Add(order);
                }
            } catch (Exception) {

                throw;
            }
            return allOrders;

        }
    }
}
