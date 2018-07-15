using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Library.Account;
using Library.Toy;
namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            
            AccountDAO dao = new AccountDAO();
            Console.WriteLine("Username or email: ");
            string username = Console.ReadLine();
            Console.WriteLine("Password: ");
            string password = Console.ReadLine();
            bool result = dao.checkLogin(username, password);
            if (result)
            {
                Console.WriteLine("Login success");
                Console.WriteLine("Search toy: ");
                string toyName = Console.ReadLine();
                ToyDAO ToyDao = new ToyDAO();
                ToyDao.FindToys(toyName);
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
                AccountDAO dao = new AccountDAO();
                try
                {
                    dao.register(username, password, firstName, lastName, email);
                    
                }
                catch (Exception e)
                {
                    throw e;
                }
                
            }
            return true;
        }
    }
}
