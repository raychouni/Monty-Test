using System;  
using System.IO;  
using System.Security.Cryptography;
using System.Text;
namespace Bob
{
    class TripleDESSample
    {
        public static string Encrypt(string TextToEncrypt,byte[] key)
        {
            byte[] MyEncryptedArray = UTF8Encoding.UTF8
               .GetBytes(TextToEncrypt);

            byte[] MysecurityKeyArray = key;

            //inintiate 3DESCryptoService
            var MyTripleDESCryptoService = new
               TripleDESCryptoServiceProvider();
            //Key
            MyTripleDESCryptoService.Key = MysecurityKeyArray;
            //Mode
            MyTripleDESCryptoService.Mode = CipherMode.ECB;

            MyTripleDESCryptoService.Padding = PaddingMode.PKCS7;

            var MyCrytpoTransform = MyTripleDESCryptoService
               .CreateEncryptor();

            byte[] MyresultArray = MyCrytpoTransform
               .TransformFinalBlock(MyEncryptedArray, 0,
               MyEncryptedArray.Length);

            MyTripleDESCryptoService.Clear();

            return Convert.ToBase64String(MyresultArray, 0,
               MyresultArray.Length);
        }



        public static string Decrypt(string TextToDecrypt,byte[] key)
        {
            byte[] MyDecryptArray = Convert.FromBase64String
               (TextToDecrypt);

            byte[] MysecurityKeyArray = key;
            //inintiate 3DESCryptoService
            var MyTripleDESCryptoService = new
               TripleDESCryptoServiceProvider();
            //Key
            MyTripleDESCryptoService.Key = MysecurityKeyArray;
            //Mode
            MyTripleDESCryptoService.Mode = CipherMode.ECB;

            MyTripleDESCryptoService.Padding = PaddingMode.PKCS7;

            var MyCrytpoTransform = MyTripleDESCryptoService
               .CreateDecryptor();

            byte[] MyresultArray = MyCrytpoTransform
               .TransformFinalBlock(MyDecryptArray, 0,
               MyDecryptArray.Length);

            MyTripleDESCryptoService.Clear();

            return UTF8Encoding.UTF8.GetString(MyresultArray);
        }
    }
}