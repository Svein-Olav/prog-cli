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

    public string ReadAllByte(string path)
    {
        var binary = File.ReadAllBytes(path);
        var returnValue = Convert.ToBase64String(binary);

        return returnValue;
    
    }

    public void WriteAllByte(string path, string content)
    {
        var binary = Convert.FromBase64String(content);
        File.WriteAllBytes(path, binary);
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