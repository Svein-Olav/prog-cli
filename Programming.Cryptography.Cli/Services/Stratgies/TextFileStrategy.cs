using System.Text;


public class TextFileStrategy : IFileStrategy
{
    public string ReadFile(string filePath)
    {
        string textFromFile = File.ReadAllText(filePath);
        
        return textFromFile;
    }

    public void WriteFile(string filePath, string content)
    {
         File.WriteAllText(filePath, content);
    }
}