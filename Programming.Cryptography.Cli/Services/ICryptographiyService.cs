public interface ICryptographiService
{
    string Encrypt(string data);
    string Decrypt(string encryptedData);
}