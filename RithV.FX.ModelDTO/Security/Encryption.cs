using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace RithV.FX.EntityDTO.Security
{
    public class Encryption64
    {
        //   ****    Use TripleDES CryptoService with Private key pair
        // *****    This key should be the same as that in MSLA.Security.Encryption64
        private static Byte[] _key = System.Text.Encoding.ASCII.GetBytes("dtsQ~JwCLhll;N$GmLMre'bu");

        /// <summary>Decryptor</summary>
        /// <param name="stringToDecrypt">The Encrypted String</param>
        /// <param name="IV">The Initialization Vector</param>
        public static string DecryptFromBase64String(String stringToDecrypt)
        {
            if (stringToDecrypt == String.Empty)
            {
                return String.Empty;
            }

            // the last 8 characters contain the IV
            var IV = System.Text.Encoding.ASCII.GetBytes(stringToDecrypt.Substring(stringToDecrypt.Length - 8, 8));
            stringToDecrypt = stringToDecrypt.Substring(0, stringToDecrypt.Length - 8);

            //   *****   Create a Byte array for the String to decrypt
            var inputByteArray = new Byte[stringToDecrypt.Length];

            var des = new TripleDESCryptoServiceProvider();
            //   ****  we have a base 64 encoded string so first must decode to regular unencoded (encrypted) string
            inputByteArray = Convert.FromBase64String(stringToDecrypt);
            //   ****  now decrypt the regular string
            var ms = new MemoryStream();
            var cs = new CryptoStream(ms, des.CreateDecryptor(_key, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            //   ****    Fetch original string from the Decrypted Memory Stream
            var encoding = System.Text.Encoding.UTF8;
            return encoding.GetString(ms.ToArray());
        }

        /// <summary>Encryptor</summary>
        /// <param name="stringToEncrypt">The Decrypted String</param>
        /// <param name="IV">The Initialization Vector of 8 character length</param>
        public static String EncryptToBase64String(String stringToEncrypt)
        {
            string iv = "Kannanrc";
            var IV = Encoding.ASCII.GetBytes(iv);
            var des = new TripleDESCryptoServiceProvider();
            //   ****    convert our input string to a byte array
            var inputByteArray = System.Text.Encoding.UTF8.GetBytes(stringToEncrypt);
            //   ****    now encrypt the bytearray
            var ms = new MemoryStream();
            var cs = new CryptoStream(ms, des.CreateEncryptor(_key, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();

            //   ****    now return the byte array as a "safe for XMLDOM" Base64 String
            return Convert.ToBase64String(ms.ToArray()) + System.Text.Encoding.ASCII.GetString(IV);
        }
    }
}
