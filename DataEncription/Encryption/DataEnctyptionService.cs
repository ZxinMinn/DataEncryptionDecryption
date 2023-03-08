using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataEncription.Encryption
{
   public class DataEnctyptionService
    {
        //Encrypt with Aes
        public static byte[] EnctyptWithAes(string key, string password)
        {
            byte[] datas ;
            byte[] iv = new byte[16];
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                //aes.Padding = PaddingMode.None;
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(aes.Key,aes.IV), CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                        {
                            sw.Write(password);
                        }
                    }
                    datas = ms.ToArray();
                }
            }
            return datas;
        }
        //Dectypt with Aes
        public  static string DecryptwithAes(string key , byte[] enctyptedData)
        {
            string data = string.Empty;
            byte[] iv = new byte[16];
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                aes.Padding = PaddingMode.None;
                using (MemoryStream ms = new MemoryStream(enctyptedData))
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(aes.Key, aes.IV), CryptoStreamMode.Read))
                    {
                        using (StreamReader sr = new StreamReader(cs))
                        {
                         data=  sr.ReadToEnd();

                         data=data.Replace("\0", string.Empty).
                                            Replace("\b", string.Empty).
                                            Replace("\v", string.Empty).
                                            Replace("\t", string.Empty).
                                            Replace("\u0010", string.Empty).
                                            Replace("\u0003", string.Empty).
                                            Replace("\u0006", string.Empty);
                        }
                    }
                   
                }
            }
            return data;
        }
    }
}
