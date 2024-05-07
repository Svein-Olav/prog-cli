using System.Security.Cryptography;
using System.IO;

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
            using (var ms = new MemoryStream(HexStringToByteArray(encryptedData)))
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

    public string protectkey(string keyfile, string ivfile)
    {
       var keyBytes = File.ReadAllBytes(keyfile);
       var IVbytes = File.ReadAllBytes(ivfile);

       var protectedKey = ProtectedData.Protect(keyBytes, null, DataProtectionScope.CurrentUser);
       var protectedIV = ProtectedData.Protect(IVbytes, null, DataProtectionScope.CurrentUser);

       var newPathKey = Path.ChangeExtension(keyfile, ".dat");
       File.WriteAllBytes(newPathKey, protectedKey);

       var newPathIV = Path.ChangeExtension(ivfile, ".dat");
       File.WriteAllBytes(newPathIV, protectedIV);
       
       var currentUser = Environment.UserName;
       return currentUser;
    }

    public void unprotectkey(string keyfile, string ivfile)
    {
       
       var keyBytes = File.ReadAllBytes(keyfile);
       var IVbytes = File.ReadAllBytes(ivfile);

       var unprotectedKey = ProtectedData.Unprotect(keyBytes, null, DataProtectionScope.CurrentUser);
       var unprotectedIV = ProtectedData.Unprotect(IVbytes, null, DataProtectionScope.CurrentUser);

   
       var newPathKey = Path.ChangeExtension(keyfile, ".unprotected");
       File.WriteAllBytes(newPathKey, unprotectedKey);

       var newPathIV = Path.ChangeExtension(ivfile, ".unprotected");
       File.WriteAllBytes(newPathIV, unprotectedIV);
       
       var currentUser = Environment.UserName;

        Console.WriteLine($"Key and Iv unprotected successfully using {currentUser} as the current user");
        
    }

    private static byte[] HexStringToByteArray(string hex)
    {
        return (from x in Enumerable.Range(0, hex.Length)
                where x % 2 == 0
                select Convert.ToByte(hex.Substring(x, 2), 16)).ToArray();
    }


}

