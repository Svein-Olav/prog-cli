using System.Text;


public class TextFileStrategy : IFileStrategy
{
    public string ReadFile(string filePath)
    {
        string testFromFile = File.ReadAllText(filePath);
        byte[] bytes = Encoding.Default.GetBytes(testFromFile);
        string base64String = Convert.ToBase64String(bytes);

        return base64String;
    }

    public void WriteFile(string filePath, string content)
    {
         File.WriteAllText(filePath, content);
    }
}