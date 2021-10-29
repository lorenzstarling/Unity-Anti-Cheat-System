using System;
using System.Security.Cryptography;
using System.Text;

   public class ValueEncryptor
    {
 
    public ValueEncryptor(string EncryptionKey)
    {
        HASH = EncryptionKey;
    }
    string HASH = "";
    public string EncryptString(string toEncrypt)
    {
        if (HASH.Length < 1)
        {
            throw new NullReferenceException("EncryptionKey was null");
        }

        if (toEncrypt.Length < 1)
        {
            throw new NullReferenceException("No Value To Encrypt");
        }

        byte[] data = UTF8Encoding.UTF8.GetBytes(toEncrypt);
        using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
        {
            string n = HASH;
            byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(n));
            using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
            {
                ICryptoTransform transform = tripDes.CreateEncryptor();
                byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                return Convert.ToBase64String(results, 0, results.Length);
            }
        }
    }

    public string DecryptSrtings(string toDecrypt)
    {
        if (HASH.Length < 1)
        {
            throw new NullReferenceException("Encryption Key was null");
        }

        if (toDecrypt.Length < 1)
        {
            throw new NullReferenceException("No Value To Decrypt");
        }

        byte[] data = Convert.FromBase64String(toDecrypt);

        using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
        {
            string n = HASH;
            byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(n));
            using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
            {
                ICryptoTransform transform = tripDes.CreateDecryptor();
                byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                return UTF8Encoding.UTF8.GetString(results);
            }
        }
    }

}

