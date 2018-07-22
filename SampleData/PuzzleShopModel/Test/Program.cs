using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Library.UserCollection;
using Library.ToyCollection;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            
            UserDAO dao = new UserDAO();
            Console.WriteLine("Username or email: ");
            string Username = Console.ReadLine();
            Console.WriteLine("Password: ");
            string Password = Console.ReadLine();
            User result = dao.checkLogin(Username, Password);
            if (result != null)
            {
                Console.WriteLine("Login success");

                ToyDAO ToyDao = new ToyDAO();

                Console.WriteLine("Search toy: ");
                string toyName = Console.ReadLine();
                List<Toy> list = ToyDao.FindToys(toyName);

                //Console.WriteLine("Three Random Toys");
                //List<Toy> list = ToyDao.RandomToy();

                foreach (Toy t in list)
                {
                    Console.WriteLine(t.ToString());
                }

                Console.WriteLine("Comment: ");
                string cmt = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Login fail");
                try
                {
                    if (register())
                    {
                        Console.WriteLine("Register successfull!");
                    }
                    else
                    {
                        Console.WriteLine("Register fail");
                    }
                }
                catch (Exception e)
                {
                    if(e.Message.Contains("UNIQUE USERNAME"))
                    {
                        Console.WriteLine("Register fail! Username already taken!");
                    }
                    if(e.Message.Contains("UNIQUE EMAIL"))
                    {
                        Console.WriteLine("Register fail! Email already taken!");
                    }
                }
            }
        }

        static bool register()
        {
            Console.WriteLine("Do you want to register?(Y/N)");
            string choice = Console.ReadLine();
            if (choice.ToUpper().Equals("Y"))
            {
                Console.WriteLine("Username: ");
                string username = Console.ReadLine();
                Console.WriteLine("Password: ");
                string password = Console.ReadLine();
                Console.WriteLine("First Name: ");
                string firstName = Console.ReadLine();
                Console.WriteLine("Last Name: ");
                string lastName = Console.ReadLine();
                Console.WriteLine("Email: ");
                string email = Console.ReadLine();
                if (username == null || password == null || firstName == null || lastName == null || email == null)
                    return false;
                UserDAO dao = new UserDAO();
                try
                {
                    dao.register(username, password, firstName, lastName, email);
                    
                }
                catch (Exception e)
                {
                    throw e;
                }
                return true;
            }
            return false;
        }
    }
}
