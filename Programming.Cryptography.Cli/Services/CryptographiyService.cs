using System.Security.Cryptography;
public class CryptographiService : ICryptographiService
{
    public string Encrypt(string key, string iv, string data)
    {
        // Implement encryption logic here
        return  "EncryptedData";
    }

    public string Decrypt(string key, string iv, string encryptedData)
    {
        
        // Implement decryption logic here
        return  "DecryptedData";
    }

    public (string Key, string IV) GenerateKey()
    {
        using (var rm = new RijndaelManaged())
        {
            rm.GenerateKey();
            var key = Convert.ToBase64String(rm.Key);
    
            rm.GenerateIV();
            var iv = Convert.ToBase64String(rm.IV);

            return (Key: key, IV: iv);
        }
    }


}

