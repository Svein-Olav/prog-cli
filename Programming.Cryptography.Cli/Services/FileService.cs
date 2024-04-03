using System.IO;

public class FileService : IFileService
{
    public string ReadAllText(string path)
    {
        return File.ReadAllText(path);
    }

    public void WriteAllText(string path, string content)
    {
        File.WriteAllText(path, content);
    }

    private void CreateFile(string filePath)
    {
        File.Create(filePath);
    }

    private void DeleteFile(string filePath)
    {
        File.Delete(filePath);
    }

    private bool FileExists(string filePath)
    {
        return File.Exists(filePath);
    }    
}