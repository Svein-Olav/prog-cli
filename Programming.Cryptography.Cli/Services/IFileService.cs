public interface IFileService
{    
    string ReadFile(string path);
    void WriteFile(string path, string content);
    bool HasDatExtension(string path);
}