using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Library.Account;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            
            AccountDAO dao = new AccountDAO();
            Console.WriteLine("Username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Password: ");
            string password = Console.ReadLine();
            bool result = dao.checkLogin(username, password);
            if (result)
            {
                Console.WriteLine("Login success");
            }
            else
            {
                Console.WriteLine("Login fail");
                register();
            }
        }

        static void register()
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
                AccountDAO dao = new AccountDAO();
                dao.register(username, password, firstName, lastName, email);
                }
        }
    }
}
