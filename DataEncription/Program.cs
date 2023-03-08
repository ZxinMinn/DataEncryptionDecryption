using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using DataEncription.Encryption;

namespace DataEncription
{
    class Program
    {
       // .NET Core provides various encryption methods that can be used to protect data and ensure its confidentiality.
        static void Main(string[] args)
        {
            string decryptedData = string.Empty;
            string key = "b14ca5898a4e4133bbce2ea2315a1916";
            string password = Console.ReadLine();
            byte[] data = DataEnctyptionService.EnctyptWithAes(key,password);
            // StoreBase64StringInDatabase
            Console.WriteLine(Convert.ToBase64String(data));
            //
            if (data != null)
            {
                decryptedData = DataEnctyptionService.DecryptwithAes(key, data);
                Console.WriteLine(decryptedData);
            }
            //if true print equal
            if (password.Equals(decryptedData))
            {
                Console.WriteLine("equals");
            }
        }
    }
    
}
