public interface IFileStrategy
{
    string ReadFile(string path);
    void WriteFile(string path, string content);    
}