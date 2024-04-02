public interface ICryptographiService
{
    string Encrypt(string key, string iv, string data);
    string Decrypt(string key, string iv, string encryptedData);
    (string Key, string IV) GenerateKey();
}