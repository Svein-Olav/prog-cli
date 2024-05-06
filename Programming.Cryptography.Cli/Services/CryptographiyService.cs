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

    public string protectkey(string keyfile, string ivfile)
    {
       var keyBytes = File.ReadAllBytes(keyfile);
       var IVbytes = File.ReadAllBytes(ivfile);

       var unprotectedKey = ProtectedData.Protect(keyBytes, null, DataProtectionScope.CurrentUser);
       var unprotectedIV = ProtectedData.Protect(IVbytes, null, DataProtectionScope.CurrentUser);

       var newPathKey = Path.ChangeExtension(keyfile, ".protected");
       File.WriteAllBytes(newPathKey, unprotectedKey);

       var newPathIV = Path.ChangeExtension(ivfile, ".protected");
       File.WriteAllBytes(newPathIV, unprotectedKey);
       
       var currentUser = Environment.UserName;
       return $"Key and Iv protected successfully using {currentUser} as the current user";
    }

    public string unprotectkey(string keyfile, string ivfile)
    {
       
       var keyBytes = File.ReadAllBytes(keyfile);
       var IVbytes = File.ReadAllBytes(ivfile);

       var unprotectedKey = ProtectedData.Unprotect(keyBytes, null, DataProtectionScope.CurrentUser);
       var unprotectedIV = ProtectedData.Unprotect(IVbytes, null, DataProtectionScope.CurrentUser);

       string keyString = Convert.ToBase64String(unprotectedKey);
       string ivString = Convert.ToBase64String(unprotectedIV);

       var newPathKey = Path.ChangeExtension(keyfile, ".unprotected");
       File.WriteAllText(newPathKey, keyString);

       var newPathIV = Path.ChangeExtension(ivfile, ".unprotected");
       File.WriteAllText(newPathIV, ivString);
       
       var currentUser = Environment.UserName;
       return $"Key and Iv protected successfully using {currentUser} as the current user";
    }


}

