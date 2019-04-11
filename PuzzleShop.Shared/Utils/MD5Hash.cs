using System;
using System.Security.Cryptography;
using System.Text;

namespace Utils
{
    public class MD5Hash
    {
        public static string GetMD5Hash(string input)
        {
            //Convert input to byte
            //Compute hash
            var MD5Hash = MD5.Create();
            var data = MD5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            var builder = new StringBuilder();

            //Loop through Hash data
            //format to hexadecimal
            for (var i = 0; i < data.Length; i++) builder.Append(data[i].ToString("x2"));

            return builder.ToString();
        }


        public static bool VerifyMD5Hash(string input, string hash)
        {
            //Hash input
            var hashInput = GetMD5Hash(input);

            //Compare
            var cmp = StringComparer.Ordinal;
            //return 0 means equal
            if (cmp.Compare(hashInput, hash) == 0)
                return true;
            return false;
        }


        //public static void Main() {
        //    string input = Console.ReadLine();
        //    MD5 MD5Hash = MD5.Create();
        //    string Hash = GetMD5Hash(input);
        //    Console.WriteLine(Hash);
        //}
    }
}