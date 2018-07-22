using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.ToyCollection;
using MongoDB.Driver;



namespace Library.OrdersCollection
{
    public class OrdersDAO
    {

        /// <summary>
        /// Not done yet
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="OrderItems"></param>
        /// <returns></returns>
        public bool CreateOrder(string Username, Dictionary<Toy,int> ListItems)
        {
            //Get connection and PuzzleShopDB
            var db = utils.DBConnect.getDB();
            var Orders = db.GetCollection<Orders>("Orders");

            string OrderDate = DateTime.Now.ToString();
            double Total = 0;

            OrderItem[] OrderItems = Array.Empty<OrderItem>();

            //iterate through list Toy-Quantity of user's order
            foreach (KeyValuePair<Toy,int>entry in ListItems)
            {
                ToyDAO toyDao = new ToyDAO();

                //Check quantity if enough
                if( toyDao.GetQuantity(entry.Key._id) < entry.Value)
                {
                    throw new Exception("Quantity exceed!");
                }

                //calculate Total price
                Total += entry.Key.Price * entry.Value;

                //Create a Order item
                OrderItem i = new OrderItem
                {
                    Toy = entry.Key,
                    Quantity = entry.Value
                };

                //Add more memory to array
                Array.Resize<OrderItem>(ref OrderItems, OrderItems.Length + 1);
                //Add Order item to Toy-Quantity list
                OrderItems[OrderItems.Length - 1] = i;
            }
            //Status = -1 means Pending order
            // 0 means Processing order
            // 1 means Completed order
            int Status = -1;

            try
            {
                Orders.InsertOne(new Orders
                {
                    OrderDate = OrderDate,
                    Username = Username,
                    OrderItems = OrderItems,
                    Total = Total,
                    Status = Status
                });
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Dictionary<Toy,int>> GetAllOrders(string Username)
        {
            var db = utils.DBConnect.getDB();
            var Orders = db.GetCollection<Orders>("Orders");

            var builder = Builders<Orders>.Filter;
            var filter = builder.Where(od => od.Username.Equals(Username));

            //List All Orders of User return to client
            List<Dictionary<Toy, int>> allOrders = new List<Dictionary<Toy, int>>();

            try
            {
                //Query all orders
                List<Orders> list = new List<Orders>();
                list = Orders.Find(filter).ToList();
                
                foreach (Orders o in list)
                {

                    Dictionary<Toy, int> order = new Dictionary<Toy, int>();
                    for (int i = 0; i < o.OrderItems.Length; i++)
                    {
                        order.Add(o.OrderItems[i].Toy, o.OrderItems[i].Quantity);
                    }
                    allOrders.Add(order);
                }
            }
            
            catch (Exception)
            {

                throw;
            }
            return allOrders;

        }
    }
}
