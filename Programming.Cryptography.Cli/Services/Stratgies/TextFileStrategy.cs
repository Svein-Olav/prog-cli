using System.IO;

public class TextFileStrategy : IFileStrategy
{
    public string ReadFile(string filePath)
    {
        return File.ReadAllText(filePath);
    }

    public void WriteFile(string filePath, string content)
    {
         File.WriteAllText(filePath, content);
    }
}