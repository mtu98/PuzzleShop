using System;
using System.Collections.Generic;
using MongoDB.Driver;
using PuzzleShop.Shared.Models.Toy;
using Utils;

namespace PuzzleShop.Shared.Models.Order
{
    public class OrdersDAO
    {
        /// <summary>
        ///     TODO This is not done
        /// </summary>
        /// <param name="username"></param>
        /// <param name="listItems"></param>
        /// <returns></returns>
        public bool CreateOrder(string username, Dictionary<Toy.Toy, int> listItems)
        {
            //Get connection and PuzzleShopDB
            var db = DBConnect.getDB();
            var orders = db.GetCollection<Orders>("Orders");

            var orderDate = DateTime.Now.ToString();
            double total = 0;

            var orderItems = Array.Empty<OrderItem>();

            //iterate through list Toy-Quantity of user's order
            foreach (var entry in listItems)
            {
                var toyDao = new ToyDAO();

                //Check quantity if enough
                if (toyDao.GetQuantity(entry.Key._id) < entry.Value) throw new Exception("Quantity exceed!");

                //calculate Total price
                total += entry.Key.Price * entry.Value;

                //Create a Order item
                var i = new OrderItem
                {
                    Toy = entry.Key,
                    Quantity = entry.Value
                };

                //Add more memory to array
                Array.Resize(ref orderItems, orderItems.Length + 1);
                //Add Order item to Toy-Quantity list
                orderItems[orderItems.Length - 1] = i;
            }

            //Status = -1 means Pending order
            // 0 means Processing order
            // 1 means Completed order
            var Status = -1;

            orders.InsertOne(new Orders
            {
                OrderDate = orderDate,
                Username = username,
                OrderItems = orderItems,
                Total = total,
                Status = Status
            });
            return true;
        }

        public List<Orders> GetAllOrders(string username)
        {
            var db = DBConnect.getDB();
            var Orders = db.GetCollection<Orders>("Orders");

            var builder = Builders<Orders>.Filter;
            var filter = builder.Where(od => od.Username.Equals(username));

            var list = new List<Orders>();

            list = Orders.Find(filter).ToList();

            return list;
        }
    }
}