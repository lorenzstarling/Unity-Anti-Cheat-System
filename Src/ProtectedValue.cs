using System;
using System.Security.Cryptography;
using System.Text;

public class ProtectedValue
    {
        private byte[] currentEntropy;
        private byte[] SecretValue;
        private byte[] encryptedSecret;

    public ProtectedValue(int value)
    {
        currentEntropy = GenerateEntropy();
        SecretValue = BitConverter.GetBytes(value);
        encryptedSecret = Protect(SecretValue);
    }
    public ProtectedValue(bool value)
    {
        currentEntropy = GenerateEntropy();
        SecretValue = Encoding.ASCII.GetBytes(value.ToString());
        encryptedSecret = Protect(SecretValue);
    }

    public ProtectedValue(string value)
    {
        currentEntropy = GenerateEntropy();
        SecretValue = Encoding.ASCII.GetBytes(value);
        encryptedSecret = Protect(SecretValue);
    }

    public void ApplyNewValue(bool value)
    {
        SecretValue = Encoding.ASCII.GetBytes(value.ToString());
        encryptedSecret = Protect(SecretValue);
    }

    public void ApplyNewValue(int value)
    {
        currentEntropy = GenerateEntropy();
        SecretValue = BitConverter.GetBytes(value);
        encryptedSecret = Protect(SecretValue);
    }
    public void ApplyNewValue(string value)
    {
        currentEntropy = GenerateEntropy();
        SecretValue = Encoding.ASCII.GetBytes(value);
        encryptedSecret = Protect(SecretValue);
    }

    public bool CompareValue(bool value)
    {
        if (value != GetBool())
        {
            return false;
        }

        return true;
    }

    public bool CompareValue(int value)
    {
        if (value != GetInt())
        {
            return false;
        }

        return true;
    }

    public bool CompareValue(string value)
    {
        if (value != GetString())
        {
            return false;
        }

        return true;
    }

    public bool GetBool()
    {
        byte[] originalData = Unprotect(encryptedSecret);
        return bool.Parse(Encoding.ASCII.GetString(originalData));
    }

    public int GetInt()
    {
        byte[] originalData = Unprotect(encryptedSecret);
        return BitConverter.ToInt32(originalData, 0);
    }

    public string GetString()
    {
        byte[] originalData = Unprotect(encryptedSecret);
        return Encoding.ASCII.GetString(originalData);
    }

    private byte[] Protect(byte[] data)
        {
            try
            {
                return ProtectedData.Protect(data, currentEntropy, DataProtectionScope.CurrentUser);
            }
            catch (CryptographicException e)
            {
                throw new Exception("Data was not encrypted. An error occurred.");
                return null;
            }
        }

        private byte[] Unprotect(byte[] data)
        {
            try
            {
                return ProtectedData.Unprotect(data, currentEntropy, DataProtectionScope.CurrentUser);
            }
            catch (CryptographicException e)
            {
                throw new Exception("Data was not decrypted. An error occurred.");
                return null;
            }
        }

        private byte[] GenerateEntropy()
        {
            Random r = new Random();
            int lenght = r.Next(50, 100);
            byte[] b = new byte[lenght];
            r.NextBytes(b);
            return b;
        }
    }
    
 
   

