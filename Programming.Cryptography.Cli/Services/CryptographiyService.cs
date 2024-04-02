using System.Security.Cryptography;
using System.Text;
public class CryptographiService : ICryptographiService
{
    public string Encrypt(string key, string iv, string data)
    {
        using (var rm = new RijndaelManaged())
        {
            rm.Key = Convert.FromBase64String(key);
            rm.IV = Convert.FromBase64String(iv);

            var encryptor = rm.CreateEncryptor(rm.Key, rm.IV);
            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                {
                    using (var sw = new StreamWriter(cs))
                    {
                        sw.Write(data);
                    }
                }
                return Convert.ToBase64String(ms.ToArray());
            }
        }       
    }

    public string Decrypt(string key, string iv, string encryptedData)
    {
        
       using (var rm = new RijndaelManaged())
        {
            
            rm.Key = Convert.FromBase64String(key);
            rm.IV = Convert.FromBase64String(iv);

            var decryptor = rm.CreateDecryptor(rm.Key, rm.IV);
            using (var ms = new MemoryStream(Convert.FromBase64String(encryptedData)))
            {
                using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                {
                    using (var sr = new StreamReader(cs))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
        }
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

