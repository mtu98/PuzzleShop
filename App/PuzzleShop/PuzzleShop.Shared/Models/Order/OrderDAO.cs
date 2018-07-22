using MongoDB.Driver;
using PuzzleShop.Shared.Models.Toy;
using System;
using System.Collections.Generic;
using Utils;

namespace PuzzleShop.Shared.Models.Order {
    public class OrdersDAO {
        /// <summary>
        /// Not done yet
        /// </summary>
        /// <param name="username"></param>
        /// <param name="ListItems"></param>
        /// <returns></returns>
        public bool CreateOrder(string username, Dictionary<Toy.Toy, int> ListItems) {
            //Get connection and PuzzleShopDB
            var db = DBConnect.getDB();
            var orders = db.GetCollection<Orders>("Orders");

            string orderDate = DateTime.Now.ToString();
            double total = 0;

            OrderItem[] orderItems = Array.Empty<OrderItem>();

            //iterate through list Toy-Quantity of user's order
            foreach (KeyValuePair<Toy.Toy, int> entry in ListItems) {
                ToyDAO toyDao = new ToyDAO();

                //Check quantity if enough
                if (toyDao.GetQuantity(entry.Key._id) < entry.Value) {
                    throw new Exception("Quantity exceed!");
                }

                //calculate Total price
                total += entry.Key.Price * entry.Value;

                //Create a Order item
                OrderItem i = new OrderItem {
                    Toy = entry.Key,
                    Quantity = entry.Value
                };

                //Add more memory to array
                Array.Resize<OrderItem>(ref orderItems, orderItems.Length + 1);
                //Add Order item to Toy-Quantity list
                orderItems[orderItems.Length - 1] = i;
            }
            //Status = -1 means Pending order
            // 0 means Processing order
            // 1 means Completed order
            int Status = -1;

            try {
                orders.InsertOne(new Orders {
                    OrderDate = orderDate,
                    Username = username,
                    OrderItems = orderItems,
                    Total = total,
                    Status = Status
                });
                return true;
            } catch (Exception) {

                throw;
            }
        }

        public List<Orders> GetAllOrders(string Username) {
            var db = DBConnect.getDB();
            var Orders = db.GetCollection<Orders>("Orders");

            var builder = Builders<Orders>.Filter;
            var filter = builder.Where(od => od.Username.Equals(Username));

            List<Orders> list = new List<Orders>();

            try {
                list = Orders.Find(filter).ToList();
            } catch (Exception) {

                throw;
            }

            return list;

        }


    }
}
