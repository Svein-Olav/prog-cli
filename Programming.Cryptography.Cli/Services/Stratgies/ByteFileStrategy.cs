using System.IO;

public class ByteFileStrategy : IFileStrategy
{
    public string ReadFile(string filePath)
    {
         var binary = File.ReadAllBytes(filePath);
        var returnValue = Convert.ToBase64String(binary);

        return returnValue;
    }

    public void WriteFile(string filePath, string content)
    {
         var binary = Convert.FromBase64String(content);
        File.WriteAllBytes(filePath, binary);
    }
}