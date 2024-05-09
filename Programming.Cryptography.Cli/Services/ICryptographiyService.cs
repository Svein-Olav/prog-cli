public interface ICryptographiService
{
    string Encrypt(string key, string iv, string data);
    string Decrypt(string key, string iv, string encryptedData);
    void protectkey(string keyfile, string ivfile);
    void unprotectkey(string keyfile, string ivfile);

    (string Key, string IV) GenerateKey();
}