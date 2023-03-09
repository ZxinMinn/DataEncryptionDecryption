using DataEncription.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataEncription.Encryption
{
    public class RSAEncryptionDecryptionManager
    {
        //RSACryptoServiceProvider 2048
        // Also known as asymmetric cryptography.
        //Two keys are used: Public Key and Private Key.
        //Public Key: For encryption.
        //Private Key: For decryption, also known as a secret key.
        public static string EncryptWithRSA(string data, RSAParameters rsaParameters)
        {
            string response = string.Empty;
            try
            {
                using (RSACryptoServiceProvider provider = new RSACryptoServiceProvider())
                {
                    provider.ImportParameters(rsaParameters);
                    var byte_data = Encoding.UTF8.GetBytes(data);
                    var encrypted_data = provider.Encrypt(byte_data, false);
                    response = Convert.ToBase64String(encrypted_data);
                }

            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
            }
            return response;
        }
        public static string DecryptWithRSA(string encryptedTest, RSAParameters parameters)
        {
            string decrypted_Text = string.Empty;
            try
            {
                using (RSACryptoServiceProvider provider = new RSACryptoServiceProvider())
                {
                    var encrypted_byte = Convert.FromBase64String(encryptedTest);
                    provider.ImportParameters(parameters);
                    var decrypt_data = provider.Decrypt(encrypted_byte, false);
                    decrypted_Text = Encoding.UTF8.GetString(decrypt_data);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
            }
            return decrypted_Text;
        }
    }
}
