using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Library
{
    public class MD5Hash
    {
        public static string GetMD5Hash(string input)
        {
            //Convert input to byte
            //Compute hash
            MD5 MD5Hash = MD5.Create();
            byte[] data = MD5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder builder = new StringBuilder();

            //Loop through Hash data
            //format to hexadecimal
            for ( int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }

            return builder.ToString();
        }


        public static bool VerifyMD5Hash(string input, string hash)
        {
            //Hash input
            string hashInput = GetMD5Hash(input);

            //Compare
            StringComparer cmp = StringComparer.Ordinal;
            //return 0 means equal
            if (cmp.Compare(hashInput, hash) == 0)
            {
                return true;
            }
            else
                return false;
        }


        public static void Main()
        {
            string input = Console.ReadLine();
            MD5 MD5Hash = MD5.Create();
            string Hash = GetMD5Hash(input);
            Console.WriteLine(Hash);
        }
    }
}
