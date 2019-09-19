using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace EventApplication.Business.EncryptionAndDecryption
{
    public class EncriptionAndDecription
    {


        public static string Encrypt(string encryptString)
        {
            byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(encryptString);
            string encrypted = Convert.ToBase64String(b);
            return encrypted;
        }

        public static string Decrypt(string encrString)
        {
            byte[] b;
            string decrypted;
            try
            {
                b = Convert.FromBase64String(encrString);
                decrypted = System.Text.ASCIIEncoding.ASCII.GetString(b);
            }
            catch (FormatException fe)
            {
                decrypted = "";
            }
            return decrypted;
        }
    }
}
