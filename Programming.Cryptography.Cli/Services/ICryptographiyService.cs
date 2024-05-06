public interface ICryptographiService
{
    string Encrypt(string key, string iv, string data);
    string Decrypt(string key, string iv, string encryptedData);
    string protectkey(string keyfile, string ivfile);
    string unprotectkey(string keyfile, string ivfile);

    (string Key, string IV) GenerateKey();
}