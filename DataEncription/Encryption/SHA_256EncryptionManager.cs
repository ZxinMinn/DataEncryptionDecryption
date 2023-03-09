using DataEncription.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataEncription.Encryption
{
   public  class SHA_256EncryptionManager
    {
        public static string EnctyptWithSHA_256(string data)
        {
            string response = string.Empty;
            try
            {
                using (SHA256 sHA256 = SHA256.Create())
                {
                    byte[] messageBytes = Encoding.UTF8.GetBytes(data);
                    byte[] hashValue = sHA256.ComputeHash(messageBytes);
                    response = Convert.ToBase64String(hashValue);
                }
            }catch(Exception ex)
            {
                Logger.LogError(ex.Message);
            }
            return response;
        }
    }
}
