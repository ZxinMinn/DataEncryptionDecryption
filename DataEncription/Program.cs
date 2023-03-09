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
            #region Advanced Encryption Standard ( AES ) Algorithm 
            string decryptedData = string.Empty;
            string key = "kljsdkkdlo4454GG";
            string password = Console.ReadLine();
            string data = DataEnctyptionService.EnctyptWithAes(key,password);
            // StoreBase64StringInDatabase
            Console.WriteLine(data);
            //
            if (!string.IsNullOrEmpty(data))
            {
                decryptedData = DataEnctyptionService.DecryptwithAes(key, data);
                Console.WriteLine(decryptedData);
            }
            //if true print equal
            if (password.Equals(decryptedData))
            {
                Console.WriteLine("equals");
            }
            #endregion
            #region RSA algorithm
            RSACryptoServiceProvider provider = new RSACryptoServiceProvider(2048);
            RSAParameters encParameters = provider.ExportParameters(false);
            RSAParameters decParameters = provider.ExportParameters(true);
            string original_Text = "Hello From RSA algoritms";
            var encryptedText = RSAEncryptionDecryptionManager.EncryptWithRSA(original_Text, encParameters);
            Console.WriteLine(encryptedText);
            string decryptedText = RSAEncryptionDecryptionManager.DecryptWithRSA(encryptedText, decParameters);
            Console.WriteLine(decryptedText);
            #endregion
        }
    }
    
}
